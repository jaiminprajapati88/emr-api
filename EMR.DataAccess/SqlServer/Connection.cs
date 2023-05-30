using System.Data;
using Npgsql;
using EMR.DataAccess.Interfaces;

namespace EMR.DataAccess.SqlServer
{
    internal class Connection : IConnection
    {

        public string ConnectionString { get; private set; }

        public IDbConnection DatabaseConnection { get; private set; }
        public bool InTransaction { get; set; }

        internal Connection(string connectionString)
        {
            ConnectionString = connectionString;
        }

        internal Connection(IDbConnection databaseConnection)
        {
            DatabaseConnection = databaseConnection;
        }

        /// <summary>
        /// Determines if the connection is currently in a transaction and
        /// close the connection if not.
        /// </summary>
        public void Close()
        {
            if (!InTransaction)
            {
                DatabaseConnection.Close();
                DatabaseConnection.Dispose();
            }
        }

        public void Open()
        {
            if (DatabaseConnection == null || DatabaseConnection.State != ConnectionState.Open)
            {
                DatabaseConnection = new NpgsqlConnection(ConnectionString);
                DatabaseConnection.Open();
            }
        }
    }
}