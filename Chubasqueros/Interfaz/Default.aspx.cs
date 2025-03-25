using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Interfaz
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["AvisoCookie"] == null || Request.Cookies["AvisoCookie"].Value != "Aceptado")
            {
                Response.Redirect("Aviso.aspx");
            }
        }

    }
}