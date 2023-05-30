using EMR.Repository.Constant;
using System.Security.Cryptography;
using System.Text;

namespace EMR.Common.Extension
{
    public static class SecurityExtension
    {
        public static string GenerateSalt(this int keySize)
        {
            var salt = RandomNumberGenerator.GetBytes(keySize); ;
            return Convert.ToHexString(salt);
        }

        public static string GenerateHash(this string value, string salt, int keySize = SecurityConstant.KeySize, int iterations = SecurityConstant.Iterations)
        {
            HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

            var hash = Rfc2898DeriveBytes.Pbkdf2(Encoding.UTF8.GetBytes(value), Convert.FromHexString(salt), iterations, hashAlgorithm, keySize);

            return Convert.ToHexString(hash);
        }

        public static bool VerifyHash(this string value, string hash, string salt, int keySize = SecurityConstant.KeySize, int iterations = SecurityConstant.Iterations) {
            HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

            var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(value, Convert.FromHexString(salt), iterations, hashAlgorithm, keySize);

            return CryptographicOperations.FixedTimeEquals(hashToCompare, Convert.FromHexString(hash));
        }
    }
}
