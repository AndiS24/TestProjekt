using System;
using MySql.Data.MySqlClient;
using System.Data;

namespace TestProjekt
{
    class MainClass
    {


        public static void Main(string[] args)
        {
            SQLconnect db = new SQLconnect();

            db.SQLopen();
            Console.WriteLine("DB offen");
            //text = db.SQLselect();
            //Console.WriteLine(text);
            db.SQLclose();
            Console.WriteLine("DB geschlossen");

        }
    }
}
