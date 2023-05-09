using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Interfaz
{
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Obtener el nombre de usuario y el correo electrónico de la sesión
                string username = (string)Session["username"];
                string email = (string)Session["email"];

                // Utilizar los valores según sea necesario
                lblUsername.Text = username;
                lblEmail.Text = email;
            }
        }



        private string ObtenerNombreDeUsuario()
        {
            // Aquí debes implementar la lógica para obtener el nombre de usuario del usuario autenticado
            // Puedes obtener esta información de la sesión, cookies u otros mecanismos de autenticación que estés utilizando en tu aplicación

            // Por ejemplo, si estás utilizando el sistema de autenticación de ASP.NET, puedes obtener el nombre de usuario así:
            string username = User.Identity.Name;

            return username;
        }
    }
}