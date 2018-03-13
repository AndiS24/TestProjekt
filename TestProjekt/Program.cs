using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;

namespace TestProjekt
{
    class MainClass
    {
        

        public static void Main(string[] args)
        {
            string a = "Länge";
            string b = "Dingelsdorf";
            List<string> text = new List<string>();
            SQLconnect db = new SQLconnect();
            text = db.SQLselect(a,b);
            foreach (var item in text)
            {
                Console.WriteLine(item);
            }
        }
    }
}
