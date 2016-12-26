using blogum.veritabani;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace blogum
{
    public partial class iletisimler : System.Web.UI.Page
    {
        Gosterim g = new Gosterim();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGonder_Click(object sender, EventArgs e)
        {
            iletisim ilt = new iletisim() {
                Ad = txtAd.Text,
                Email = txtEmail.Text,
               Mesaj = txticerik.Text,
                Tarih = DateTime.Now,
                Onay = false
            };
            if (g.IletisimKaydet(ilt))
            {
                lblDurum.Text = "mesajınız gönderildi";
            }
            else
            {
                lblDurum.Text = "mesaj gönderilmedi hata oluştu";
            }

        }
    }
}