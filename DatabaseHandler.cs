using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;


namespace SecurePasswords
{
    public class DatabaseHandler
    {
        public string connString = @"Server=(localdb)\MSSQLLocalDB;Database=SecurePasswordDB;Trusted_Connection = True; Integrated Security=true;";

        public SqlConnection Connect()
        {
            SqlConnection conn = new SqlConnection(connString);
            return conn;
        }
        public void ConnectionOpen(SqlConnection conn)
        {
            conn.Open();
        }
        public void ConnectionClose(SqlConnection conn)
        {
            conn.Close();
        }
        public SqlCommand Command(string query, SqlConnection conn)
        {
            SqlCommand cmd = new SqlCommand(query, conn);
            return cmd;
        }
        public void CreateUser(string userName, byte[] salt, byte[] hashedpassword)
        {
            string SALT = Convert.ToBase64String(salt);
            string HASHED = Convert.ToBase64String(hashedpassword);

            SqlConnection conn = Connect();
            string query = "INSERT into Users (Username, Salt, HashedPassword) VALUES (@Username, @Salt, @HashedPassword)";
            SqlCommand cmd = Command(query, conn);
            ConnectionOpen(conn);
            cmd.Parameters.AddWithValue("@Username", userName);
            cmd.Parameters.AddWithValue("@Salt", SALT);
            cmd.Parameters.AddWithValue("@HashedPassword", HASHED);
            cmd.ExecuteNonQuery();
            ConnectionClose(conn);
        }
        public List<string> GetUsernames()
        {
            List<string> users = new List<string>();
            SqlConnection conn = Connect();
            string query = "SELECT Username FROM Users";
            SqlCommand cmd = new SqlCommand(query, conn);
            ConnectionOpen(conn);
            using (SqlDataReader dataReader = cmd.ExecuteReader())

                if (dataReader != null)
                {
                    while (dataReader.Read())
                    {
                        string username = dataReader.GetString(0);
                        users.Add(username);
                    }
                }
                else
                {
                    Console.WriteLine("No data found.");
                }
            ConnectionClose(conn);
            return users;
        }
        public List<string> GetSalt()
        {
            List<string> salts = new List<string>();
            SqlConnection conn = Connect();
            string query = "SELECT Salt FROM Users";
            SqlCommand cmd = new SqlCommand(query, conn);
            ConnectionOpen(conn);
            using (SqlDataReader dataReader = cmd.ExecuteReader())

                if (dataReader != null)
                {
                    while (dataReader.Read())
                    {
                        string salt = dataReader.GetString(0);

                        salts.Add(salt);
                    }
                }
                else
                {
                    Console.WriteLine("No data found.");
                }
            ConnectionClose(conn);
            return salts;
        }
        public void GetUsers()
        {

        }
        public string GetSpecificSalt(int id)
        {
            
            string salt = "";
            SqlConnection conn = Connect();
            string query = "SELECT Salt FROM Users WHERE UserID = " + id;
            SqlCommand cmd = new SqlCommand(query, conn);
            ConnectionOpen(conn);
            using (SqlDataReader dataReader = cmd.ExecuteReader())

                if (dataReader != null)
                {
                    while (dataReader.Read())
                    {
                        return salt = dataReader.GetString(0);
            
                    }
                }
                else
                {
                    return "No data found.";
                }
            ConnectionClose(conn);

            return salt;
        }
        public string GetSpecificHash(int id)
        {

            string salt = "";
            SqlConnection conn = Connect();
            string query = "SELECT HashedPassword FROM Users WHERE UserID = " + id;
            SqlCommand cmd = new SqlCommand(query, conn);
            ConnectionOpen(conn);
            using (SqlDataReader dataReader = cmd.ExecuteReader())

                if (dataReader != null)
                {
                    while (dataReader.Read())
                    {
                        return salt = dataReader.GetString(0);

                    }
                }
                else
                {
                    return "No data found.";
                }
            ConnectionClose(conn);

            return salt;
        }
    }
}
