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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["username"] == null)
                    Response.Redirect("Login.aspx");
            }

            ENUsuario usuario = new ENUsuario();
            usuario.nombre = (string)Session["username"];
            usuario.readUsuario();

            if (!usuario.esAdmin) 
                Response.Redirect("Oferta.aspx"); 
        }

        protected void btnAddOffer_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    if (txtIdOferta.Text != "" && txtTitle.Text != "" && txtDescription.Text != "" && txtImage.Text != "")
                    {
                        ENOfertas oferta = new ENOfertas();
                        oferta.IdOferta = int.Parse(txtIdOferta.Text);
                        oferta.PorcentajeDescuento = int.Parse(txtTitle.Text);
                        oferta.Descripcion = txtDescription.Text;
                        oferta.Img = txtImage.Text;

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

        protected void btnEditOffer_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    if (txtIdOferta.Text != "" && txtTitle.Text != "" && txtDescription.Text != "" && txtImage.Text != "")
                    {
                        ENOfertas oferta = new ENOfertas();
                        oferta.IdOferta = int.Parse(txtIdOferta.Text);
                        oferta.PorcentajeDescuento = int.Parse(txtTitle.Text);
                        oferta.Descripcion = txtDescription.Text;
                        oferta.Img = txtImage.Text;

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

        protected void btnDeleteOffer_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    if (txtIdOferta.Text != "" && txtTitle.Text != "" && txtDescription.Text != "" && txtImage.Text != "")
                    {
                        ENOfertas oferta = new ENOfertas();
                        oferta.IdOferta = int.Parse(txtIdOferta.Text);
                        oferta.PorcentajeDescuento = int.Parse(txtTitle.Text);
                        oferta.Descripcion = txtDescription.Text;
                        oferta.Img = txtImage.Text;

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
