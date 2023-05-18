using library;
using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Interfaz
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegresarClick(object sender, EventArgs e)
        {
            //Regresa a la pestaña de producto
            Response.Redirect("Producto.aspx");
        }

        protected void Estrella1Click(object sender, EventArgs e)
        {
            Label3.Text = "1";
        }

        protected void Estrella2Click(object sender, EventArgs e)
        {
            Label3.Text = "2";
        }
        protected void Estrella3Click(object sender, EventArgs e)
        {
            Label3.Text = "3";
        }
        protected void Estrella4Click(object sender, EventArgs e)
        {
            Label3.Text = "4";
        }
        protected void Estrella5Click(object sender, EventArgs e)
        {
            Label3.Text = "5";
        }
        protected void PuntuarClick(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                ENProducto en_prod = new ENProducto();
                //en_prod.getNombre
                ENUsuario en_u = new ENUsuario();
                en_u.nombre = (string)Session["username"];
                en_u.readUsuario();
                ENPuntuacion en_p = new ENPuntuacion();
                en_p.aux_estrella = int.Parse(Label3.Text);
                en_p.aux_id_user = en_u.id;
                if (en_p.createPuntuacion() == true)
                {
                    Label3.Text = "Ha puntuado correctamente";
                }
                else
                {
                    Label3.Text = "Ha habido un error, compruebe que haya seleccionado una opción";
                }
            }
        }
        protected void ComentarClick(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                ENProducto en_prod = new ENProducto();
                //en_prod.getNombre
                ENUsuario en_u = new ENUsuario();
                en_u.nombre = (string)Session["username"];
                en_u.readUsuario();
                ENPuntuacion en_p = new ENPuntuacion();
                en_p.aux_estrella = int.Parse(Label3.Text);
                en_p.aux_id_user = en_u.id;
                ENComentario en_c = new ENComentario();
                en_c.aux_estrellas = en_p.aux_estrella;
                en_c.aux_id_user = en_p.aux_id_user;
                en_c.aux_item = en_c.aux_item;
                en_c.aux_likes = 0;
                en_c.aux_dislikes = 0;
                en_c.aux_comentario = TBComentario.Text;
                //Datos del comentario (user, item)
                if (en_c.createComment() == true)
                {
                    Label1.Text = "Se ha creado el comentario correctamente";
                }
                else
                {
                    Label1.Text = "Ha habido un error, compruebe que no haya superado el máximo de carácteres";
                }
            }
        }
        protected void EliminarClick(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                ENProducto en_prod = new ENProducto();
                //en_prod.getNombre
                ENUsuario en_u = new ENUsuario();
                en_u.nombre = (string)Session["username"];
                en_u.readUsuario();
                ENPuntuacion en_p = new ENPuntuacion();
                en_p.aux_estrella = int.Parse(Label3.Text);
                en_p.aux_id_user = en_u.id;
                ENComentario en_c = new ENComentario();
                en_c.aux_estrellas = en_p.aux_estrella;
                en_c.aux_id_user = en_p.aux_id_user;
                en_c.aux_item = en_c.aux_item;
                en_c.aux_comentario = TBComentario.Text;
                //Datos del comentario (user, item)
                if (en_c.eliminateComment() == true)
                {
                    Label2.Text = "Se ha eliminado el comentario correctamente";
                }
                else
                {
                    Label2.Text = "Ha habido un error, compruebe que haya comentado y esté con sus credenciales";
                }
            }
        }
        protected void LikeClick(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                ENProducto en_prod = new ENProducto();
                //en_prod.getNombre
                ENUsuario en_u = new ENUsuario();
                en_u.nombre = (string)Session["username"];
                en_u.readUsuario();
                ENPuntuacion en_p = new ENPuntuacion();
                en_p.aux_estrella = int.Parse(Label3.Text);
                en_p.aux_id_user = en_u.id;
                ENComentario en_c = new ENComentario();
                en_c.aux_estrellas = en_p.aux_estrella;
                en_c.aux_id_user = en_p.aux_id_user;
                en_c.aux_item = en_c.aux_item;
                en_c.aux_comentario = TBComentario.Text;
                //Datos del comentario (user, item)
                if (en_c.likesItem() == false)
                {
                    Label4.Text = "Ha habido un error";
                }
            }
        }
        protected void DislikeClick(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                ENProducto en_prod = new ENProducto();
                //en_prod.getNombre
                ENUsuario en_u = new ENUsuario();
                en_u.nombre = (string)Session["username"];
                en_u.readUsuario();
                ENPuntuacion en_p = new ENPuntuacion();
                en_p.aux_estrella = int.Parse(Label3.Text);
                en_p.aux_id_user = en_u.id;
                ENComentario en_c = new ENComentario();
                en_c.aux_estrellas = en_p.aux_estrella;
                en_c.aux_id_user = en_p.aux_id_user;
                en_c.aux_item = en_c.aux_item;
                en_c.aux_comentario = TBComentario.Text;
                //Datos del comentario (user, item)
                if (en_c.dislikesItem() == false)
                {
                    Label5.Text = "Ha habido un error";
                }
            }
        }

        protected void ModificarClick(object sender, EventArgs e)
        {
            //Lleva a la pestaña de modificar
            Response.Redirect("ModificarComentario.aspx");
        }
    }
}