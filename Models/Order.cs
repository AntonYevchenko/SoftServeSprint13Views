using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViewTask.Models
{
    public class Order
    {

        public string Name { get; set; }
        public string Address { get; set; }
        public string Supermarket { get; set; }
        public List<string> Products { get; set; }

        public List<DateTime> DeliveryTimes { get; set; }

        public DateTime DeliveryTime { get; set; }

        public Order(){
            DeliveryTimes = new();
        }

        public Order(string name, string address, string supermarket, List<string> products, DateTime deliveryTime)
        {
            Name = name;
            Address = address;
            Supermarket = supermarket;
            Products = products;
            DeliveryTime = deliveryTime;
            DeliveryTimes = new();
        }
    }
}