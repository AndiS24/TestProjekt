using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace TestProjekt
{
    public class SQLconnect
    {
        protected MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();

        //Übergabe der Parameter zum öffnen der SQL Datenbank
        public SQLconnect()
        {
            Params param = new Params();

            conn_string.Server = param.Server;
            //conn_string.Port = param.Port;
            conn_string.UserID = param.UserID;
            conn_string.Password = param.PWD;
            conn_string.Database = param.Database;
        }

        /*
        //Schließen der aktuellen Verbindung zur Datenbank
        public void SQLclose()
        {
            MySqlConnection MyCon = new MySqlConnection();
            MyCon.Close();
        }*/

        //Datenwerte aus der Datenbank auslesen
       /* public List<string> SQLselect(string SelectParam, string Harbour, string Places, int ID)
        {
            List<string> list = new List<string>();
            MySqlConnection MyCon = new MySqlConnection(conn_string.ToString());
            try
            {
                MyCon.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT " + SelectParam + " FROM " + Harbour + " LEFT JOIN " + Places + " on ID = HarbourID WHERE ID = " + ID + ";", MyCon);
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
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\nEs konnte keine Verbindung hergestellt werden.");
            }
            MyCon.Close();
            return list;
        }*/

        public List<string> SQLselect(string SelectParam, string Harbour, string Places, int ID)
        {
            List<string> list = new List<string>();
            MySqlConnection MyCon = new MySqlConnection(conn_string.ToString());
            try
            {
                MyCon.Open();
                string sql = "SELECT @parSelectParam FROM @parHarbour LEFT JOIN @parPlaces ON ID = HarbourID WHERE ID = @parID;";
                MySqlCommand cmd = new MySqlCommand(sql, MyCon);
                cmd.CommandType = CommandType.Text;
                //("SELECT " + SelectParam + " FROM " + Harbour + " LEFT JOIN " + Places + " on ID = HarbourID WHERE ID = " + ID + ";"
                /*MySqlParameter parSelectParam = new MySqlParameter("@parSelectParam", MySqlDbType.VarChar);
                parSelectParam.Value = SelectParam;
                MySqlParameter parHarbour = new MySqlParameter("@parHarbour", MySqlDbType.Text);
                parHarbour.Value = Harbour;
                MySqlParameter parPlaces = new MySqlParameter("@parPlaces", MySqlDbType.Text);
                parPlaces.Value = Places;
                MySqlParameter parID = new MySqlParameter("@parID", MySqlDbType.Int16);
                parID.Value = ID;
                cmd.Parameters.Add(parSelectParam);
                cmd.Parameters.Add(parHarbour);
                cmd.Parameters.Add(parPlaces);
                cmd.Parameters.Add(parID);*/


                cmd.Parameters.Add("@parSelectParam", MySqlDbType.VarChar);
                cmd.Parameters.Add("@parHarbour", MySqlDbType.VarChar);
                cmd.Parameters.Add("@parPlaces", MySqlDbType.VarChar);
                cmd.Parameters.Add("@parID", MySqlDbType.Int16);
                cmd.Parameters["@parSelectParam"].Value = SelectParam;
                cmd.Parameters["@parHarbour"].Value = Harbour;
                cmd.Parameters["@parPlaces"].Value = Places;
                cmd.Parameters["@parID"].Value = ID;

                cmd.Prepare();
                cmd.ExecuteNonQuery();
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
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\nEs konnte keine Verbindung hergestellt werden.");
            }
            MyCon.Close();
            return list;
        }

        //"State" Spalte auf 0/1 setzen (1=belegt, 0=frei) 
        public void SQLupdateOcc(int UpdateParam, string Harbour, int place)
        {
            MySqlConnection MyCon = new MySqlConnection(conn_string.ToString());
            try
            {
                MyCon.Open(); //Überarbeiten!!!
                MySqlCommand cmd = new MySqlCommand("UPDATE " + Harbour + " SET State = " + UpdateParam + " WHERE Place = " + place + ";", MyCon);
                try
                {
                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + "\nStatus konnte nicht geändert werden.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\nEs konnte keine Verbindung hergestellt werden.");
            }
            MyCon.Close();
        }

        //"Length" Spalte verändern
        public void SQLupdateLenght(string LengthParam, string Harbour, int place)
        {
            MySqlConnection MyCon = new MySqlConnection(conn_string.ToString());
            try
            {
                MyCon.Open(); //Überarbeiten!!!
                MySqlCommand cmd = new MySqlCommand("UPDATE " + Harbour + " SET Length = '" + LengthParam + "' WHERE Place = " + place + ";", MyCon);
                try
                {
                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + "\nLänge konnte nicht geändert werden.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\nEs konnte keine Verbindung hergestellt werden.");
            }
            MyCon.Close();
        }

        //Platz X löschen
        public void SQLdeletePlace(int place, string Harbour)
        {
            MySqlConnection MyCon = new MySqlConnection(conn_string.ToString());
            try
            {
                MyCon.Open();//Überarbeiten!!!
                MySqlCommand cmd = new MySqlCommand("DELETE FROM " + Harbour + " WHERE Place = " + place + ";", MyCon);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + "\nPlatz konnte nicht gelöscht werden.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\nEs konnte keine Verbindung hergestellt werden.");
            }
            MyCon.Close();
        }
    }
}
