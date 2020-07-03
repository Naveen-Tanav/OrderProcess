using System;
using System.Collections.Generic;
using System.Text;

namespace OrderProcessManagement.BO
{
    public class Shipping
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string City { get; set; }
        public string State { get; set; }

        public string Country { get; set; }

        public int ZipCode { get; set; }

        public string PhoneNumber { get; set; }
    }
}
