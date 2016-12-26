using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using blogum.veritabani;
namespace blogum
{
    public partial class Default : System.Web.UI.Page
    {
        Gosterim g = new Gosterim();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
                Doldur();
        }
        public void Doldur()
        {
            rptMakale.DataSource = g.MakaleGetir();
            rptMakale.DataBind();
        }
    }
}