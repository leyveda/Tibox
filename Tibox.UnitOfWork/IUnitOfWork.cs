﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibox.Models;
using Tibox.Repository;
using Tibox.Repository.Northwind_Lite;

namespace Tibox.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICustomerRepository Customers { get; }
        IOrderRepository Orden { get; }

        IRepository<Order> Orders { get; }
        IRepository<OrderItem> OrdeOrderItems { get; }
        IRepository<Product> Products { get; }
        IRepository<Supplier> Suppliers { get; }
    }


}
