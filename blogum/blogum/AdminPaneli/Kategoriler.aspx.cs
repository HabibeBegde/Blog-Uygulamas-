using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using blogum.veritabani;

namespace blogum.AdminPaneli
{
    public partial class Kategoriler : System.Web.UI.Page
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
                    Doldur();
                }
            }
            

        }
       
        public void Doldur()
        {
            DropDownList1.Items.Clear();
            List<String> isimler = n.KategoriIsim();
            foreach (string i in isimler)
            {
                DropDownList1.Items.Add(i);
            }
            lblId.Text = "";
            txtAd.Text = "";
            txtSira.Text = "";
            txtUrl.Text = "";

        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            Kategori kat = new Kategori()
            {
                Ad=txtAd.Text, url=txtUrl.Text, Sira=Convert.ToInt32(txtSira.Text)

            };
            if (n.KategoriKaydet(kat))
            {
                lblDurum.Text = "Kayıt başarılı";
            }
            else 
            {
                lblDurum.Text = "Kayıtta hata oluştu";
            }
            Doldur();

             
        }
        

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string isim = DropDownList1.Text;
            var k = n.KategoriGetir(isim);
            lblId.Text = k.id.ToString();
            txtAd.Text = k.Ad;
            txtSira.Text = k.Sira.ToString();
            txtUrl.Text = k.url;



        }
        

       

        protected void btnDuzenle_Click(object sender, EventArgs e)
        {
            Kategori k = new Kategori(){
            Ad=txtAd.Text, url=txtUrl.Text, Sira=Convert.ToInt32(txtSira.Text) , id=Convert.ToInt32(lblId.Text)
            };
            if (n.KategoriDuzenle(k))
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
            if (n.KategoriSil(id))
            {
                lblDurum.Text = "silme başarılı.";

            }
            else
            {
                lblDurum.Text = "silmede hata var.";
            }
            Doldur();

        }

    }
}