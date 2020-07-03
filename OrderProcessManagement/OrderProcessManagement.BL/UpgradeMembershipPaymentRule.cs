using OrderProcessManagement.BO;

namespace OrderProcessManagement.BL
{
    public class UpgradeMembershipPaymentRule : IPaymentRule
    {
        IMembsership _membership; IEmailSender _emailSender;
        public UpgradeMembershipPaymentRule(IMembsership membership, IEmailSender emailSender)
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
                    _membership.UpgradeMembership(order.Customer.Name);
                    _emailSender.SendEmailForActivateUpgradeMembership(order.Customer.Name, "Upgraded");


                }
            }

        }

    }
}