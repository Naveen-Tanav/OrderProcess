using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OrderProcessManagement.BL;
using OrderProcessManagement.BO;

namespace OrderProcessManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IManageOrder _manageOrder;
        IPaymentRuleProcessor _paymentRuleProcessor;
        private readonly IOptions<SettingsModel> appSettings;
        public OrderController(IOptions<SettingsModel> app,IManageOrder manageOrder,IPaymentRuleProcessor paymentRuleProcessor)
        {
            appSettings = app;
            _manageOrder = manageOrder;
            _paymentRuleProcessor = paymentRuleProcessor;
        }
        [HttpPost]
        public IActionResult Create(Order order)
        {
            var connectionValue = appSettings.Value.ConnectionString;
            bool status = _manageOrder.CreateOrder(order, connectionValue);
            if(!status)
            {
                return BadRequest();
            }
            else if(status)
            {
              var ruleEngineStatus= _paymentRuleProcessor.ProcessPaymentRules(order);
                if(!ruleEngineStatus)
                {
                    return BadRequest();
                }
                
            }
            return Ok();
        }
    }
}