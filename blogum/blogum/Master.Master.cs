using blogum.veritabani;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace blogum
{
    public partial class Master : System.Web.UI.MasterPage
    {
        Gosterim g = new Gosterim();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Doldur();
        }
        public void Doldur()
        {
            rptEtiket.DataSource = g.EtiketGoster();
            rptEtiket.DataBind();
            rptKategori.DataSource = g.KategoriGoster();
            rptKategori.DataBind();
            rptMakale.DataSource = g.MakaleGoster();
            rptMakale.DataBind();
        }
    }
}