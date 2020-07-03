using System;

namespace OrderProcessManagement.BL
{
    public class PackageSlip : IPackageSlip
    {
        public void GenerateDuplicatePackageSlip(string productName)
        {
            Console.WriteLine("Duplicate package slip generated for product : " + productName);
        }

        public void GeneratePackageSlip(string productName)
        {
            Console.WriteLine("Package slip generated for product : " + productName);
        }
    }
}