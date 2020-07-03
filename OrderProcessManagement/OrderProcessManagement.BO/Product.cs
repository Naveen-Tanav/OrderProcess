using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace OrderProcessManagement.BO
{
    
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
        public long Quantity { get; set; }

    }
}
