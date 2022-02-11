using BBL.DTO;
using DAL.Entities;
using System.Security.Claims;

namespace BBL.Services.Interfaces
{
    public interface IAuthenticateService
    {
        string CreateToken(User user);
    }
}
