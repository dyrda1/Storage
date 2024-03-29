﻿using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual List<Order> Orders { get; set; }

        public virtual List<Report> Reports { get; set; }
    }
}
