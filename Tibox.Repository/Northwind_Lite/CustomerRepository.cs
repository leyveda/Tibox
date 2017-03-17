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
   public  class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public Customer CustomerWithOrders(int id)
        {
            using (var connection = new SqlConnection(_conecctionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@customerId", id);

                using (var multiple = connection
                    .QueryMultiple("dbo.CustomerWithOrders",
                    parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    var customer = multiple.Read<Customer>().Single();
                    customer.Orders = multiple.Read<Order>();
                    return customer;
                }
            }
       }

        public Customer SearchByNames(string firstname, string lastname)
        {
            using (var connection = new SqlConnection(_conecctionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@firstName", firstname);
                parameters.Add("@lastName", lastname);

                return connection
                    .QueryFirst<Customer>("dbo.CustomerSearchByNames",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
