using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    class Role
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual List<User> Users { get; set; }
    }
}
