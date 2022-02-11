using System;
using System.Collections.Generic;

namespace BBL.DTO
{
    public class OrderDTO
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public List<ProductDTO> Products { get; set; }
    }
}
