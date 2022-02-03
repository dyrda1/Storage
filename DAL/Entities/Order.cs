using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }

        //public decimal Sum { get { return Products.Select(x => x.Price).Sum(); } }    
        //public int Count { get { return Products.Count; } }
        //TODO: in service

        public virtual List<Product> Products { get; set; }
        public virtual List<OrderProducts> OrderProducts { get; set; }
    }
}
