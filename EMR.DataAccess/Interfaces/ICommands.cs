using Npgsql;
using System.Data;
using System.Data.Common;

namespace EMR.DataAccess.Interfaces
{
    public interface ICommands
    {

        /// <summary>
        /// Executes a command that does not return a query
        /// </summary>
        /// <param name="commandText">Name of stored procedure to execute</param>
        /// <param name="parameters">NpgsqlParameter collection to use in executing</param>
        int ExecuteNonQuery(string commandText, params NpgsqlParameter[] parameters);

        /// <summary>
        /// Executes a command that does not return a query
        /// </summary>
        /// <param name="cmd">Output parameter that holds reference to the command object just executed</param>/// 
        /// <param name="commandText">Name of stored procedure to execute</param>
        /// <param name="parameters">NpgsqlParameter collection to use in executing</param>
        /// <returns>DbCommand containing the command executed</returns>
        int ExecuteNonQuery(out DbCommand cmd, string commandText, params NpgsqlParameter[] parameters);

        /// <summary>
        /// Executes a command that returns a single value
        /// </summary>
        /// <param name="commandText">Name of stored procedure to execute</param>
        /// <param name="parameters">NpgsqlParameter collection to use in executing</param>
        /// <returns>Object holding result of execution of database</returns>
        object ExecuteScalar(string commandText, params NpgsqlParameter[] parameters);

        /// <summary>
        /// Executes a command that returns a single value
        /// </summary>
        /// <param name="cmd">Output parameter that holds reference to the command object just executed</param>
        /// <param name="commandText">Name of stored procedure to execute</param>
        /// <param name="parameters">NpgsqlParameter collection to use in executing</param>
        /// <returns>Object holding result of execution of database</returns>
        object ExecuteScalar(out DbCommand cmd, string commandText, params NpgsqlParameter[] parameters);

        /// <summary>
        /// Executes a command and returns a data reader
        /// </summary>
        /// <param name="commandText">Name of stored procedure to execute</param>
        /// <param name="parameters">NpgsqlParameter collection to use in executing</param>
        /// <returns>SqlDataReader allowing access to results from command</returns>
        DbDataReader ExecuteReader(string commandText, params NpgsqlParameter[] parameters);

        /// <summary>
        /// Executes a command and returns a DataTable
        /// </summary>
        /// <param name="commandText">Name of stored procedure to execute</param>
        /// <param name="parameters">NpgsqlParameter collection to use in executing</param>
        /// <returns>DataTable populated with data from executing stored procedure</returns>
        DataTable ExecuteDataTable(string commandText, params NpgsqlParameter[] parameters);

        /// <summary>
        /// Executes a command and returns a DataTable
        /// </summary>
        /// <param name="cmd">Output parameter that holds reference to the command object just executed</param>
        /// <param name="commandText">Name of stored procedure to execute</param>
        /// <param name="parameters">SqlParameter collection to use in executing</param>
        /// <returns>DataTable populated with data from executing stored procedure</returns>
        DataTable ExecuteDataTable(out DbCommand cmd, string commandText, params NpgsqlParameter[] parameters);

        /// <summary>
        /// Executes a command and returns a DataTable
        /// </summary>
        /// <param name="commandText">Name of stored procedure to execute</param>
        /// <param name="parameters">SqlParameter collection to use in executing</param>
        /// <returns>DataTable populated with data from executing stored procedure</returns>
        DataSet ExecuteDataSet(string commandText, params NpgsqlParameter[] parameters);

        /// <summary>
        /// Executes a command and returns a DataTable
        /// </summary>
        /// <param name="cmd">Output parameter that holds reference to the command object just executed</param>
        /// <param name="commandText">Name of stored procedure to execute</param>
        /// <param name="parameters">SqlParameter collection to use in executing</param>
        /// <returns>DataTable populated with data from executing stored procedure</returns>
        DataSet ExecuteDataSet(out DbCommand cmd, string commandText, params NpgsqlParameter[] parameters);
    }
}