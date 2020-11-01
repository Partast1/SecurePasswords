using System;
using System.Collections.Generic;

namespace SecurePasswords
{
    class Program
    {
        static void Main(string[] args)
        {
            Verification verification = new Verification();
            Hash hash = new Hash();
            DatabaseHandler dbh = new DatabaseHandler();

            string output = dbh.GetSpecificSalt(1);
            Console.WriteLine(output);


            CreateUser createUser = new CreateUser();
            Console.WriteLine("Press 1 for user creating, press 2 to logon");
            int input = Int32.Parse(Console.ReadLine());
            if (input == 1)
            {
                Console.WriteLine("Type username");
                string userName = Console.ReadLine();
                Console.WriteLine("Type password");
                string passWord = Console.ReadLine();
                createUser.Create(userName, passWord);
                Console.WriteLine("User Created");
            }
            else
            {
                Console.WriteLine("Type username");
                string logonName = Console.ReadLine();
                Console.WriteLine("Type password");
                string possiblePassWord = Console.ReadLine();
                verification.VerifyeUser(logonName,possiblePassWord);
                //byte[] hashedPassword = hash.CreateSpecificHash(possiblePassWord);
                ////call specific
                //CreateSaltWithKey();
                //List<int> userids = verification.FindPossibleUser(logonName);
                //if (userids.Count != 0)
                //{

                //    //for
                //    //List<string> dbNames = new List<string>();

                 
                //}
            }
            

            //if

            //validate
            //  decrypt
            //      fail log

        }
    }
}
