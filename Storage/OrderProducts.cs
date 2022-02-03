using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class OrderProducts
    {
        public Guid OrderId { get; set; }
        public List<Order> Orders { get; set; }

        public Guid ProductId { get; set; }
        public List<Product> Products { get; set; }
    }
}
