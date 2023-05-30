using System.ComponentModel.DataAnnotations;

namespace EMR.Data.Model.User.Request
{
    public class SaveUserRequestModel
    {
        [Required(ErrorMessage = "Please select an organization to proceed with save user")]
        public Guid OrganizationDetailId { get; set; }
        public Guid? UserDetailId { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [MaxLength(10)]
        public string? Title { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string? MiddleName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        [MaxLength(10)]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Birth Date is required")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Phone No is required")]
        [MaxLength(10)]
        public string? CellNo { get; set; }

        [Required(ErrorMessage = "Email Address is required")]
        [MaxLength(50)]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MaxLength(50)]
        public string Password { get; set; }

        [MaxLength(100)]
        public string? AddressLine1 { get; set; }

        [MaxLength(100)]
        public string? AddressLine2 { get; set; }

        [MaxLength(50)]
        public string? City { get; set; }

        [MaxLength(2)]
        public string? StateCode { get; set; }

        public short? CountryId { get; set; }

        [MaxLength(6)]
        public string? PinCode { get; set; }

        [Required(ErrorMessage = "User Role is required")]
        public int UserRoleId { get; set; }
    }
}
