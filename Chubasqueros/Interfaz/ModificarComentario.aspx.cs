using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using library;

namespace Interfaz
{
    public partial class WebForm2 : System.Web.UI.Page
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
        }

        protected void RegresarClick(object sender, EventArgs e)
        {
            //Regresa a la pestaña de comentarios
            Response.Redirect("Producto.aspx");
        }

        protected void ModificarClick(object sender, EventArgs e)
        {      
            ENComentario en = new ENComentario();
            //Datos del comentario (user, item)
            if (en.changeComment() == true)
            {
                Label1.Text = "Se ha modificado el comentario correctamente";
            }
            else
            {
                Label1.Text = "Ha habido un error, compruebe que no haya superado el máximo de carácteres";
            }            
        }
    }
}