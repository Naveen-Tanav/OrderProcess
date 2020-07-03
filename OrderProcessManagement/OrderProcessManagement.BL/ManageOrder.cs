using System;
using System.Collections.Generic;
using System.Text;
using OrderProcessManagement.BO;
using OrderProcessManagement.DAL;

namespace OrderProcessManagement.BL
{
    public class ManageOrder : IManageOrder
    {
        DALManageOrder objDALManager;
        public bool CreateOrder(Order order,string connection)
        {
            bool status = false;

            try
            {
                objDALManager = new DALManageOrder(connection);
                status = objDALManager.CreateOrder(order);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Occured : {ex}");
                throw ex;
            }
            return status;
        }
    }
}
