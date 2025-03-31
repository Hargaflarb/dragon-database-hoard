using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace dragon_database
{
    public enum ConsoleState
    {
        TableSelection = 1,
        RowSelection = 2,
        RowManipulation = 3,
    }

    public enum Table
    {
        Players = 1,
        Hoards = 2,
        Treasures = 3,
        Kingdoms = 4,
        Debts = 5,
        KingdomRelations = 6,
    }

    public static class ConsoleManager
    {
        private static SqlConnection connection;
        private static Table selectedTable = Table.Players;
        private static ConsoleState selectedState = ConsoleState.TableSelection;
        private static int selectedRow = 0;
        private static int rowMax = 1;

        public static SqlConnection Connection { private get => connection; set => connection = value; }
        public static Table SelectedTable
        {
            get => selectedTable;
            set
            {
                if (value > selectedTable & (int)selectedTable < 6)
                {
                    selectedTable++;
                }
                else if (value < selectedTable & (int)selectedTable > 1)
                {
                    selectedTable--;
                }
            }
        }
        public static ConsoleState SelectedState 
        {
            get => selectedState; 
            set
            {
                if (value > selectedState & (int)selectedState < 3)
                {
                    selectedState++;
                }
                else if (value < selectedState & (int)selectedState > 1)
                {
                    selectedState--;
                }
            } 
        }
        public static int SelectedRow 
        {
            get => selectedRow;
            set
            {
                if (value >= 0 & value <= rowMax)
                {
                    selectedRow = value;
                }
            }
        }



        public static void TakeInput(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (selectedState == ConsoleState.TableSelection)
                    {
                        SelectedTable--;
                    }
                    else if (selectedState == ConsoleState.RowSelection)
                    {
                        SelectedRow--;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (selectedState == ConsoleState.TableSelection)
                    {
                        SelectedTable++;
                    }
                    else if (selectedState == ConsoleState.RowSelection)
                    {
                        SelectedRow++;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    SelectedState++;
                    break;
                case ConsoleKey.LeftArrow:
                    SelectedState--;
                    break;

                case ConsoleKey.Enter:
                    SelectedState++;
                    break;

                case ConsoleKey.Select:
                    break;
                case ConsoleKey.Insert:
                    break;
                case ConsoleKey.Delete:
                    break;

                case ConsoleKey.Escape:
                    break;

                default:
                    break;
            }

            UpdateScreen();
        }

        public static void UpdateScreen()
        {
            Console.Clear();
            Console.WriteLine($"State: {SelectedState}\nTabel: {selectedTable}\nRow: {SelectedRow}\n");

            List<string> rows = Display();
            foreach (string row in rows)
            {
                Console.WriteLine(row);
            }
            Console.WriteLine("Insert Row...");
            rowMax = rows.Count;
        }

        public static void AddAccount(string name, string password)
        {
            string writeQuery = $"INSERT INTO Accounts (Name, Password) VALUES ('{name}','{password}')";
            SqlCommand insertCommand = new SqlCommand(writeQuery, Connection);

            int rowsAffected = insertCommand.ExecuteNonQuery();
            Console.WriteLine($"{rowsAffected} accounts successfully added");
        }

        public static void DeleteAccount(int ID)
        {
            string deleteQuery = $"DELETE FROM Accounts WHERE (Account_ID = '{ID}')";
            SqlCommand deleteCommand = new SqlCommand(deleteQuery, Connection);

            int rowsAffected = deleteCommand.ExecuteNonQuery();
            Console.WriteLine($"{rowsAffected} accounts successfully deleted");

        }

        public static List<string> Display()
        {
            SqlCommand readCommand = new SqlCommand($"SELECT * FROM Players", Connection); //{SelectedTable.ToString()}
            SqlDataReader reader = readCommand.ExecuteReader();

            List<string> rows = new List<string>();

            while (reader.Read())
            {
                rows.Add($"{reader.GetInt32(0)}, {reader.GetString(1)}, {reader.GetString(2)}, {reader.GetInt32(3)}");
            }

            reader.Close();
            return rows;
        }


    }
}
