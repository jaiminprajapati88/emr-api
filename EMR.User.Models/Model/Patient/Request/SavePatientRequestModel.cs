namespace EMR.Data.Model.Patient.Request
{
    public class SavePatientRequestModel
    {
        public Guid? PatientDetailId { get; set; }

        public Guid OrganizationDetailId { get; set; }

        public string PatientId { get; set; } = null!;

        public string Title { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string? MiddleName { get; set; }

        public string LastName { get; set; } = null!;

        public string TitlePerm { get; set; } = null!;

        public string FirstNamePerm { get; set; } = null!;

        public string? MiddleNamePerm { get; set; }

        public string LastNamePerm { get; set; } = null!;

        public int GenderId { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int DateOfBirthType { get; set; }

        public string CellNo { get; set; } = null!;

        public string AddressLine1 { get; set; } = null!;

        public string? AddressLine2 { get; set; }

        public string City { get; set; } = null!;

        public string State { get; set; } = null!;

        public string Country { get; set; } = null!;

        public short CountryCode { get; set; }

        public string Zipcode { get; set; } = null!;

        public string AddressLine1Perm { get; set; } = null!;

        public string? AddressLine2Perm { get; set; }

        public string CityPerm { get; set; } = null!;

        public string StatePerm { get; set; } = null!;

        public string CountryPerm { get; set; } = null!;

        public short CountryCodePerm { get; set; }

        public string ZipcodePerm { get; set; } = null!;

        public string? AadharNum { get; set; }

        public string? CentralHealthId { get; set; }

        public string? OtherIdentityType { get; set; }

        public string? OtherIdentityValue { get; set; }

        public bool IsActive { get; set; }
    }
}
