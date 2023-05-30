using System.Data;
using Npgsql;
using NpgsqlTypes;

namespace EMR.Repository.Core
{
    public class SqlParameterFactory : IParameterCreation
    {
        /// <summary>
        /// Converts a generic DbType into an NpgsqlDbType
        /// </summary>
        /// <param name="dbType">The DbType to convert</param>
        /// <returns>The corresponding NpgsqlDbType</returns>
        internal NpgsqlDbType ConvertDbTypeToSqlDbType(DbType dbType)
        {
            NpgsqlDbType sqlType;

            switch (dbType)
            {
                case DbType.AnsiString:
                case DbType.AnsiStringFixedLength:
                    sqlType = NpgsqlDbType.Text;
                    break;

                case DbType.Binary:
                    sqlType = NpgsqlDbType.Bytea;
                    break;

                case DbType.Boolean:
                    sqlType = NpgsqlDbType.Boolean;
                    break;

                case DbType.Byte:
                    sqlType = NpgsqlDbType.Numeric;
                    break;

                case DbType.Currency:
                    sqlType = NpgsqlDbType.Money;
                    break;

                case DbType.Date:
                    sqlType = NpgsqlDbType.Date;
                    break;

                case DbType.DateTime:
                case DbType.DateTime2:
                case DbType.DateTimeOffset:
                    sqlType = NpgsqlDbType.TimestampTz;
                    break;

                case DbType.Decimal:
                    sqlType = NpgsqlDbType.Numeric;
                    break;

                case DbType.Double:
                    sqlType = NpgsqlDbType.Double;
                    break;

                case DbType.Guid:
                    sqlType = NpgsqlDbType.Uuid;
                    break;

                case DbType.Int16:
                    sqlType = NpgsqlDbType.Smallint;
                    break;

                case DbType.Int32:
                    sqlType = NpgsqlDbType.Integer;
                    break;

                case DbType.Int64:
                    sqlType = NpgsqlDbType.Bigint;
                    break;

                case DbType.Single:
                    sqlType = NpgsqlDbType.Real;
                    break;

                case DbType.String:
                case DbType.StringFixedLength:
                    sqlType = NpgsqlDbType.Text;
                    break;

                case DbType.Time:
                    sqlType = NpgsqlDbType.Time;
                    break;

                case DbType.Xml:
                    sqlType = NpgsqlDbType.Xml;
                    break;

                case DbType.Object:
                    throw new ArgumentException("DbType.Object has no corresponding SQL Server datatype");

                case DbType.SByte:
                    throw new ArgumentException("DbType.SByte has no corresponding SQL Server datatype");

                case DbType.UInt16:
                    throw new ArgumentException("DbType.UInt16 has no corresponding SQL Server datatype");

                case DbType.UInt32:
                    throw new ArgumentException("DbType.UInt32 has no corresponding SQL Server datatype");

                case DbType.UInt64:
                    throw new ArgumentException("DbType.UInt64 has no corresponding SQL Server datatype");

                case DbType.VarNumeric:
                    throw new ArgumentException("DbType.VarNumeric has no corresponding SQL Server datatype");

                default:
                    throw new ArgumentException(dbType.ToString() + " has no corresponding SQL Server datatype");
            }

            return sqlType;
        }

        /// <summary>
        /// Creates a SqlParameter
        /// </summary>
        /// <param name="paramName">Name of the parameter</param>
        /// <param name="paramType">The NpgsqlDbType for the parameter</param>
        /// <param name="value">The value for the parameter</param>
        /// <returns>a configured SqlParameter object</returns>
        public NpgsqlParameter Create(string paramName, NpgsqlDbType paramType, object? value)
        {
            NpgsqlParameter param = new NpgsqlParameter(paramName, paramType);

            // If null passed for value then set value to DBNull
            if (value == null)
                param.Value = DBNull.Value;
            else
                param.Value = value;

            return param;
        }

