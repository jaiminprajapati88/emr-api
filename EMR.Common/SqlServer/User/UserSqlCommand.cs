using EMR.Common.SqlServer.Organization;

namespace EMR.Common.SqlServer.User
{
    public static class UserSqlCommand
    {
        public static string GET_ALL_USER = "SELECT * FROM \"User\".\"UserDetails\"";
        public static string GET_USER_DETAIL = "SELECT * FROM \"User\".\"UserDetails\" WHERE \"EmailAddress\" = " + CommonParams.EmailAddress;
        public static string SEARCH_USERS = "SELECT UD.* FROM \"User\".\"UserDetails\" UD " +
                                            "INNER JOIN \"Organization\".\"OrganizationUsers\" OU on OU.\"UserDetailId\" = UD.\"UserDetailId\" " +
                                            "INNER JOIN \"Organization\".\"OrganizationDetails\" OD on OD.\"OrganizationDetailId\" = OU.\"OrganizationDetailId\" " +
                                            "WHERE" +
                                                   " OD.\"OrganizationDetailId\" = COALESCE (" + OrganizationSqlParams.OrganizationDetailId + ", OD.\"OrganizationDetailId\")" +
                                                   " AND \"FirstName\" LIKE COALESCE (" + UserSqlParams.FirstName + ", \"FirstName\")" +
                                                   " AND \"LastName\" LIKE COALESCE (" + UserSqlParams.LastName + ", \"LastName\")" +
                                                   " AND \"EmailAddress\" LIKE COALESCE (" + UserSqlParams.EmailAddress + ", \"EmailAddress\")" +
                                                   " AND \"UserRoleId\" = COALESCE (" + UserSqlParams.UserRoleId + ", \"UserRoleId\")";
        public static string RESET_PASSWORD = "UPDATE \"User\".\"UserDetails\" " +
                                              "SET \"PasswordHash\" = " + UserSqlParams.PasswordHash + ", " +
                                                   "\"PasswordSalt\" = " + UserSqlParams.PasswordSalt + "  " +
                                              "WHERE \"EmailAddress\" = " + CommonParams.EmailAddress;
        public static string ADD_USER = "INSERT INTO \"User\".\"UserDetails\" (\"Title\", \"FirstName\", \"MiddleName\", \"LastName\", \"Gender\", \"DateOfBirth\", \"CellNo\", \"EmailAddress\", \"PasswordHash\", \"PasswordSalt\", \"AddressLine1\", \"AddressLine2\", \"City\", \"StateCode\", \"CountryId\", \"PinCode\", \"UserRoleId\") " +
                                                 "VALUES (" + UserSqlParams.Title + ", " + UserSqlParams.FirstName + ", " + UserSqlParams.MiddleName + ", " + UserSqlParams.LastName + ", " + UserSqlParams.Gender + ", " + UserSqlParams.DateOfBirth + ", " + UserSqlParams.CellNo + ", " + UserSqlParams.EmailAddress + ", " + UserSqlParams.PasswordHash + 
                                                          ", " + UserSqlParams.PasswordSalt + ", " +  UserSqlParams.AddressLine1 + ", " + UserSqlParams.AddressLine2 + ", " + UserSqlParams.City + ", " + UserSqlParams.StateCode + ", " + UserSqlParams.CountryId + ", " + UserSqlParams.PinCode +
                                                          ", " + UserSqlParams.UserRoleId + "); SELECT CURRVAL('table_sequence');";
        public static string UPDATE_USER = "UPDATE \"Organization\".\"OrganizationDetails\" " +
                                                    "SET \"Title\" = " + UserSqlParams.Title + ", " +
                                                        "\"FirstName\" = " + UserSqlParams.FirstName + ", " +
                                                        "\"MiddleName\" = " + UserSqlParams.MiddleName + ", " +
                                                        "\"LastName\" = " + UserSqlParams.LastName + ", " +
                                                        "\"Gender\" = " + UserSqlParams.Gender + ", " +
                                                        "\"DateOfBirth\" = " + UserSqlParams.DateOfBirth + ", " +
                                                        "\"CellNo\" = " + UserSqlParams.CellNo + ", " +
                                                        "\"EmailAddress\" = " + UserSqlParams.EmailAddress + ", " +
                                                        "\"AddressLine1\" = " + UserSqlParams.AddressLine1 + ", " +
                                                        "\"AddressLine2\" = " + UserSqlParams.AddressLine2 + ", " +
                                                        "\"City\" = " + UserSqlParams.City + ", " +
                                                        "\"StateCode\" = " + UserSqlParams.StateCode + ", " +
                                                        "\"CountryId\" = " + UserSqlParams.CountryId + ", " +
                                                        "\"PinCode\" = " + UserSqlParams.PinCode + ", " +
                                                        "\"UserRoleId\" = " + UserSqlParams.UserRoleId + ", " +
                                                        "\"RowUpdateStamp\" = " + CommonParams.RowUpdateStamp + ", " +
                                                        "\"RowUpdateUserId\" = " + CommonParams.RowUpdateUserId +
                                                    " WHERE \"UserDetailId\" = " + UserSqlParams.UserDetailId + ";";
    }
}
