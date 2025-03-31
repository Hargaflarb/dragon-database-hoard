using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;

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
        Players = 0,
        Hoards = 1,
        Treasures = 2,
        Kingdoms = 3,
        Debts = 4,
        KingdomRelations = 5,
    }

    public static class ConsoleManager
    {
        private static SqlConnection connection;
        private static Table selectedTable = Table.Players;
        private static readonly TableFormat[] Formats = new TableFormat[] { new PlayerFormat(), new HoardFormat(), new TreasureFormat(), new KingdomsFormat(), new DebtFormat(), new KingdomRelationsFormat() };
        private static ConsoleState selectedState = ConsoleState.TableSelection;
        private static int selectedRow = 0;
        private static int rowMax = 0;

        public static SqlConnection Connection { private get => connection; set => connection = value; }
        public static Table SelectedTable
        {
            get => selectedTable;
            set
            {
                if (value > selectedTable & selectedTable < Table.KingdomRelations)
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



        public static void TakeInput(ConsoleKey key, out bool exit)
        {
            exit = false;
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
                    exit = true;
                    return;

                default:
                    break;
            }

            UpdateScreen();
        }

        public static void UpdateScreen()
        {
            Console.Clear();
            Console.WriteLine($"State: {SelectedState}\nTabel: {selectedTable}\nRow: {SelectedRow}\n\n");

            List<string> rows = Formats[(int)SelectedTable].Select(Connection);
            rows.Add("Insert Row...");
            for (int i = 0; i < rows.Count | i <= (int)Table.KingdomRelations; i++)
            {
                string tableString = i <= (int)Table.KingdomRelations ? ((Table)i).ToString() : "";
                string rowString = i < rows.Count ? rows[i] : "";

                WriteWithColor(selectedState == ConsoleState.TableSelection & selectedTable == (Table)i, tableString);
                Console.CursorLeft = 20;
                WriteWithColor(selectedState == ConsoleState.RowSelection & selectedRow == i, rowString);


                Console.WriteLine();
            }
            rowMax = rows.Count;
        }

        private static void WriteWithColor(bool condition, string text)
        {
            if (condition)
            {
                Console.BackgroundColor = ConsoleColor.White;
            }
            Console.Write(text);
            Console.ResetColor();
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



    }
}
