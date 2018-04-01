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
            string Harbour = "Harbours";
            string SelectParam = "Harbour";
            string Places = "Places";
            int ID = 3;
            //int OccParam = 1;
            //string LengthParam = "10m";
            //int Place = 4;
            List<string> text = new List<string>();
            SQLconnect db = new SQLconnect();
            //db.SQLdeletePlace(Place, Harbour);
            //db.SQLupdateOcc(OccParam, Harbour, Place);
            //db.SQLupdateLenght(LengthParam, Harbour, Place);
            text = db.SQLselect(SelectParam, Harbour, Places, ID);
            foreach (var item in text)
            {
                Console.WriteLine(item);
            }
        }
    }
}
