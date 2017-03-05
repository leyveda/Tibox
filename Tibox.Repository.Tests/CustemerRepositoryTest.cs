using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Tibox.Repository;
using Tibox.Models;
namespace Tibox.DataAccess.Tests
{
    [TestClass]
    public class CustomerRepositoryTest
    {
        private readonly IRepository<Customer> _repository;
        public CustomerRepositoryTest()
        {
            _repository = new BaseRepository<Customer>();
        }
        [TestMethod]
        public void Get_All_Customers()
        {
            var result = _repository.GetAll();
            Assert.AreEqual(result.Count() > 0, true);
        }

        [TestMethod]
        public void Insert_Customer()
        {
            var customer = new Customer
            {
                FirstName = "Julio",
                LastName = "Velarde",
                City = "Huancavelica",
                Country = "Peru",
                Phone = "555-555-555"
            };
            var result = _repository.Insert(customer);
            Assert.AreEqual(result > 0, true);
        }

        [TestMethod]
        public void First_Customer_By_Id()
        {
            var customer = _repository.GetEntityById(1);
            Assert.AreEqual(customer != null, true);

            Assert.AreEqual(customer.Id, 1);
            Assert.AreEqual(customer.FirstName, "Maria");
            Assert.AreEqual(customer.LastName, "Anders");
        }

        [TestMethod]
        public void Delete_Customer()
        {
            var customer = _repository.GetEntityById(93);
            Assert.AreEqual(customer != null, true);

            Assert.AreEqual(_repository.Delete(customer), true);
        }

        [TestMethod]
        public void Update_Customer()
        {
            var customer = _repository.GetEntityById(1);
            Assert.AreEqual(customer != null, true);

            Assert.AreEqual(_repository.Update(customer), true);
        }
    }
}