using System.Data.Common;
using System.Data;
using EMR.DataAccess.Interfaces;
using EMR.DataAccess.SqlServer;
using Npgsql;

namespace EMR.DataAccess.Core
{
    /// <summary>
    /// Concrete facade hiding actual database interaction
    /// </summary>
    public class SqlDataAccess : IDataAccess
    {
        private readonly IConnection _connection;
        private readonly ITransactionControl _transactionControl;
        private IParameterCreation? parameterFactory;

        /// <summary>
        /// Allows child classes to pass the connection string to be used for the
        /// connection during construction
        /// </summary>
        /// <param name="connectionString"></param>
        public SqlDataAccess(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString)) throw new ArgumentNullException("connectionString");

            _connection = new Connection(connectionString);
            _transactionControl = new TransactionControl(_connection);
        }

        public SqlDataAccess(IDbConnection databaseConnection)
        {
            _connection = new Connection(databaseConnection);
            _transactionControl = new TransactionControl(_connection);
        }

        /// <summary>
        /// Timeout setting to use when executing commands
        /// </summary>
        public int CommandTimeOut { get; set; }

       
        public IParameterCreation ParameterFactory
        {
            get
            {
                if (parameterFactory == null)
                    parameterFactory = new SqlParameterFactory();

                return parameterFactory;
            }
            set { parameterFactory = value; }
        }

        /// <summary>
        /// Provides access to the Transaction control object
        /// </summary>
        public ITransactionControl Transactions
        {
            get { return _transactionControl; }
        }


        /// <summary>
        /// Executes a command that does not return a query
        /// </summary>
        /// <param name="cmd">Output parameter that holds reference to the command object just executed</param>/// 
        /// <param name="commandText">command text to execute</param>
        /// <param name="parameters">NpgsqlParameter collection to use in executing</param>
        /// <returns>DbCommand containing the command executed</returns>
        public int ExecuteNonQuery(out DbCommand cmd, string commandText, params NpgsqlParameter[] parameters)
        {
            return CreateCommand().ExecuteNonQuery(out cmd, commandText, parameters);
        }

        /// <summary>
        /// Executes a command that does not return a query
        /// </summary>
        /// <param name="commandText">command text to execute</param>
        /// <param name="parameters">NpgsqlParameter collection to use in executing</param>
        public int ExecuteNonQuery(string commandText, params NpgsqlParameter[] parameters)
        {
            return RunCommand(c => c.ExecuteNonQuery(commandText, parameters));
        }

        /// <summary>
        /// Executes a command that returns a single value
        /// </summary>
        /// <param name="commandText">command text to execute</param>
        /// <param name="parameters">NpgsqlParameter collection to use in executing</param>
        /// <returns>Object holding result of execution of database</returns>
        public object ExecuteScalar(string commandText, params NpgsqlParameter[] parameters)
        {
            return RunCommand(c => c.ExecuteScalar(commandText,parameters));
        }

        /// <summary>
        /// Executes a command that returns a single value
        /// </summary>
        /// <param name="cmd">Output parameter that holds reference to the command object just executed</param>
        /// <param name="commandText">command text to execute</param>
        /// <param name="parameters">NpgsqlParameter collection to use in executing</param>
        /// <returns>Object holding result of execution of database</returns>
        public object ExecuteScalar(out DbCommand cmd, string commandText, params NpgsqlParameter[] parameters)
        {
            return  CreateCommand().ExecuteScalar(out cmd, commandText, parameters);
        }

        /// <summary>
        /// Executes a command and returns a data reader
        /// </summary>
        /// <param name="commandText">command text to execute</param>
        /// <param name="parameters">NpgsqlParameter collection to use in executing</param>
        /// <returns>SqlDataReader allowing access to results from command</returns>
        public DbDataReader ExecuteReader(string commandText, params NpgsqlParameter[] parameters)
        {
            return CreateCommand().ExecuteReader(commandText, parameters);
        }


        /// <summary>
        /// Executes a command and returns a DataTable
        /// </summary>
        /// <param name="commandText">command text to execute</param>
        /// <param name="parameters">NpgsqlParameter collection to use in executing</param>
        /// <returns>DataTable populated with data from executing command</returns>
        public DataTable ExecuteDataTable(string commandText, params NpgsqlParameter[] parameters)
        {
            return RunCommand(c => c.ExecuteDataTable(commandText, parameters));
        }

        /// <summary>
        /// Executes a command and returns a DataTable
        /// </summary>
        /// <param name="cmd">Output parameter that holds reference to the command object just executed</param>
        /// <param name="commandText">command text to execute</param>
        /// <param name="parameters">SqlParameter collection to use in executing</param>
        /// <returns>DataTable populated with data from executing command</returns>
        public DataTable ExecuteDataTable(out DbCommand cmd, string commandText, params NpgsqlParameter[] parameters)
        {
            return CreateCommand().ExecuteDataTable(out cmd, commandText, parameters);
        }

        /// <summary>
        /// Executes a command and returns a DataTable
        /// </summary>
        /// <param name="commandText">command text to execute</param>
        /// <param name="parameters">SqlParameter collection to use in executing</param>
        /// <returns>DataTable populated with data from executing command</returns>
        public DataSet ExecuteDataSet(string commandText, params NpgsqlParameter[] parameters)
        {
            return RunCommand(c => c.ExecuteDataSet(commandText, parameters));
        }

        /// <summary>
        /// Executes a command and returns a DataTable
        /// </summary>
        /// <param name="cmd">Output parameter that holds reference to the command object just executed</param>
        /// <param name="commandText">command text to execute</param>
        /// <param name="parameters">SqlParameter collection to use in executing</param>
        /// <returns>DataTable populated with data from executing command</returns>
        public DataSet ExecuteDataSet(out DbCommand cmd, string commandText, params NpgsqlParameter[] parameters)
        {
            return CreateCommand().ExecuteDataSet(out cmd, commandText, parameters);
        }

        private Commands CreateCommand()
        {
            return new Commands(_connection, _transactionControl.CurrentTransaction, CommandTimeOut);
        }

        private T RunCommand<T>(Func<Commands, T> toRun)
        {
            return toRun(CreateCommand());
        }
    }
}
