using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkDOTNET3
{
    public class Order
    {
        public int Id { get; set; } = 0;
        public string Client { get; set; } = "";
        public double Money { get; set; } = 0;

        private OrderDetail od = new OrderDetail();
        public OrderDetail Od
        {
            get { return od; }
            set
            {
                Money = 0;
                foreach (OrderLineDetail odl in od.L)
                {
                    Money += odl.TotalPrice;
                }
            }
        }

        public Order() { }
        public Order(int id, string client, OrderDetail od)
        {
            this.Id = id;
            this.Client = client;
            this.od = od;
            Money = 0;
            foreach (OrderLineDetail odl in od.L)
            {
                Money += odl.TotalPrice;
            }
        }

        public override string ToString()
        {
            string msg = "ID: " + Id + "  Client: " + Client + "  Money: " + Money;
            return msg;
        }

        public override bool Equals(object obj)
        {
            return obj is Order order &&
                   Id == order.Id &&
                   Id == order.Id;
        }

        public override int GetHashCode()
        {
            int hashCode = -1496434976;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            return hashCode;
        }
    }
}
