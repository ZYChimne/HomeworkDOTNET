using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public class ClientDemand
    {
        public string Name { get; } = "";
        public int Num { get; set; } = 0;

        public ClientDemand(string name, int num)
        {
            this.Name = name;
            this.Num = num;
        }
    }
}
