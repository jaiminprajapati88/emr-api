using MedicalTourismDataLayer;
using System.Text;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using MedicalTourismDataLayer.DataModels;

namespace MedicalTourismBusinessLogic
{
    public class UserLoginBL : BaseAppLogic
    {
        public UserLoginDBData UserLogin(UserLoginAppInData userLoginAppInData)
        {
            if (!userLoginAppInData.UserEmail.IsValidEmail())
                throw new Exception("Email Exception", new Exception("Invalid User Email"));

            string sql = "SELECT \"UserId\", \"Title\", \"FirstName\", \"MiddleName\", \"LastName\", \"Gender\", \"DateOfBirth\", \"CellNo\", \"EmailAddress\", \"PasswordSalt\", \"PasswordHash\", \"AddressLine1\", \"AddressLine2\", \"City\", \"State\", \"Country\", \"CountryCode\", \"Zipcode\", \"UserRoleId\", \"IsActive\", \"RowAddStamp\", \"RowAddUserId\", \"RowUpdateStamp\", \"RowUpdateUserId\"\r\n\tFROM \"User\".\"UserDetails\" where \"EmailAddress\" = '" + userLoginAppInData.UserEmail + "'";

            var result = new AzurePostgresDataLayer().GetData<UserLoginDBData>(sql);

            if (result.Count == 1)
            {
                UserLoginDBData usr = result[0];

                if (userLoginAppInData.UserPassword.IsValidHash(usr.PasswordSalt, usr.PasswordHash))
                {
                    return usr;
                }
                else
                    throw new Exception("User Exception", new Exception("Invalid UserName Or Password"));
            }
            else
            {
                throw new Exception("User Exception", new Exception("Invalid UserName Or Password"));
            }
        }

        public UserLoginDBData UserResetPassword(UserResetPassword userLoginAppInData)
        {
            if (!userLoginAppInData.UserEmail.IsValidEmail())
                throw new Exception("Email Exception", new Exception("Invalid User Email"));

            string sql = "SELECT \"UserId\", \"Title\", \"FirstName\", \"MiddleName\", \"LastName\", \"Gender\", \"DateOfBirth\", \"CellNo\", \"EmailAddress\", \"PasswordSalt\", \"PasswordHash\", \"AddressLine1\", \"AddressLine2\", \"City\", \"State\", \"Country\", \"CountryCode\", \"Zipcode\", \"UserRoleId\", \"IsActive\", \"RowAddStamp\", \"RowAddUserId\", \"RowUpdateStamp\", \"RowUpdateUserId\"\r\n\tFROM \"User\".\"UserDetails\" where \"EmailAddress\" = '" + userLoginAppInData.UserEmail + "'";

            var result = new AzurePostgresDataLayer().GetData<UserLoginDBData>(sql);

            if (result.Count == 1)
            {
                UserLoginDBData usr = result[0];

                if (userLoginAppInData.UserOldPassword.IsValidHash(usr.PasswordSalt, usr.PasswordHash))
                {
                    byte[] PasswordHash = userLoginAppInData.UserNewPassword.GenerateHash(usr.PasswordSalt);

                    new UserAppLogic().UpdateUserCredentials(new UserLoginAppInData()
                    {
                        IsActive = true,
                        RowUpdateStamp = DateTime.Now,
                        RowUpdateUserId = userLoginAppInData.UserId.ToString(),
                        UserId = userLoginAppInData.UserId,
                        UserEmail = usr.EmailAddress,
                        UserPassword = userLoginAppInData.UserNewPassword
                    });

                    return usr;
                }
                else
                    throw new Exception("User Exception", new Exception("Invalid UserName Or Password"));
            }
            else
            {
                throw new Exception("User Exception", new Exception("Invalid UserName Or Password"));
            }
        }
    }
}