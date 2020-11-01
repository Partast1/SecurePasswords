using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Security.Cryptography;
using System.Text;

namespace SecurePasswords
{

    public class Salt
    {
        private const int saltSize = 24;


        public static byte[] CreateSalt()
        {
            RNGCryptoServiceProvider rngProvider = new RNGCryptoServiceProvider();
            byte[] salt = new byte[saltSize];
            rngProvider.GetBytes(salt);
            return salt;
        }
        public static byte[] CreateSaltWithKey(byte[] key)
        {
            RNGCryptoServiceProvider rngProvider = new RNGCryptoServiceProvider();
            byte[] determinedSalt = key;
            rngProvider.GetBytes(determinedSalt);
            return determinedSalt;
        }
    }
}
