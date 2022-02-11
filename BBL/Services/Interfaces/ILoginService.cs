using BBL.BusinessModels;
using BBL.DTO;
using System.Threading.Tasks;

namespace BBL.Services.Interfaces
{
    public interface ILoginService
    {
        Task<Response<string>> Login(UserDTO userDTO);
    }
}
