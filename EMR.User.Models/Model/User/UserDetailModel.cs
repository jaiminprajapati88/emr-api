using System.Text.Json.Serialization;

namespace EMR.Data.Model.User
{
    public class UserDetailModel 
    {
        public Guid? UserDetailId { get; set; }
        public string? Title { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? CellNo { get; set; }
        public string EmailAddress { get; set; }
        [JsonIgnore]
        public string? PasswordSalt { get; set; }
        [JsonIgnore]
        public string? PasswordHash { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? City { get; set; }
        public string? StateCode { get; set; }                
        public short? CountryId { get; set; }
        public string? PinCode { get; set; }
        public int UserRoleId { get; set; }
    }
}
