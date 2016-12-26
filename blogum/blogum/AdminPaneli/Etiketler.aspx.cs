using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using blogum.veritabani;

using System.Web.UI.WebControls;

namespace blogum.AdminPaneli
{
    public partial class Etiketler : System.Web.UI.Page
    {
        islemler nesne = new islemler();

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
                    Doldur();
                }
            }

        }
        public void Doldur()
        {
            drpEtiket.Items.Clear();
            List<String> etiketisim = nesne.EtiketIsim();
            foreach (var item in etiketisim)
            {
                drpEtiket.Items.Add(item);
            }
            txtAd.Text = ""; lblId.Text = "";


        }

        protected void drpEtiket_SelectedIndexChanged(object sender, EventArgs e)
        {
            String ad = drpEtiket.Text;
            Etiket etk = nesne.EtiketiGetir(ad);
            txtAd.Text = etk.Ad;
            lblId.Text = etk.id.ToString();


        }

        protected void btnDuzenle_Click(object sender, EventArgs e)
        {
            Etiket etk = new Etiket()
            {
                Ad = txtAd.Text, id = Convert.ToInt32(lblId.Text)

            };
            if (nesne.EtiketDuzenle(etk))
            {
                lblDurum.Text = "Düzenleme başarılı.";
            }
            else
            {
                lblDurum.Text = "Düzenlemede hata var.";
            }
            Doldur();

        }

        protected void btnSil_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(lblId.Text);
            if (nesne.EtiketSil(id))
            {
                lblDurum.Text = "silme baaşrılı";

            }
            else
            {
                lblDurum.Text = "silmede hata var";

            }
            Doldur();
        }

       
        
        
    }
}