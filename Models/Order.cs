using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;

namespace Tibox.Models
{
    [Table("[order]")]
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }        
        public string OrderNumber { get; set; }
        public int CustomerId { get; set; }
        public decimal? TotalAmount { get; set; }

        public IEnumerable<OrderItem> OrderItems { get; set; }
    }
}
