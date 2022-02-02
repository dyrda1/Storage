using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }

        //public decimal Sum { get return ; set; }
        //public int Count { get return; set; }

        public List<Product> Products { get; set; }
        public List<OrderProducts> OrderProducts { get; set; }
    }
}
