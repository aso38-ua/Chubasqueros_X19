using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
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
                if (Session["username"] == null)
                {
                    // El usuario no ha iniciado sesión, redirigir a la página de inicio de sesión
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    // Obtener el nombre de usuario y el correo electrónico de la sesión
                    string username = (string)Session["username"];
                    string email = (string)Session["email"];

                    // Utilizar los valores según sea necesario
                    lblUsername.Text = username;
                    lblEmail.Text = email;

                    // Obtén la ruta de la imagen de perfil del usuario desde la base de datos o desde la ubicación especificada
                    string imagePath = ObtenerRutaImagenPerfil(username);

                    // Asigna la ruta de la imagen al control <asp:Image>
                    imgProfile.ImageUrl = ResolveUrl(imagePath);
                }
                
            }
        }

        private string ObtenerRutaImagenPerfil(string username)
        {
            // Aquí debes implementar la lógica para obtener la ruta de la imagen de perfil del usuario desde la base de datos

            string connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT ImagenPerfil FROM usuario WHERE nombre = @username";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);

                    connection.Open();
                    string imagePath = command.ExecuteScalar() as string;

                    // Verifica si la ruta de la imagen de perfil está vacía o nula
                    if (!string.IsNullOrEmpty(imagePath))
                    {
                        // La ruta de la imagen de perfil existe, puedes retornarla
                        return imagePath;
                    }
                    else
                    {
                        // La ruta de la imagen de perfil está vacía o nula, puedes retornar una ruta predeterminada o mostrar una imagen por defecto
                        return "~/ProfileImages/Profile.jpg";
                    }
                }
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditarPerfil.aspx");
        }




    }
}