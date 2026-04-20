using BuisnessLayer.Interface;
using DataAccess.Entities;
using BuisnessLayer.Service;
using System;
using System.Collections.Generic;
using System.Text;
using Utilities.Helper;
using ConsoleTables;
using Shared.Enums;

namespace UI.Views
{
    public class AdminView
    {
        ICarService _carService;
        IRentalService _rentalService;
        public AdminView()
        {
            _carService = new CarService();
            _rentalService = new RentalService();
        }
        public async Task AddCarAsync()
        {
            Console.WriteLine("Enter detials to add car: ");
            Console.Write("Enter Model Name: ");
            string model = Console.ReadLine();
            Console.Write("Enter Brand : ");
            string brand = Console.ReadLine();
            Console.Write("Enter price per day: ");
            decimal priceperday = InputHelper.GetDecimal();
            var carResult = await _carService.AddCarAsync(model, brand, priceperday);
            if(carResult != null )
            {
                Console.WriteLine(carResult);
                return;
            }
            Console.WriteLine("Car Added Succefully!");
        }
        public async Task ToggleAsync()
        {
            var allCars = await _carService.GetAllCar();
            var table =new ConsoleTable("Car Id","Model","Brand","Price Per Day","IsAvailable","IsActive");
            foreach (var car in allCars)
            {
                var activity = car.IsActive ? "Active" : "Inactive";
                var availibility = car.IsAvailable ? "Available" : "Unavailable";
                table.AddRow(car.Id,car.Model,car.Brand,car.PricePerDay, availibility, activity);
            }
            table.Write();
            Console.Write("Enter the Car Id to toggle the activity: ");
            int carId = InputHelper.GetInt();
            var carResult = await _carService.ToggleActivityAsync(carId);
            if(!carResult.Success )
            {
                Console.WriteLine(carResult.Message);
                return;
            }
            Console.WriteLine(carResult.Message);
        }
        public async Task ShowAllRecord()
        {
            Console.WriteLine("All records: ");
            var records = await _rentalService.GetAllRecords();
            if(records == null)
            {
                Console.WriteLine("Record not found");
                return;
            }

            var table = new ConsoleTable("Rental Id","Customer Id ","Car Id","Start Date","End Date","Total Amount", "Status");
            foreach (var r in records)
            {
                if (r == null) Console.WriteLine(r + " is null");
                table.AddRow(r.Id,r.CustomerId,r.CarId,r.StartDate,r.EndDate,r.TotalAmount,r.Status.ToString());
            }
            table.Write();
        }
    }
}
