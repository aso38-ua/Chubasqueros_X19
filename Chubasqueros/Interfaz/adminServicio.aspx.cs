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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["username"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
            }

            ENUsuario usuario = new ENUsuario();
            usuario.nombre = (string)Session["username"];
            usuario.readUsuario();

            if (!usuario.esAdmin) { 
                Response.Redirect("Servicio.aspx"); }
        }

        protected void btnAddService_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    if (txtIdServicio.Text != "" && txtTitle.Text != "" && txtDescription.Text != "" && txtImage.Text != "")
                    {
                        ENServicio servicio = new ENServicio();
                        servicio.IdServicio = int.Parse(txtIdServicio.Text);
                        servicio.Titulo = txtTitle.Text;
                        servicio.Descripcion = txtDescription.Text;
                        servicio.Img = txtImage.Text;

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

        protected void btnEditService_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    if (txtIdServicio.Text != "" && txtTitle.Text != "" && txtDescription.Text != "" && txtImage.Text != "")
                    {
                        ENServicio servicio = new ENServicio();
                        servicio.IdServicio = int.Parse(txtIdServicio.Text);
                        servicio.Titulo = txtTitle.Text;
                        servicio.Descripcion = txtDescription.Text;
                        servicio.Img = txtImage.Text;

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

        protected void btnDeleteService_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    if (txtIdServicio.Text != "" && txtTitle.Text != "" && txtDescription.Text != "" && txtImage.Text != "")
                    {
                        ENServicio servicio = new ENServicio();
                        servicio.IdServicio = int.Parse(txtIdServicio.Text);
                        servicio.Titulo = txtTitle.Text;
                        servicio.Descripcion = txtDescription.Text;
                        servicio.Img = txtImage.Text;

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
