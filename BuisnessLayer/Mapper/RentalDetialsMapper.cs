using DataAccess.Entities;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuisnessLayer.Mapper
{
    public class RentalDetialsMapper
    {
        public static MyRentalDetailsDto ToDto (Rental rental)
        {
            return new MyRentalDetailsDto
            {
                RentalId = rental.Id,
                Email = rental.Customer.User.Email,
                Name = rental.Customer.Name,
                CarName = rental.Car.Model,
                StartDate= rental.StartDate,
                EndDate= rental.EndDate,
                TotalAmount= rental.TotalAmount,
                Status= rental.Status,
            };

        }
    }
}
