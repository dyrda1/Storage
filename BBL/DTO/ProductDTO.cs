using System;
using System.Collections.Generic;

namespace BBL.DTO
{
    public class ProductDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid? BrandId { get; set; }
        public List<OrderDTO> Orders { get; set; }
    }
}
