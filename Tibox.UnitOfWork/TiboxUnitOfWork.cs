using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibox.Models;
using Tibox.Repository;
using Tibox.Repository.Northwind_Lite;

namespace Tibox.UnitOfWork
{
    public class TiboxUnitOfWork:IUnitOfWork,IDisposable
    {
        public TiboxUnitOfWork() {
            Customers = new CustomerRepository();
            Orders = new BaseRepository<Order>();
            OrdeOrderItems = new BaseRepository<OrderItem>();
            Products = new BaseRepository<Product>();
            Orders = new BaseRepository<Order>();
        }

        public ICustomerRepository Customers { get; private set; }
        public IRepository<Order> Orders { get; private set; }
        public IRepository<OrderItem> OrdeOrderItems { get; private set; }
        public IRepository<Product> Products { get; private set; }
        public IRepository<Supplier> Suppliers { get; private set; }
              

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
