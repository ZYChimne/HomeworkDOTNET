using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public class OrderDetail
    {
        public List<OrderLineDetail> L { get; set; } = new List<OrderLineDetail>();

        public OrderDetail(List<OrderLineDetail> l)
        {
            this.L = l;
        }

        public OrderDetail()
        {

        }

        public override string ToString()
        {
            string msg = "";
            foreach (OrderLineDetail odl in L)
            {
                msg += "Product Name: " + odl.Name + "  Single Price: " + odl.Price + "  Number: " + odl.Num + "  Total Price: " + odl.TotalPrice + "\n";
            }
            return msg;
        }

        public override bool Equals(object obj)
        {
            return obj is OrderDetail detail &&
                   EqualityComparer<List<OrderLineDetail>>.Default.Equals(L, detail.L) &&
                   EqualityComparer<List<OrderLineDetail>>.Default.Equals(L, detail.L);
        }

        public override int GetHashCode()
        {
            int hashCode = -2014347154;
            hashCode = hashCode * -1521134295 + EqualityComparer<List<OrderLineDetail>>.Default.GetHashCode(L);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<OrderLineDetail>>.Default.GetHashCode(L);
            return hashCode;
        }
    }
}
