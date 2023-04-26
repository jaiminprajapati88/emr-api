using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

public static class ExtentionMethods
{
    public static bool IsValidEmail(this string email)
    {
        MailMessage mailMessage = new MailMessage();

        bool flag = false;
        try
        {
            mailMessage.To.Add(email);
        }
        catch
        {
            flag = true;
        }
        mailMessage.Dispose();
        return !flag;
    }

    public static List<T> ToListof<T>(this DataTable dt)
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