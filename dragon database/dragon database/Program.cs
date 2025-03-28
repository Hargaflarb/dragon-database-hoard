using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dragon_database
{
    public class Program
    {
        static string EchoConnectionString = "Server=LAPTOP-MALTHE\\SQLEXPRESS;Database=CSTestThing;Trusted_Connection=True;TrustServerCertificate=True";
        static string EmmaConnectionString = "Server=LAPTOP-MALTHE\\SQLEXPRESS;Database=CSTestThing;Trusted_Connection=True;TrustServerCertificate=True";
        static string MaltheconnectionString = "Server=LAPTOP-MALTHE\\SQLEXPRESS;Database=CSTestThing;Trusted_Connection=True;TrustServerCertificate=True";
        static SqlConnection connection;

        static void Main(string[] args)
        {
            //REMEMBER TO ACTIVATE DATABASE BEFORE RUNNING PROGRAM!!!
            Console.WriteLine("Who is the user?");
            string user = Console.ReadLine().ToLower();

            switch (user)
            {
                case "echo":
                    connection = new SqlConnection(EchoConnectionString);
                    break;
                case "emma":
                    connection = new SqlConnection(EmmaConnectionString);
                    break;
                case "malthe":
                    connection = new SqlConnection(MaltheconnectionString);
                    break;
                default:
                    Console.WriteLine("Not a user");
                    Console.ReadLine();
                    Environment.Exit(0);
                    break;
            }

            connection.Open();
            try
            {
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadLine();
                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        public static void AddAccount(string name, string password)
        {
            string writeQuery = $"INSERT INTO Accounts (Name, Password) VALUES ('{name}','{password}')";
            SqlCommand insertCommand = new SqlCommand(writeQuery, connection);

            int rowsAffected = insertCommand.ExecuteNonQuery();
            Console.WriteLine($"{rowsAffected} accounts successfully added");
        }

        public static void DeleteAccount(int ID)
        {
            string deleteQuery = $"DELETE FROM Accounts WHERE (Account_ID = '{ID}')";
            SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);

            int rowsAffected = deleteCommand.ExecuteNonQuery();
            Console.WriteLine($"{rowsAffected} accounts successfully deleted");

        }

        public static void DisplayAccounts()
        {

            SqlCommand readCommand = new SqlCommand("SELECT * FROM Accounts", connection);
            SqlDataReader reader = readCommand.ExecuteReader();


            while (reader.Read())
            {
                Console.WriteLine($"{reader.GetInt32(0)}, {reader.GetString(1)}, {reader.GetString(2)}");
            }


            reader.Close();
        }
        

        public string InsertStatmentFor(string tableName)
        {
            switch (tableName)
            {
                case "Player":
                    return "Player (Username, Password, Hunger) VALUE ('', '', '0')";
                default:
                    return "hi";
            }
        }
    }
}
