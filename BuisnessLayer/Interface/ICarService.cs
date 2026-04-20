using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Utilities;

namespace BuisnessLayer.Interface
{
    public interface ICarService
    {
        Task<List<Car>> GetAvailableCarAsync();
        Task<string> AddCarAsync(string model, string brand, decimal priceperday);
        Task<List<Car>> GetAllCar();
        Task<Result<Car>> ToggleActivityAsync(int carId);
    }
}
