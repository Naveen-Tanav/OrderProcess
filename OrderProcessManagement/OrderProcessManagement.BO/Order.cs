using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OrderProcessManagement.BO
{
    public class Order
    {
        [Required]
        public string OrderId { get; set; }
        [Required]
        public DateTime? OrderDate { get; set; }
        [Required]
        public List<Product> Products { get; set; }
        [Required]
        public Customer Customer { get; set; }
        [Required]
        public Shipping Shipping { get; set; }
       
        public Product Product { get; set; }

    }
}
