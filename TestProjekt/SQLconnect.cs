using System;
using MySql.Data.MySqlClient;

namespace TestProjekt
{
    public class SQLconnect : Params
    {
        MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
        public string[] list;

        public SQLconnect()
        {
            conn_string.Server = Server;
            conn_string.Port = Port;
            conn_string.UserID = UserID;
            conn_string.Password = PWD;
            conn_string.Database = Database;
        }

        public void SQLopen()
        {
            MySqlConnection MyCon = new MySqlConnection(conn_string.ToString());
            MyCon.Open();
        }

        public void SQLclose()
        {
            MySqlConnection MyCon = new MySqlConnection();
            MyCon.Close();
        }

        public string[] SQLselect()
        {
            MySqlConnection MyCon = new MySqlConnection(conn_string.ToString());
            MySqlCommand cmd = new MySqlCommand("SELECT Länge FROM Dingelsdorf;", MyCon);


            try
            {
                //MyCon.Open();
                //Console.WriteLine("Open");

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    for (int i = 0; i < reader.GetString(0).Length; i++)
                    {
                        list[i] = reader.GetString(0).ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return list;
        }

    }
}
