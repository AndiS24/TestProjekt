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
        public List<string> SQLselect(string SelectParam, string Harbour)
        {
            MySqlConnection MyCon = new MySqlConnection(conn_string.ToString());
            try
            {
                MyCon.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\nEs konnte keine Verbindung hergestellt werden.");
            }

            MySqlCommand cmd = new MySqlCommand("SELECT " + SelectParam + " FROM " + Harbour + ";", MyCon);
            list.Clear();

            try
            {
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        list.Add(reader.GetString(i));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\nDatenauswahl fehlgeschlagen.");
            }
            MyCon.Close();
            return list;
        }

        //"State" Spalte auf 0/1 setzen (1=frei, 0=belegt) 
        public void SQLupdateState(int UpdateParam, string Harbour, int place)
        {
            MySqlConnection MyCon = new MySqlConnection(conn_string.ToString());
            try
            {
                MyCon.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\nEs konnte keine Verbindung hergestellt werden.");
            }
            MySqlCommand cmd = new MySqlCommand("UPDATE " + Harbour + " SET State = " + UpdateParam + " WHERE Place = " + place + ";", MyCon);
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

        //"Length" Spalte verändern
        public void SQLupdateLenght(string LengthParam, string Harbour, int place)
        {
            MySqlConnection MyCon = new MySqlConnection(conn_string.ToString());
            try
            {
                MyCon.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\nEs konnte keine Verbindung hergestellt werden.");
            }
            MySqlCommand cmd = new MySqlCommand("UPDATE " + Harbour + " SET Length = '" + LengthParam + "' WHERE Place = " + place + ";", MyCon);
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

        //Platz X löschen
        public void SQLdeletePlace(int place, string Harbour)
        {
            MySqlConnection MyCon = new MySqlConnection(conn_string.ToString());
            try
            {
                MyCon.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\nEs konnte keine Verbindung hergestellt werden.");
            }
            MySqlCommand cmd = new MySqlCommand("DELETE FROM " + Harbour + " WHERE Place = " + place + ";", MyCon);
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
