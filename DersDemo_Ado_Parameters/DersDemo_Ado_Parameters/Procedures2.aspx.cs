using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DersDemo_Ado_Parameters.DataSet1TableAdapters;

namespace DersDemo_Ado_Parameters
{
    public partial class Procedures2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bSearch_Click(object sender, EventArgs e)
        {
            using (SP_GetOrdersByDateRangeTableAdapter ta =
                new SP_GetOrdersByDateRangeTableAdapter())
            {
                decimal? totalPrice = 0;

                var dt = ta.GetData(
                    DateTime.Parse(tbStart.Text),
                    DateTime.Parse(tbEnd.Text),
                    ref totalPrice);

                Label1.Text = string.Format(
                    "Total Price: {0:C}", totalPrice);

                gv.DataSource = dt;
                gv.DataBind();
            }
        }
    }
}
