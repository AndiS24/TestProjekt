using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;

namespace TestProjekt
{
    public class SQLactivity : SQLconnect
    {
        //MySqlConnection conn = new MySqlConnection();

        string text;


        public string SQLselect()
        {
            object MyCon = SQLopen();
            MySqlCommand cmd = new MySqlCommand("SELECT Länge FROM Dingelsdorf;", MyCon);
            string[] list;

            try
            {
                MyCon.Open();
                Console.WriteLine("Open");

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
        }
    }
}
