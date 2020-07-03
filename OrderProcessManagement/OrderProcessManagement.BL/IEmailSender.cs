using System;
using System.Collections.Generic;
using System.Text;

namespace OrderProcessManagement.BL
{
    public interface IEmailSender
    {
        void SendEmailForActivateUpgradeMembership(string customerName, string membershipStatus);
    }
}
