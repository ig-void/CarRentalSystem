using DataAccess.Entities;
using DataAccess.Interface;
using Shared.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repository
{
    public class RentalRepository : IRentalRepository
    {
        AppDbContext _context;
        public RentalRepository()
        {
            _context = new AppDbContext();
        }

        public async Task AddRecordAsync(Rental record)
        {
            await _context.Rentals.AddAsync(record);
            await SaveAsync();
        }

        public async Task<List<Rental>> GetAllAsync()
        {
            return await _context.Rentals.ToListAsync();
        }

        public async Task<List<Rental>> GetMyRecordsAsync(int custId)
        {
            return await _context.Rentals
                .Include(r => r.Car)
                .Include(r => r.Customer)
                .Where(r => r.CustomerId == custId && r.Status == RentalStatus.Booked).ToListAsync();
        }

        public async Task<Rental> GetPreviousRecordAsync(int custId, int carId)
        {
            return await _context.Rentals.FirstOrDefaultAsync(r => r.CustomerId == custId && r.CarId == carId && r.Status != RentalStatus.Booked);
        }

        public async Task<Rental> GetRecordByIdAsync(int rentalId)
        {
            return await _context.Rentals.FirstOrDefaultAsync(r => r.Id == rentalId);
        }

        public async Task<Rental> GetRentalDataAsync(int custId, int carId)
        {
            return await _context.Rentals
                .Include(r => r.Car)
                .Include(r => r.Customer)
                .ThenInclude(c => c.User)
                .FirstOrDefaultAsync(r => r.CustomerId == custId && r.CarId == carId);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
