using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;

namespace TestProjekt
{
    class MainClass
    {
        public static void Main()
        {
            string Harbour = "Dingelsdorf";
            string SelectParam = "*";
            int StateParam = 1;
            string LengthParam = "10m";
            int Place = 4;
            List<string> text = new List<string>();
            SQLconnect db = new SQLconnect();
            db.SQLdeletePlace(Place, Harbour);
            //db.SQLupdateState(StateParam, Harbour, Place);
            //db.SQLupdateLenght(LengthParam, Harbour, Place);
            /*text = db.SQLselect(SelectParam, Harbour);
            foreach (var item in text)
            {
                Console.WriteLine(item);
            }*/
        }
    }
}
