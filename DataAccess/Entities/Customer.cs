using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public User User { get; set; }
        public List<Rental> Rentals { get; set; }
    }
}
