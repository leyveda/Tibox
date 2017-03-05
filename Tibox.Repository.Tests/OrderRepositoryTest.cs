using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tibox.Models;
using Tibox.Repository;
using System.Linq;

namespace Tibox.DataAccess.Tests
{
    [TestClass]
    public class OrderRepositoryTest
    {
        private readonly IRepository<Order> _repository;
        public OrderRepositoryTest()
        {
            _repository = new BaseRepository<Order>();
        }

        [TestMethod]
        public void Get_All_Orders()
        {
            var orderList = _repository.GetAll();
            Assert.AreEqual(orderList.Count() > 0, true);
        }

    }
}