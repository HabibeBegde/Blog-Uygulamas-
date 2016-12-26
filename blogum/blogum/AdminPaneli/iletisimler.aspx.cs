using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using blogum.veritabani;

namespace blogum.AdminPaneli
{
    public partial class iletisimler : System.Web.UI.Page
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
                    rptiletisim.DataSource = n.iletisimGetir();
                    rptiletisim.DataBind();

                    
                }
            }

        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            if (n.iletisimSil())
            {
                lblDurum.Text = "silme başarılı";

            }
            else
            {
                lblDurum.Text = "silmede hata oluştu";
            }
        }
    }
}