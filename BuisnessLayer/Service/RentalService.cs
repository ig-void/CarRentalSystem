using BuisnessLayer.Interface;
using BuisnessLayer.Mapper;
using DataAccess.Entities;
using DataAccess.Interface;
using DataAccess.Repository;
using Shared.Constants;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using Utilities.MailSender;

namespace BuisnessLayer.Service
{
    public class RentalService : IRentalService
    {
        IRentalRepository _rentalRepo;
        ICustomerRepository _customerRepo;
        ICarRepository _carRepo;
        public RentalService()
        {
            _rentalRepo = new RentalRepository();
            _customerRepo = new CustomerRepository();
            _carRepo = new CarRepository();
        }

        public async Task<string> AddRecordAsync(int userId, int carId,DateTime startDate ,DateTime endDate)
            {
            if (startDate.Date < DateTime.Today.Date) return Messages.InvalidStartDate;
            if(endDate <= startDate) return Messages.InvalidDate;
            var cust = await _customerRepo.GetByUserIdAsync(userId);
            var record = await _rentalRepo.GetPreviousRecordAsync(cust.Id, carId);
            if (record != null) return Messages.AlreadyRented;
            var car = await _carRepo.GetCarByCarId(carId);
            if(car == null) return Messages.CarNotFound;
            Rental reco = new Rental
            {
                CarId = carId,
                CustomerId = cust.Id,
                StartDate = startDate,
                EndDate = endDate,
                TotalAmount = car.PricePerDay * (endDate - startDate).Days,
                Status = Shared.Enums.RentalStatus.Booked  
            };
            await _rentalRepo.AddRecordAsync(reco);
            car.IsActive =false;
            car.IsAvailable = false;
            await _carRepo.SaveAsync();
            var rentRecord =await _rentalRepo.GetRentalDataAsync(cust.Id, carId);
            var rentData = RentalDetialsMapper.ToDto(rentRecord);
            var emailResult = await Task.Run(async()=>await RentCarMail.SentMail(rentData));
            Console.WriteLine(emailResult);
            return null;
        }

        public async Task<string> CancelRecordAsync(int rentalId)
        {
            var record = await _rentalRepo.GetRecordByIdAsync(rentalId);
            if(record == null) return Messages.RecordNotFound;
            var car = await _carRepo.GetCarByCarId(record.CarId);
            car.IsAvailable = true;
            car.IsActive=true;
            await _carRepo.SaveAsync();
            record.Status = Shared.Enums.RentalStatus.Cancelled;
            await _rentalRepo.SaveAsync();
            return null;
        }

        public async Task<List<Rental>> GetAllRecords()
        {
           var records = await _rentalRepo.GetAllAsync();
            return records;
        }

        public async Task<List<MyRentalDetailsDto>> GetRentalsByCustIdAsync(int userId)
        {
            var customer = await _customerRepo.GetByUserIdAsync(userId);
            var rentals = await _rentalRepo.GetMyRecordsAsync(customer.Id);
            return  rentals.Select(r => RentalDetialsMapper.ToDto(r)).ToList();
        }
    }
}

