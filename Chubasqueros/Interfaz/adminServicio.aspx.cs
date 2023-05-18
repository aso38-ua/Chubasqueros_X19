using library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Interfaz
{
    public partial class adminServicio : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnAddService_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                ENServicio servicio = new ENServicio();
                servicio.IdServicio = int.Parse(txtIdServicio.Text);
                servicio.Titulo = txtTitle.Text;
                servicio.Descripcion = txtDescription.Text;
                servicio.Img = txtImage.Text;

                if (servicio.createServicio())
                {
                    mensaje.Text = "Servicio " + servicio.Titulo + "creado";
                }
                else
                {
                    mensaje.Text = "Servicio " + servicio.Titulo + " no creado";
                }
            }
        }

        protected void btnEditService_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                ENServicio servicio = new ENServicio();
                servicio.IdServicio = int.Parse(txtIdServicio.Text);
                servicio.Titulo = txtTitle.Text;
                servicio.Descripcion = txtDescription.Text;
                servicio.Img = txtImage.Text;

                if (servicio.updateServicio())
                {
                    mensaje.Text = "Servicio " + servicio.Titulo + "actualizado";
                }
                else
                {
                    mensaje.Text = "Servicio " + servicio.Titulo + " no actualizado";
                }
            }
        }

        protected void btnDeleteService_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                ENServicio servicio = new ENServicio();
                servicio.IdServicio = int.Parse(txtIdServicio.Text);
                servicio.Titulo = txtTitle.Text;
                servicio.Descripcion = txtDescription.Text;
                servicio.Img = txtImage.Text;

                if (servicio.deleteServicio())
                {
                    mensaje.Text = "Servicio " + servicio.Titulo + "eliminado";
                }
                else
                {
                    mensaje.Text = "Servicio " + servicio.Titulo + " no eliminado";
                }
            }
        }
    }
}
