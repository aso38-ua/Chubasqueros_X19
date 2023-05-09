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
                // Las credenciales son válidas, puedes realizar alguna acción, como redireccionar a otra página
                Response.Redirect("Default.aspx");
            }
            else
            {
                // Las credenciales no son válidas, mostrar un mensaje de error al usuario
                message.Text = "Usuario o contraseña incorrectos.";
            }
        }

        private bool ValidarCredenciales(string username, string password)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM usuario WHERE nombre = @username AND contraseña = @password";
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
    }
}