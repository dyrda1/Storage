using System;

namespace DAL.Entities
{
    class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Guid? RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
