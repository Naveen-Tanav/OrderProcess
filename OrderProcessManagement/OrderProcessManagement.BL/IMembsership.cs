using System;
using System.Collections.Generic;
using System.Text;

namespace OrderProcessManagement.BL
{
    public interface IMembsership
    {
        void ActivateMembership(string order);
        void UpgradeMembership(string order);
    }
}
