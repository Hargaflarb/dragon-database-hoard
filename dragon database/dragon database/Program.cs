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
        static string EchoConnectionString = "Server=DATAMATIKEREN\\SQLEXPRESS;Database=Dragon_Hoard;Trusted_Connection=True;TrustServerCertificate=True";
        static string EmmaConnectionString = "server= PC_FOR_CAKES\\SQLEXPRESS;Database=Dragon_Hoghnard;Trusted_Connection=True;TrustServerCertificate=True";
        static string MaltheconnectionString = "Server=LAPTOP-MALTHE\\SQLEXPRESS;Database=Dragon_Hoard;Trusted_Connection=True;TrustServerCertificate=True";
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
            ConsoleManager.Connection = connection;

            try
            {
                connection.Open();
                ConsoleManager.UpdateScreen();
                for (int i = 0; i < 10; i++)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    ConsoleManager.TakeInput(key.Key, out bool exit);
                    if (exit)
                    {
                        break;
                    }
                }
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

    }
}
