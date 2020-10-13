using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkDOTNET6
{
    public class Product
    {
        public string Name { get; } = "";
        public double Price { get; } = 0;

        public Product(string name, double price)
        {
            this.Name = name;
            this.Price = price;
        }
    }
}
