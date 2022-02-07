using System;

namespace BBL.DTO
{
    public class SkippedDaysDTO
    {
        public int Amount { get; set; }
        public bool MarkedToday { get; set; }
        public UserDTO User { get; set; }
    }
}
