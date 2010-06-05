using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;


namespace DersDemo_Ado_XmlDocument_XDocument
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument xd = new XmlDocument();
            xd.AppendChild(
                xd.CreateXmlDeclaration("1.0", "UTF-8", "yes"));

            XmlElement root =
                xd.CreateElement("NorthwindDataSet");

            XmlElement products =
                xd.CreateElement("Products");

            XmlAttribute productID =
                xd.CreateAttribute("ProductID");

            productID.Value = "1";

            products.Attributes.Append(productID);



            XmlElement productName =
                xd.CreateElement("ProductName");
            productName.AppendChild(
                xd.CreateTextNode("Chai"));

            products.AppendChild(productName);


            XmlElement supplierID =
               xd.CreateElement("SupplierID");
            supplierID.AppendChild(
                xd.CreateTextNode("1"));

            products.AppendChild(supplierID);

            root.AppendChild(products);

            xd.AppendChild(root);

            //xd.Save(Console.Out);


            // XDocument
            XDocument xdoc = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("NorthwindDataSet",
                    new XElement("Products",
                        new XAttribute("ProductID", 1),
                        new XElement("ProductName", "Chai"),
                        new XElement("SupplierID", 1))));


            xdoc.Save(Console.Out);

            XDocument xdoc2 = XDocument.Load(
                @"C:\Documents and Settings\Administrator\Desktop\ara.xml",
                LoadOptions.SetLineInfo);


            var sonuc = xdoc2
                    .Descendants(XName.Get("Products", "http://tempuri.org/NorthwindDataSet.xsd"))
                //.Where(x => x.Element("ProductID").Value == "1")
                    .ToArray();



            var sonuc2 = xdoc2
                    .Descendants(XName.Get("Products", "http://tempuri.org/NorthwindDataSet.xsd"))
                    .Where(x => x.Element(XName.Get("ProductID", "http://tempuri.org/NorthwindDataSet.xsd")).Value == "1")
                    .ToArray();

            XDocument xdoc3 =
                XDocument.Load("http://realtime.paragaranti.com/asp/xml/icpiyasaX.asp");


            var datas = (from x in xdoc3.Descendants("STOCK")
                         select new
                         {
                             Name = x.Element("DESC").Value,
                             Price = x.Element("LAST").Value
                         }).ToArray();


            //var datas = xdoc3
            //    .Descendants("stock")
            //    .Select();

        }
    }
}
