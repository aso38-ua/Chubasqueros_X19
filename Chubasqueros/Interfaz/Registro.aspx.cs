using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Interfaz
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RequiredFieldValidator3.Text = "";
            cvPassword.Text = "";
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text!="" && txtEmail.Text!="" && txtPassword.Text!="" && (txtPassword.Text == txtConfirmPassword.Text))
            {
                // Obtener los datos del formulario
                string nombre = txtUsername.Text;
                string contraseña = txtPassword.Text;
                string email = txtEmail.Text;

                // Crear una instancia de ENUsuario y asignar los valores
                ENUsuario en = new ENUsuario();
                en.nombre = nombre;
                en.contraseña = contraseña;
                en.email = email;

                // Crear una instancia de CADUsuario
                CADUsuario cadUsuario = new CADUsuario();

                // Llamar al método correspondiente en CADUsuario
                bool resultado = cadUsuario.CrearUsuario(en);

                // Verificar el resultado y realizar las acciones necesarias
                if (resultado)
                {
                    // El usuario se creó correctamente
                    // Realizar alguna acción, como redireccionar a otra página o mostrar un mensaje de éxito
                    Response.Redirect("Reservas.aspx");
                }
                else
                {
                    // Ocurrió un error al crear el usuario
                    // Realizar alguna acción, como mostrar un mensaje de error o registrar el error
                    Response.Redirect("Registro.aspx");
                }
            }

            else if (txtPassword.Text!=txtConfirmPassword.Text)
            {
                cvPassword.Text = "Las contraseñas no coinciden";
            }

            else
            {
                RequiredFieldValidator3.Text = "Pon un nombre titán";
            }
            
        }

    }
}