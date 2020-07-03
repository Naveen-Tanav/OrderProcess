using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OrderProcessManagement.BO
{
    public enum PaymentEnum
    {
        PhysicalProduct,
        Book,
        ActivateMembership,
        UpgradeMembership,
        video
    }

    public class Product
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public PaymentEnum Type { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public long Quantity { get; set; }

    }
}
