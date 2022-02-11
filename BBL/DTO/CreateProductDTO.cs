using System;

namespace BBL.DTO
{
    public class CreateProductDTO
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
