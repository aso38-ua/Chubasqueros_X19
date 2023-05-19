using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using library;
using Library;

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
            else
            {
                ENProducto en_prod = new ENProducto();
                //en_prod.getNombre
                ENUsuario en_u = new ENUsuario();
                en_u.nombre = (string)Session["username"];
                en_u.readUsuario();
                ENPuntuacion en_p = new ENPuntuacion();
                //en_p.aux_estrella = int.Parse(Label3.Text);
                en_p.aux_id_user = en_u.id;
                ENComentario en_c = new ENComentario();
                en_c.aux_estrellas = en_p.aux_estrella;
                en_c.aux_id_user = en_p.aux_id_user;
                en_c.aux_item = en_c.aux_item;
                en_c.aux_comentario = TBComentario.Text;
                TBComentario.Text = en_c.aux_comentario;
            }
        }

        protected void RegresarClick(object sender, EventArgs e)
        {
            //Regresa a la pestaña de comentarios
            Response.Redirect("Comentario.aspx");
        }

        protected void ModificarClick(object sender, EventArgs e)
        {
            ENProducto en_prod = new ENProducto();
            //en_prod.getNombre
            ENUsuario en_u = new ENUsuario();
            en_u.nombre = (string)Session["username"];
            en_u.readUsuario();
            ENPuntuacion en_p = new ENPuntuacion();
           // en_p.aux_estrella = int.Parse(Label3.Text);
            en_p.aux_id_user = en_u.id;
            ENComentario en_c = new ENComentario();
            en_c.aux_estrellas = en_p.aux_estrella;
            en_c.aux_id_user = en_p.aux_id_user;
            en_c.aux_item = en_c.aux_item;
            en_c.aux_comentario = TBModificar.Text;
            if (en_c.changeComment() == true)
            {
                TBModificar.Text = en_c.aux_comentario;
                Label1.Text = "Se ha modificado el comentario correctamente";
            }
            else
            {
                Label1.Text = "Ha habido un error, compruebe que no haya superado el máximo de carácteres";
            }            
        }
    }
}