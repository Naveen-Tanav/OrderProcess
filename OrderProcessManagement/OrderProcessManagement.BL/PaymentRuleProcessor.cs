using OrderProcessManagement.BO;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderProcessManagement.BL
{
    public class PaymentRuleProcessor : IPaymentRuleProcessor
    {

        List<IPaymentRule> _paymentRules = new List<IPaymentRule>();

        public PaymentRuleProcessor()
        {
            _paymentRules.Add(new PhysicalProductPaymentRule(new PackageSlip()));
            _paymentRules.Add(new BookPaymentRule(new PackageSlip()));
            _paymentRules.Add(new ActivateMembershipPaymentRule(new Membsership(), new EmailSender()));
            _paymentRules.Add(new UpgradeMembershipPaymentRule(new Membsership(), new EmailSender()));
            _paymentRules.Add(new VideoPaymentRule());
        }
        public bool ProcessPaymentRules(Order order)
        {
            bool result = false;
            try
            {
                foreach (var rule in _paymentRules)
                {
                    rule.ExecutePaymentRule(order);
                }
                result = true;

            }
            catch(Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
}
