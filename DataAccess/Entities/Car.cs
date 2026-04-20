using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public decimal PricePerDay { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsActive { get; set; }
        public List<Rental> Rentals { get; set; }
    }
}
