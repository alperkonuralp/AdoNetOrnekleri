using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DersDemo_Ado_DataAdapter
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlDataAdapter daCategories =
                new SqlDataAdapter(
                    "SELECT * FROM Categories",
                    GetConnection());

            //daCategories.InsertCommand =
            //    new SqlCommand(
            //        "INSERT INTO Categories(CategoryName, Description, Picture) " +
            //        "VALUES(@CategoryName, @Description, @Picture);",
            //        daCategories.SelectCommand.Connection);
            //daCategories.InsertCommand.Parameters.Add(
            //    "@CategoryName", System.Data.SqlDbType.NVarChar, 15);
            //daCategories.InsertCommand.Parameters.Add(
            //    "@Description", System.Data.SqlDbType.NText);
            //daCategories.InsertCommand.Parameters.Add(
            //    "@Picture", System.Data.SqlDbType.Image);


            SqlCommandBuilder scb =
                new SqlCommandBuilder(daCategories);



            SqlDataAdapter daProducts =
                new SqlDataAdapter(
                    "SELECT * FROM Products",
                    GetConnection());

            SqlCommandBuilder scb2 =
                new SqlCommandBuilder(daProducts);


            DataSet ds = new DataSet("NorthwindDataSet");

            daCategories.Fill(ds, "Kategoriler");
            daProducts.Fill(ds, "Urunler");

            ds.Tables["Kategoriler"].Columns["CategoryID"].AutoIncrement = true;

            // Primary Key Tanımlama
            ds.Tables["Kategoriler"].PrimaryKey =
                new DataColumn[] { 
                    ds.Tables["Kategoriler"].Columns["CategoryID"] };

            // yeni satır oluşturma
            DataRow drc1 =
                ds.Tables["Kategoriler"].NewRow();

            drc1["CategoryName"] = "Sağlık";
            drc1["Description"] = "Sağlık Ürünleri";

            ds.Tables["Kategoriler"].Rows.Add(drc1);

            // veri değiştirme
            DataRow drc2 =
                ds.Tables["Kategoriler"].Rows.Find(9);
            drc2.BeginEdit();

            drc2["CategoryName"] = "Nalburiye";
            drc2["Description"] = null;

            drc2.EndEdit();


            // veri silme
            DataRow drc3 =
                ds.Tables["Kategoriler"].Rows.Find(11);
            drc3.Delete();

            daCategories.Update(ds, "Kategoriler");
        }

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(
                "Data Source=.; Initial Catalog=Northwind; " +
                "Integrated Security=true");
        }
    }
}
