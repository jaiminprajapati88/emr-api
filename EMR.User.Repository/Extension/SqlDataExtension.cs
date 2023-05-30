using EMR.Data.Extension;
using Npgsql;
using System.Data;
using System.Reflection;

namespace EMR.Repository.Extension
{
    public static class SqlDataExtension
    {
        public static List<T> ToExecuteReader<T>(this NpgsqlCommand command)
        {
            List<T> list = new List<T>();

            using (command)
            {
                using (var reader = command.ExecuteReader())
                {
                    list = reader.ToList<T>();
                }
            }

            return list;
        }

        public static object? ToExecuteScalar(this NpgsqlCommand command)
        {
            object? value;

            using (command)
            {
                value = command.ExecuteScalar();
            }

            return value;
        }

        public static List<T> ToList<T>(this IDataReader dataReader)
        {
            const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance;
            
            var objectProperties = typeof(T).GetProperties(flags).GetFilteredProperties();

            List<T> list = new List<T>();
                        
            while (dataReader.Read())
            {
                var instanceOfT = Activator.CreateInstance<T>();

                foreach (PropertyInfo prop in objectProperties)
                {
                    if (!object.Equals(dataReader[prop.Name], DBNull.Value))
                    {
                        prop.SetValue(instanceOfT, dataReader[prop.Name], null);
                    }
                }

                list.Add(instanceOfT);
            }

            return list;
        }

        public static List<T> ToList<T>(this DataTable dt)
        {
            const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance;

            var columnNames = dt.Columns.Cast<DataColumn>()
                .Select(c => c.ColumnName)
                .ToList();

            var objectProperties = typeof(T).GetProperties(flags);

            var targetList = dt.AsEnumerable().Select(dataRow =>
            {
                var instanceOfT = Activator.CreateInstance<T>();

                foreach (var properties in objectProperties.Where(properties => columnNames.Contains(properties.Name) && dataRow[properties.Name] != DBNull.Value))
                {
                    properties.SetValue(instanceOfT, dataRow[properties.Name], null);
                }

                return instanceOfT;

            }).ToList();

            return targetList;
        }
    }
}
