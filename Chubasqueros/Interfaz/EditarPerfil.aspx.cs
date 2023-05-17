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
    public partial class EditarPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                // El usuario no ha iniciado sesión, redirigir a la página de inicio de sesión
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (fileUploadProfileImage.HasFile)
            {
                string fileName = Path.GetFileName(fileUploadProfileImage.FileName);
                string imagePath = Server.MapPath("~/ProfileImages/") + fileName;
                fileUploadProfileImage.SaveAs(imagePath);

                // Obtén el nombre de usuario del usuario autenticado desde la sesión
                string username = Session["username"] as string;

                // Actualiza la ruta de la imagen de perfil en la base de datos para el usuario actual
                ActualizarRutaImagenPerfil(username, imagePath);


            }
            else
            {

            }
        }

        private void ActualizarRutaImagenPerfil(string username, string imagePath)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE usuario SET ImagenPerfil = CONVERT(varbinary(max), @imagePath) WHERE nombre = @username";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@imagePath", imagePath);
                    command.Parameters.AddWithValue("@username", username);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        protected void btnName_Click(object sender, EventArgs e)
        {
            string newUsername = txtNewUsername.Text;

            // Verificar si el nuevo nombre de usuario ya existe en la base de datos
            bool usernameExists = VerificarNombreUsuarioExistente(newUsername);

            if (usernameExists)
            {
                // El nuevo nombre de usuario ya existe, mostrar mensaje de error
                changeName.Text = "El nombre de usuario ya está en uso. Por favor, elija otro nombre.";
            }
            else if (newUsername=="")
            {
                changeName.Text = "No se puede asignar un nombre vacío.";
            }
            else
            {
                // El nuevo nombre de usuario está disponible, actualizar en la base de datos
                ActualizarNombreUsuario(Session["username"] as string, newUsername);

                // Mostrar mensaje de éxito
                changeName.Text = "El nombre de usuario se ha actualizado correctamente.";

                // Actualizar el nombre de usuario en la sesión
                Session["username"] = newUsername;
            }
        }

        private bool VerificarNombreUsuarioExistente(string newUsername)
        {
            // Consulta SQL para verificar si el nombre de usuario ya existe en la base de datos
            string connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM usuario WHERE nombre = @newUsername";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@newUsername", newUsername);

                    connection.Open();
                    int count = (int)command.ExecuteScalar();

                    return count > 0;
                }
            }
        }

        private void ActualizarNombreUsuario(string currentUsername, string newUsername)
        {
            // Consulta SQL para actualizar el nombre de usuario en la base de datos
            string connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE usuario SET nombre = @newUsername WHERE nombre = @currentUsername";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@newUsername", newUsername);
                    command.Parameters.AddWithValue("@currentUsername", currentUsername);

                    connection.Open();
                    command.ExecuteNonQuery();

                    // Actualizar el valor en la sesión
                    Session["username"] = newUsername;
                }
            }
        }

        protected void volver(object sender, EventArgs e)
        {
            Response.Redirect("Perfil.aspx");
        }
    }
}