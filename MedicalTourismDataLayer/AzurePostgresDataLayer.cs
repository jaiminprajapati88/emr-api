using MedicalTourismDataLayer.DataModels;
using Npgsql;
using System.Data;

namespace MedicalTourismDataLayer
{
    public class AzurePostgresDataLayer
    {
        // Obtain connection string information from the portal
        //
        private static string Host = "emr-database.cusm6pt4gbpk.us-east-1.rds.amazonaws.com";
        private static string User = "emr_admin";
        private static string DBname = "emr";
        private static string Password = "emr#admindb";
        private static string Port = "5432";

        private string getConnectionString()
        {
            return String.Format(
                    "Server={0};Username={1};Database={2};Port={3};Password={4};SSLMode=Prefer",
                    Host,
                    User,
                    DBname,
                    Port,
                    Password);
        }

        public List<T> GetData<T>(string sql)
        {
            try
            {
                DataSet dataSet = new DataSet();

                using (var conn = new NpgsqlConnection(getConnectionString()))

                {
                    Console.Out.WriteLine("Opening connection");
                    conn.Open();

                    NpgsqlCommand command = new NpgsqlCommand(sql, conn);

                    NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);

                    adapter.Fill(dataSet, "TestTable");

                    List<T> lst = new List<T>();

                    if (dataSet.Tables["TestTable"].Rows.Count > 0)
                        lst = dataSet.Tables["TestTable"].ToListof<T>();


                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void ExecuteData(NpgsqlCommand command, CommandType commandType)
        {
            try
            {
                using (var conn = new NpgsqlConnection(getConnectionString()))
                {
                    Console.Out.WriteLine("Opening connection");
                    conn.Open();

                    command.CommandType = commandType;
                    command.Connection = conn;

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}