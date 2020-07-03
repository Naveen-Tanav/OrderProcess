﻿using Microsoft.AspNetCore.Mvc;
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

        public class OrderController : ControllerBase
        {
        }
    }
}
