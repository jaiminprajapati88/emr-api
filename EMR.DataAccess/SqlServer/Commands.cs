using System.Data;
using System.Data.Common;
using System.Xml;
using EMR.DataAccess.Interfaces;
using Npgsql;

namespace EMR.DataAccess.SqlServer
{
    public class Commands : ICommands
    {
        private readonly NpgsqlTransaction _currentTransaction;
        private readonly IConnection _currentConnection;
        private readonly int _commandTimeOut;

        internal Commands(IConnection currentConnection, IDbTransaction currentTransaction, int commandTimeOut)
        {
            if (currentConnection == null) throw new ArgumentNullException("currentConnection");

            this._currentTransaction = currentTransaction as NpgsqlTransaction;
            this._currentConnection = currentConnection;
            this._commandTimeOut = commandTimeOut;
        }

        /// <summary>
        /// Executes a command that does not return a query
        /// </summary>
        /// <param name="commandText">Name of stored procedure to execute</param>
        /// <param name="parameters">NpgsqlParameter collection to use in executing</param>
        public int ExecuteNonQuery(string commandText, params NpgsqlParameter[] parameters)
        {
            return Execute(x => x.ExecuteNonQuery(), commandText, parameters);
        }

        /// <summary>
        /// Executes a command that does not return a query
        /// </summary>
        /// <param name="cmd">Output parameter that holds reference to the command object just executed</param>/// 
        /// <param name="commandText">Name of stored procedure to execute</param>
        /// <param name="parameters">NpgsqlParameter collection to use in executing</param>
        /// <returns>DbCommand containing the command executed</returns>
        public int ExecuteNonQuery(out DbCommand cmd, string commandText, params NpgsqlParameter[] parameters)
        {
            return Execute(x => x.ExecuteNonQuery(), out cmd, commandText, parameters);
        }

        /// <summary>
        /// Executes a command that returns a single value
        /// </summary>
        /// <param name="commandText">Name of stored procedure to execute</param>
        /// <param name="parameters">NpgsqlParameter collection to use in executing</param>
        /// <returns>Object holding result of execution of database</returns>
        public object ExecuteScalar(string commandText, params NpgsqlParameter[] parameters)
        {
            return Execute(x => x.ExecuteScalar(), commandText, parameters);
        }

        /// <summary>
        /// Executes a command that returns a single value
        /// </summary>
        /// <param name="cmd">Output parameter that holds reference to the command object just executed</param>
        /// <param name="commandText">Name of stored procedure to execute</param>
        /// <param name="parameters">NpgsqlParameter collection to use in executing</param>
        /// <returns>Object holding result of execution of database</returns>
        public object ExecuteScalar(out DbCommand cmd, string commandText, params NpgsqlParameter[] parameters)
        {
            return Execute(x => x.ExecuteScalar(), out cmd, commandText, parameters);
        }

        /// <summary>
        /// Executes a command and returns a data reader
        /// </summary>
        /// <param name="commandText">Name of stored procedure to execute</param>
        /// <param name="parameters">NpgsqlParameter collection to use in executing</param>
        /// <returns>SqlDataReader allowing access to results from command</returns>
        public DbDataReader ExecuteReader(string commandText, params NpgsqlParameter[] parameters)
        {
            NpgsqlDataReader reader;

            _currentConnection.Open();

            using (NpgsqlCommand readerCommand = new NpgsqlCommand(commandText, (NpgsqlConnection)_currentConnection.DatabaseConnection))
            {
                readerCommand.Transaction = _currentTransaction;

                if (parameters != null && parameters.Length > 0)
                    readerCommand.Parameters.AddRange(parameters);

                reader = readerCommand.ExecuteReader(CommandBehavior.CloseConnection);
            }

            return reader;
        }

        /// <summary>
        /// Executes a command and returns a DataTable
        /// </summary>
        /// <param name="commandText">Name of stored procedure to execute</param>
        /// <param name="parameters">NpgsqlParameter collection to use in executing</param>
        /// <returns>DataTable populated with data from executing stored procedure</returns>
        public DataTable ExecuteDataTable(string commandText, params NpgsqlParameter[] parameters)
        {
            DbCommand cmd = null;
            DataTable results;
            try
            {
                results = ExecuteDataTable(out cmd, commandText, parameters);
            }
            finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
            }

