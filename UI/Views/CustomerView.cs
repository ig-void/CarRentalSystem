using BuisnessLayer.Interface;
using BuisnessLayer.Service;
using ConsoleTables;
using DataAccess.Entities;
using Shared.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Utilities.Helper;

namespace UI.Views
{
    public class CustomerView
    {
        ICarService _carService;
        IRentalService _rentalService;
        public CustomerView()
        {
            _carService = new CarService();
            _rentalService = new RentalService();
        }
        public async Task ViewAvailableCars()
        {
            Console.WriteLine("Cars Available for rent: ");
            var cars = await _carService.GetAvailableCarAsync();
            var table = new ConsoleTable("Car ID", "Model", "Brand", "Price per day");
            foreach (var c in cars)
            {
                table.AddRow(c.Id, c.Model, c.Brand, c.PricePerDay);
            }
            table.Write();
        }
        public async Task RentCar()
        {
            await ViewAvailableCars();
            Console.Write("Enter the Id of car you want to rent: ");
            int carId = InputHelper.GetInt();
            Console.Write("Enter Start Date: (dd-mm-yyyy)");
            var startDate = InputHelper.GetDateExact();
            Console.Write("Enter End Date: (dd-mm-yyyy)");
            var endDate = InputHelper.GetDateExact();
            var rentResult = await _rentalService.AddRecordAsync(SessionManager.CurrentUser.Id, carId, startDate, endDate);
            if (rentResult != null)
            {
                Console.WriteLine(rentResult);
                return;
            }
            Console.WriteLine(Messages.CarRentSuccess);
        }
        public async Task CancelRent()
        {
            await ViewMyRentals();
            Console.Write("Enter the Id of the rental record you with to cancel: ");
            int rentalId = InputHelper.GetInt();
            var rentalResult = await _rentalService.CancelRecordAsync(rentalId);
            if (rentalResult != null)
            {
                Console.WriteLine(rentalResult);
                return;
            }
            Console.WriteLine("Rental record cancelled!");
        }
        public async Task ViewMyRentals()
        {
            var rentals = await _rentalService.GetRentalsByCustIdAsync(SessionManager.CurrentUser.Id);
            var table = new ConsoleTable("Rental Id","Customer Name", "Car Name","Start Date","End Date","Total Amount","Status");
            Console.WriteLine("My Rental Records: ");
            foreach (var c in rentals)
            {
                table.AddRow(c.RentalId, c.Name, c.CarName, c.StartDate, c.EndDate, c.TotalAmount, c.Status);
            }
            table.Write();
        }
    }  
}
