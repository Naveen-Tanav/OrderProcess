using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OrderProcessManagement.BO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OrderProcessManagement.DAL
{
    public class DALManageOrder
    {
        public string jsonFile =string.Empty; 
        public DALManageOrder(string conenction)
        {
            jsonFile= conenction + "/OrderDetails.json";
            if (!Directory.Exists(conenction))
            {

                Directory.CreateDirectory(conenction);
            }
            if (!File.Exists(jsonFile))
            {
                using (var writer = new StreamWriter(new FileStream(jsonFile, FileMode.Create)))
                {
                    writer.WriteLine("{\"OrderDetails\":[]}");
                }

            }
        }
        public bool CreateOrder(Order order)
        {
            bool status = false;
            try
            {

                order.OrderId = Guid.NewGuid().ToString().Replace("-", "");
                var newOrderDetails = JsonConvert.SerializeObject(order);
                var json = File.ReadAllText(jsonFile);
                var jsonObj = JObject.Parse(json);
                var OrderList = jsonObj.GetValue("OrderDetails") as JArray;
                var newMedicine = JObject.Parse(newOrderDetails);
                OrderList.Add(newMedicine);
                jsonObj["OrderDetails"] = OrderList;
                string newJsonResult = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
                File.WriteAllText(jsonFile, newJsonResult);
                status = true;

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
