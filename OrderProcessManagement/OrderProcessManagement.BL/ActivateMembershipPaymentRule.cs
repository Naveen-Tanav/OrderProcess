using OrderProcessManagement.BO;

namespace OrderProcessManagement.BL
{
    public class ActivateMembershipPaymentRule : IPaymentRule
    {
        IMembsership _membership; IEmailSender _emailSender;
        public ActivateMembershipPaymentRule(IMembsership membership, IEmailSender emailSender)
        {
            _membership = membership;
            _emailSender = emailSender;
        }

        public void ExecutePaymentRule(Order order)
        {
            foreach (Product product in order.Products)
            {
                if (product.Type == PaymentEnum.ActivateMembership)
                {
                    _membership.ActivateMembership(product.Name);
                    _emailSender.SendEmailForActivateUpgradeMembership(order.Customer.Name, "Activated");

                }
            }

        }
    }
}