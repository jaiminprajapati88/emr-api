using System.ComponentModel.DataAnnotations;

namespace EMR.Data.Model.Organization.Request
{
    public class SaveOrganizationRequestModel
    {
        public Guid? OrganizationDetailId { get; set; }

        [Required(ErrorMessage = "Organization Name is required")]
        [MaxLength(255)]
        public string OrganizationName { get; set; }

        [Required(ErrorMessage = "Address Line 1 is required")]
        [MaxLength(100)]
        public string AddressLine1 { get; set; }

        [Required(ErrorMessage = "Address Line 2 is required")]
        public string AddressLine2 { get; set; }

        [Required(ErrorMessage = "City is required")]
        [MaxLength(50)]
        public string City { get; set; }

        [Required(ErrorMessage = "State is required")]
        [MaxLength(2)]
        public string StateCode { get; set; }

        [Required(ErrorMessage = "Country is required")]
        public short CountryId { get; set; }

        [Required(ErrorMessage = "PinCode is required")]
        [MaxLength(6)]
        public string PinCode { get; set; }

        [Required(ErrorMessage = "Phone No is required")]
        [MaxLength(10)]
        public string CellNo { get; set; }

        [MaxLength(50)]
        public string FormCNumber { get; set; }

        [MaxLength(10)]
        public string PanCardNumber { get; set; }

        [MaxLength(15)]
        public string GSTIN { get; set; }

        [Required(ErrorMessage = "Organization Type is required")]
        public int OrganizationTypeId { get; set; }
    }
}
