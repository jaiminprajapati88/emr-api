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
        public static int GenerateSalt()
        {
            RNGCryptoServiceProvider cryptoServiceProvider = new RNGCryptoServiceProvider();
            
            byte[] numArray = new byte[4];
            byte[] data = numArray;
            
            cryptoServiceProvider.GetNonZeroBytes(data);

            return (numArray[0] << 24) + (numArray[1] << 16) + (numArray[2] << 8) + numArray[3];
        }
    }
}
