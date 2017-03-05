using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibox.Models;

namespace Tibox.Repository.Northwind_Lite
{
    public interface IOrderRepository : IRepository<Order>
    {
        Order OrderSearchByOrderNumber(string OrderNumber);
        Order OrderWithOrderItems(String ordername);

        
    }
}