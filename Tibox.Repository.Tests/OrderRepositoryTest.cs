using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tibox.Models;
using Tibox.Repository;
using System.Linq;
using Tibox.UnitOfWork;

namespace Tibox.DataAccess.Tests
{
    [TestClass]
    public class OrderRepositoryTest
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderRepositoryTest()
        {
            _unitOfWork = new TiboxUnitOfWork();
        }

        [TestMethod]
        public void Get_All_Customers()
        {
            var result = _unitOfWork.Orden.GetAll();
            Assert.AreEqual(result.Count() > 0, true);
        }

        [TestMethod]
        public void Insert_Customer()
        {
            var ordenes= new Order
            {
                OrderDate = DateTime.Now,
                OrderNumber = "Vega",
                TotalAmount = 1000
            };
            var result = _unitOfWork.Orden.Insert(ordenes);
            Assert.AreEqual(result > 0, true);
        }

        [TestMethod]
        public void First_Customer_By_Id()
        {
            var customer = _unitOfWork.Customers.GetEntityById(1);
            Assert.AreEqual(customer != null, true);

            Assert.AreEqual(customer.Id, 1);
            Assert.AreEqual(customer.FirstName, "Maria");
            Assert.AreEqual(customer.LastName, "Anders");
        }

        [TestMethod]
        public void Delete_Customer()
        {
            var customer = _unitOfWork.Customers.GetEntityById(93);
            Assert.AreEqual(customer != null, true);

            Assert.AreEqual(_unitOfWork.Customers.Delete(customer), true);
        }

        [TestMethod]
        public void Update_Customer()
        {
            var customer = _unitOfWork.Customers.GetEntityById(1);
            Assert.AreEqual(customer != null, true);

            Assert.AreEqual(_unitOfWork.Customers.Update(customer), true);
        }

        [TestMethod]
        public void CustomerOrderSearchByOrderNumber()
        {
            var ordenes = _unitOfWork.Orden.OrderSearchByOrderNumber("542379");
            Assert.AreEqual(ordenes != null, true);
            
        }

        [TestMethod]
        public void OrderWithOrderItem()
        {
            var ordenes = _unitOfWork.Orden.OrderWithOrderItems(10);
            Assert.AreEqual(ordenes != null, true);
            Assert.AreEqual(ordenes.Ordernes, true);
        }

    }
}