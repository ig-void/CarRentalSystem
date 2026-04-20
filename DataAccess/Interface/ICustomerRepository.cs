using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Interface
{
    public interface ICustomerRepository
    {
        Task AddAsync(Customer customer);
        Task SaveAsync();
        Task<Customer> GetByUserIdAsync(int userId);
        
    }
}
