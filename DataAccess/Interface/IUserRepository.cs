using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Interface
{
    public interface IUserRepository
    {
        Task AddAsync(User u);
        Task SaveAsync();
        Task<User> GetUserByEmail(string email) ;
        
    }
}
