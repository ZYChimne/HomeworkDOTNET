using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public class ProductList
    {
        public List<Product> L { get; } = new List<Product>()
        {
            new Product("camera1", 5000),
            new Product("phone1", 4500),
            new Product("computer1", 10000),
            new Product("camera2", 30000),
            new Product("phone2", 8000),
            new Product("computer2", 20000)
        };

        public ProductList()
        {

        }

        public ProductList(List<Product> l, string operation)
        {
            if (operation == "REPLACE")
            {
                this.L = l;
            }
            else if (operation == "ADD")
            {
                foreach (Product p in l)
                {
                    this.L.Add(p);
                }
            }
            else Console.WriteLine("INVALID PRODUCT LIST");
        }
    }
}
