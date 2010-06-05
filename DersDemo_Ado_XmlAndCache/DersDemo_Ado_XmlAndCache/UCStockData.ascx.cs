using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Xml.Linq;
using System.Web.Caching;
using System.Globalization;
using System.ComponentModel;
using DersDemo_Ado_XmlAndCache.Properties;

namespace DersDemo_Ado_XmlAndCache
{
    [DataObject]
    public partial class UCStockData : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //gv.DataSource = StockDatas;
            //gv.DataBind();
        }

        protected StockData[] ReadStockDataFromInternet()
        {
            string url =
                WebConfigurationManager.AppSettings["StockDataUrl"] ??
                "http://realtime.paragaranti.com/asp/xml/icpiyasaX.asp";

            XDocument xd = XDocument.Load(url);

            return xd.Descendants("STOCK")
                .Select(x =>
                new StockData()
                {
                    Symbol = x.Element("SYMBOL").Value,
                    Description = x.Element("DESC").Value,
                    LastPrice = double.Parse(x.Element("LAST").Value),
                    Pernc = double.Parse(x.Element("PERNC").Value),
                    LastModifiedDateTime = x.Element("LAST_MOD").Value
                })
                .ToArray();
        }

        public StockData[] StockDatas
        {
            get
            {
                if (HttpContext.Current.Cache["StockDatas"] is StockData[])
                {
                    return (StockData[])HttpContext.Current.Cache["StockDatas"];
                }

                StockData[] dizi = ReadStockDataFromInternet();

                HttpContext.Current.Cache.Add("StockDatas", dizi, null,
                    System.Web.Caching.Cache.NoAbsoluteExpiration,
                    new TimeSpan(0, 30, 0),
                    CacheItemPriority.Normal,
                    null);

                return dizi;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public StockData[] GetStockDatas()
        {
            return StockDatas;
        }

        protected void iDown_Init(object sender, EventArgs e)
        {
            Image i = sender as Image;
            i.ImageUrl = Page.ClientScript.GetWebResourceUrl(typeof(Properties.Resources), "DersDemo_Ado_XmlAndCache.Resources.down.png");
        }

        protected void iUp_Init(object sender, EventArgs e)
        {
            Image i = sender as Image;
            i.ImageUrl = Page.ClientScript.GetWebResourceUrl(typeof(Properties.Resources), "DersDemo_Ado_XmlAndCache.Resources.up.png");
        }
    }

    public class StockData
    {
        public string Symbol { get; set; }
        public string Description { get; set; }
        public double LastPrice { get; set; }
        public double Pernc { get; set; }
        public string LastModifiedDateTime { get; set; }
    }
}