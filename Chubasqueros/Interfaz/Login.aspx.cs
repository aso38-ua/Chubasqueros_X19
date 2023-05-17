using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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


            // Validar las credenciales del usuario en la base de datos
            if (ValidarCredenciales(username, password))
            {
                string email = ObtenerEmailPorUsuario(username);

                string user = ObtenerUsuarioPorEmail(email);

                // Almacena el nombre de usuario y el correo electrónico en variables de sesión
                Session["username"] = user;
                Session["email"] = email;
            }
            
            else
            {
                // Las credenciales no son válidas, mostrar un mensaje de error al usuario
                message.Text = "Usuario o contraseña incorrectos.";
                return;
            }


            // Redireccionar a la página de perfil
            Response.Redirect("Perfil.aspx");
        }



        private bool ValidarCredenciales(string username, string password)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM usuario WHERE (nombre = @username OR email = @username) AND contraseña = @password";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);

                    connection.Open();
                    int count = (int)command.ExecuteScalar();

                    return count > 0; // Retorna true si se encontró un registro, o false si no se encontró
                }
            }
        }

        private string ObtenerEmailPorUsuario(string username)
        {
            string email = string.Empty;

            if (EsCorreoElectronico(username))
            {
                return username; // El 'username' ya es un correo electrónico, devolverlo directamente
            }

            string connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT email FROM usuario WHERE nombre = @username";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);

                    connection.Open();
                    email = (string)command.ExecuteScalar();
                }
            }

            return email;

        }

        private string ObtenerUsuarioPorEmail(string email)
        {
            string username = string.Empty;

            // Realiza la consulta a la base de datos para obtener el nombre de usuario del correo electrónico
            // Aquí debes implementar tu lógica de acceso a la base de datos
            // Puedes utilizar consultas SQL o algún ORM (Object-Relational Mapping) como Entity Framework

            // Ejemplo de consulta SQL
            string connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT nombre FROM usuario WHERE email = @email";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@email", email);

                    connection.Open();
                    username = (string)command.ExecuteScalar();
                }
            }

            return username;
        }

        private bool EsCorreoElectronico(string input)
        {
            try
            {
                var email = new System.Net.Mail.MailAddress(input);
                return email.Address == input;
            }
            catch
            {
                return false;
            }
        }

    }
}