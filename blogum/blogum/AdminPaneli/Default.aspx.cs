using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using blogum.veritabani;

namespace blogum.AdminPaneli
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["online"] != "Admin")
            {
                pnlMenu.Visible = false;
                pnlGiris.Visible = true;

            }
            else
            {
                pnlMenu.Visible = true;
                pnlGiris.Visible = false;
            }

        }

       

        

        protected void btnGiris_Click(object sender, EventArgs e)
        {
            islemler nesne = new islemler();
            var kul = new Kullanici()
            {
                Ad=txtAd.Text, Sifre=txtSifre.Text

            };
            if (nesne.GirisYap(kul))
            {
                pnlGiris.Visible = false;
                pnlMenu.Visible = true;
            }
            else
            {
                lblHata.Text = "Kullanici bulunamadı.";
            }
        }


        
    }
}