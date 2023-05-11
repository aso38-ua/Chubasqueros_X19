using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Interfaz
{
    public partial class Verified : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Verificar si se proporcionó un token en la consulta de la URL
                if (Request.QueryString["token"] != null)
                {
                    string token = Request.QueryString["token"].ToString();

                    // Obtener el token almacenado en la sesión del usuario
                    string storedToken = Session["verificationToken"] as string;

                    // Comparar el token proporcionado con el token almacenado
                    if (token == storedToken)
                    {
                        // El token es válido, el correo electrónico está verificado
                        // Realiza alguna acción, como marcar el correo electrónico como verificado en la base de datos
                        // o mostrar un mensaje de éxito al usuario
                        Response.Write("¡Tu correo electrónico ha sido verificado exitosamente!");

                        // Limpia el token almacenado en la sesión del usuario
                        Session["verificationToken"] = null;
                    }
                    else
                    {
                        // El token no coincide o ha expirado
                        // Realiza alguna acción, como mostrar un mensaje de error o redireccionar a una página de error
                        Response.Write("El token de verificación no es válido o ha expirado.");
                    }
                }
                else
                {
                    // No se proporcionó ningún token en la consulta de la URL
                    // Realiza alguna acción, como mostrar un mensaje de error o redireccionar a una página de error
                    Response.Write("No se proporcionó ningún token de verificación.");
                }
            }
        }

    }
}