using DataAccess.Entities;
using DataAccess.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        AppDbContext _context;
        public CustomerRepository()
        {
            _context = new AppDbContext();
        }
        public async Task AddAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await SaveAsync();
        }

        public async Task<Customer> GetByUserIdAsync(int userId)
        {
            return await _context.Customers
                .Include(c => c.User)
                .FirstOrDefaultAsync(c => c.UserId == userId);
        }

        public async Task SaveAsync()
        {
           await _context.SaveChangesAsync();
        }
    }
}
