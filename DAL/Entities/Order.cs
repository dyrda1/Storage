using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }

        public virtual List<Product> Products { get; set; }
        public virtual List<OrderProducts> OrderProducts { get; set; }
    }
}
