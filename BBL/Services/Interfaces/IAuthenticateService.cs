using BBL.DTO;
using System.Security.Claims;

namespace BBL.Services.Interfaces
{
    public interface IAuthenticateService
    {
        ClaimsIdentity Authenticate(UserDTO userDTO);
    }
}
