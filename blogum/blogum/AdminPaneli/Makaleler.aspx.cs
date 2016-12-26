using blogum.veritabani;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace blogum.AdminPaneli
{
    public partial class Makaleler : System.Web.UI.Page
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
                    Doldur();

            }
        }
        public void Doldur()
        {
            drpKategori.Items.Clear();
            cblEtiket.Items.Clear();
            gvMakale.DataSource = n.MakaleIsim();
            gvMakale.DataBind();
            List<string> kategoriler = n.KategoriIsim();
            List<string> etiket = n.EtiketIsim();
            foreach (var item in kategoriler)
            {
                drpKategori.Items.Add(item);

            }
            foreach (var item in etiket)
            {
                cblEtiket.Items.Add(item);
            }

        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            List<String> olmayanEtiketler = null;
            List<string> varolanEtiketler = new List<string>();
            if (txtEtiket.Text != String.Empty)
            {
                olmayanEtiketler = txtEtiket.Text.Split(',').ToList();

            }
            for (int i = 0; i < cblEtiket.Items.Count; i++)
            {
                if (cblEtiket.Items[i].Selected)
                {
                    varolanEtiketler.Add(cblEtiket.Items[i].Text);
                }
            }
            string ktg = drpKategori.Text;
            Makale mkl = new Makale() {
                Baslik=txtBaslik.Text , Ozet=txtOzet.Text, Icerik=txtIcerik.Text,  Tarih=DateTime.Now, url=txtUrl.Text  
            };
            if (n.MakaleKaydet(mkl, varolanEtiketler, olmayanEtiketler, ktg))
            {
                lblDurum.Text = "Kayıt Başarılı";

            }else
            {
                lblDurum.Text = "kayıtta sorun var";
            }
        }

        protected void btnGizleGoster_Click(object sender, EventArgs e)
        {
            GizleGoster();
        }
        public void GizleGoster()
        {
            if (btnGizleGoster.Text == "Göster")
            {
                pnlMakale.Visible = true;
                btnGizleGoster.Text = "Gizle";
            }
            else
            {
                pnlMakale.Visible = false;
                btnGizleGoster.Text = "Göster";
            }
        }

        protected void gvMakale_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[4].Visible = false;
            e.Row.Cells[5].Visible = false;
            e.Row.Cells[6].Visible = false;
        }

        protected void btnSil_Click(object sender, EventArgs e)
        {
            List<int> idler = new List<int>();
            for (int i = 0; i < gvMakale.Rows.Count; i++)
            {
                CheckBox c = (CheckBox)gvMakale.Rows[i].Cells[0].FindControl("chkSec");
                if(c.Checked)
                {
                    idler.Add(Convert.ToInt32(gvMakale.Rows[i].Cells[i].Text));
                }
            }
            if (n.MakaleSil(idler))
            {
                lblDurum.Text = "silme başarılı.";
            }
            else
            {
                lblDurum.Text = "silmede hata var";
            }
        }

        protected void btnGvSectigimiDuzenle_Click(object sender, EventArgs e)
        {
            int rowNo=0;
            for (int i = 0; i < gvMakale.Rows.Count; i++)
            {
                CheckBox c = (CheckBox)gvMakale.Rows[i].Cells[0].FindControl("chkSec");
                if (c.Checked)
                {
                    rowNo = i;
                }
            }
     lblId.Text = HttpUtility.HtmlDecode(gvMakale.Rows[rowNo].Cells[1].Text);
            txtBaslik.Text =HttpUtility.HtmlDecode( gvMakale.Rows[rowNo].Cells[2].Text);
            txtOzet.Text =HttpUtility.HtmlDecode (gvMakale.Rows[rowNo].Cells[3].Text);
            txtIcerik.Text = HttpUtility.HtmlDecode(gvMakale.Rows[rowNo].Cells[4].Text);
            txtUrl.Text = gvMakale.Rows[rowNo].Cells[6].Text;


        }

        protected void btnDuzenle_Click(object sender, EventArgs e)
        {
            Makale makale = new Makale()
            {
                Baslik = txtBaslik.Text,
                Ozet = txtOzet.Text,
                Icerik = txtIcerik.Text,
                url = txtUrl.Text,
                id = Convert.ToInt32(lblId.Text)

            };
            if (n.MakaleDuzenle(makale))
            {
                lblDurum.Text = "düzenleme başarılı";
            }
            else
            {
                lblDurum.Text = "düzenlemede hata var";
            }

        }

        protected void btnBosalt_Click(object sender, EventArgs e)
        {
            txtBaslik.Text = "";
            txtOzet.Text = "";
            txtIcerik.Text = "";
            txtUrl.Text = "";
            lblDurum.Text = "";
            lblId.Text = "";
            Doldur();
        }
    }
}