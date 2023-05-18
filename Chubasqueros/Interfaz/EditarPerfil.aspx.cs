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
            // Configuración del encabezado de respuesta HTTP para evitar el almacenamiento en caché
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
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