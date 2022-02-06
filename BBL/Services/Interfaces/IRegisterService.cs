using BBL.AuthorizationModels;
using BBL.BusinessModels;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BBL.Services.Interfaces
{
    public interface IRegisterService
    {
        Task<Response<ClaimsIdentity>> Register(RegisterModel model);
    }
}
