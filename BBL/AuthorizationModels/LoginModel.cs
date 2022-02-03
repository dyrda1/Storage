using System.ComponentModel.DataAnnotations;

namespace BBL.AuthorizationModels
{
    public class LoginModel
    {
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
