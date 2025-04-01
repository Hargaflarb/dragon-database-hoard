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



        public void ExecuteQuery(string query)
        {
            SqlCommand insertCommand = new SqlCommand(query, ConsoleManager.Connection);

            int rowsAffected = insertCommand.ExecuteNonQuery();
            Console.WriteLine($"{rowsAffected} rows successfully affected.");
        }

        public abstract List<string> Select();

        public abstract void Insert(string args);

        public abstract void Update(string args);

        public abstract void Delete(string args);

    }

    public class PlayerFormat : TableFormat
    {
        public override (int parameters, string format) InsertFormat { get => (3, "'Name', 'Password', 'Hunger'"); }


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


        public override void Insert(string args)
        {
            string insertQuery = $"INSERT INTO Players (Username, LoginPassword, Hunger) VALUES ({args})";
            ExecuteQuery(insertQuery);
        }

        public override void Update(string args)
        {

        }

        public override void Delete(string args)
        {
            string deleteQuery = $"DELETE FROM Player WHERE (PlayerId = '{ID}')";
            ExecuteQuery(deleteQuery);
        }
    }
    public class HoardFormat : TableFormat
    {
        public override (int parameters, string format) InsertFormat { get => (3, "(PlayerId, MoneyAmount)"); }

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

        public override void Insert(string args)
        {
            string insertQuery = $"INSERT INTO Players (PlayerId, MoneyAmount) VALUES ({args})";
            ExecuteQuery(insertQuery);
        }

        public override void Update(string args)
        {

        }

        public override void Delete(string args)
        {

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

        public override void Insert(string args)
        {
            string insertQuery = $"INSERT INTO Players (PlayerId, Rarity, TreasureName) VALUES ({args})";
            ExecuteQuery(insertQuery);
        }

        public override void Update(string args)
        {

        }

        public override void Delete(string args)
        {

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

        public override void Insert(string args)
        {
            string insertQuery = $"INSERT INTO Players (PlayerId, Approval, Fear, Economy, KingdomName) VALUES ({args})";
            ExecuteQuery(insertQuery);
        }

        public override void Update(string args)
        {

        }

        public override void Delete(string args)
        {

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

        public override void Insert(string args)
        {
            string insertQuery = $"INSERT INTO KingdomRelations (Amount, ForKingdom, PlayerId, LastPayment) VALUES ({args})";
            ExecuteQuery(insertQuery);
        }

        public override void Update(string args)
        {

        }

        public override void Delete(string args)
        {

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

        public override void Insert(string args)
        {
            string insertQuery = $"INSERT INTO KingdomRelations (Kingdom1Name, Kingdom2Name, PlayerId, Relation) VALUES ({args})";
            ExecuteQuery(insertQuery);
        }

        public override void Update(string args)
        {

        }

        public override void Delete(string args)
        {

        }
    }

}
