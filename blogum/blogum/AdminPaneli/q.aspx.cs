using blogum.veritabani;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace blogum.AdminPaneli
{
    public partial class q : System.Web.UI.Page
    {
        islemler n = new islemler();
        int ic;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["online"] != "Admin")
            {
                Response.Redirect("~/AdminPaneli/Default.aspx");
            }
            else
            {
                if(Request.QueryString["ic"]!="")
                {
                     ic = Convert.ToInt32(Request.QueryString["ic"]);
                    var ilet = n.iletisimGetir(ic);
                    lblAd.Text = ilet.Ad; lblMail.Text = ilet.Email; lblMesaj.Text = ilet.Mesaj; lblTarih.Text = ilet.Tarih.ToString();

                }
            }


        }

        protected void btnGonder_Click(object sender, EventArgs e)
        {
            cevapla cvp = new cevapla() { 
                iletisimMesaji = lblMesaj.Text ,
                Konu = txtMKonu.Text, 
                Mesaj = txtMesaj.Text ,
                MailAdresi = lblMail.Text 

         
            };
            n.MailGonder(cvp);
            n.iletisimOnay(ic);
            Response.Redirect("~/AdminPaneli/iletisimler.aspx");
        }

        protected void btnSil_Click(object sender, EventArgs e)
        {
            n.iletisimOnay(ic);
            Response.Redirect("~/AdminPaneli/iletisimler.aspx");

        }
    }
}