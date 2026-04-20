using DataAccess.Entities;
using DataAccess.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repository
{
    public class CarRepository : ICarRepository
    {
        AppDbContext _context;
        public CarRepository()
        {
            _context = new AppDbContext();
        }

        public async Task AddAsync(Car car)
        {
            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Car>> GetAllCars()
        {
            return await _context.Cars.ToListAsync();
        }

        public async Task<List<Car>> GetAvailableCars()
        {
            return await _context.Cars.Where(c => c.IsAvailable).ToListAsync();
        }

        public async Task<Car> GetCarByCarId(int carId)
        {
            return await _context.Cars.FirstOrDefaultAsync(c => c.Id ==carId);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
