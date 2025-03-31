using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dragon_database
{
    public abstract class TableFormat
    {

        public void ExecuteQuery(string query, SqlConnection connection)
        {
            SqlCommand insertCommand = new SqlCommand(query, connection);

            int rowsAffected = insertCommand.ExecuteNonQuery();
            Console.WriteLine($"{rowsAffected} rows successfully affected.");
        }

        public abstract List<string> Select(SqlConnection connection);

        public abstract void Insert(object[] args);

        public abstract void Update(object[] args);

        public abstract void Delete(object[] args);

    }

    public class PlayerFormat : TableFormat
    {
        public override List<string> Select(SqlConnection connection)
        {
            SqlCommand readCommand = new SqlCommand($"SELECT * FROM Players", connection);
            SqlDataReader reader = readCommand.ExecuteReader();

            List<string> rows = new List<string>();

            while (reader.Read())
            {
                rows.Add($"{reader.GetInt32(0)} | {reader.GetString(1)} | {reader.GetString(2)} | {reader.GetInt32(3)}");
            }

            reader.Close();
            return rows;
        }


        public override void Insert(object[] args)
        {

        }

        public override void Update(object[] args)
        {

        }

        public override void Delete(object[] args)
        {

        }
    }
    public class HoardFormat : TableFormat
    {
        public override List<string> Select(SqlConnection connection)
        {
            SqlCommand readCommand = new SqlCommand($"SELECT * FROM Hoard", connection);
            SqlDataReader reader = readCommand.ExecuteReader();

            List<string> rows = new List<string>();

            while (reader.Read())
            {
                rows.Add($"{reader.GetInt32(0)} | {reader.GetInt32(1)}");
            }

            reader.Close();
            return rows;
        }

        public override void Insert(object[] args)
        {

        }

        public override void Update(object[] args)
        {

        }

        public override void Delete(object[] args)
        {

        }
    }
    public class TreasureFormat : TableFormat
    {
        public override List<string> Select(SqlConnection connection)
        {
            SqlCommand readCommand = new SqlCommand($"SELECT * FROM Treasures", connection);
            SqlDataReader reader = readCommand.ExecuteReader();

            List<string> rows = new List<string>();

            while (reader.Read())
            {
                rows.Add($"{reader.GetInt32(0)} | {reader.GetInt32(1)} | {reader.GetString(2)} | {reader.GetInt32(3)}");
            }

            reader.Close();
            return rows;
        }

        public override void Insert(object[] args)
        {

        }

        public override void Update(object[] args)
        {

        }

        public override void Delete(object[] args)
        {

        }
    }
    public class KingdomsFormat : TableFormat
    {
        public override List<string> Select(SqlConnection connection)
        {
            SqlCommand readCommand = new SqlCommand($"SELECT * FROM Kingdoms", connection);
            SqlDataReader reader = readCommand.ExecuteReader();

            List<string> rows = new List<string>();

            while (reader.Read())
            {
                rows.Add($"{reader.GetInt32(0)} | {reader.GetInt32(1)} | {reader.GetInt32(2)} | {reader.GetInt32(3)} | {reader.GetString(3)}");
            }

            reader.Close();
            return rows;
        }

        public override void Insert(object[] args)
        {

        }

        public override void Update(object[] args)
        {

        }

        public override void Delete(object[] args)
        {

        }
    }
    public class DebtFormat : TableFormat
    {
        public override List<string> Select(SqlConnection connection)
        {
            SqlCommand readCommand = new SqlCommand($"SELECT * FROM Debt", connection);
            SqlDataReader reader = readCommand.ExecuteReader();

            List<string> rows = new List<string>();

            while (reader.Read())
            {
                rows.Add($"{reader.GetInt32(0)} | {reader.GetString(1)} | {reader.GetInt32(2)} | {reader.GetDateTime(3)}");
            }

            reader.Close();
            return rows;
        }

        public override void Insert(object[] args)
        {

        }

        public override void Update(object[] args)
        {

        }

        public override void Delete(object[] args)
        {

        }
    }
    public class KingdomRelationsFormat : TableFormat
    {
        public override List<string> Select(SqlConnection connection)
        {
            SqlCommand readCommand = new SqlCommand($"SELECT * FROM KingdomRelations", connection);
            SqlDataReader reader = readCommand.ExecuteReader();

            List<string> rows = new List<string>();

            while (reader.Read())
            {
                rows.Add($"{reader.GetString(0)} | {reader.GetString(1)} | {reader.GetInt32(2)} | {reader.GetInt32(3)}");
            }

            reader.Close();
            return rows;
        }

        public override void Insert(object[] args)
        {

        }

        public override void Update(object[] args)
        {

        }

        public override void Delete(object[] args)
        {

        }
    }

}
