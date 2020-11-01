using System;
using System.Collections.Generic;
using System.Text;

namespace SecurePasswords
{
    public class CreateUser
    {
        Hash hash = new Hash();
        public void Create(string username, string password)
        {
            hash.CreateRandomHash(username, password);
        }
    }
}
