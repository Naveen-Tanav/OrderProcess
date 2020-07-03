using System;
using System.Collections.Generic;
using System.Text;

namespace OrderProcessManagement.BL
{
    public interface IPackageSlip
    {
        void GeneratePackageSlip(string productName);
        void GenerateDuplicatePackageSlip(string productName);
    }
}
