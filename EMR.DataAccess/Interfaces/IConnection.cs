using System.Data;

namespace EMR.DataAccess.Interfaces
{
    internal interface IConnection
    {
        string ConnectionString { get; }

        IDbConnection DatabaseConnection { get;}

        bool InTransaction { get; set; }

        void Close();

        void Open();
    }
}