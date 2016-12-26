using blogum.veritabani;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace blogum.AdminPaneli
{
    public partial class p : System.Web.UI.Page
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
                if (Request.QueryString["yo"] != null)
                {
                    int id = Convert.ToInt32(Request.QueryString["yo"]);
                    n.YorumOnayla(id);

                    Response.Redirect("~/AdminPaneli/Yorumlar.aspx");
                }
                else if (Request.QueryString["ys"] != null)
                {
                    int id = Convert.ToInt32(Request.QueryString["ys"]);
                    n.YorumSil(id);

                    Response.Redirect("~/AdminPaneli/Yorumlar.aspx");
                }

            }
        }
    }
}