using System;

namespace DAL.Entities
{
    public class SkippedDays
    {
        public Guid Id { get; set; }
        public int Amount { get; set; }
        public bool MarkedToday { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
