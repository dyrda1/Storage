using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class ReportProducts
    {
        public Guid Product_Id { get; set; }
        public virtual List<Product> Products { get; set; }

        public Guid Report_Id { get; set; }
        public virtual List<Report> Reports { get; set; }
    }
}
