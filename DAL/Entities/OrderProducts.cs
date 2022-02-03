using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class OrderProducts
    {
        public Guid OrderId { get; set; }
        public virtual List<Order> Orders { get; set; }

        public Guid ProductId { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
