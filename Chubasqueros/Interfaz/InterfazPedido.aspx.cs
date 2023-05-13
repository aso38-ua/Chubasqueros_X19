using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Interfaz
{
    public partial class InterfazPedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_pagar(object sender, EventArgs e)
        {
            Response.Redirect("");
        }

        protected void btn_cancelar(object sender, EventArgs e)
        {
            Response.Redirect("InterfazCarrito.aspx");
        }
    }
}