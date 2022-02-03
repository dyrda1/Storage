using BBL.AuthorizationModels;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BBL.Services.Interfaces
{
    public interface ILoginService
    {
        Task<ClaimsIdentity> Login(LoginModel model);
    }
}
