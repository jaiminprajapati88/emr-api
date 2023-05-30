using System.ComponentModel.DataAnnotations;

namespace EMR.Data.Model.Auth.Request
{
    public class ResetPasswordRequestModel
    {
        [Required(ErrorMessage = "Email Address is required")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "New Password is required")]
        public string NewPassword { get; set; }
    }
}
