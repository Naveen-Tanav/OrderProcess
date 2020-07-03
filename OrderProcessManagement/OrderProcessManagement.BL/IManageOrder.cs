using OrderProcessManagement.BO;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderProcessManagement.BL
{
    public interface IManageOrder
    {

        bool CreateOrder(Order order,string connection);
    }
}
