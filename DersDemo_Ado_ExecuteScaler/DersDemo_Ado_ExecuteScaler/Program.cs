using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace DersDemo_Ado_ExecuteScaler
{
    class Program
    {
        static void Main(string[] args)
        {
            // SELECT COUNT(*) FROM Products
            using (SqlConnection sc = new SqlConnection(
                "Data Source=.; " +
                "Initial Catalog=Northwind; " +
                "Integrated Security=True; "))
            {
                sc.Open();

                // 1.yol
                //SqlCommand scom = new SqlCommand("SELECT COUNT(*) FROM Products", sc);

                // 2.yol
                //SqlCommand scom = new SqlCommand();
                //scom.CommandText = "SELECT COUNT(*) FROM Products";
                //scom.Connection = sc;

                // 3. yol
                SqlCommand scom = sc.CreateCommand();
                scom.CommandText =
                    "SELECT COUNT(*) FROM Products";

                Console.WriteLine(scom.ExecuteScalar());

            }

        }
    }
}
