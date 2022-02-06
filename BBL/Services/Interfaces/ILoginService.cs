using BBL.AuthorizationModels;
using BBL.BusinessModels;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BBL.Services.Interfaces
{
    public interface ILoginService
    {
        Task<Response<ClaimsIdentity>> Login(LoginModel model);
    }
}
