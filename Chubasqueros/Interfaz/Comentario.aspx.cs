using library;
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

        }

        protected void Estrella2Click(object sender, EventArgs e)
        {

        }
        protected void Estrella3Click(object sender, EventArgs e)
        {

        }
        protected void Estrella4Click(object sender, EventArgs e)
        {

        }
        protected void Estrella5Click(object sender, EventArgs e)
        {

        }
        protected void PuntuarClick(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                ENPuntuacion en = new ENPuntuacion();
                //Datos del comentario (user, item)
                if (en.createPuntuacion() == true)
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
                ENComentario en = new ENComentario();
                //Datos del comentario (user, item)
                if (en.createComment() == true)
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
                ENComentario en = new ENComentario();
                //Datos del comentario (user, item)
                if(en.eliminateComment() == true)
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
                ENComentario en = new ENComentario();
                //Datos del comentario (user, item)
                if (en.likesItem() == false)
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
                ENComentario en = new ENComentario();
                //Datos del comentario (user, item)
                if (en.dislikesItem() == false)
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

        protected void RespuestaClick(object sender, EventArgs e)
        {

        }
    }
}