using System.ComponentModel.DataAnnotations;

namespace EMR.Data.Model.Auth.Request
{
    public class AuthenticateRequestModel
    {
        [Required(ErrorMessage = "Email Address is required")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
