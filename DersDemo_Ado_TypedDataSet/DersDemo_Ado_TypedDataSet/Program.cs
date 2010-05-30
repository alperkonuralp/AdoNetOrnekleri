using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DersDemo_Ado_TypedDataSet.DataLayer;
using DersDemo_Ado_TypedDataSet.DataLayer.NorthwindDataSetTableAdapters;

namespace DersDemo_Ado_TypedDataSet
{
    class Program
    {
        static void Main(string[] args)
        {
            using (NorthwindDataSet ds =
                new NorthwindDataSet())
            using (CategoriesTableAdapter tac =
                new CategoriesTableAdapter())
            using (ProductsTableAdapter tap =
                new ProductsTableAdapter())
            {
                tac.Fill(ds.Categories);
                tap.Fill(ds.Products);

                foreach (var item in ds.Categories)
                {
                    Console.WriteLine("{0} {1} {2}",
                        item.ItemArray);

                    NorthwindDataSet.ProductsRow[] childs =
                        item.GetProductsRows();
                    foreach (var item2 in childs)
                    {
                        Console.WriteLine("\t{0} {1} {2} {3} ",
                            item2.CategoryID,
                            item2.ProductID,
                            item2.ProductName,
                            item2.UnitPrice);
                    }
                }
            }
        }
    }
}
