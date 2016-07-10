using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace PetrolPump
{
    class MySqlFunctions
    {
        public static int CashierID;
        public static string CashierName;
        public static string CashierType;
        string ConnString = "Server=localhost;Database=petrolpump;UID=root;Password=";
        MySqlConnection Conn;
        
        public MySqlFunctions()
        {
            Conn = new MySqlConnection(ConnString);
            Conn.Open();
        }

        public void Dest()
        {
            Conn.Close();
        }

        public bool NonReturnQuery(string Query)
        {
            MySqlCommand cmd = new MySqlCommand(Query, Conn);
            try
            {
                return cmd.ExecuteNonQuery() >= 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public MySqlDataReader SelectQuery(string Query)
        {
            MySqlCommand cmd = new MySqlCommand(Query, Conn);
            return cmd.ExecuteReader();
        }

        public string ScalarString(string Query)
        {
            MySqlCommand cmd = new MySqlCommand(Query, Conn);
            return cmd.ExecuteScalar() + "";
        }

        public int ScalarInt(string Query)
        {
            MySqlCommand cmd = new MySqlCommand(Query, Conn);
            string Ret = cmd.ExecuteScalar() + "";
            if (Ret == "")
                return -1;
            return Convert.ToInt32(Ret);
        }

        public void BackUp(string Path)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = Conn;
            MySqlBackup mb = new MySqlBackup(cmd);
            mb.ExportToFile(Path);
        }

        public void Restore(string Path)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = Conn;
            MySqlBackup mb = new MySqlBackup(cmd);
            mb.ImportFromFile(Path);
        }
    }
}
