using BuisnessLayer.Interface;
using DataAccess.Entities;
using DataAccess.Interface;
using DataAccess.Repository;
using Shared.Constants;
using System;
using System.Collections.Generic;
using System.Text;
using Utilities;

namespace BuisnessLayer.Service
{
    public class CarService : ICarService
    {
        ICarRepository _carRepo;
        public CarService()
        {
            _carRepo = new CarRepository();
        }

        public async Task<string> AddCarAsync(string model, string brand, decimal priceperday)
        {
            if (priceperday <= 0) return Messages.InvalidPrice;
            var car = new Car
            {
                Model = model,
                Brand = brand,
                PricePerDay = priceperday,
                IsActive = true,
                IsAvailable = true,
            };
            await _carRepo.AddAsync(car);
            return null;
        }

        public async Task<List<Car>> GetAllCar()
        {
            return await _carRepo.GetAllCars();
        }

        public async Task<List<Car>> GetAvailableCarAsync()
        {
            var cars = await _carRepo.GetAvailableCars();
            return cars;
        }

        public async Task<Result<Car>> ToggleActivityAsync(int carId)
        {
            var car = await _carRepo.GetCarByCarId(carId);
            if (car == null) return new Result<Car> { Message=Messages.CarNotFound , Success =false};
            car.IsActive = !car.IsActive;
            car.IsAvailable = !car.IsAvailable;
            await _carRepo.SaveAsync();
            var activity = car.IsActive ? "Active" : "Inactive";
            var availibility = car.IsAvailable ? "Available" : "Unavailable";
            return new Result<Car> { Success = true , Data =car , Message= $"Activity of {car.Model} set to {activity}, {availibility}" };

        }
    }
}
