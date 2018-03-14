using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace TestProjekt
{
    public class SQLconnect : Params
    {
        protected MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
        protected List<string> list = new List<string>();
        //public string[] list;

        //Übergabe der Parameter zum öffnen der SQL Datenbank
        public SQLconnect()
        {
            conn_string.Server = Server;
            conn_string.Port = Port;
            conn_string.UserID = UserID;
            conn_string.Password = PWD;
            conn_string.Database = Database;
        }

        //Schließen der aktuellen Verbindung zur Datenbank
        public void SQLclose()
        {
            MySqlConnection MyCon = new MySqlConnection();
            MyCon.Close();
        }

        //Datenwerte aus der Datenbank auslesen
        public List<string> SQLselect(string SearchParam, string Harbour)
        {
            MySqlConnection MyCon = new MySqlConnection(conn_string.ToString());
            MyCon.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT " + SearchParam + " FROM " + Harbour + ";", MyCon);
            list.Clear();

            try
            {
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(reader.GetString(0));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            MyCon.Close();
            return list;
        }

        //Datensätze updaten
        public void SQLupdate(string UpdateParam, string Harbour)
        {
            MySqlConnection MyCon = new MySqlConnection(conn_string.ToString());
            MyCon.Open();
            MySqlCommand cmd = new MySqlCommand("UPDATE " + UpdateParam + " FROM " + Harbour + ";", MyCon);
            try
            {
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            MyCon.Close();
        }

        //Datensätze löschen
        public void SQLdelete(string DeleteParam, string Harbour)
        {
            MySqlConnection MyCon = new MySqlConnection(conn_string.ToString());
            MyCon.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE " + DeleteParam + " FROM " + Harbour + ";", MyCon);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            MyCon.Close();
        }

    }
}