        /// <summary>
        /// Creates a SqlParameter
        /// </summary>
        /// <param name="paramName">Name of the parameter</param>
        /// <param name="paramType">The NpgsqlDbType for the parameter</param>
        /// <param name="direction">Indicates whether the parameter is input-only, output-only, bidirectional, or a stored procedure return value parameter.</param>
        /// <returns>a configured SqlParameter object</returns>
        public NpgsqlParameter Create(string paramName, NpgsqlDbType paramType, ParameterDirection direction)
        {
            NpgsqlParameter param = Create(paramName, paramType, null);
            param.Direction = direction;

            return param;
        }

        /// <summary>
        /// Creates a SqlParameter
        /// </summary>
        /// <param name="paramName">Name of the parameter</param>
        /// <param name="paramType">The NpgsqlDbType of the parameter</param>
        /// <param name="value">The value for the parameter</param>
        /// <param name="direction">Indicates whether the parameter is input-only, output-only, bidirectional, or a stored procedure return value parameter.</param>
        /// <returns>a configured SqlParameter object</returns>
        public NpgsqlParameter Create(string paramName, NpgsqlDbType paramType, object value, ParameterDirection direction)
        {
            NpgsqlParameter returnVal = Create(paramName, paramType, value);
            returnVal.Direction = direction;
            return returnVal;
        }

        /// <summary>
        /// Creates a SqlParameter
        /// </summary>
        /// <param name="paramName">Name of parameter</param>
        /// <param name="paramType">The NpgsqlDbType for the parameter</param>
        /// <param name="value">The value of the parameter</param>
        /// <param name="size">The maximum size, in bytes, of the data within the column.</param>
        /// <returns>a configured SqlParameter object</returns>
        public NpgsqlParameter Create(string paramName, NpgsqlDbType paramType, object value, int size)
        {
            NpgsqlParameter returnVal = Create(paramName, paramType, value);
            returnVal.Size = size;
            return returnVal;
        }

        /// <summary>
        /// Creates a SqlParameter
        /// </summary>
        /// <param name="paramName">Name of parameter</param>
        /// <param name="paramType">The NpgsqlDbType for the parameter</param>
        /// <param name="value">The value for the parameter</param>
        /// <param name="size">The maximum size, in bytes, of the data within the column.</param>
        /// <param name="direction">Indicates whether the parameter is input-only, output-only, bidirectional, or a stored procedure return value parameter.</param>>
        /// <returns>a configured SqlParameter object</returns>
        public NpgsqlParameter Create(string paramName, NpgsqlDbType paramType, object value, int size, ParameterDirection direction)
        {
            NpgsqlParameter returnVal = Create(paramName, paramType, value);
            returnVal.Direction = direction;
            returnVal.Size = size;
            return returnVal;
        }

        /// <summary>
        /// Creates a SqlParameter
        /// </summary>
        /// <param name="paramName">Name of parameter</param>
        /// <param name="paramType">The NpgsqlDbType for the parameter</param>
        /// <param name="value">The value for the parameter</param>
        /// <param name="size">The maximum size, in bytes, of the data within the column.</param>
        /// <param name="precision">the maximum number of digits used to represent the Value property.</param>
        /// <returns>a configured SqlParameter object</returns>
        public NpgsqlParameter Create(string paramName, NpgsqlDbType paramType, object value, int size, byte precision)
        {
            NpgsqlParameter returnVal = Create(paramName, paramType, value);
            returnVal.Size = size;
            returnVal.Precision = precision;
            return returnVal;
        }

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
        public NpgsqlParameter Create(string paramName, NpgsqlDbType paramType, object value, int size, byte precision, ParameterDirection direction)
        {
            NpgsqlParameter returnVal = Create(paramName, paramType, value);
            returnVal.Direction = direction;
            returnVal.Size = size;
            returnVal.Precision = precision;
            return returnVal;
        }
    }
}
