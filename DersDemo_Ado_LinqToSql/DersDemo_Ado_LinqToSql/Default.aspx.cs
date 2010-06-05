using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DersDemo_Ado_LinqToSql.DataLayer;

namespace DersDemo_Ado_LinqToSql
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ara();
            using (NorthwindDBDataContext datas =
                new NorthwindDBDataContext())
            {
                if (!Page.IsPostBack)
                {
                    var c = from x in datas.Categories
                            orderby x.CategoryName descending
                            select new
                            {
                                x.CategoryID,
                                x.CategoryName
                            };

                    ddl.DataSource = c;
                    ddl.DataTextField = "CategoryName";
                    ddl.DataValueField = "CategoryID";
                    ddl.DataBind();
                }

                int cid;
                if (ddl.SelectedIndex >= 0)
                {
                    cid = int.Parse(ddl.SelectedValue);
                }
                else
                {
                    ddl.SelectedIndex = 0;
                    cid = int.Parse(ddl.Items[0].Value);
                }

                var p = from x in datas.Products
                        where x.CategoryID == cid
                        select x;

                gv.DataSource = p;
                gv.DataBind();
            }

        }

        public void ara()
        {
            lb.Items.Clear();
            int a, b, c, d;
            for (int i = 1000; i < 10000; i++)
            {
                a = i % 10;
                b = (i % 100 - a) / 10;
                c = (i % 1000 - b * 10 - a) / 100;
                d = (i - c * 100 - b * 10 - a) / 1000;
                if (i == (a * b * c * d))
                {
                    lb.Items.Add(i.ToString());
                }
            }
        }
    }
}
