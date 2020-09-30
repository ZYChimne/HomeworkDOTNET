using Microsoft.VisualStudio.TestTools.UnitTesting;
using HomeworkDOTNET3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkDOTNET3.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        static readonly ProductList pl = new ProductList();
        OrderService os = new OrderService(pl);
        public void init()
        {
            os = new OrderService(pl);
            os.AddOrder("client1", new List<ClientDemand>(){
                new ClientDemand("camera1", 1),
                new ClientDemand("computer1",1)
            });
            os.AddOrder("client2", new List<ClientDemand>(){
                new ClientDemand("camera2", 1),
                new ClientDemand("phone2",1)
            });
        }
        
        [TestMethod()]
        public void OrderServiceTest()
        {
            
        }

        [TestMethod()]
        public void AddOrderTest()
        {
            os.AddOrder("client3", new List<ClientDemand>(){
                new ClientDemand("camera2", 1),
                new ClientDemand("phone1",1)
            });
        }

        [TestMethod()]
        public void DeleteOrderTest()
        {
            os.DeleteOrder("client2");
        }

        [TestMethod()]
        public void GetOrderTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateOrderTest()
        {
            os.UpdateOrder("client2", new List<ClientDemand>(){
                new ClientDemand("camera2", 2),
                new ClientDemand("phone2",1)
            });
        }

        [TestMethod()]
        public void ToStringLongTest()
        {
            Console.WriteLine(os.ToStringLong("client2"));
        }

        [TestMethod()]
        public void ToStringShortTest()
        {
            Console.WriteLine(os.ToStringShort("client2"));
        }

        [TestMethod()]
        public void ExportTest()
        {
            os.Export("Order.xml");
        }

        [TestMethod()]
        public void ImportTest()
        {
            os.Export("Order.xml");
            os.Import("Order.xml");
        }
    }
}