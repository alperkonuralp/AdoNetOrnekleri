using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Drawing;

namespace DersDemo_Ado_Parameters
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bLogin_Click(object sender, EventArgs e)
        {
            using (SqlConnection sc = new SqlConnection(
                "Data Source=.; Initial Catalog=Store;" +
                "Integrated Security=true"))
            {
                SqlCommand scom = sc.CreateCommand();
                //scom.CommandText =
                //    "SELECT ISNULL(COUNT(*), 0) " +
                //    "FROM TUser " +
                //    "WHERE UserName='" + tbUserName.Text +
                //    "' AND Password='" + tbPassword.Text +
                //    "'";

                scom.CommandText =
                    "SELECT ISNULL(COUNT(*), 0) " +
                    "FROM TUser " +
                    "WHERE UserName=@UserName AND Password=@Password";

                scom.Parameters.AddWithValue(
                    "@UserName", tbUserName.Text);
                scom.Parameters.AddWithValue(
                    "@Password", tbPassword.Text);
                //scom.Parameters.AddWithValue(
                //    "@Date", DateTime.Now);
                scom.Parameters.AddWithValue(
                    "@Date", DateTime.Parse(tbDate.Text));

                sc.Open();
                int sonuc = (int)scom.ExecuteScalar();

                if (sonuc >= 1)
                {
                    lMessage.Text = "Doğru Giriş Yaptınız.";
                    lMessage.ForeColor = Color.Green;
                }
                else
                {
                    lMessage.Text = "Giriş Hatalı";
                    lMessage.ForeColor = Color.Red;
                }
            }
        }
    }
}
