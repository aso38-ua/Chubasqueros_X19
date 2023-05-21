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
using Library;

namespace Interfaz
{
    public partial class CV : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtApellido.Text!="" || txtEducacion.Text!="" || txtEmail.Text!="" || txtNombre.Text!="" || txtTelefono.Text!="")
            {
                // Obtener los valores de los campos de texto
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                string email = txtEmail.Text;
                string experiencia = txtExperiencia.Text;
                string educacion = txtEducacion.Text;
                string telefono = txtTelefono.Text;

                // Crear una instancia del objeto ENCV con los datos ingresados
                ENCurriculum cv = new ENCurriculum();
                cv.Nombre = nombre;
                cv.Apellido = apellido;
                cv.Email = email;
                cv.Experiencia = experiencia;
                cv.Educacion = educacion;
                cv.Telefono = telefono;

                // Guardar el CV en la base de datos utilizando la clase CADCV
                CADCurriculum cadCV = new CADCurriculum();
                cadCV.CrearCurriculum(cv);

                error.Text = "Curriculum enviado exitosamente";
            }
            else
            {
                error.Text = "ERROR, datos incorrectos";
            }

            // Mostrar un mensaje de éxito o redirigir a otra página
            //lblMensaje.Text = "El CV ha sido guardado correctamente.";

            // Response.Redirect("Default.aspx");
        }
    }
}