using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Interfaz
{
    public partial class Aviso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }

        protected void btnAccept_Click(object sender, EventArgs e)
        {
            // Establecer una cookie para indicar que el aviso ha sido aceptado
            HttpCookie cookie = new HttpCookie("AvisoCookie", "Aceptado");
            cookie.Expires = DateTime.Now.AddDays(30); // Configura la fecha de expiración de la cookie según tus necesidades
            Response.Cookies.Add(cookie);

            Response.Redirect("Default.aspx");

            
        }

    }
}
