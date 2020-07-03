
using OrderProcessManagement.BO;
using OrderProcessManagement.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace OrderProcessManagement.Tests
{
    public class OrderControllerTests
    {
        [Fact]
        public void IsOrderControllerExist()
        {
            OrderController controller = new OrderController();

            Assert.IsType<OrderController>(controller);

        }

        [Fact]
        public void IsOrderControllerCreateMethodExist()
        {
            OrderController controller = new OrderController();
            var actionResult = controller.Create(null);            
            Assert.IsType<OrderController>(controller);
            Assert.IsType<Microsoft.AspNetCore.Mvc.OkResult>(actionResult);

        }
        [Fact]
        public void CreateModelAndCheckItisnotNull()
        {
            Order order = GetOrderRequest();
            
            OrderController controller = new OrderController();
            var actionResult = controller.Create(order);
            Assert.IsType<OrderController>(controller);
            Assert.IsType<Microsoft.AspNetCore.Mvc.OkResult>(actionResult);
            Assert.NotNull(order);

        }

        public Order GetOrderRequest()
        {
            Order order = new Order();
            order.OrderId = "OR00001";
            order.OrderDate = DateTime.Now;
            var customer = new Customer();
            var shipping = new Shipping();
            customer.Id = "C00001";
            shipping.Name = customer.Name = "Naveen";
            shipping.AddressLine1 = customer.AddressLine1 = "TestAddress1";
            shipping.AddressLine2 = customer.AddressLine2 = "TestAddress2";
            shipping.City = customer.City = "Bangalore";
            shipping.State = customer.State = "KA";
            shipping.Country = customer.Country = "IN";
            shipping.ZipCode = customer.ZipCode = 560001;
            shipping.PhoneNumber = customer.PhoneNumber = "+91-9741969579";
            order.Customer = customer;
            shipping.Id = "S00000001";
            order.Shipping = shipping;
            var products = new Product();

            products.Id = "P0000001";
            products.Name = "Chair";
            products.Type = "Physical Product";
            products.Quantity = 1;
            products.Price = 100000.00;
            var Listproducts = new List<Product>();
            Listproducts.Add(products);
            order.Products = Listproducts;
            return order;

        }


    }
}
