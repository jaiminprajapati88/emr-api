using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Security.Cryptography;
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

    public static byte[] GenerateHash(this string value, int salt) {
        byte[] numArray = new byte[4]
                {
                (byte) (salt >> 24),
                (byte) (salt >> 16),
                (byte) (salt >> 8),
                (byte) salt
                };

        byte[] bytes = Encoding.UTF8.GetBytes(value);
        byte[] buffer = new byte[numArray.Length + bytes.Length];
        Buffer.BlockCopy(bytes, 0, buffer, 0, bytes.Length);
        Buffer.BlockCopy(numArray, 0, buffer, bytes.Length, numArray.Length);
        return SHA1.Create().ComputeHash(buffer);
    }

    public static bool IsValidHash(this string value, int salt, byte[] A_2)
    {
        byte[] hash = value.GenerateHash(salt);
        return hash.SequenceEqual<byte>(A_2);
    }
}