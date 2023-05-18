using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;

namespace Interfaz
{
	public partial class InterfazCarrito : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			Message.Text = "";
		}

		protected void btn_compra(object sender, EventArgs e)
		{
			Response.Redirect("InterfazPedido.aspx");
		}

		protected void btn_eliminar(object sender, EventArgs e)
		{
			/*
			ENCarrito carrito = new ENCarrito();
            if (carrito.eliminarCarrito())
            {
				Message.Text = "Se han eliminado todos los productos del carrito";
            }
            else
            {
				Message.Text = "No hay productos en el carrito";
            }
			*/
		}
	}
}