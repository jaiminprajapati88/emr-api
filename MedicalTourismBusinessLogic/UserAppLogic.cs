using MedicalTourismDataLayer;
using MedicalTourismDataLayer.DataModels;
using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MedicalTourismBusinessLogic
{
    public class UserAppLogic : BaseAppLogic
    {
        public RegisterUserRequest2 CreateUser(RegisterUserRequest registerUser)
        {
            if (!registerUser.EmailAddress.IsValidEmail())
                throw new Exception("Email Exception", new Exception("Invalid User Email"));

            int PasswordSalt = GenerateSalt();
            byte[] PasswordHash = registerUser.EmailPassword.GenerateHash(PasswordSalt);


            Guid UserId = Guid.NewGuid();

            string JWTToken = "";// get JWT Token

            UserLoginDBData usr = new UserLoginDBData()
            {
                EmailAddress = registerUser.EmailAddress,
                IsActive = true,
                JWTToken = JWTToken,
                PasswordHash = PasswordHash,
                PasswordSalt = PasswordSalt,
                UserId = UserId,
                AddressLine1 = registerUser.AddressLine1,
                AddressLine2 = registerUser.AddressLine2,
                CellNo = registerUser.CellNo,
                City = registerUser.City,
                Country = registerUser.Country,
                CountryCode = registerUser.CountryCode,
                DateOfBirth = registerUser.DateOfBirth,
                FirstName = registerUser.FirstName,
                Gender = registerUser.Gender,
                LastName = registerUser.LastName,
                MiddleName = registerUser.MiddleName,
                RowAddStamp = registerUser.RowAddStamp,
                RowAddUserId = registerUser.RowAddUserId,
                RowUpdateStamp = registerUser.RowUpdateStamp,
                RowUpdateUserId = registerUser.RowUpdateUserId,
                State = registerUser.State,
                Title = registerUser.Title,
                UserRoleId = registerUser.UserRoleId,
                Zipcode = registerUser.Zipcode
            };

            string sql = "INSERT INTO \"User\".\"UserDetails\"(\r\n\t\"UserId\", \"Title\", \"FirstName\", \"MiddleName\", \"LastName\", \"Gender\", \"DateOfBirth\", \"CellNo\", \"EmailAddress\", \"PasswordSalt\", \"PasswordHash\", \"AddressLine1\", \"AddressLine2\", \"City\", \"State\", \"Country\", \"CountryCode\", \"Zipcode\", \"UserRoleId\", \"IsActive\", \"RowAddStamp\", \"RowAddUserId\", \"RowUpdateStamp\", \"RowUpdateUserId\")";
            sql += "VALUES (@UserId,@Title,@FirstName,@MiddleName,@LastName,@Gender,@DateOfBirth,@CellNo,@EmailAddress,@PasswordSalt,@PasswordHash,@AddressLine1,@AddressLine2,@City,@State,@Country,@CountryCode,@Zipcode,@UserRoleId,@IsActive,@RowAddStamp,@RowAddUserId,@RowUpdateStamp,@RowUpdateUserId)";

            using (var cmd = new NpgsqlCommand(sql))
            {
                cmd.Parameters.Add(new NpgsqlParameter<Guid>("UserId", NpgsqlTypes.NpgsqlDbType.Uuid) { TypedValue = usr.UserId }); //@UserId
                cmd.Parameters.Add(new NpgsqlParameter<string>("Title", NpgsqlTypes.NpgsqlDbType.Text) { TypedValue = usr.Title }); //@Title

                cmd.Parameters.Add(new NpgsqlParameter<string>("FirstName", NpgsqlTypes.NpgsqlDbType.Text) { TypedValue = usr.FirstName }); //@FirstName
                cmd.Parameters.Add(new NpgsqlParameter<string>("MiddleName", NpgsqlTypes.NpgsqlDbType.Text) { TypedValue = usr.MiddleName }); //@MiddleName
                cmd.Parameters.Add(new NpgsqlParameter<string>("LastName", NpgsqlTypes.NpgsqlDbType.Text) { TypedValue = usr.LastName }); //@LastName

                cmd.Parameters.Add(new NpgsqlParameter<string>("Gender", NpgsqlTypes.NpgsqlDbType.Text) { TypedValue = usr.Gender }); //@Gender
                cmd.Parameters.Add(new NpgsqlParameter<DateTime>("DateOfBirth", NpgsqlTypes.NpgsqlDbType.Timestamp) { TypedValue = usr.DateOfBirth }); //@DateOfBirth
                cmd.Parameters.Add(new NpgsqlParameter<string>("CellNo", NpgsqlTypes.NpgsqlDbType.Text) { TypedValue = usr.CellNo }); //@CellNo
                cmd.Parameters.Add(new NpgsqlParameter<string>("EmailAddress", NpgsqlTypes.NpgsqlDbType.Text) { TypedValue = usr.EmailAddress }); //@UserId

                cmd.Parameters.Add(new NpgsqlParameter<int>("PasswordSalt", NpgsqlTypes.NpgsqlDbType.Integer) { TypedValue = PasswordSalt }); //@PasswordSalt
                cmd.Parameters.Add(new NpgsqlParameter<byte[]>("PasswordHash", NpgsqlTypes.NpgsqlDbType.Bytea) { TypedValue = PasswordHash }); //@PasswordHash

                cmd.Parameters.Add(new NpgsqlParameter<string>("AddressLine1", NpgsqlTypes.NpgsqlDbType.Text) { TypedValue = usr.AddressLine1 }); //@AddressLine1
                cmd.Parameters.Add(new NpgsqlParameter<string>("AddressLine2", NpgsqlTypes.NpgsqlDbType.Text) { TypedValue = usr.AddressLine2 }); //@AddressLine2

                cmd.Parameters.Add(new NpgsqlParameter<string>("City", NpgsqlTypes.NpgsqlDbType.Text) { TypedValue = usr.City }); //@City                                                                                                                              //
                cmd.Parameters.Add(new NpgsqlParameter<string>("State", NpgsqlTypes.NpgsqlDbType.Text) { TypedValue = usr.State }); //@State
                cmd.Parameters.Add(new NpgsqlParameter<string>("Country", NpgsqlTypes.NpgsqlDbType.Text) { TypedValue = usr.Country }); //@Country

                cmd.Parameters.Add(new NpgsqlParameter<short>("CountryCode", NpgsqlTypes.NpgsqlDbType.Smallint) { TypedValue = usr.CountryCode }); //@CountryCode
                cmd.Parameters.Add(new NpgsqlParameter<string>("Zipcode", NpgsqlTypes.NpgsqlDbType.Text) { TypedValue = usr.Zipcode }); //@Zipcode
                cmd.Parameters.Add(new NpgsqlParameter<int>("UserRoleId", NpgsqlTypes.NpgsqlDbType.Integer) { TypedValue = usr.UserRoleId }); //@UserRoleId

                cmd.Parameters.Add(new NpgsqlParameter<bool>("IsActive", NpgsqlTypes.NpgsqlDbType.Boolean) { TypedValue = usr.IsActive }); //@IsActive.

                cmd.Parameters.Add(new NpgsqlParameter<DateTime>("RowAddStamp", NpgsqlTypes.NpgsqlDbType.Timestamp) { TypedValue = usr.RowAddStamp }); //@RowAddStamp
                cmd.Parameters.Add(new NpgsqlParameter<string>("RowAddUserId", NpgsqlTypes.NpgsqlDbType.Text) { TypedValue = usr.RowAddUserId }); //@RowAddUserId

                cmd.Parameters.Add(new NpgsqlParameter<DateTime>("RowUpdateStamp", NpgsqlTypes.NpgsqlDbType.Timestamp) { TypedValue = usr.RowUpdateStamp }); //@RowUpdateStamp
                cmd.Parameters.Add(new NpgsqlParameter<string>("RowUpdateUserId", NpgsqlTypes.NpgsqlDbType.Text) { TypedValue = usr.RowUpdateUserId }); //@RowUpdateUserId

                new AzurePostgresDataLayer().ExecuteData(cmd, System.Data.CommandType.Text);
            };

            sql = "select * from \"User\".\"UserDetails\" where \"IsActive\" =  true and \"UserId\" = '" + UserId + "')";

            var RegisterUserRequest = new List<RegisterUserRequest2>();

            using (var command = new NpgsqlCommand(sql))
            {
                RegisterUserRequest = new AzurePostgresDataLayer().GetData<RegisterUserRequest2>(sql);
            }

            return RegisterUserRequest.First();
        }

        public RegisterUserRequest2 UpdateUser(RegisterUserRequest registerUser)
        {
            if (!registerUser.EmailAddress.IsValidEmail())
                throw new Exception("Email Exception", new Exception("Invalid User Email"));


            UserLoginDBData usr = new UserLoginDBData()
            {
                EmailAddress = registerUser.EmailAddress,
                IsActive = registerUser.IsActive,
                AddressLine1 = registerUser.AddressLine1,
                AddressLine2 = registerUser.AddressLine2,
                CellNo = registerUser.CellNo,
                City = registerUser.City,
                Country = registerUser.Country,
                CountryCode = registerUser.CountryCode,
                DateOfBirth = registerUser.DateOfBirth,
                FirstName = registerUser.FirstName,
                Gender = registerUser.Gender,
                LastName = registerUser.LastName,
                MiddleName = registerUser.MiddleName,
                RowUpdateStamp = registerUser.RowUpdateStamp,
                RowUpdateUserId = registerUser.RowUpdateUserId,
                State = registerUser.State,
                Title = registerUser.Title,
                UserRoleId = registerUser.UserRoleId,
                Zipcode = registerUser.Zipcode,
                UserId = registerUser.UserId,
            };

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("UPDATE \"User\".\"UserDetails\" SET  \"Title\"=@Title, \"FirstName\"=@FirstName, \"MiddleName\"=@MiddleName, \"LastName\"=@LastName, \"Gender\"=@Gender, \"DateOfBirth\"=@DateOfBirth, \"CellNo\"=@CellNo, \"EmailAddress\"=@EmailAddress, \"AddressLine1\"=@AddressLine1, \"AddressLine2\"=@AddressLine2, \"City\"=@City, \"State\"=@State, \"Country\"=@Country, \"CountryCode\"=@CountryCode, \"Zipcode\"=@Zipcode, \"UserRoleId\"=@UserRoleId, \"IsActive\"=@IsActive, \"RowAddStamp\"=@RowAddStamp, \"RowAddUserId\"=@RowAddUserId, \"RowUpdateStamp\"=@RowUpdateStamp, \"RowUpdateUserId\"=@RowUpdateUserId\r\n\tWHERE \"UserId\"=@UserId;");

            using (var cmd = new NpgsqlCommand(sb.ToString()))
            {
                cmd.Parameters.Add(new NpgsqlParameter<Guid>("UserId", NpgsqlTypes.NpgsqlDbType.Uuid) { TypedValue = usr.UserId }); //@UserId
                cmd.Parameters.Add(new NpgsqlParameter<string>("Title", NpgsqlTypes.NpgsqlDbType.Text) { TypedValue = usr.Title }); //@Title

                cmd.Parameters.Add(new NpgsqlParameter<string>("FirstName", NpgsqlTypes.NpgsqlDbType.Text) { TypedValue = usr.FirstName }); //@FirstName
                cmd.Parameters.Add(new NpgsqlParameter<string>("MiddleName", NpgsqlTypes.NpgsqlDbType.Text) { TypedValue = usr.MiddleName }); //@MiddleName
                cmd.Parameters.Add(new NpgsqlParameter<string>("LastName", NpgsqlTypes.NpgsqlDbType.Text) { TypedValue = usr.LastName }); //@LastName

                cmd.Parameters.Add(new NpgsqlParameter<string>("Gender", NpgsqlTypes.NpgsqlDbType.Text) { TypedValue = usr.Gender }); //@Gender
                cmd.Parameters.Add(new NpgsqlParameter<DateTime>("DateOfBirth", NpgsqlTypes.NpgsqlDbType.Timestamp) { TypedValue = usr.DateOfBirth }); //@DateOfBirth
                cmd.Parameters.Add(new NpgsqlParameter<string>("CellNo", NpgsqlTypes.NpgsqlDbType.Text) { TypedValue = usr.CellNo }); //@CellNo
                cmd.Parameters.Add(new NpgsqlParameter<string>("EmailAddress", NpgsqlTypes.NpgsqlDbType.Text) { TypedValue = usr.EmailAddress }); //@UserId

                cmd.Parameters.Add(new NpgsqlParameter<string>("AddressLine1", NpgsqlTypes.NpgsqlDbType.Text) { TypedValue = usr.AddressLine1 }); //@AddressLine1
                cmd.Parameters.Add(new NpgsqlParameter<string>("AddressLine2", NpgsqlTypes.NpgsqlDbType.Text) { TypedValue = usr.AddressLine2 }); //@AddressLine2

                cmd.Parameters.Add(new NpgsqlParameter<string>("City", NpgsqlTypes.NpgsqlDbType.Text) { TypedValue = usr.City }); //@City                                                                                                                              //
                cmd.Parameters.Add(new NpgsqlParameter<string>("State", NpgsqlTypes.NpgsqlDbType.Text) { TypedValue = usr.State }); //@State
                cmd.Parameters.Add(new NpgsqlParameter<string>("Country", NpgsqlTypes.NpgsqlDbType.Text) { TypedValue = usr.Country }); //@Country

                cmd.Parameters.Add(new NpgsqlParameter<short>("CountryCode", NpgsqlTypes.NpgsqlDbType.Smallint) { TypedValue = usr.CountryCode }); //@CountryCode
                cmd.Parameters.Add(new NpgsqlParameter<string>("Zipcode", NpgsqlTypes.NpgsqlDbType.Text) { TypedValue = usr.Zipcode }); //@Zipcode
                cmd.Parameters.Add(new NpgsqlParameter<int>("UserRoleId", NpgsqlTypes.NpgsqlDbType.Integer) { TypedValue = usr.UserRoleId }); //@UserRoleId

                cmd.Parameters.Add(new NpgsqlParameter<bool>("IsActive", NpgsqlTypes.NpgsqlDbType.Boolean) { TypedValue = usr.IsActive }); //@IsActive.

                cmd.Parameters.Add(new NpgsqlParameter<DateTime>("RowUpdateStamp", NpgsqlTypes.NpgsqlDbType.Timestamp) { TypedValue = usr.RowUpdateStamp }); //@RowUpdateStamp
                cmd.Parameters.Add(new NpgsqlParameter<string>("RowUpdateUserId", NpgsqlTypes.NpgsqlDbType.Text) { TypedValue = usr.RowUpdateUserId }); //@RowUpdateUserId

                new AzurePostgresDataLayer().ExecuteData(cmd, System.Data.CommandType.Text);
            };

            string sql = "select * from \"User\".\"UserDetails\" where \"IsActive\" =  true and \"UserId\" = '" + usr.UserId + "')";

            var RegisterUserRequest = new List<RegisterUserRequest2>();

            using (var command = new NpgsqlCommand(sql))
            {
                RegisterUserRequest = new AzurePostgresDataLayer().GetData<RegisterUserRequest2>(sql);
            }

            return RegisterUserRequest.First();
        }

        public RegisterUserRequest2 UpdateUserCredentials(UserLoginAppInData tmpUsr)
        {
            string sql = "select * from \"User\".\"UserDetails\" where \"IsActive\" =  true and \"UserId\" = '" + tmpUsr.UserId + "')";

            var RegisterUserRequest = new List<UserCredentialsDBData>();

            using (var command = new NpgsqlCommand(sql))
            {
                RegisterUserRequest = new AzurePostgresDataLayer().GetData<UserCredentialsDBData>(sql);
            }

            var _usr = RegisterUserRequest.First();

            int PasswordSalt = _usr.PasswordSalt;
            byte[] PasswordHash = tmpUsr.UserPassword.GenerateHash(PasswordSalt);

            UserLoginDBData usr = new UserLoginDBData()
            {
                IsActive = true,
                UserId = tmpUsr.UserId,
                PasswordSalt = PasswordSalt,
                PasswordHash = PasswordHash,
                RowUpdateStamp = tmpUsr.RowUpdateStamp,
                RowUpdateUserId = tmpUsr.RowUpdateUserId,
            };

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("UPDATE \"User\".\"UserDetails\" SET \"PasswordSalt\"=@PasswordSalt, \"PasswordHash\"=@PasswordHash,  \"IsActive\"=@IsActive, \"RowUpdateStamp\"=@RowUpdateStamp, \"RowUpdateUserId\"=@RowUpdateUserId\r\n\tWHERE \"UserId\"=@UserId;");

            using (var cmd = new NpgsqlCommand(sb.ToString()))
            {
                cmd.Parameters.Add(new NpgsqlParameter<Guid>("UserId", NpgsqlTypes.NpgsqlDbType.Uuid) { TypedValue = usr.UserId }); //@UserId
                cmd.Parameters.Add(new NpgsqlParameter<bool>("IsActive", NpgsqlTypes.NpgsqlDbType.Boolean) { TypedValue = usr.IsActive }); //@IsActive.

                cmd.Parameters.Add(new NpgsqlParameter<DateTime>("RowUpdateStamp", NpgsqlTypes.NpgsqlDbType.Timestamp) { TypedValue = usr.RowUpdateStamp }); //@RowUpdateStamp
                cmd.Parameters.Add(new NpgsqlParameter<string>("RowUpdateUserId", NpgsqlTypes.NpgsqlDbType.Text) { TypedValue = usr.RowUpdateUserId }); //@RowUpdateUserId
                cmd.Parameters.Add(new NpgsqlParameter<int>("PasswordSalt", NpgsqlTypes.NpgsqlDbType.Integer) { TypedValue = PasswordSalt }); //@PasswordSalt
                cmd.Parameters.Add(new NpgsqlParameter<byte[]>("PasswordHash", NpgsqlTypes.NpgsqlDbType.Bytea) { TypedValue = PasswordHash }); //@PasswordHash

                new AzurePostgresDataLayer().ExecuteData(cmd, System.Data.CommandType.Text);
            };

            sql = "select * from \"User\".\"UserDetails\" where \"IsActive\" =  true and \"UserId\" = '" + usr.UserId + "')";

            var RegisterUserRequest2 = new List<RegisterUserRequest2>();

            using (var command = new NpgsqlCommand(sql))
            {
                RegisterUserRequest2 = new AzurePostgresDataLayer().GetData<RegisterUserRequest2>(sql);
            }

            return RegisterUserRequest2.First();
        }

        public RegisterUserRequest2 DeleteUser(RegisterUserRequest registerUser)
        {
            UserLoginDBData usr = new UserLoginDBData()
            {
                IsActive = registerUser.IsActive,
                UserId = registerUser.UserId,
                RowUpdateStamp = registerUser.RowUpdateStamp,
                RowUpdateUserId = registerUser.RowUpdateUserId,
            };

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("UPDATE \"User\".\"UserDetails\" SET \"IsActive\"=@IsActive, \"RowUpdateStamp\"=@RowUpdateStamp, \"RowUpdateUserId\"=@RowUpdateUserId\r\n\tWHERE \"UserId\"=@UserId;");


            using (var cmd = new NpgsqlCommand(sb.ToString()))
            {
                cmd.Parameters.Add(new NpgsqlParameter<Guid>("UserId", NpgsqlTypes.NpgsqlDbType.Uuid) { TypedValue = usr.UserId }); //@UserId               
                cmd.Parameters.Add(new NpgsqlParameter<bool>("IsActive", NpgsqlTypes.NpgsqlDbType.Boolean) { TypedValue = usr.IsActive }); //@IsActive.
                cmd.Parameters.Add(new NpgsqlParameter<DateTime>("RowUpdateStamp", NpgsqlTypes.NpgsqlDbType.Timestamp) { TypedValue = usr.RowUpdateStamp }); //@RowUpdateStamp
                cmd.Parameters.Add(new NpgsqlParameter<string>("RowUpdateUserId", NpgsqlTypes.NpgsqlDbType.Text) { TypedValue = usr.RowUpdateUserId }); //@RowUpdateUserId

                new AzurePostgresDataLayer().ExecuteData(cmd, System.Data.CommandType.Text);
            };


            using (var command = new NpgsqlCommand(sb.ToString()))
            {
                new AzurePostgresDataLayer().ExecuteData(command, System.Data.CommandType.Text);
            }

            string sql = "select * from \"User\".\"UserDetails\" where \"IsActive\" =  true and \"UserId\" = '" + usr.UserId + "')";

            var RegisterUserRequest = new List<RegisterUserRequest2>();

            using (var command = new NpgsqlCommand(sql))
            {
                RegisterUserRequest = new AzurePostgresDataLayer().GetData<RegisterUserRequest2>(sql);
            }

            return RegisterUserRequest.First();
        }

        public List<RegisterUserRequest2> GetUsers()
        {
            string sql = "select * from \"User\".\"UserDetails\" where \"IsActive\" =  true";

            var RegisterUserRequest = new List<RegisterUserRequest2>();

            using (var command = new NpgsqlCommand(sql))
            {
                RegisterUserRequest = new AzurePostgresDataLayer().GetData<RegisterUserRequest2>(sql);
            }

            return RegisterUserRequest;
        }

        public List<RegisterUserRequest2> GetAllUser()
        {
            string sql = "select * from \"User\".\"UserDetails\"";

            var RegisterUserRequest = new List<RegisterUserRequest2>();

            using (var command = new NpgsqlCommand(sql))
            {
                RegisterUserRequest = new AzurePostgresDataLayer().GetData<RegisterUserRequest2>(sql);
            }

            return RegisterUserRequest;
        }
    }
}
