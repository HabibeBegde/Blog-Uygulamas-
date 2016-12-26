using blogum.veritabani;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace blogum
{
    public partial class Konu : System.Web.UI.Page
    {
        string url;
        Gosterim g = new Gosterim();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["url"] != null)
                {
                    url = Request.QueryString["url"];
                    Makale mkl = g.makaleGetir(url);
                    lblBaslik.Text =HttpUtility.HtmlDecode( mkl.Baslik);
                    lblTarih.Text =HttpUtility.HtmlDecode ( mkl.Tarih.ToString());
                    lblIcerik.Text =HttpUtility.HtmlDecode( mkl.Icerik);
                    rptEtiket.DataSource = g.EtiketGetir(url);
                    rptEtiket.DataBind();

                    if (g.YorumlariGetir(url) == null)
                    {
                        lblYrmDurum.Text = "Bu makaleye henüz yorum yapılmamış";
                    }
                    else
                    {
                        rptYorum.DataSource = g.YorumlariGetir(url);
                        rptYorum.DataBind();
                    }

                }
            }
        }

        protected void btnGonder_Click(object sender, EventArgs e)
        {
            Yorum yrm = new Yorum() { 
                Ad = txtAd.Text , Email = txtEmail.Text , Icerik = txtYorum.Text , Tarih = DateTime.Now , onay=false
            
            };
            if (g.YorumKaydet(Request.QueryString["url"], yrm))
            {
                lblDurum.Text = "Yorumunuz kaydedilmiştir onaylama sürecinden geçecektir";
            }
            else
            {
                lblDurum.Text = "Bir hata oluştu tekrar deneyin";
            }
        }
       
    }
}