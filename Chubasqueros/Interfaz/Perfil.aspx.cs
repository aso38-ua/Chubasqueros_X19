using Library;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
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
                if (Session["username"] == null)
                {
                    // El usuario no ha iniciado sesión, redirigir a la página de inicio de sesión
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    // Obtener el nombre de usuario y el correo electrónico de la sesión
                    string username = Session["username"].ToString();
                    string email = Session["email"].ToString();

                    // Utilizar los valores según sea necesario
                    lblUsername.Text = username;
                    lblEmail.Text = email;

                    // Configuración del encabezado de respuesta HTTP para evitar el almacenamiento en caché
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Cache.SetNoStore();

                    // Crear una instancia de ENUsuario
                    ENUsuario usuario = new ENUsuario();
                    usuario.nombre = username;
                    usuario.email = email;

                    // Obtén la ruta de la imagen de perfil del usuario desde la base de datos o desde la ubicación especificada
                    string imagePath = usuario.ObtenerRutaImagenPerfil(usuario.nombre);

                    // Asigna la ruta de la imagen al control <asp:Image>
                    imgProfile.ImageUrl = ResolveUrl(imagePath);
                }
                
            }
        }

        protected void btnName_Click(object sender, EventArgs e)
        {
            string newUsername = txtNewUsername.Text;

            // Crear una instancia de ENUsuario
            ENUsuario usuario = new ENUsuario();

            // Verificar si el nuevo nombre de usuario ya existe en la base de datos
            bool usernameExists = usuario.VerificarNombreUsuarioExistente(newUsername);

            if (usernameExists)
            {
                // El nuevo nombre de usuario ya existe, mostrar mensaje de error
                changeName.Text = "El nombre de usuario ya está en uso. Por favor, elija otro nombre.";
            }
            else if (newUsername == "")
            {
                changeName.Text = "No se admiten nombres vacíos.";
            }
            else
            {
                // El nuevo nombre de usuario está disponible, actualizar en la base de datos
                usuario.ActualizarNombreUsuario(Session["username"] as string, newUsername);

                // Mostrar mensaje de éxito
                changeName.Text = "El nombre de usuario se ha actualizado correctamente.";

                // Actualizar el nombre de usuario en la sesión
                Session["username"] = newUsername;
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditarPerfil.aspx");
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (fileUploadProfileImage.HasFile)
            {
                string fileName = "profile.jpg"; // Nombre de archivo deseado
                string uploadsPath = Server.MapPath("~/ProfileImages");
                string filePath = Path.Combine(uploadsPath, fileName);

                fileUploadProfileImage.SaveAs(filePath);

                // Guardar la ruta del archivo en la base de datos o cualquier otra operación necesaria
            }
        }




    }
}