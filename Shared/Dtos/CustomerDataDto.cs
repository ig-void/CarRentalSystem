using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Dtos
{
    public class CustomerDataDto
    {
        public int CustomerId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
    }
}
