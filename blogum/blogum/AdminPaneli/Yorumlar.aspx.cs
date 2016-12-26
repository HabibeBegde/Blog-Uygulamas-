using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using blogum.veritabani;
namespace blogum.AdminPaneli
{
    public partial class Yorumlar : System.Web.UI.Page
    {
        islemler n = new islemler();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["online"] != "Admin")
            {
                Response.Redirect("~/AdminPaneli/Default.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    rptYorum.DataSource = n.YorumGetir();
                    rptYorum.DataBind();


                }
            }

        }
    }
}