using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecurePasswords
{
    public class Verification
    {
        DatabaseHandler dbh = new DatabaseHandler();

        //public List<int> FindPossibleUser(string logonName)
        //{
        //    List<string> dbNames = new List<string>();
        //    List<int> matchedNames = new List<int>();

        //    dbNames = dbh.GetUsernames();
        //    for (int i = 0; i < dbNames.Count; i++)
        //    {

        //        if (dbNames[i] == logonName)
        //        {
        //            matchedNames.Add(i);

        //        }
        //    }
        //    return matchedNames;

        //}
        public void VerifyeUser(string logonName, string password)
        {
            Hash hash = new Hash();
            List<string> dbNames = new List<string>();
            List<int> matchedIDs = new List<int>();
            List<byte[]> salts = new List<byte[]>();
            List<byte[]> hashes = new List<byte[]>();


            //Finder alle brugere i databasen
            dbNames = dbh.GetUsernames();
            for (int i = 0; i < dbNames.Count; i++)
            {
                if (dbNames[i] == logonName)
                {
                    matchedIDs.Add(i);
                    salts.Add(Salt.CreateSaltWithKey(Encoding.UTF8.GetBytes(dbh.GetSpecificSalt(i))));
                }
            }
            //tilføjer til hashes igennem fundet salts
            for (int i = 0; i < salts.Count; i++)
            {
                hashes.Add(hash.CreateSpecificHash(salts[i], password));
            }
            // Finder og samligner de mulige hashes med hashes fra databasen
            for (int i = 0; i < hashes.Count; i++)
            {
               byte[] hashfromDB = Encoding.UTF8.GetBytes(dbh.GetSpecificHash(i));
                if (hashes[i] == hashfromDB)
                {
                    Console.WriteLine("Success");
                }
                else
                {
                    Console.WriteLine("Login denied");
                }
            }
           



        }




    }
}
