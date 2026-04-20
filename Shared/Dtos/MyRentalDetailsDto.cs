using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Dtos
{
    public class MyRentalDetailsDto
    {
        public int RentalId { get; set; }   
        public string Email { get; set; }
        public string Name { get; set; }
        public string CarName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalAmount { get; set; }
        public RentalStatus Status { get; set; }
    }
}
