using OrderProcessManagement.BO;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderProcessManagement.BL
{
    public interface IPaymentRuleProcessor
    {
        bool ProcessPaymentRules(Order order);
    }
}
