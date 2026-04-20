using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Utilities;

namespace BuisnessLayer.Interface
{
    public interface IUserService
    {
        Task<string> RegisterAsync(string email, string password, string name , string phone);
        Task<Result<User>> LoginUser(string email , string password)  ;
    }
}
