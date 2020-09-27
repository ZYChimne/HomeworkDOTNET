using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

//Using id may lead to Order Not Found if the order is removed.
//Id is usually not known to the user as an internal number.
//I use the client to be the only identifier here.
//Which means a client can have only one order.
namespace HomeworkDOTNET3
{
    class Program
    {
        static void Main(string[] args)
        {
            string stop = Console.ReadLine();
        }
    }
}
