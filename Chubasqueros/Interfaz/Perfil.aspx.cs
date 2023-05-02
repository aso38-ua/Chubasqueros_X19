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
            /*if (!IsPostBack)
            {
                string connectionString = "Data Source=(local);Initial Catalog=MyDatabase;Integrated Security=True";
                string query = "SELECT * FROM UserProfile WHERE UserId = @UserId";
                int userId = Convert.ToInt32(Session["UserId"]);
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UserId", userId);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        txtName.Text = reader["Name"].ToString();
                        txtEmail.Text = reader["Email"].ToString();
                        txtPhone.Text = reader["Phone"].ToString();
                    }
                    reader.Close();
                }
            }
        }*/
        }

        /*protected void btnSave_Click(object sender, EventArgs e)
        {
            // Leer los valores de los controles de la página y actualizar los datos del perfil del usuario en la base de datos.
            string connectionString = "Data Source=(local);Initial Catalog=MyDatabase;Integrated Security=True";
            string query = "UPDATE UserProfile SET Name = @Name, Email = @Email, Phone = @Phone WHERE UserId = @UserId";
            int userId = Convert.ToInt32(Session["UserId"]);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", txtName.Text);
                command.Parameters.AddWithValue("@Email", txtEmail.Text);
                command.Parameters.AddWithValue("@Phone", txtPhone.Text);
                command.Parameters.AddWithValue("@UserId", userId);
                connection.Open();
                command.ExecuteNonQuery();
            }
            lblMessage.Text = "Perfil actualizado correctamente.";
        }*/
    }
}