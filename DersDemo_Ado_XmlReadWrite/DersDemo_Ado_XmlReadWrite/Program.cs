using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace DersDemo_Ado_XmlReadWrite
{
    class Program
    {
        static void Main(string[] args)
        {
            MemoryStream ms = new MemoryStream();

            XmlTextWriter xtw =
                new XmlTextWriter(ms, Encoding.UTF8);
            xtw.Formatting = Formatting.Indented;
            //xtw.WriteProcessingInstruction(
            //    "xml", "version=\"1.0\" standalone=\"yes\"");


            xtw.WriteStartDocument();

            xtw.WriteStartElement("NorthwindDataSet");


            xtw.WriteStartElement("Products");
            xtw.WriteAttributeString("CategoryID", "1");


            xtw.WriteStartElement("ProductID");

            xtw.WriteValue(1);

            xtw.WriteEndElement();


            xtw.WriteStartElement("ProductName");

            xtw.WriteValue("Chai");

            xtw.WriteEndElement();




            xtw.WriteEndElement();

            xtw.WriteEndElement();

            xtw.WriteEndDocument();

            xtw.Flush();


            Console.WriteLine(Encoding.UTF8.GetString(ms.ToArray()));
        }
    }
}
