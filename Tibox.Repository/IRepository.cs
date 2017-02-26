using System.Collections.Generic;
using Tibox.Models;

namespace Tibox.Repository
{
    interface IRepository
    {
        int InsertCustomer(Customer customer);
        bool UpdateCustomer(Customer customer);
        bool DeleteCustomer(Customer customer);
        Customer GetCustomerById(int id);

        //List<Customer> GetAllCustomer();
        IEnumerable<Customer> GetAllCustomer();

    }

}
