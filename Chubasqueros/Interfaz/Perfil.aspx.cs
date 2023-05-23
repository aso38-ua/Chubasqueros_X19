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
                    ENSeguidores follow = new ENSeguidores();
                    // Obtén la ruta de la imagen de perfil del usuario desde la base de datos o desde la ubicación especificada
                    string imagePath = usuario.ObtenerRutaImagenPerfil(usuario.nombre);

                    // Asigna la ruta de la imagen al control <asp:Image>
                    imgProfile.ImageUrl = ResolveUrl(imagePath);

                    int seguidores = follow.ObtenerNumeroSeguidos(username);
                    int seguidos = follow.ObtenerNumeroSeguidores(username);

                    int misubs = follow.MisSeguidores(username);
                    misSubs.InnerText = misubs.ToString();
                    misimp.InnerText = seguidores.ToString();

                    // Asignar los valores a los elementos span
                    lblFollowers.InnerText = misubs.ToString();
                    //lblFollowing.InnerText = seguidos.ToString();

                    if (usuario.EsAdmin(username))
                    {
                        // Mostrar el contenido solo si el usuario es administrador
                        divUsuariosConMasSeguidores.Visible = true;
                    }
                    else
                    {
                        // Ocultar el contenido si el usuario no es administrador
                        divUsuariosConMasSeguidores.Visible = false;
                    }

                }
                
            }
        }

        protected void btnMostrarUsuarios_Click(object sender, EventArgs e)
        {
            ENSeguidores follow = new ENSeguidores();
            int cantidad = 10; // Cantidad de usuarios con más seguidores a mostrar
            List<UsuarioConSeguidores> usuarios = follow.ObtenerUsuariosConMasSeguidores(cantidad);
            gvUsuariosConMasSeguidores.DataSource = usuarios;
            gvUsuariosConMasSeguidores.DataBind();
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

                Response.Redirect(Request.Url.AbsoluteUri);
            }
        }

        protected void btnEmail_Click(object sender, EventArgs e)
        {
            
            string newEmail = txtNewEmail.Text;

            // Crear una instancia de ENUsuario
            ENUsuario usuario = new ENUsuario();

            // Verificar si el nuevo nombre de usuario ya existe en la base de datos
            bool usernameExists = usuario.VerificarEmailExistente(newEmail);

            if (usernameExists)
            {
                // El nuevo nombre de usuario ya existe, mostrar mensaje de error
                changEmail.Text = "El email ya está en uso. Por favor, elija otro nombre.";
            }
            else if (newEmail == "")
            {
                changEmail.Text = "No se admiten emails vacíos.";
            }
            else
            {
                // El nuevo nombre de usuario está disponible, actualizar en la base de datos
                usuario.ActualizarEmail(Session["email"] as string, newEmail);

                // Mostrar mensaje de éxito
                changEmail.Text = "El email se ha actualizado correctamente.";

                // Actualizar el nombre de usuario en la sesión
                Session["email"] = newEmail;

                Response.Redirect(Request.Url.AbsoluteUri);
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (fileUploadProfileImage.HasFile)
            {
                string fileName = Path.GetFileName(fileUploadProfileImage.FileName); // Obtiene el nombre del archivo
                string uploadsPath = Server.MapPath("~/ProfileImages");
                string filePath = Path.Combine(uploadsPath, fileName);

                fileUploadProfileImage.SaveAs(filePath);

                // Guardar la ruta del archivo en la base de datos o cualquier otra operación necesaria
                string username = Session["username"].ToString(); // Reemplaza con el nombre de usuario del usuario actual
                string imagePath = "~/ProfileImages/" + fileName; // Ruta relativa que se guardará en la base de datos

                string connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE usuario SET ImagenPerfil = @imagePath WHERE nombre = @username";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@imagePath", imagePath);
                        command.Parameters.AddWithValue("@username", username);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }

                Response.Redirect(Request.Url.AbsoluteUri);
            }
        }

        protected void btnSeguir_Click(object sender, EventArgs e)
        {
            string seguido = txtSeguido.Value; // Obtener el valor del TextBox
            string seguidor = Session["username"].ToString(); // Obtener el usuario actual
            ENSeguidores follow = new ENSeguidores();
            
            follow.AgregarSeguido(seguidor, seguido);

            // Actualizar la cantidad de seguidores y seguidos en la interfaz
            int numeroSeguidores = follow.ObtenerNumeroSeguidores(seguido);
            int numeroSeguidos = follow.ObtenerNumeroSeguidos(seguidor);
            lblFollowers.InnerText = numeroSeguidores.ToString();
            //lblFollowing.InnerText = numeroSeguidos.ToString();
        }


    }
}