using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace DersDemo_Ado_Parameters
{
    public partial class FitrelemedeParametre : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bSearch_Click(object sender, EventArgs e)
        {
            using (SqlConnection sc = new SqlConnection(
                "Data Source=.; Initial Catalog=Northwind;" +
                "Integrated Security=true;"))
            {
                sc.Open();

                SqlCommand scom = new SqlCommand(
                    "SELECT * FROM Orders " +
                    "WHERE OrderDate BETWEEN " +
                    "@Start AND @End",
                    sc);

                scom.Parameters.Add("@Start", System.Data.SqlDbType.DateTime);
                scom.Parameters["@Start"].Value = DateTime.Parse(tbStart.Text);

                scom.Parameters.Add("@End", System.Data.SqlDbType.DateTime);
                scom.Parameters["@End"].Value = DateTime.Parse(tbEnd.Text);

                SqlDataReader sdr = scom.ExecuteReader();

                gv.DataSource = sdr;
                gv.DataBind();

            }
        }
    }
}
