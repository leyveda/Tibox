using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibox.Models;

namespace Tibox.Repository.Northwind_Lite
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public Order OrderWithOrderItems(String ordername)
        {
            using (var connection = new SqlConnection(_conecctionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@OrderNumber", ordername);

                using (var multiple = connection
                    .QueryMultiple("dbo.OrderWithOrdersItems",
                    parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    var order = multiple.Read<Order>().Single();
                    order.Ordernes = multiple.Read<OrderItem>();
                    return order;
                }
            }
        }

        public Order OrderSearchByOrderNumber(string orderNumber)
        {
            using (var connection = new SqlConnection(_conecctionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@OrderNumber", orderNumber);

                return connection
                    .QueryFirst<Order>("dbo.OrderSearchByOrderNumber",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

    }
}
