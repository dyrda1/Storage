using BBL.BusinessModels;
using BBL.DTO;
using System;
using System.Threading.Tasks;

namespace BBL.Services.Interfaces
{
    public interface IRegisterService
    {
        Task<Response<Guid>> Register(UserDTO userDTO);
    }
}
