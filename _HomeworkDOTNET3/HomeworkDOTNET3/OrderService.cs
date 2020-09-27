using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HomeworkDOTNET3
{
    public class OrderService
    {
        private int id = 0;

        public List<Order> Ol { get; set; } = new List<Order>();
        private readonly ProductList pl = new ProductList();

        public OrderService(ProductList pl)
        {
            this.pl = pl;
        }

        public void AddOrder(string client, List<ClientDemand> demand)
        {
            List<OrderLineDetail> odTemp = new List<OrderLineDetail>();
            foreach (ClientDemand c in demand)
            {
                var price = from product in pl.L where product.Name == c.Name select product.Price;
                OrderLineDetail ol = new OrderLineDetail(c.Name, price.First(), c.Num);
                odTemp.Add(ol);
            }
            OrderDetail od = new OrderDetail(odTemp);
            Order o = new Order(id, client, od);
            Ol.Add(o);
            id++;
        }

        public void DeleteOrder(string client)
        {
            foreach (Order o in Ol)
            {
                if (o.Client == client)
                    try
                    {
                        Ol.Remove(o);
                        return;
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
            }
            Console.WriteLine("Order Not Found");
        }

        public Order GetOrder(int id = -1, string goodsName = "", string client = "", double money = -1)
        {
            //TODO
            if (id != -1)
            {
                var o = from order in Ol where order.Id == id select order;
                if (o.Any()) return o.First();
                else Console.WriteLine("Order Not Found");
            }
            return null;
        }

        public void UpdateOrder(string client, List<ClientDemand> l)
        {
            foreach (Order o in Ol)
            {
                if (o.Client == client)
                {
                    foreach (ClientDemand cd in l)
                    {
                        var product = from odl in o.Od.L where odl.Name == cd.Name select odl;
                        if (product.Any())
                        {
                            product.First().Num = cd.Num;
                        }
                        else
                        {
                            var price = from productWant in pl.L where productWant.Name == cd.Name select productWant.Price;
                            OrderLineDetail odl = new OrderLineDetail(cd.Name, price.First(), cd.Num);
                            o.Od.L.Add(odl);
                        }
                    }
                }
                Console.WriteLine("Order Not Found");
            }
        }

        public string ToStringLong(string client)
        {
            string msg1 = "", msg2 = "";
            foreach (Order o in Ol)
            {
                if (client == o.Client)
                {
                    msg1 = o.ToString();
                    msg2 = o.Od.ToString();
                }
            }
            if (msg1 == "" && msg2 == "") Console.WriteLine("Order Not Found");
            return msg1 + "\n" + msg2;
        }

        public string ToStringShort(string client)
        {
            string msg1 = "";
            foreach (Order o in Ol)
            {
                if (client == o.Client)
                {
                    msg1 = o.ToString();
                }
            }
            if (msg1 == "") Console.WriteLine("Order Not Found");
            return msg1;
        }

        public void Export()
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream("Order.xml", FileMode.Create))
                xml.Serialize(fs, Ol);
        }

        public void Import()
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream("Order.xml", FileMode.Open))
            {
                List<Order> olTemp = (List<Order>)xml.Deserialize(fs);
                Ol = olTemp;
            }
        }
    }
}
