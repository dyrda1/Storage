using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class Report
    {
        public Guid Id { get; set; }
        public string Time { get; set; }
        public decimal Sum { get; set; }
        public int Amount { get; set; }

        public virtual List<Product> Products { get; set; }
        public virtual List<ReportProducts> ReportProducts { get; set; }
    }
}
