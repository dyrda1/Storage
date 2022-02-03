using BBL.AuthorizationModels;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BBL.Services.Interfaces
{
    public interface IRegisterService
    {
        Task<ClaimsIdentity> Register(RegisterModel model);
    }
}
