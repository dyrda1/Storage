using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime CreateDate { get; set; }

        public Guid? BrandId { get; set; }
        public virtual Brand Brand { get; set; }

        public virtual List<Order> Orders { get; set; }
        public virtual List<OrderProducts> OrderProducts { get; set; }

        public virtual List<Report> Report { get; set; }
        public virtual List<ReportProducts> ReportProducts { get; set; }
    }
}
