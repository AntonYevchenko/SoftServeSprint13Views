using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViewTask.Models
{
    public class Product
    {
        public string Name { get; private set; }
        public double Price { get; private set; }
        public int Count { get; private set; }
        public Product(string name, double price = 0, int count = 0)
        {
            Name = name;
            Price = price;
            Count = count;
        }
    }
}