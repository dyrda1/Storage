using BBL.DTO;
using System.Security.Claims;

namespace BBL.Services.Interfaces
{
    interface IAuthenticateService
    {
        ClaimsIdentity Authenticate(UserDTO user);
    }
}
