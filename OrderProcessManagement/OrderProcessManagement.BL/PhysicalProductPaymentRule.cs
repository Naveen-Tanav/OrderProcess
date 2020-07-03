using OrderProcessManagement.BO;
using System;

namespace OrderProcessManagement.BL
{
    public class PhysicalProductPaymentRule : IPaymentRule
    {
        IPackageSlip _packageSlip;
        public PhysicalProductPaymentRule(IPackageSlip packageSlip)
        {
            _packageSlip = packageSlip;
        }
        public void ExecutePaymentRule(Order order)
        {
            foreach (Product product in order.Products)
            {
                if (product.Type == PaymentEnum.PhysicalProduct)
                {
                    _packageSlip.GeneratePackageSlip(product.Name);

                    GenerateCommissionPayment(product.Name);

                }
            }

        }
        public void GenerateCommissionPayment(string productname)
        {
            Console.WriteLine("Agent commision payment generated for and item " + productname);
        }
    }
}