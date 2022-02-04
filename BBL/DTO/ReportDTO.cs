using System;
using System.Collections.Generic;

namespace BBL.DTO
{
    public class ReportDTO
    {
        public Guid Id { get; set; }
        public string Time { get; set; }
        public decimal Sum { get; set; }
        public int Amount { get; set; }
        public List<ProductDTO> Products { get; set; }
    }
}
