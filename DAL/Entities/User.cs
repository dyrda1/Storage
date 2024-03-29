﻿using System;

namespace DAL.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public Guid RoleId { get; set; }
        public virtual Role Role { get; set; }

        public virtual SkippedDays SkippeddDays { get; set; }
    }
}
