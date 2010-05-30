using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace DersDemo_Ado_Parameters
{
    public partial class Procedures : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bSearch_Click(object sender, EventArgs e)
        {
            using (SqlConnection sc = new SqlConnection(
                "Data Source=.; Initial Catalog=Northwind;" +
                "Integrated Security=true"))
            {
                SqlCommand scom = sc.CreateCommand();
                //scom.CommandText =
                //    "SP_GetOrdersByDateRange";
                scom.CommandText =
                    "EXEC SP_GetOrdersByDateRange @Start, @End, @TotalPrice OUTPUT";
                //scom.CommandType =
                //    CommandType.StoredProcedure;

                scom.Parameters.AddWithValue(
                    "@Start", DateTime.Parse(tbStart.Text));
                scom.Parameters.AddWithValue(
                    "@End", DateTime.Parse(tbEnd.Text));
                SqlParameter sp = new SqlParameter(
                    "@TotalPrice", SqlDbType.Money, 8, ParameterDirection.Output, false, 1, 1, "", DataRowVersion.Current, 0);
                //sp.Direction = ParameterDirection.InputOutput;
                //sp.Value = 0;
                scom.Parameters.Add(sp);

                sc.Open();
                //SqlDataReader sdr = scom.ExecuteReader();
                scom.ExecuteNonQuery();

                Label1.Text = string.Format(
                    "Total Price: {0:C}",
                    scom.Parameters["@TotalPrice"].Value); // 1.yol
                //sp.Value); // 2. yol

                //gv.DataSource = sdr;
                //gv.DataBind();
            }
        }
    }
}