            return results;
        }

        /// <summary>
        /// Executes a command and returns a DataTable
        /// </summary>
        /// <param name="cmd">Output parameter that holds reference to the command object just executed</param>
        /// <param name="commandText">Name of stored procedure to execute</param>
        /// <param name="parameters">SqlParameter collection to use in executing</param>
        /// <returns>DataTable populated with data from executing stored procedure</returns>
        public DataTable ExecuteDataTable(out DbCommand cmd, string commandText, params NpgsqlParameter[] parameters)
        {
            DataTable result = new DataTable();
            NpgsqlCommand cmdDataTable;

            try
            {
                _currentConnection.Open();
                cmdDataTable = BuildCommand(commandText, parameters);

                using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmdDataTable))
                {
                    da.Fill(result);
                }
            }
            finally
            {
                _currentConnection.Close();
            }

            cmd = cmdDataTable;
            return result;
        }

        /// <summary>
        /// Executes a command and returns a DataTable
        /// </summary>
        /// <param name="commandText">Name of stored procedure to execute</param>
        /// <param name="parameters">SqlParameter collection to use in executing</param>
        /// <returns>DataTable populated with data from executing stored procedure</returns>
        public DataSet ExecuteDataSet(string commandText, params NpgsqlParameter[] parameters)
        {
            DbCommand cmd;
            DataSet results = ExecuteDataSet(out cmd, commandText, parameters);
            cmd.Parameters.Clear();
            cmd.Dispose();

            return results;
        }

        /// <summary>
        /// Executes a command and returns a DataTable
        /// </summary>
        /// <param name="cmd">Output parameter that holds reference to the command object just executed</param>
        /// <param name="commandText">Name of stored procedure to execute</param>
        /// <param name="parameters">SqlParameter collection to use in executing</param>
        /// <returns>DataTable populated with data from executing stored procedure</returns>
        public DataSet ExecuteDataSet(out DbCommand cmd, string commandText, params NpgsqlParameter[] parameters)
        {
            NpgsqlCommand cmdDataSet;

            DataSet result = new DataSet();

            try
            {
                _currentConnection.Open();
                cmdDataSet = BuildCommand(commandText, parameters);

                using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmdDataSet))
                {
                    adapter.Fill(result);
                }
            }
            finally
            {
                _currentConnection.Close();
            }

            cmd = cmdDataSet;
            return result;
        }

        /// <summary>
        /// Builds a NpgsqlCommand to execute
        /// </summary>
        /// <param name="commandText">Name of stored procedure to execute</param>
        /// <param name="parameters">Param array of NpgsqlParameter objects to use with command</param>
        /// <returns>NpgsqlCommand object ready for use</returns>
        private NpgsqlCommand BuildCommand(string commandText, params NpgsqlParameter[] parameters)
        {
            NpgsqlCommand newCommand = new NpgsqlCommand(commandText, (NpgsqlConnection)_currentConnection.DatabaseConnection)
            {
                Transaction = _currentTransaction,
            };

            if (_commandTimeOut > 0)
            {
                newCommand.CommandTimeout = _commandTimeOut;
            }

            if (parameters != null)
                newCommand.Parameters.AddRange(parameters);

            return newCommand;
        }

        private T Execute<T>(Func<NpgsqlCommand, T> commandToExecute, string commandText, params NpgsqlParameter[] parameters)
        {
            DbCommand cmd = null;
            T result;

            try
            {
                result = Execute(commandToExecute, out cmd, commandText, parameters);
            }
            finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
            }

            return result;
        }

        private T Execute<T>(Func<NpgsqlCommand, T> commandToExecute, out DbCommand cmd, string commandText, params NpgsqlParameter[] parameters)
        {
            NpgsqlCommand toExecute;
            object result;

            try
            {
                _currentConnection.Open();
                toExecute = BuildCommand(commandText, parameters);
                result = commandToExecute(toExecute);

                cmd = toExecute;
            }
            finally
            {
                _currentConnection.Close();
            }

            return (T)result;
        }

    }
}