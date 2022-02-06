using System.ComponentModel.DataAnnotations;

namespace BBL.AuthorizationModels
{
    public class RegisterModel : LoginModel
    {
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
