using OrderProcessManagement.BO;
using System;

namespace OrderProcessManagement.BL
{
    public class VideoPaymentRule : IPaymentRule
    {

        public void ExecutePaymentRule(Order order)
        {
            foreach (Product product in order.Products)
            {
                if (product.Type == PaymentEnum.video)
                {
                    AddVideoToPackageSlip();
                }
            }
        }
        public void AddVideoToPackageSlip()
        {

            Console.WriteLine("First Aid Video is added to package slip");
        }

    }
}