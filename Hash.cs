using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace SecurePasswords
{
    public class Hash
    {
        private const int hashSize = 24;
        private const int rounds = 10000;

        public void CreateRandomHash(string username, string notPassword)
        {
            DatabaseHandler databaseHandler = new DatabaseHandler();
            byte[] salt = Salt.CreateSalt();
            Rfc2898DeriveBytes rfc2898 = new Rfc2898DeriveBytes(Encoding.UTF8.GetBytes(notPassword), salt, rounds);
            databaseHandler.CreateUser(username, salt, rfc2898.GetBytes(hashSize));
        }
        public byte[] CreateSpecificHash(byte[] salt, string notPassword)
        {
            DatabaseHandler databaseHandler = new DatabaseHandler();
            Rfc2898DeriveBytes rfc2898 = new Rfc2898DeriveBytes(Encoding.UTF8.GetBytes(notPassword), salt, rounds);
            byte[] hash = rfc2898.GetBytes(hashSize);
            return hash;
        }
    }
}
