using System;

namespace OrderProcessManagement.BL
{
    public class EmailSender : IEmailSender
    {
        public void SendEmailForActivateUpgradeMembership(string customer, string membershipStatus)
        {
            Console.WriteLine($"Dear Mr.{customer} Your Membership is {membershipStatus}");
        }
    }
}