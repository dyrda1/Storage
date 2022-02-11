using DAL.Entities;

namespace BBL.Services.Interfaces
{
    public interface IAuthenticateService
    {
        string CreateToken(User user);
    }
}
