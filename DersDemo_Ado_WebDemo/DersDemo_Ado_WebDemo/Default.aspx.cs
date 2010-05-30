using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DersDemo_Ado_WebDemo
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((CommandField)gv.Columns[0]).SelectText = "Seçççç";
        }

        protected void dv_ItemDeleted(object sender, DetailsViewDeletedEventArgs e)
        {
            if (e.Exception == null)
            {
                Page.ClientScript.RegisterStartupScript(
                    GetType(), "IslemTamam",
                    "alert('İşlem Tamam!...');", true);
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            Page.Header.Controls.Add(
                new LiteralControl("<script src=\"" + 
                    VirtualPathUtility.ToAbsolute("~/Resources/js/jquery.js") +
                    "\" type=\"text/javascript\" ></script>"));
        }
    }
}
