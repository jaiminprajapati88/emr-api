namespace EMR.Data.Model.Patient
{
    public class PatientDetailModel
    {
        public Guid PatientDetailId { get; set; }

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

        public bool IsActive { get; set; }

        public DateTime RowAddStamp { get; set; }

        public string RowAddUserId { get; set; } = null!;

        public DateTime RowUpdateStamp { get; set; }

        public string RowUpdateUserId { get; set; } = null!;
    }
}
