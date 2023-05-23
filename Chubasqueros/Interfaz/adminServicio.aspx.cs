using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using library;
using Library;

namespace Interfaz
{
    public partial class adminServicio : System.Web.UI.Page
    {
        // Evento al carga la página 
        protected void Page_Load(object sender, EventArgs e)
        {
            // Comprueba si la página es una carga inicial o un postback
            if (!IsPostBack)
            {
                // Verifica si no se ha iniciado sesión 
                if (Session["username"] == null)
                    Response.Redirect("Login.aspx");
            }

            ENUsuario usuario = new ENUsuario();
            usuario.nombre = (string)Session["username"];
            usuario.readUsuario();

            // Si el usuario no es admin, redirige a Servicio
            if (!usuario.esAdmin)
                Response.Redirect("Servicio.aspx"); 
        }

        // Botón agregar servicio
        protected void btnAddService_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    // Entra si no están vacíos los campos de id servicio, título, descripción y ruta de la imagen
                    if (txtIdServicio.Text != "" && txtTitle.Text != "" && txtDescription.Text != "" && txtImage.Text != "")
                    {
                        // Instancia de servicio
                        ENServicio servicio = new ENServicio();
                        servicio.IdServicio = int.Parse(txtIdServicio.Text);
                        servicio.Titulo = txtTitle.Text;
                        servicio.Descripcion = txtDescription.Text;
                        servicio.Img = txtImage.Text;

                        // Se crea el servicio en la BD
                        if (servicio.createServicio())
                        {
                            mensaje.Text = "Servicio \"" + servicio.Titulo + "\" creado";
                        }
                        else
                        {
                            mensaje.Text = "Servicio \"" + servicio.Titulo + "\" no creado";
                        }
                    }
                    else
                    {
                        mensaje.Text = "Por favor, complete todos los campos.";
                    }
                }
                catch (Exception ex)
                {
                    mensaje.Text = "Error al agregar el servicio: " + ex.Message;
                }
            }
        }

        // Botón actualizar servicio
        protected void btnEditService_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    // Entra si no están vacíos los campos de id servicio, título, descripción y ruta de la imagen
                    if (txtIdServicio.Text != "" && txtTitle.Text != "" && txtDescription.Text != "" && txtImage.Text != "")
                    {
                        // Instancia de servicio
                        ENServicio servicio = new ENServicio();
                        servicio.IdServicio = int.Parse(txtIdServicio.Text);
                        servicio.Titulo = txtTitle.Text;
                        servicio.Descripcion = txtDescription.Text;
                        servicio.Img = txtImage.Text;

                        // Se actualiza el servicio en la BD
                        if (servicio.updateServicio())
                        {
                            mensaje.Text = "Servicio \"" + servicio.Titulo + "\" actualizado";
                        }
                        else
                        {
                            mensaje.Text = "Servicio \"" + servicio.Titulo + "\" no actualizado";
                        }
                    }
                    else
                    {
                        mensaje.Text = "Por favor, complete todos los campos.";
                    }
                }
                catch (Exception ex)
                {
                    mensaje.Text = "Error al editar el servicio: " + ex.Message;
                }
            }
        }

        // Botón eliminar servicio
        protected void btnDeleteService_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    // Entra si no están vacíos los campos de id servicio, título, descripción y ruta de la imagen
                    if (txtIdServicio.Text != "" && txtTitle.Text != "" && txtDescription.Text != "" && txtImage.Text != "")
                    {
                        // Instancia de servicio
                        ENServicio servicio = new ENServicio();
                        servicio.IdServicio = int.Parse(txtIdServicio.Text);
                        servicio.Titulo = txtTitle.Text;
                        servicio.Descripcion = txtDescription.Text;
                        servicio.Img = txtImage.Text;

                        // Se elimina el servicio en la BD
                        if (servicio.deleteServicio())
                        {
                            mensaje.Text = "Servicio \"" + servicio.Titulo + "\" eliminado";
                        }
                        else
                        {
                            mensaje.Text = "Servicio \"" + servicio.Titulo + "\" no eliminado";
                        }
                    }
                    else
                    {
                        mensaje.Text = "Por favor, complete todos los campos.";
                    }
                }
                catch (Exception ex)
                {
                    mensaje.Text = "Error al eliminar el servicio: " + ex.Message;
                }
            }
        }
    }
}
