using System;

namespace OrderProcessManagement.BL
{
    public class Membsership : IMembsership
    {
        public void ActivateMembership(string order)
        {
            Console.WriteLine("Membership Activated");
        }

        public void UpgradeMembership(string order)
        {
            Console.WriteLine("Membership updated");
        }
    }
}