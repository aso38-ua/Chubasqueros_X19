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
    public partial class adminOferta : System.Web.UI.Page
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

            // Si el usuario no es admin, redirige a Ofertas
            if (!usuario.esAdmin) 
                Response.Redirect("Oferta.aspx"); 
        }

        // Botón agregar oferta
        protected void btnAddOffer_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    // Entra si no están vacíos los campos de oferta, porcentaje, descripción y ruta de la imagen
                    if (txtIdOferta.Text != "" && txtTitle.Text != "" && txtDescription.Text != "" && txtImage.Text != "")
                    {
                        // Instancia de oferta
                        ENOfertas oferta = new ENOfertas();
                        oferta.IdOferta = int.Parse(txtIdOferta.Text);
                        oferta.PorcentajeDescuento = int.Parse(txtTitle.Text);
                        oferta.Descripcion = txtDescription.Text;
                        oferta.Img = txtImage.Text;
                        
                        // Se crea la oferta en la BD
                        if (oferta.createOferta())
                        {
                            mensaje.Text = "Oferta \"" + oferta.IdOferta + "\" creado";
                        }
                        else
                        {
                            mensaje.Text = "Oferta \"" + oferta.IdOferta + "\" no creado";
                        }
                    }
                    else
                    {
                        mensaje.Text = "Por favor, complete todos los campos.";
                    }
                }
                catch (Exception ex)
                {
                    mensaje.Text = "Error al agregar el oferta: " + ex.Message;
                }
            }
        }

        // Botón actualizar oferta
        protected void btnEditOffer_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    // Entra si no están vacíos los campos de oferta, porcentaje, descripción y ruta de la imagen
                    if (txtIdOferta.Text != "" && txtTitle.Text != "" && txtDescription.Text != "" && txtImage.Text != "")
                    {
                        // Instancia de oferta
                        ENOfertas oferta = new ENOfertas();
                        oferta.IdOferta = int.Parse(txtIdOferta.Text);
                        oferta.PorcentajeDescuento = int.Parse(txtTitle.Text);
                        oferta.Descripcion = txtDescription.Text;
                        oferta.Img = txtImage.Text;

                        // Se actualiza la oferta en la BD
                        if (oferta.updateOferta())
                        {
                            mensaje.Text = "Oferta \"" + oferta.IdOferta + "\" actualizada";
                        }
                        else
                        {
                            mensaje.Text = "Oferta \"" + oferta.IdOferta + "\" no actualizada";
                        }
                    }
                    else
                    {
                        mensaje.Text = "Por favor, complete todos los campos.";
                    }
                }
                catch (Exception ex)
                {
                    mensaje.Text = "Error al editar el oferta: " + ex.Message;
                }
            }
        }

        // Botón eliminar oferta
        protected void btnDeleteOffer_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    // Entra si no están vacíos los campos de oferta, porcentaje, descripción y ruta de la imagen
                    if (txtIdOferta.Text != "" && txtTitle.Text != "" && txtDescription.Text != "" && txtImage.Text != "")
                    {
                        // Instancia de oferta
                        ENOfertas oferta = new ENOfertas();
                        oferta.IdOferta = int.Parse(txtIdOferta.Text);
                        oferta.PorcentajeDescuento = int.Parse(txtTitle.Text);
                        oferta.Descripcion = txtDescription.Text;
                        oferta.Img = txtImage.Text;

                        // Se elimina la oferta en la BD
                        if (oferta.deleteOferta())
                        {
                            mensaje.Text = "Oferta \"" + oferta.IdOferta + "\" eliminado";
                        }
                        else
                        {
                            mensaje.Text = "Oferta \"" + oferta.IdOferta + "\" no eliminado";
                        }
                    }
                    else
                    {
                        mensaje.Text = "Por favor, complete todos los campos.";
                    }
                }
                catch (Exception ex)
                {
                    mensaje.Text = "Error al eliminar el oferta: " + ex.Message;
                }
            }
        }
    }
}
