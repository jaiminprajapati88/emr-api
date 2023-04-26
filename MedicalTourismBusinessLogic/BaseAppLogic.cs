using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MedicalTourismBusinessLogic
{
    public class BaseAppLogic
    {
        public static int GenerateSaltForPassword()
        {
            RNGCryptoServiceProvider cryptoServiceProvider = new RNGCryptoServiceProvider();
            
            byte[] numArray = new byte[4];
            byte[] data = numArray;
            
            cryptoServiceProvider.GetNonZeroBytes(data);

            return (numArray[0] << 24) + (numArray[1] << 16) + (numArray[2] << 8) + numArray[3];
        }

        protected bool generatePassword(string password, int salt, byte[] A_2)
        {
            return ((IEnumerable<byte>)GeneratePasswordHash(password, salt)).SequenceEqual<byte>(A_2);
        }

        protected byte[] GeneratePasswordHash(string password, int salt)
        {
            byte[] numArray = new byte[4]
            {
                (byte) (salt >> 24),
                (byte) (salt >> 16),
                (byte) (salt >> 8),
                (byte) salt
            };

            byte[] bytes = Encoding.UTF8.GetBytes(password);
            byte[] buffer = new byte[numArray.Length + bytes.Length];
            Buffer.BlockCopy(bytes, 0, buffer, 0, bytes.Length);
            Buffer.BlockCopy(numArray, 0, buffer, bytes.Length, numArray.Length);
            return SHA1.Create().ComputeHash(buffer);
        }
    }
}
