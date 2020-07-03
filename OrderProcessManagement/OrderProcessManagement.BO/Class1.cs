using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace OrderProcessManagement.BO
{
    public class Order
    {
        
        public string OrderId { get; set; }

        public DateTime? OrderDate { get; set; }

        public List<Product> Products { get; set; }
        public Customer Customer { get; set; }

        public Shipping Shipping { get; set; }
        public Product Product { get; set; }

    }
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
    public class Customer
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
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
        public long Quantity { get; set; }

    }
}
