namespace EMR.Data.Model.Organization.Request
{
    public class SearchOrganizationRequestModel
    {
        public Guid? OrganizationDetailId { get; set; }
        public string? OrganizationName { get; set; }
        public int? OrganizationTypeId { get; set; }

        public SearchOrganizationRequestModel(Guid? organizationDetailId = null, string? organizationName = null, int? organizationTypeId = null)
        {
            OrganizationDetailId = organizationDetailId;
            OrganizationName = organizationName;
            OrganizationTypeId = organizationTypeId;
        }
    }
}
