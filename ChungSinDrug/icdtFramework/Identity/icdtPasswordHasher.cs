using icdtFramework.Helpers;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace icdtFramework.Identity
{
    public class AESPasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            return AESHelper.AES_Encryption(password);
        }

        public PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
            string decryptedPassword = AESHelper.AES_Decryption(hashedPassword);

            if (decryptedPassword.Equals(providedPassword))
                return PasswordVerificationResult.Success;
            else
                return PasswordVerificationResult.Failed;
        }
    }

    public class ClearPasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            return password;
        }

        public PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
            if (hashedPassword.Equals(providedPassword))
                return PasswordVerificationResult.Success;
            else return PasswordVerificationResult.Failed;
        }
    }
}
