using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Interfaz
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                // El usuario está registrado, mostrar el botón de Perfil
                liperfil.Visible = true;
                lifav.Visible = true;
                lireg.Visible = true;
                liregistro.Visible = false;
            }
            else
            {
                // El usuario no está registrado, ocultar el botón de oferta
                liregistro.Visible = true;
                lifav.Visible = false;
                lireg.Visible = false;
                liperfil.Visible = false;
            }
        }
    }
}