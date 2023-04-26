using MedicalTourismDataLayer;
using MedicalTourismDataLayer.DataModels;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalTourismBusinessLogic
{
    //public class UserTypeAppLogic
    //{
    //    public void addUserType(UserTypeDBData userTypeDBData)
    //    {
    //        string sql = "INSERT INTO \"user\".\"UserType\"(\r\n\t\"UserTypeId\", \"UserType\", \"RowAddUserId\", \"RowAddStamp\", \"RowUpdateUserId\", \"RowUpdateStamp\", \"IsActive\")\r\n\tVALUES (" + userTypeDBData.UserTypeId + ", '" + userTypeDBData.UserType + "', " + userTypeDBData.RowAddUserId + ", '" + userTypeDBData.RowAddStamp.ToString("yyyy-MM-dd HH:mm:ss") + "', " + userTypeDBData.RowUpdateUserId + ", '" + userTypeDBData.RowUpdateStamp.ToString("yyyy-MM-dd HH:mm:ss") + "', " + (userTypeDBData.IsActive ? "true" : "false") + ");";

    //        using (var command = new NpgsqlCommand(sql))
    //        {
    //            new AzurePostgresDataLayer().executeData(command, System.Data.CommandType.Text);
    //        }
    //    }

    //    public void updateUserType(UserTypeDBData userTypeDBData)
    //    {

    //    }

    //    public void deleteUserType(UserTypeDBData userTypeDBData)
    //    {

    //    }

    //    public List<UserTypeDBData> getUserType()
    //    {
    //        string sql = "select * from \"user\".\"UserType\";";

    //        using (var command = new NpgsqlCommand(sql))
    //        {
    //           return new AzurePostgresDataLayer().getData<UserTypeDBData>(sql);
    //        }
    //    }        
    //}
}
