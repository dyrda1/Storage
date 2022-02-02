﻿using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class Brand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}