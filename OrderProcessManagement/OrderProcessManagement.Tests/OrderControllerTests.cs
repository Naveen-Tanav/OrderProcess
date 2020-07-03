
using Microsoft.Extensions.Options;
using Moq;
using OrderProcessManagement.BL;
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
        Mock<IManageOrder> _manageOrder;
        Mock<IPaymentRuleProcessor> _paymentProcessor;
        Mock<IOptions<SettingsModel>> _appSettings;
        OrderController controller;
        SettingsModel settingsModel;
        public OrderControllerTests()
        {
            _manageOrder = new Mock<IManageOrder>();
            _paymentProcessor = new Mock<IPaymentRuleProcessor>();
            settingsModel = new SettingsModel() {ConnectionString= "c:\\OrderManagement" };
            _appSettings = new Mock<IOptions<SettingsModel>>();
            _appSettings.Setup(ap => ap.Value).Returns(settingsModel);
            controller = new OrderController(_appSettings.Object, _manageOrder.Object, _paymentProcessor.Object);


        }
        [Fact]
        public void IsOrderControllerExist()
        {
           

            Assert.IsType<OrderController>(controller);

        }

        [Fact]
        public void IsOrderControllerCreateMethodExist()
        {
            Order order = GetOrderRequest();           
            var actionResult = controller.Create(order);            
            Assert.IsType<OrderController>(controller);
            Assert.IsType<Microsoft.AspNetCore.Mvc.BadRequestResult>(actionResult);

        }

        [Fact]
        public void CreateModelAndCheckItisnotNull()
        {
            Order order = GetOrderRequest();
            
            
            var actionResult = controller.Create(order);
            Assert.IsType<OrderController>(controller);            
            Assert.NotNull(order);

        }
        [Fact]
        public void ExpectOkResult()
        {
            Order order = GetOrderRequest();
            
            _manageOrder.Setup(a => a.CreateOrder(order, settingsModel.ConnectionString)).Returns(true);
            _paymentProcessor.Setup(b => b.ProcessPaymentRules(order)).Returns(true);
            var actionResult = controller.Create(order);
            var returnStatus = (Microsoft.AspNetCore.Mvc.OkResult)actionResult;
            Assert.IsType<OrderController>(controller);           
            Assert.NotNull(order);
            Assert.Equal(200, returnStatus.StatusCode);

        }
        [Fact]
        public void ExpectOrderCreated_WhileProcessingPasymentRuleFailed()
        {
            Order order = GetOrderRequest();

            _manageOrder.Setup(a => a.CreateOrder(order, settingsModel.ConnectionString)).Returns(true);
            _paymentProcessor.Setup(b => b.ProcessPaymentRules(order)).Returns(true);
            var actionResult = controller.Create(order);
            var result1 = (Microsoft.AspNetCore.Mvc.OkResult)actionResult;
            Assert.Equal(200, result1.StatusCode);
            Assert.IsType<OrderController>(controller);
            Assert.NotNull(order);
            _paymentProcessor.Setup(b => b.ProcessPaymentRules(order)).Returns(false);
            actionResult = controller.Create(order);
             var  result2 = (Microsoft.AspNetCore.Mvc.BadRequestResult)actionResult;
            Assert.Equal(400, result2.StatusCode);

        }

        [Fact]
        public void PassIncorrectOrderID_ExpectValidationFailure()
        {
            Order order = GetOrderRequest();
           order.OrderId = null;
            _manageOrder.Setup(a => a.CreateOrder(order, settingsModel.ConnectionString)).Returns(false);
                
             var actionResult = controller.Create(order);
            var returnStatus = (Microsoft.AspNetCore.Mvc.BadRequestResult)actionResult;
            Assert.IsType<OrderController>(controller);
            Assert.IsType<Microsoft.AspNetCore.Mvc.BadRequestResult>(actionResult);
            Assert.NotNull(order);
            Assert.Equal(400, returnStatus.StatusCode);

        }
        [Fact]
        public void PassIncorrectOrderdate_ExpectValidationFailure()
        {
            Order order = GetOrderRequest();
            order.OrderDate = null;
            _manageOrder.Setup(a => a.CreateOrder(order, settingsModel.ConnectionString)).Returns(false);

            var actionResult = controller.Create(order);
            var returnStatus = (Microsoft.AspNetCore.Mvc.BadRequestResult)actionResult;
            Assert.IsType<OrderController>(controller);
            Assert.IsType<Microsoft.AspNetCore.Mvc.BadRequestResult>(actionResult);
            Assert.NotNull(order);
            Assert.Equal(400, returnStatus.StatusCode);

        }
        [Fact]
        public void PassProductsAsNull_ExpectValidationFailure()
        {
            Order order = GetOrderRequest();
            order.Products = null;
            _manageOrder.Setup(a => a.CreateOrder(order, settingsModel.ConnectionString)).Returns(false);

            var actionResult = controller.Create(order);
            var returnStatus = (Microsoft.AspNetCore.Mvc.BadRequestResult)actionResult;
            Assert.IsType<OrderController>(controller);
            Assert.IsType<Microsoft.AspNetCore.Mvc.BadRequestResult>(actionResult);
            Assert.NotNull(order);
            Assert.Equal(400, returnStatus.StatusCode);

        }
        [Fact]
        public void PassProductsNameAsNull_ExpectValidationFailure()
        {
            Order order = GetOrderRequest();
            order.Products[0].Name = null;
            _manageOrder.Setup(a => a.CreateOrder(order, settingsModel.ConnectionString)).Returns(false);

            var actionResult = controller.Create(order);
            var returnStatus = (Microsoft.AspNetCore.Mvc.BadRequestResult)actionResult;
            Assert.IsType<OrderController>(controller);
            Assert.IsType<Microsoft.AspNetCore.Mvc.BadRequestResult>(actionResult);
            Assert.NotNull(order);
            Assert.Equal(400, returnStatus.StatusCode);

        }
        [Fact]
        public void PassProductsPriceAsZero_ExpectValidationFailure()
        {
            Order order = GetOrderRequest();
            order.Products[0].Price = 0;
            _manageOrder.Setup(a => a.CreateOrder(order, settingsModel.ConnectionString)).Returns(false);

            var actionResult = controller.Create(order);
            var returnStatus = (Microsoft.AspNetCore.Mvc.BadRequestResult)actionResult;
            Assert.IsType<OrderController>(controller);
            Assert.IsType<Microsoft.AspNetCore.Mvc.BadRequestResult>(actionResult);
            Assert.NotNull(order);
            Assert.Equal(400, returnStatus.StatusCode);

        }
        [Fact]
        public void PassProductsQtyAsZero_ExpectValidationFailure()
        {
            Order order = GetOrderRequest();
            order.Products[0].Quantity = 0;
            _manageOrder.Setup(a => a.CreateOrder(order, settingsModel.ConnectionString)).Returns(false);

            var actionResult = controller.Create(order);
            var returnStatus = (Microsoft.AspNetCore.Mvc.BadRequestResult)actionResult;
            Assert.IsType<OrderController>(controller);
            Assert.IsType<Microsoft.AspNetCore.Mvc.BadRequestResult>(actionResult);
            Assert.NotNull(order);
            Assert.Equal(400, returnStatus.StatusCode);

        }
        [Fact]
        public void PassPCustomerAsNull_ExpectValidationFailure()
        {
            Order order = GetOrderRequest();
            order.Customer = null;
            _manageOrder.Setup(a => a.CreateOrder(order, settingsModel.ConnectionString)).Returns(false);

            var actionResult = controller.Create(order);
            var returnStatus = (Microsoft.AspNetCore.Mvc.BadRequestResult)actionResult;
            Assert.IsType<OrderController>(controller);
            Assert.IsType<Microsoft.AspNetCore.Mvc.BadRequestResult>(actionResult);
            Assert.NotNull(order);
            Assert.Equal(400, returnStatus.StatusCode);

        }
        [Fact]
        public void PassPCustomerNameAsNull_ExpectValidationFailure()
        {
            Order order = GetOrderRequest();
            order.Customer.Name = null;
            _manageOrder.Setup(a => a.CreateOrder(order, settingsModel.ConnectionString)).Returns(false);

            var actionResult = controller.Create(order);
            var returnStatus = (Microsoft.AspNetCore.Mvc.BadRequestResult)actionResult;
            Assert.IsType<OrderController>(controller);
            Assert.IsType<Microsoft.AspNetCore.Mvc.BadRequestResult>(actionResult);
            Assert.NotNull(order);
            Assert.Equal(400, returnStatus.StatusCode);

        }
        [Fact]
        public void PassPCustomerAddress1AsNull_ExpectValidationFailure()
        {
            Order order = GetOrderRequest();
            order.Customer.AddressLine1 = null;
            _manageOrder.Setup(a => a.CreateOrder(order, settingsModel.ConnectionString)).Returns(false);

            var actionResult = controller.Create(order);
            var returnStatus = (Microsoft.AspNetCore.Mvc.BadRequestResult)actionResult;
            Assert.IsType<OrderController>(controller);
            Assert.IsType<Microsoft.AspNetCore.Mvc.BadRequestResult>(actionResult);
            Assert.NotNull(order);
            Assert.Equal(400, returnStatus.StatusCode);

        }
        [Fact]
        public void PassPCustomerCityAsNull_ExpectValidationFailure()
        {
            Order order = GetOrderRequest();
            order.Customer.City = null;
            _manageOrder.Setup(a => a.CreateOrder(order, settingsModel.ConnectionString)).Returns(false);

            var actionResult = controller.Create(order);
            var returnStatus = (Microsoft.AspNetCore.Mvc.BadRequestResult)actionResult;
            Assert.IsType<OrderController>(controller);
            Assert.IsType<Microsoft.AspNetCore.Mvc.BadRequestResult>(actionResult);
            Assert.NotNull(order);
            Assert.Equal(400, returnStatus.StatusCode);

        }
        [Fact]
        public void PassPCustomerStateAsNull_ExpectValidationFailure()
        {
            Order order = GetOrderRequest();
            order.Customer.State = null;
            _manageOrder.Setup(a => a.CreateOrder(order, settingsModel.ConnectionString)).Returns(false);

            var actionResult = controller.Create(order);
            var returnStatus = (Microsoft.AspNetCore.Mvc.BadRequestResult)actionResult;
            Assert.IsType<OrderController>(controller);
            Assert.IsType<Microsoft.AspNetCore.Mvc.BadRequestResult>(actionResult);
            Assert.NotNull(order);
            Assert.Equal(400, returnStatus.StatusCode);

        }
        [Fact]
        public void PassPCustomerCountryAsNull_ExpectValidationFailure()
        {
            Order order = GetOrderRequest();
            order.Customer.Country = null;
            _manageOrder.Setup(a => a.CreateOrder(order, settingsModel.ConnectionString)).Returns(false);

            var actionResult = controller.Create(order);
            var returnStatus = (Microsoft.AspNetCore.Mvc.BadRequestResult)actionResult;
            Assert.IsType<OrderController>(controller);
            Assert.IsType<Microsoft.AspNetCore.Mvc.BadRequestResult>(actionResult);
            Assert.NotNull(order);
            Assert.Equal(400, returnStatus.StatusCode);

        }
        [Fact]
        public void PassPCustomerZipCodeAszero_ExpectValidationFailure()
        {
            Order order = GetOrderRequest();
            order.Customer.ZipCode = 0;
            _manageOrder.Setup(a => a.CreateOrder(order, settingsModel.ConnectionString)).Returns(false);

            var actionResult = controller.Create(order);
            var returnStatus = (Microsoft.AspNetCore.Mvc.BadRequestResult)actionResult;
            Assert.IsType<OrderController>(controller);
            Assert.IsType<Microsoft.AspNetCore.Mvc.BadRequestResult>(actionResult);
            Assert.NotNull(order);
            Assert.Equal(400, returnStatus.StatusCode);

        }
        [Fact]
        public void PassPCustomerPhoneAsNull_ExpectValidationFailure()
        {
            Order order = GetOrderRequest();
            order.Customer.PhoneNumber = null;
            _manageOrder.Setup(a => a.CreateOrder(order, settingsModel.ConnectionString)).Returns(false);

            var actionResult = controller.Create(order);
            var returnStatus = (Microsoft.AspNetCore.Mvc.BadRequestResult)actionResult;
            Assert.IsType<OrderController>(controller);
            Assert.IsType<Microsoft.AspNetCore.Mvc.BadRequestResult>(actionResult);
            Assert.NotNull(order);
            Assert.Equal(400, returnStatus.StatusCode);

        }

        [Fact]
        public void PassShippingAsNull_ExpectValidationFailure()
        {
            Order order = GetOrderRequest();
            order.Shipping = null;
            _manageOrder.Setup(a => a.CreateOrder(order, settingsModel.ConnectionString)).Returns(false);

            var actionResult = controller.Create(order);
            var returnStatus = (Microsoft.AspNetCore.Mvc.BadRequestResult)actionResult;
            Assert.IsType<OrderController>(controller);
            Assert.IsType<Microsoft.AspNetCore.Mvc.BadRequestResult>(actionResult);
            Assert.NotNull(order);
            Assert.Equal(400, returnStatus.StatusCode);

        }
        [Fact]
        public void PassPShippingNameAsNull_ExpectValidationFailure()
        {
            Order order = GetOrderRequest();
            order.Shipping.Name = null;
            _manageOrder.Setup(a => a.CreateOrder(order, settingsModel.ConnectionString)).Returns(false);

            var actionResult = controller.Create(order);
            var returnStatus = (Microsoft.AspNetCore.Mvc.BadRequestResult)actionResult;
            Assert.IsType<OrderController>(controller);
            Assert.IsType<Microsoft.AspNetCore.Mvc.BadRequestResult>(actionResult);
            Assert.NotNull(order);
            Assert.Equal(400, returnStatus.StatusCode);

        }
        [Fact]
        public void PassPShippingAddress1AsNull_ExpectValidationFailure()
        {
            Order order = GetOrderRequest();
            order.Shipping.AddressLine1 = null;
            _manageOrder.Setup(a => a.CreateOrder(order, settingsModel.ConnectionString)).Returns(false);

            var actionResult = controller.Create(order);
            var returnStatus = (Microsoft.AspNetCore.Mvc.BadRequestResult)actionResult;
            Assert.IsType<OrderController>(controller);
            Assert.IsType<Microsoft.AspNetCore.Mvc.BadRequestResult>(actionResult);
            Assert.NotNull(order);
            Assert.Equal(400, returnStatus.StatusCode);

        }
        [Fact]
        public void PassPShippingCityAsNull_ExpectValidationFailure()
        {
            Order order = GetOrderRequest();
            order.Shipping.City = null;
            _manageOrder.Setup(a => a.CreateOrder(order, settingsModel.ConnectionString)).Returns(false);

            var actionResult = controller.Create(order);
            var returnStatus = (Microsoft.AspNetCore.Mvc.BadRequestResult)actionResult;
            Assert.IsType<OrderController>(controller);
            Assert.IsType<Microsoft.AspNetCore.Mvc.BadRequestResult>(actionResult);
            Assert.NotNull(order);
            Assert.Equal(400, returnStatus.StatusCode);

        }
        [Fact]
        public void PassPShippingStateAsNull_ExpectValidationFailure()
        {
            Order order = GetOrderRequest();
            order.Shipping.State = null;
            _manageOrder.Setup(a => a.CreateOrder(order, settingsModel.ConnectionString)).Returns(false);

            var actionResult = controller.Create(order);
            var returnStatus = (Microsoft.AspNetCore.Mvc.BadRequestResult)actionResult;
            Assert.IsType<OrderController>(controller);
            Assert.IsType<Microsoft.AspNetCore.Mvc.BadRequestResult>(actionResult);
            Assert.NotNull(order);
            Assert.Equal(400, returnStatus.StatusCode);

        }
        [Fact]
        public void PassPShippingCountryAsNull_ExpectValidationFailure()
        {
            Order order = GetOrderRequest();
            order.Shipping.Country = null;
            _manageOrder.Setup(a => a.CreateOrder(order, settingsModel.ConnectionString)).Returns(false);

            var actionResult = controller.Create(order);
            var returnStatus = (Microsoft.AspNetCore.Mvc.BadRequestResult)actionResult;
            Assert.IsType<OrderController>(controller);
            Assert.IsType<Microsoft.AspNetCore.Mvc.BadRequestResult>(actionResult);
            Assert.NotNull(order);
            Assert.Equal(400, returnStatus.StatusCode);

        }
        [Fact]
        public void PassPShippingZipCodeAszero_ExpectValidationFailure()
        {
            Order order = GetOrderRequest();
            order.Shipping.ZipCode = 0;
            _manageOrder.Setup(a => a.CreateOrder(order, settingsModel.ConnectionString)).Returns(false);

            var actionResult = controller.Create(order);
            var returnStatus = (Microsoft.AspNetCore.Mvc.BadRequestResult)actionResult;
            Assert.IsType<OrderController>(controller);
            Assert.IsType<Microsoft.AspNetCore.Mvc.BadRequestResult>(actionResult);
            Assert.NotNull(order);
            Assert.Equal(400, returnStatus.StatusCode);

        }
        [Fact]
        public void PassPShippingPhoneAsNull_ExpectValidationFailure()
        {
            Order order = GetOrderRequest();
            order.Shipping.PhoneNumber = null;
            _manageOrder.Setup(a => a.CreateOrder(order, settingsModel.ConnectionString)).Returns(false);

            var actionResult = controller.Create(order);
            var returnStatus = (Microsoft.AspNetCore.Mvc.BadRequestResult)actionResult;
            Assert.IsType<OrderController>(controller);
            Assert.IsType<Microsoft.AspNetCore.Mvc.BadRequestResult>(actionResult);
            Assert.NotNull(order);
            Assert.Equal(400, returnStatus.StatusCode);

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
            products.Type = PaymentEnum.PhysicalProduct;
            products.Quantity = 1;
            products.Price = 100000.00;
            var Listproducts = new List<Product>();
            Listproducts.Add(products);
            order.Products = Listproducts;
            return order;

        }


    }
}
