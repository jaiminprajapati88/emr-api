namespace EMR.Data.Model.Patient.Request
{
    public class SearchPatientRequestModel
    {
        public Guid OrganizationDetailId { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string CellNo { get; set; } = null!;

        public SearchPatientRequestModel(Guid organizationDetailId, string? cellNo = null)
        {
            OrganizationDetailId = organizationDetailId;
            CellNo = cellNo;
        }
    }
}
