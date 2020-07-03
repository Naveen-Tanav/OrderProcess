using System;
using System.Collections.Generic;
using System.Text;

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
}
