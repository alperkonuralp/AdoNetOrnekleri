using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;

namespace DersDemo_Ado_Excel
{
    public partial class _Default : System.Web.UI.Page
    {
        protected string FileName
        {
            get { return ViewState["FileName"] as string; }
            set { ViewState["FileName"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bSend_Click(object sender, EventArgs e)
        {
            if (fu.HasFile)
            {
                FileName = Server.MapPath(
                    "~/App_data/Uploads/" + fu.FileName);

                fu.SaveAs(FileName);

                using (OleDbConnection con = GetConnection())
                {
                    con.Open();

                    DataTable dt = con.GetSchema("Tables");

                    ddlSheets.DataSource = dt;
                    ddlSheets.DataTextField = "TABLE_NAME";
                    ddlSheets.DataValueField = "TABLE_NAME";
                    ddlSheets.DataBind();

                    p1.Visible = false;
                    p2.Visible = true;
                }
            }
        }

        protected OleDbConnection GetConnection()
        {
            return new OleDbConnection(
                "Provider=Microsoft.ACE.OLEDB.12.0;" +
                "Data Source=" + FileName +
                ";Extended Properties=\"" +
                "Excel 12.0 Xml;HDR=YES\";");
        }

        protected void ddlSheets_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            using (OleDbConnection con = GetConnection())
            {
                con.Open();
                OleDbCommand com =
                    new OleDbCommand(
                        "SELECT * FROM [" + ddlSheets.SelectedValue + "];",
                        con);

                OleDbDataReader dr = com.ExecuteReader();

                gv.DataSource = dr;
                gv.DataBind();
                dr.Close();
            }
        }
    }
}
