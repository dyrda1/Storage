using BBL.DTO;
using BBL.Services.Interfaces;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BBL.Services.Classes
{
    public class AuthenticateService : IAuthenticateService
    {
        public ClaimsIdentity Authenticate(UserDTO userDTO)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userDTO.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, userDTO.Role.Name)
            };

            return new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        }
    }
}
