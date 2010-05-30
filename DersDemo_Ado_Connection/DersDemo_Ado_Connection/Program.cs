using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;


using System.Threading;
using System.Reflection;
using System.IO;
using System.Data;

namespace DersDemo_Ado_Connection
{
    class Program
    {
        static void Main(string[] args)
        {
            string fn =
                    "Northwind.sqlite";
            //Path.Combine(
            //    Path.GetDirectoryName(
            //        typeof(Program).Assembly.CodeBase),
            //    "Northwind.sqlite");

            using (SQLiteConnection con =
                new SQLiteConnection("data source=" + fn))
            {
                con.Open();

                // ExecuteReader Örneği
                //SQLiteCommand com = new SQLiteCommand(
                //    "SELECT * FROM Products;",
                //    con);

                //SQLiteDataReader dr = com.ExecuteReader();

                //while (dr.Read())
                //{
                //    Console.WriteLine("{0,5} {1,-20} {2:C} {3}",
                //        dr.GetInt32(0),
                //        dr.GetString(dr.GetOrdinal("ProductName")),
                //        dr.GetDouble(dr.GetOrdinal("UnitPrice")),
                //        dr.GetInt32(dr.GetOrdinal("UnitsInStock"))
                //        );

                //}

                //// Execute Non Query Örneği
                //SQLiteCommand com = new SQLiteCommand();
                //com.CommandText = 
                //    "INSERT INTO Products"+
                //    "(ProductName, CategoryID, UnitPrice, UnitsInStock) "+
                //    "VALUES('Kağıt', 1, 0.10, 1000);";
                //com.Connection = con;

                //com.ExecuteNonQuery();

                DataTable dt = con.GetSchema("Tables");
            }
        }
    }
}
