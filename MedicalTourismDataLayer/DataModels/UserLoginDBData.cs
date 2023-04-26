using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MedicalTourismDataLayer.DataModels
{
    public class UserLoginDBData : BaseModel
    {
        public Guid UserId { get; set; }
        public string Title { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string MiddleName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Gender { get; set; } = "";
        public DateTime DateOfBirth { get; set; } = DateTime.Now;
        public string CellNo { get; set; } = "";
        public string EmailAddress { get; set; } = "";
        public int PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; } = new byte[0];
        public string AddressLine1 { get; set; } = "";
        public string AddressLine2 { get; set; } = "";
        public string City { get; set; } = "";
        public string State { get; set; } = "";
        public string Country { get; set; } = "";
        public Int16 CountryCode { get; set; }
        public string Zipcode { get; set; } = "";
        public int UserRoleId { get; set; }
        public string JWTToken { get; set; } = "";
    }

    public class UserCredentialsDBData : BaseModel
    {
        public Guid UserId { get; set; }       
        public int PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; } = new byte[0];        
    }

   


    public class UserLoginAppInData : BaseModel
    {
        public Guid UserId { get; set; }         
        public string UserEmail { get; set; } = "";
        public string UserPassword { get; set; } = "";
    }

    public class UserResetPassword : BaseModel
    {
        public Guid UserId { get; set; }
        public Guid ApplicationId { get; set; }
        public string UserEmail { get; set; } = "";
        public string UserOldPassword { get; set; } = "";
        public string UserNewPassword { get; set; } = "";
    }

    public class RegisterUserRequest : BaseModel
    {
        public Guid UserId { get; set; }
        public string Title { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string MiddleName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Gender { get; set; } = "";
        public DateTime DateOfBirth { get; set; } = DateTime.Now;
        public string CellNo { get; set; } = "";
        public string EmailAddress { get; set; } = "";
        public string EmailPassword { get; set; } = "";
        //public int PasswordSalt { get; set; }   
        //public byte PasswordHash { get; set; }
        public string AddressLine1 { get; set; } = "";
        public string AddressLine2 { get; set; } = "";
        public string City { get; set; } = "";
        public string State { get; set; } = "";
        public string Country { get; set; } = "";
        public Int16 CountryCode { get; set; }
        public string Zipcode { get; set; } = "";
        public int UserRoleId { get; set; }
    }

    public class RegisterUserRequest2 : BaseModel
    {
        public Guid UserId { get; set; }
        public string Title { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string MiddleName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Gender { get; set; } = "";
        public DateTime DateOfBirth { get; set; } = DateTime.Now;
        public string CellNo { get; set; } = "";
        public string EmailAddress { get; set; } = "";       
        public string AddressLine1 { get; set; } = "";
        public string AddressLine2 { get; set; } = "";
        public string City { get; set; } = "";
        public string State { get; set; } = "";
        public string Country { get; set; } = "";
        public Int16 CountryCode { get; set; }
        public string Zipcode { get; set; } = "";
        public int UserRoleId { get; set; }
    }

    public class UserResponse
    {
        public Guid ApplicationId { get; set; }
        public string UserEmail { get; set; } = "";
        public string JWTToken { get; set; } = "";
        public string UserName { get; set; } = "";
    }
}
