using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;

namespace Interfaz
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            ENUsuario usuario = new ENUsuario();
            usuario.nombre = username;
            usuario.contraseña = password;

            // Validar las credenciales del usuario utilizando el método en ENUsuario
            if (usuario.ValidarCredenciales(usuario.nombre, usuario.contraseña))
            {
                string email = usuario.ObtenerEmailPorUsuario(username);
                string user = usuario.ObtenerUsuarioPorEmail(email);

                // Almacena el nombre de usuario y el correo electrónico en variables de sesión
                Session["username"] = user;
                Session["email"] = email;

                // Redireccionar a la página de perfil
                Response.Redirect("Perfil.aspx");
            }
            else
            {
                // Las credenciales no son válidas, mostrar un mensaje de error al usuario
                message.Text = "Usuario o contraseña incorrectos.";
                return;
            }
        }


    }
}