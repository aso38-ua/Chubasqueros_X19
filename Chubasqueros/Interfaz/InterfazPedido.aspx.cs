using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;

namespace Interfaz
{
    public partial class InterfazPedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Message.Text = "";
        }

        protected void btn_pagar(object sender, EventArgs e)
        {
            Response.Redirect("");
        }

        protected void btn_cancelar(object sender, EventArgs e)
        {
            Response.Redirect("InterfazCarrito.aspx");
            ENPedido pedido = new ENPedido();
            if (pedido.eliminarPedido())
            {
                Message.Text = "Pedido cancelado con exito";
            }
            else
            {
                Message.Text = "No es posible cancelar el pedido. Intentalo mas tarde";
            }
        }
    }
}