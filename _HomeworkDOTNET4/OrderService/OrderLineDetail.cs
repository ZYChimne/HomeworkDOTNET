using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public class OrderLineDetail
    {
        public string Name { get; set; } = "";

        public double Price { get; set; } = 0;

        private int num = 0;
        public int Num { get { return num; } set { num = value; TotalPrice = num * Price; } }

        public double TotalPrice { get; set; } = 0;

        public OrderLineDetail(string name, double price, int num)
        {
            this.Name = name;
            this.Price = price;
            this.num = num;
            TotalPrice = num * price;
        }

        public OrderLineDetail() { }
    }
}
