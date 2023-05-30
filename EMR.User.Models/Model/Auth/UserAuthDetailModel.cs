namespace EMR.Data.Model.Auth
{
    public class UserAuthDetailModel
    {
        public Guid UserDetailId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string UserName { get { return string.Join(".", FirstName, LastName); } }
        public string? EmailAddress { get; set; }
        public int UserRoleId { get; set; }
                
    }
}
