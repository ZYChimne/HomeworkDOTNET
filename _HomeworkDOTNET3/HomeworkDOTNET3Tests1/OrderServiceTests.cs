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
        
        [TestMethod()]
        public void OrderServiceTest()
        {
            ProductList pl = new ProductList();
            OrderService os = new OrderService(pl);
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
        public void AddOrderTest()
        {
            ProductList pl = new ProductList();
            OrderService os = new OrderService(pl);
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
        public void DeleteOrderTest()
        {
            ProductList pl = new ProductList();
            OrderService os = new OrderService(pl);
            os.AddOrder("client1", new List<ClientDemand>(){
                new ClientDemand("camera1", 1),
                new ClientDemand("computer1",1)
            });
            os.AddOrder("client2", new List<ClientDemand>(){
                new ClientDemand("camera2", 1),
                new ClientDemand("phone2",1)
            });
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
            ProductList pl = new ProductList();
            OrderService os = new OrderService(pl);
            os.AddOrder("client1", new List<ClientDemand>(){
                new ClientDemand("camera1", 1),
                new ClientDemand("computer1",1)
            });
            os.AddOrder("client2", new List<ClientDemand>(){
                new ClientDemand("camera2", 1),
                new ClientDemand("phone2",1)
            });
            os.UpdateOrder("client2", new List<ClientDemand>(){
                new ClientDemand("camera2", 2),
                new ClientDemand("phone2",1)
            });
        }

        [TestMethod()]
        public void ToStringLongTest()
        {
            ProductList pl = new ProductList();
            OrderService os = new OrderService(pl);
            os.AddOrder("client1", new List<ClientDemand>(){
                new ClientDemand("camera1", 1),
                new ClientDemand("computer1",1)
            });
            os.AddOrder("client2", new List<ClientDemand>(){
                new ClientDemand("camera2", 1),
                new ClientDemand("phone2",1)
            });
            Console.WriteLine(os.ToStringLong("client2"));
        }

        [TestMethod()]
        public void ToStringShortTest()
        {
            ProductList pl = new ProductList();
            OrderService os = new OrderService(pl);
            os.AddOrder("client1", new List<ClientDemand>(){
                new ClientDemand("camera1", 1),
                new ClientDemand("computer1",1)
            });
            os.AddOrder("client2", new List<ClientDemand>(){
                new ClientDemand("camera2", 1),
                new ClientDemand("phone2",1)
            });
            Console.WriteLine(os.ToStringShort("client2"));
        }

        [TestMethod()]
        public void ExportTest()
        {
            ProductList pl = new ProductList();
            OrderService os = new OrderService(pl);
            os.AddOrder("client1", new List<ClientDemand>(){
                new ClientDemand("camera1", 1),
                new ClientDemand("computer1",1)
            });
            os.AddOrder("client2", new List<ClientDemand>(){
                new ClientDemand("camera2", 1),
                new ClientDemand("phone2",1)
            });
            os.Export();
        }

        [TestMethod()]
        public void ImportTest()
        {
            ProductList pl = new ProductList();
            OrderService os = new OrderService(pl);
            os.AddOrder("client1", new List<ClientDemand>(){
                new ClientDemand("camera1", 1),
                new ClientDemand("computer1",1)
            });
            os.AddOrder("client2", new List<ClientDemand>(){
                new ClientDemand("camera2", 1),
                new ClientDemand("phone2",1)
            });
            os.Export();
            os.Import();
        }
    }
}