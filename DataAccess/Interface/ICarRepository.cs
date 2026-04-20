using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Interface
{
    public interface ICarRepository
    {
        Task<List<Car>> GetAvailableCars();
        Task<Car> GetCarByCarId(int carId);
        Task<List<Car>> GetAllCars();
        Task AddAsync(Car car);
        Task SaveAsync();
    }
}
