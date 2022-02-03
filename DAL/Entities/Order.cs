﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }

        public decimal Sum { get { return Products.Select(x => x.Price).Sum(); } } //TODO: hier or in DTO        
        public int Count { get { return Products.Count; } }

        public List<Product> Products { get; set; }
        public List<OrderProducts> OrderProducts { get; set; }
    }
}