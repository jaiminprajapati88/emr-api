using MedicalTourismBusinessLogic;
using MedicalTourismDataLayer.DataModels;

namespace TestApp;

internal class Program
{
    static void Main(string[] args)
    {
        ///*UserType */

        //UserTypeDBData userTypeDBData = new UserTypeDBData()
        //{
        //    IsActive = true,
        //    UserType = "Admin",
        //    UserTypeId = 5,
        //};

        //new UserTypeAppLogic().addUserType(userTypeDBData);

        //userTypeDBData = new UserTypeDBData()
        //{
        //    IsActive = true,
        //    UserType = "Admin",
        //    UserTypeId = 5,
        //};

        //var t = new UserTypeAppLogic().getUserType();

        Guid IdForTest = Guid.Parse("00711788-361d-4490-b9a6-020a9cec4b7f");

        RegisterUserRequest registerUser = new RegisterUserRequest()
        {
            AddressLine1 = "Address Line 1",
            AddressLine2 = "Address Line 2",
            CellNo = "+01-111-111-1111",
            City = "Test City",
            Country = "USA",
            CountryCode = 01,
            DateOfBirth = DateTime.Now,
            EmailAddress = "admin@site.com",
            EmailPassword = "Password",
            FirstName = "FirstName",
            Gender = "M",
            IsActive = true,
            LastName = "LastName",
            MiddleName = "MiddleName",
            RowAddStamp = DateTime.Now,
            RowAddUserId = IdForTest.ToString(),
            RowUpdateStamp = DateTime.Now,
            RowUpdateUserId = IdForTest.ToString(),
            State = "State",
            Title = "Mr",
            UserId = IdForTest,
            UserRoleId = 1,
            Zipcode = "12801"
        };

        new UserAppLogic().CreateUser(registerUser);
    }
}