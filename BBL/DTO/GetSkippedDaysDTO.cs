using BBL.DTO;

namespace BLL.DTO
{
    public class GetSkippedDaysDTO
    {
        public int Amount { get; set; }
        public bool MarkedToday { get; set; }
        public UserDTO User { get; set; }
    }
}
