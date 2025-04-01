using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace dragon_database
{
    public abstract class TableFormat
    {
        protected static SqlConnection connection;
        public abstract (int parameters, string format) InsertFormat { get; }
        //public abstract string UpdateFormat { get; }


        public void ExecuteQuery(string query)
        {
            SqlCommand insertCommand = new SqlCommand(query, ConsoleManager.Connection);

            int rowsAffected = insertCommand.ExecuteNonQuery();
            Console.WriteLine($"{rowsAffected} rows successfully affected.");
        }

        public abstract string GetItemCondition(int index);

        public abstract List<string> Select();

        public abstract void Insert(string args);

        public abstract void Update(string args);

        public abstract void Delete(string args);


    }

    public class PlayerFormat : TableFormat
    {
        public override (int parameters, string format) InsertFormat { get => (3, "'Name', 'Password', 'Hunger'"); }
        //public override string UpadteFormat { get => "name => idk"; }

        public override List<string> Select()
        {
            SqlCommand readCommand = new SqlCommand($"SELECT * FROM Players", ConsoleManager.Connection);
            SqlDataReader reader = readCommand.ExecuteReader();

            List<string> rows = new List<string>();

            while (reader.Read())
            {
                rows.Add($"{reader.GetInt32(0)} | {reader.GetString(1)} | {reader.GetString(2)} | {reader.GetInt32(3)}");
            }

            reader.Close();
            return rows;
        }

        public override string GetItemCondition(int index)
        {
            SqlCommand readCommand = new SqlCommand($"SELECT * FROM Players", ConsoleManager.Connection);
            SqlDataReader reader = readCommand.ExecuteReader();

            for (int i = 0; i != index; i++)
            {
                reader.Read();
            }
            string outCondition = $"Id = '{reader.GetInt32(0)}'";
            reader.Close();
            return outCondition;
        }

        public override void Insert(string args)
        {
            string insertQuery = $"INSERT INTO Players (Username, LoginPassword, Hunger) VALUES ({args})";
            ExecuteQuery(insertQuery);
        }

        public override void Update(string args)
        {

        }

        public override void Delete(string conditions)
        {
            string deleteQuery = $"DELETE FROM Players WHERE ({conditions})";
            ExecuteQuery(deleteQuery);
        }
    }
    public class HoardFormat : TableFormat
    {
        public override (int parameters, string format) InsertFormat { get => (3, "'PlayerId', 'MoneyAmount'"); }

        public override List<string> Select()
        {
            SqlCommand readCommand = new SqlCommand($"SELECT * FROM Hoards", ConsoleManager.Connection);
            SqlDataReader reader = readCommand.ExecuteReader();

            List<string> rows = new List<string>();

            while (reader.Read())
            {
                rows.Add($"{reader.GetInt32(0)} | {reader.GetInt32(1)}");
            }

            reader.Close();
            return rows;
        }

        public override string GetItemCondition(int index)
        {
            SqlCommand readCommand = new SqlCommand($"SELECT * FROM Hoards", ConsoleManager.Connection);
            SqlDataReader reader = readCommand.ExecuteReader();

            List<string> rows = new List<string>();

            for (int i = 0; i != index; i++)
            {
                reader.Read();
            }
            string outCondition = $"PlayerId = '{reader.GetInt32(0)}'";
            reader.Close();
            return outCondition;
        }


        public override void Insert(string args)
        {
            string insertQuery = $"INSERT INTO Hoards (PlayerId, MoneyAmount) VALUES ({args})";
            ExecuteQuery(insertQuery);
        }

        public override void Update(string args)
        {

        }

        public override void Delete(string conditions)
        {
            string deleteQuery = $"DELETE FROM Hoards WHERE ({conditions})";
            ExecuteQuery(deleteQuery);
        }
    }
    public class TreasureFormat : TableFormat
    {
        public override (int parameters, string format) InsertFormat { get => (3, "'PlayerId', 'Rarity', 'TreasureName'"); }
        public override List<string> Select()
        {
            SqlCommand readCommand = new SqlCommand($"SELECT * FROM Treasures", ConsoleManager.Connection);
            SqlDataReader reader = readCommand.ExecuteReader();

            List<string> rows = new List<string>();

            while (reader.Read())
            {
                rows.Add($"{reader.GetInt32(0)} | {reader.GetInt32(1)} | {reader.GetString(2)} | {reader.GetInt32(3)}");
            }

            reader.Close();
            return rows;
        }

        public override string GetItemCondition(int index)
        {
            SqlCommand readCommand = new SqlCommand($"SELECT * FROM Treasures", ConsoleManager.Connection);
            SqlDataReader reader = readCommand.ExecuteReader();

            List<string> rows = new List<string>();

            for (int i = 0; i != index; i++)
            {
                reader.Read();
            }
            string outCondition = $"PlayerId = '{reader.GetInt32(0)}' AND Id = '{reader.GetInt32(4)}'";
            reader.Close();
            return outCondition;
        }


        public override void Insert(string args)
        {
            string insertQuery = $"INSERT INTO Treasures (PlayerId, Rarity, TreasureName) VALUES ({args})";
            ExecuteQuery(insertQuery);
        }

        public override void Update(string args)
        {

        }

        public override void Delete(string conditions)
        {
            string deleteQuery = $"DELETE FROM Treasures WHERE ({conditions})";
            ExecuteQuery(deleteQuery);
        }
    }
    public class KingdomsFormat : TableFormat
    {
        public override (int parameters, string format) InsertFormat { get => (3, "'PlayerId', 'Approval', 'Fear', 'Economy', 'KingdomName'"); }
        public override List<string> Select()
        {
            SqlCommand readCommand = new SqlCommand($"SELECT * FROM Kingdoms", ConsoleManager.Connection);
            SqlDataReader reader = readCommand.ExecuteReader();

            List<string> rows = new List<string>();

            while (reader.Read())
            {
                rows.Add($"{reader.GetInt32(0)} | {reader.GetInt32(1)} | {reader.GetInt32(2)} | {reader.GetInt32(3)} | {reader.GetString(3)}");
            }

            reader.Close();
            return rows;
        }

        public override string GetItemCondition(int index)
        {
            SqlCommand readCommand = new SqlCommand($"SELECT * FROM Kingdoms", ConsoleManager.Connection);
            SqlDataReader reader = readCommand.ExecuteReader();

            List<string> rows = new List<string>();

            for (int i = 0; i != index; i++)
            {
                reader.Read();
            }
            string outCondition = $"PlayerId = '{reader.GetInt32(0)}' & KingdomName = '{reader.GetInt32(4)}'";
            reader.Close();
            return outCondition;
        }


        public override void Insert(string args)
        {
            string insertQuery = $"INSERT INTO Kingdoms (PlayerId, Approval, Fear, Economy, KingdomName) VALUES ({args})";
            ExecuteQuery(insertQuery);
        }

        public override void Update(string args)
        {

        }

        public override void Delete(string conditions)
        {
            string deleteQuery = $"DELETE FROM Kingdoms WHERE ({conditions})";
            ExecuteQuery(deleteQuery);
        }
    }
    public class DebtFormat : TableFormat
    {
        public override (int parameters, string format) InsertFormat { get => (3, "'Amount', 'ForKingdom', 'PlayerId', 'LastPayment'"); }
        public override List<string> Select()
        {
            SqlCommand readCommand = new SqlCommand($"SELECT * FROM Debts", ConsoleManager.Connection);
            SqlDataReader reader = readCommand.ExecuteReader();

            List<string> rows = new List<string>();

            while (reader.Read())
            {
                rows.Add($"{reader.GetInt32(0)} | {reader.GetString(1)} | {reader.GetInt32(2)} | {reader.GetDateTime(3)}");
            }

            reader.Close();
            return rows;
        }

        public override string GetItemCondition(int index)
        {
            SqlCommand readCommand = new SqlCommand($"SELECT * FROM Debts", ConsoleManager.Connection);
            SqlDataReader reader = readCommand.ExecuteReader();

            List<string> rows = new List<string>();

            for (int i = 0; i != index; i++)
            {
                reader.Read();
            }
            string outCondition = $"ForKingdom = '{reader.GetInt32(1)}' AND PlayerId = '{reader.GetInt32(2)}'";
            reader.Close();
            return outCondition;
        }

        public override void Insert(string args)
        {
            string insertQuery = $"INSERT INTO Debts (Amount, ForKingdom, PlayerId, LastPayment) VALUES ({args})";
            ExecuteQuery(insertQuery);
        }

        public override void Update(string args)
        {

        }

        public override void Delete(string conditions)
        {
            string deleteQuery = $"DELETE FROM Debts WHERE ({conditions})";
            ExecuteQuery(deleteQuery);
        }
    }
    public class KingdomRelationsFormat : TableFormat
    {
        public override (int parameters, string format) InsertFormat { get => (3, "'Kingdom1Name', 'Kingdom2Name', 'PlayerId', 'Relation'"); }
        public override List<string> Select()
        {
            SqlCommand readCommand = new SqlCommand($"SELECT * FROM KingdomRelations", ConsoleManager.Connection);
            SqlDataReader reader = readCommand.ExecuteReader();

            List<string> rows = new List<string>();

            while (reader.Read())
            {
                rows.Add($"{reader.GetString(0)} | {reader.GetString(1)} | {reader.GetInt32(2)} | {reader.GetInt32(3)}");
            }

            reader.Close();
            return rows;
        }

        public override string GetItemCondition(int index)
        {
            SqlCommand readCommand = new SqlCommand($"SELECT * FROM KingdomRelations", ConsoleManager.Connection);
            SqlDataReader reader = readCommand.ExecuteReader();

            List<string> rows = new List<string>();

            for (int i = 0; i != index; i++)
            {
                reader.Read();
            }
            string outCondition = $"Kingdom1Name = '{reader.GetInt32(0)}' AND Kingdom2Name = '{reader.GetInt32(1)}' AND PlayerId = '{reader.GetInt32(2)}'";
            reader.Close();
            return outCondition;
        }


        public override void Insert(string args)
        {
            string insertQuery = $"INSERT INTO KingdomRelations (Kingdom1Name, Kingdom2Name, PlayerId, Relation) VALUES ({args})";
            ExecuteQuery(insertQuery);
        }

        public override void Update(string args)
        {

        }

        public override void Delete(string conditions)
        {
            string deleteQuery = $"DELETE FROM KingdomRelations WHERE ({conditions})";
            ExecuteQuery(deleteQuery);
        }
    }

}
