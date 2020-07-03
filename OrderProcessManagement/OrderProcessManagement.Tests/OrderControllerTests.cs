
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

            var actionResult = controller.Create();

            
            Assert.IsType<OrderController>(controller);
            Assert.IsType<Microsoft.AspNetCore.Mvc.OkResult>(actionResult);

        }

       
    }
}
