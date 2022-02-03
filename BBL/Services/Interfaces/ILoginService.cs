using BBL.AuthorizationModels;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BBL.Services.Interfaces
{
    interface ILoginService
    {
        Task<ClaimsIdentity> Login(LoginModel model);
    }
}
