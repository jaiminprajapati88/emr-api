namespace EMR.Data.Model.User.Request
{
    public class SearchUserRequestModel
    {
        public Guid? OrganizationDetailId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmailAddress { get; set; }
        public int? UserRoleId { get; set; }

        public SearchUserRequestModel(Guid? organizationDetailId = null, string? emailAddress = null, string? firstName = null, string? lastName = null, int? userRoleId = null)
        {
            OrganizationDetailId = organizationDetailId;
            EmailAddress = emailAddress;
            FirstName = firstName;
            LastName = lastName;
            UserRoleId = userRoleId;
        }
    }
}
