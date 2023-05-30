using Npgsql;
using NpgsqlTypes;
using System.Data;

namespace EMR.DataAccess.Interfaces
{
    public interface IParameterCreation
    {
        /// <summary>
        /// Creates a SqlParameter
        /// </summary>
        /// <param name="paramName">Name of the parameter</param>
        /// <param name="paramType">The NpgsqlDbType of the parameter</param>
        /// <param name="value">The value for the parameter</param>
        /// <param name="direction">Indicates whether the parameter is input-only, output-only, bidirectional, or a stored procedure return value parameter.</param>
        /// <returns>a configured SqlParameter object</returns>
        NpgsqlParameter Create(string paramName, NpgsqlDbType paramType, object value, ParameterDirection direction);

        /// <summary>
        /// Creates a SqlParameter
        /// </summary>
        /// <param name="paramName">Name of the parameter</param>
        /// <param name="paramType">The NpgsqlDbType for the parameter</param>
        /// <param name="direction">Indicates whether the parameter is input-only, output-only, bidirectional, or a stored procedure return value parameter.</param>
        /// <returns>a configured SqlParameter object</returns>
        NpgsqlParameter Create(string paramName, NpgsqlDbType paramType, ParameterDirection direction);

        /// <summary>
        /// Creates a SqlParameter
        /// </summary>
        /// <param name="paramName">Name of the parameter</param>
        /// <param name="paramType">The SqlDBType for the parameter</param>
        /// <param name="value">The value for the parameter</param>
        /// <returns>a configured SqlParameter object</returns>
        NpgsqlParameter Create(string paramName, NpgsqlDbType paramType, object value);

        /// <summary>
        /// Creates a SqlParameter
        /// </summary>
        /// <param name="paramName">Name of parameter</param>
        /// <param name="paramType">The NpgsqlDbType for the parameter</param>
        /// <param name="value">The value of the parameter</param>
        /// <param name="size">The maximum size, in bytes, of the data within the column.</param>
        /// <returns>a configured SqlParameter object</returns>
        NpgsqlParameter Create(string paramName, NpgsqlDbType paramType, object value, int size);

        /// <summary>
        /// Creates a SqlParameter
        /// </summary>
        /// <param name="paramName">Name of parameter</param>
        /// <param name="paramType">The NpgsqlDbType for the parameter</param>
        /// <param name="value">The value for the parameter</param>
        /// <param name="size">The maximum size, in bytes, of the data within the column.</param>
        /// <param name="precision">the maximum number of digits used to represent the Value property.</param>
        /// <param name="direction">Indicates whether the parameter is input-only, output-only, bidirectional, or a stored procedure return value parameter.</param>
        /// <returns>a configured SqlParameter object</returns>
        NpgsqlParameter Create(string paramName, NpgsqlDbType paramType, object value, int size, byte precision, ParameterDirection direction);

        /// <summary>
        /// Creates a SqlParameter
        /// </summary>
        /// <param name="paramName">Name of parameter</param>
        /// <param name="paramType">The NpgsqlDbType for the parameter</param>
        /// <param name="value">The value for the parameter</param>
        /// <param name="size">The maximum size, in bytes, of the data within the column.</param>
        /// <param name="precision">the maximum number of digits used to represent the Value property.</param>
        /// <returns>a configured SqlParameter object</returns>
        NpgsqlParameter Create(string paramName, NpgsqlDbType paramType, object value, int size, byte precision);

        /// <summary>
        /// Creates a SqlParameter
        /// </summary>
        /// <param name="paramName">Name of parameter</param>
        /// <param name="paramType">The NpgsqlDbType for the parameter</param>
        /// <param name="value">The value for the parameter</param>
        /// <param name="size">The maximum size, in bytes, of the data within the column.</param>
        /// <param name="direction">Indicates whether the parameter is input-only, output-only, bidirectional, or a stored procedure return value parameter.</param>>
        /// <returns>a configured SqlParameter object</returns>
        NpgsqlParameter Create(string paramName, NpgsqlDbType paramType, object value, int size, ParameterDirection direction);
    }
}
