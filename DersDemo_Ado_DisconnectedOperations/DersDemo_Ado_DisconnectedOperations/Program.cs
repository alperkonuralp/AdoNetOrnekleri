using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DersDemo_Ado_DisconnectedOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            DataSet ds = CreateDataSet();

            //foreach (DataRow item in ds.Tables["Categories"].Rows)
            //{
            //    //Console.WriteLine("{0} {1} {2}",
            //    //    item["CategoryID"],
            //    //    item["CategoryName"],
            //    //    item["Description"]);

            //    Console.WriteLine("{0} {1} {2}",
            //        item.ItemArray);
            //}

            //Console.WriteLine();

            //foreach (DataRow item in ds.Tables["Products"].Rows)
            //{
            //    //Console.WriteLine("{0} {1} {2} {3} {4} {5}",
            //    //    item["CategoryID"],
            //    //    item["ProductID"],
            //    //    item["ProductName"],
            //    //    item["UnitPrice"],
            //    //    item["UnitsInStock"],
            //    //    item["UnitsTotalPrice"]);

            //    Console.WriteLine("{0} {1} {2} {3} {4} {5}",
            //        item.ItemArray);
            //}

            //Console.ReadLine();
            //Console.Clear();
            //foreach (DataRow item in ds.Tables["Categories"].Rows)
            //{
            //    Console.WriteLine("{0} {1} {2}", item.ItemArray);

            //    DataRow[] subItems =
            //        item.GetChildRows("rlCategoryID");

            //    //Products tablosundan veriler
            //    foreach (DataRow item2 in subItems)
            //    {
            //        Console.WriteLine(
            //            "\t{0} {1} {2} {3} {4} {5}",
            //            item2.ItemArray);
            //    }
            //    Console.WriteLine();
            //}

            //Console.ReadLine();
            //Console.Clear();

            //foreach (DataRow item in ds.Tables["Products"].Rows)
            //{
            //    DataRow drParent = item.GetParentRow("rlCategoryID");
            //    Console.Write("    {0} ", drParent["CategoryName"]);
            //    Console.WriteLine("{0} {1} {2} {3} {4} {5}",
            //        item.ItemArray);
            //}


            // dataset içerisindeki veriyi değiştirme
            DataRow dr = ds.Tables["Products"].Rows[0];
            dr.BeginEdit();

            dr["ProductName"] = "Silgi";
            dr["UnitPrice"] = 5.99;

            dr.EndEdit();

            // dataset içindeki veriyi silme
            DataRow[] dr2 = ds.Tables["Products"]
                .Select("ProductID = 3");
            foreach (var item in dr2)
            {
                item.Delete();
            }

            // tablodaki sadece değişiklik olan satırları alma
            DataTable dt = 
                ds.Tables["Products"].GetChanges();

            // dataset üzerindeki sadece değişiklik olan verileri alma
            DataSet ds2 = ds.GetChanges();

            // yapılan işlemleri geri alma.
            //ds.RejectChanges();
            ds.Tables["Products"].RejectChanges();
        }

        private static DataSet CreateDataSet()
        {
            // dataset'i oluşturuyoruz.
            DataSet ds = new DataSet("NorthwindDataSet");

            // Categories Tablomuzu oluşturuyoruz.
            DataTable dtCategories =
                ds.Tables.Add("Categories");

            // CategoryID Kolonunu oluşturuyoruz.
            DataColumn dcCategoryID =
                dtCategories.Columns.Add(
                    "CategoryID", typeof(int));
            // CategoryID'nin Null değer içeremeceğini tanımlıyoruz.
            dcCategoryID.AllowDBNull = false;
            // CategoryID'nin Identity kolon olduğunu söyledik.
            dcCategoryID.AutoIncrement = true;
            // CategoryID'nin Caption Değerini tanımladık.
            dcCategoryID.Caption = "Category ID";

            // CategoryID'yi primary key olarak tanımladık.
            dtCategories.PrimaryKey =
                new DataColumn[] { dcCategoryID };

            // CategoryName kolonunu tanımladık
            DataColumn dcCategoryName =
                dtCategories.Columns.Add(
                    "CategoryName", typeof(string));
            // CategoryName'in Max 15 karakter almasını sağladık
            dcCategoryName.MaxLength = 15;
            // CategoryName'in Null değer içerememesini sağladık
            dcCategoryName.AllowDBNull = false;

            // Description kolonunu tanımladık.
            DataColumn dcDescription =
                dtCategories.Columns.Add(
                    "Description", typeof(string));
            //description kolonun null değer içermesini tanımladık.
            dcDescription.AllowDBNull = true;



            // Products tablosunu tanımlıyoruz.
            DataTable dtProducts =
                ds.Tables.Add("Products");

            // ProductID kolonunu tanımlıyoruz.
            DataColumn dcProductID =
                dtProducts.Columns.Add(
                    "ProductID", typeof(int));

            // ProductID Null değer içeremeyeceğini söylüyoruz.
            dcProductID.AllowDBNull = false;
            // ProductID'nin Identity Kolon oluğunu söyleyelim
            dcProductID.AutoIncrement = true;

            // productID kolonunu primarykey yapalım
            dtProducts.PrimaryKey =
                new DataColumn[] { dcProductID };


            // CategoryID kolonunu tanımlayalım.
            DataColumn dcCategoryID2 =
                dtProducts.Columns.Add(
                    "CategoryID", typeof(int));
            // CategoryID'nin null değer içeremeyeceğini tanımlayalım.
            dcCategoryID2.AllowDBNull = false;

            // ProductName kolonunu tanımlıyoruz.
            DataColumn dcProductName =
                dtProducts.Columns.Add(
                    "ProductName", typeof(string));

            // ProductName'i max 40 karakter olarak tanımlayalım.
            dcProductName.MaxLength = 40;
            // ProductName Null değer içeremez.
            dcProductName.AllowDBNull = false;


            //UnitPrice kolonunu hazırlayalım
            DataColumn dcUnitPrice =
                dtProducts.Columns.Add(
                    "UnitPrice", typeof(double));
            //UnitPrice null içeremez
            dcUnitPrice.AllowDBNull = false;
            // default değer atayalım
            dcUnitPrice.DefaultValue = 0.0;

            // UnitsInStock Kolonunu oluşturalım.
            DataColumn dcUnitsInStock =
                dtProducts.Columns.Add(
                    "UnitsInStock", typeof(short));
            // Null değer içeremez.
            dcUnitsInStock.AllowDBNull = false;
            // default value = 0 yapalım
            dcUnitsInStock.DefaultValue = (short)0;


            // Compute kolon olan UnitsTotalPrice kolonunu oluşturalım.
            DataColumn dcUnitsTotalPrice =
                dtProducts.Columns.Add(
                    "UnitsTotalPrice", typeof(double),
                    "UnitPrice * UnitsInStock");


            // Categories ve Product tablolarını birbirine bağlayalım.
            // Parent Kolon:
            DataColumn parentColumn =
                ds.Tables["Categories"].Columns["CategoryID"];
            // Child Kolon:
            DataColumn childColumn =
                ds.Tables["Products"].Columns["CategoryID"];

            DataRelation drl = ds.Relations.Add(
                "rlCategoryID", parentColumn, childColumn);



            // Verilerin Girilmesi :
            // categories tablosuna veri girelim.
            DataRow dr1 = ds.Tables["Categories"].NewRow();

            dr1["CategoryID"] = 1;
            dr1["CategoryName"] = "Kırtasiye";
            dr1["Description"] = "Boşşş";

            ds.Tables["Categories"].Rows.Add(dr1);

            //2. Satır
            dr1 = ds.Tables["Categories"].NewRow();

            dr1["CategoryID"] = 2;
            dr1["CategoryName"] = "Sağlık";
            dr1["Description"] = null;

            ds.Tables["Categories"].Rows.Add(dr1);

            // products veri girişi
            DataRow dr2 = ds.Tables["Products"].NewRow();
            dr2["ProductID"] = 1;
            dr2["ProductName"] = "Kalem";
            dr2["CategoryID"] = 1;
            dr2["UnitPrice"] = 0.75;
            dr2["UnitsInStock"] = 1000;

            ds.Tables["Products"].Rows.Add(dr2);

            // 2. ürün
            dr2 = ds.Tables["Products"].NewRow();
            dr2["ProductID"] = 2;
            dr2["ProductName"] = "Kalemtraş";
            dr2["CategoryID"] = 1;
            dr2["UnitPrice"] = 1.75;
            dr2["UnitsInStock"] = 100;

            ds.Tables["Products"].Rows.Add(dr2);

            // 3. ürün
            dr2 = ds.Tables["Products"].NewRow();
            dr2["ProductID"] = 3;
            dr2["ProductName"] = "Asprin";
            dr2["CategoryID"] = 2;
            dr2["UnitPrice"] = 3.99;
            dr2["UnitsInStock"] = 99;

            ds.Tables["Products"].Rows.Add(dr2);

            // 4. ürün
            dr2 = ds.Tables["Products"].NewRow();
            dr2["ProductID"] = 4;
            dr2["ProductName"] = "Teramisin";
            dr2["CategoryID"] = 2;
            dr2["UnitPrice"] = 6.99;
            dr2["UnitsInStock"] = 59;


            ds.Tables["Products"].Rows.Add(dr2);

            ds.AcceptChanges();

            return ds;
        }
    }
}
