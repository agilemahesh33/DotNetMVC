using System.ComponentModel.DataAnnotations;

namespace MVCCoreTagHelpers.Models
{
    public class LoginModel
    {
        [EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }

    }
}
