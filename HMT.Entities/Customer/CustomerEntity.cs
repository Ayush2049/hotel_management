using System;
using System.Collections.Generic;
using System.Text;

namespace HMT.Entities.Customer
{
    public class CustomerEntity
    {

        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }

        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;
    }
}
