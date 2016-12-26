using blogum.veritabani;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace blogum
{
    public partial class p : System.Web.UI.Page
    {
        Gosterim g = new Gosterim();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["url"] != null)
                {
                    //kategori için
                    string url = Request.QueryString["url"];
                    rptMakale.DataSource = g.KategoriIcin(url);
                    rptMakale.DataBind();

                }
                else if (Request.QueryString["id"] != null)
                { // etiket için
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    rptMakale.DataSource = g.EtiketIcin(id);
                    rptMakale.DataBind();


                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }
            }

        }
    }
}