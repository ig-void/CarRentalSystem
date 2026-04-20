using DataAccess.Entities;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuisnessLayer.Mapper
{
    public class UserToCustomerMapper
    {
        public static CustomerDataDto ToDto(Customer cust)
        {
            return new CustomerDataDto
            {
                CustomerId = cust.Id,
                Name = cust.Name,
                Email = cust.User.Email,
                Phone = cust.PhoneNumber,
            };
        }
    }
}
