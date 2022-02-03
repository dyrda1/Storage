using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class Role
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual List<User> Users { get; set; }
    }
}
