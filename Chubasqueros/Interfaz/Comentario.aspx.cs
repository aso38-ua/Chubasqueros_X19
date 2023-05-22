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
            //Si no está registrado no puede acceder a las opciones de comentario
            if (!IsPostBack)
            {
                if (Session["username"] == null)
                {
                    Like.Visible = false;
                    Dislike.Visible = false;
                    BtnEliminar.Visible = false;
                    BtnModificar.Visible = false;
                    TBModificar.Visible = false;
                    eliminarP.Visible = false;
                }
            }
        }

        //Regresa a la pestaña de producto
        protected void RegresarClick(object sender, EventArgs e)
        {
            Response.Redirect("Producto.aspx");
        }

        //Busca el producto que desea comentar
        protected void BuscarClick(object sender, EventArgs e)
        {
            if (TBBuscar.Text != "")
            {
                ENProducto en_prod = new ENProducto();
                en_prod.setCodigo(int.Parse(TBBuscar.Text));
                //Compruebo si existe el producto
                if (en_prod.readProducto() == true)
                {
                    //Muestro los datos
                    Label13.Text = "Nombre: ";
                    Label14.Text = en_prod.getNombre();
                    Label15.Text = "Precio: ";
                    Label16.Text = Convert.ToString(en_prod.getPrecio());
                    Label17.Text = "ID: ";
                    Label18.Text = Convert.ToString(en_prod.getCodigo());
                    //Creo un usuario con el usuario logeado
                    ENUsuario en_u = new ENUsuario();
                    en_u.nombre = (string)Session["username"];
                    ENPuntuacion en_p = new ENPuntuacion();
                    en_p.aux_item = en_prod.getCodigo();
                    //Muestro los datos actuales

                    ENComentario en_c = new ENComentario();
                    en_c.aux_item = en_p.aux_item;
                    //Se muestra el primer comentario
                    if (en_c.FirstComment() == true)
                    {
                        Comentarios.Text = en_c.aux_comentario;
                        Label10.Text = Convert.ToString(en_c.aux_likes);
                        Label11.Text = Convert.ToString(en_c.aux_dislikes);
                    }
                    else
                    {
                        Comentarios.Text = "No hay ningún comentarios";
                        Label10.Text = Convert.ToString(en_c.aux_likes);
                        Label11.Text = Convert.ToString(en_c.aux_dislikes);
                    }
                    //Muestra el comentario del cliente en ese producto en caso de haber y estar logeado
                    if (en_u.readUsuario())
                    {
                        en_p.aux_id_user = en_u.id;
                        //Muestro su puntuación en caso de haber
                        if (en_p.findItem() == true)
                        {
                            Label3.Text = Convert.ToString(en_p.aux_estrella);
                            Label6.Text = Convert.ToString(en_p.aux_media);
                        }
                        else
                        {
                            Label3.Text = Convert.ToString(en_p.aux_estrella);
                            Label6.Text = Convert.ToString(en_p.aux_media);
                        }
                        //Muestro su comentario en caso de haber
                        if (en_c.showComments())
                        {
                            TBComentario.Text = en_c.aux_comentario;
                            Label4.Text = Convert.ToString(en_c.aux_likes);
                            Label5.Text = Convert.ToString(en_c.aux_dislikes);
                        }
                    }
                }
                else
                {
                    Label9.Text = "El producto no existe. Por favor introzca un producto válido";
                }
            }
            else
            {
                Label9.Text = "Introduzca un producto por favor";
            }
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
                //Se asegura de que haya buscado un producto válido antes de puntuar
                if (Label6.Text != "" && TBBuscar.Text != "")
                {
                    ENProducto en_prod = new ENProducto();
                    en_prod.setCodigo(int.Parse(TBBuscar.Text));
                    if (en_prod.readProducto())
                    {
                        ENUsuario en_u = new ENUsuario();
                        en_u.nombre = (string)Session["username"];
                        en_u.readUsuario();
                        ENPuntuacion en_p = new ENPuntuacion();
                        en_p.aux_estrella = int.Parse(Label3.Text);
                        en_p.aux_id_user = en_u.id;
                        en_p.aux_item = en_prod.getCodigo();
                        en_p.aux_contador = en_p.aux_contador + 1;
                        if (en_p.changePuntuacion() == true)
                        {
                            /*en_p.aux_contador = en_p.aux_contador + 1;
                            ENPuntuacion en_p_aux = new ENPuntuacion();
                            en_p_aux.totalEstrellas();
                            en_p_aux.aux_contador = en_p.aux_contador;
                            en_p_aux.totalEstrellas();
                            en_p_aux.mediaPuntuacion();
                            en_p.aux_media = en_p_aux.aux_media;*/
                            Label3.Text = Convert.ToString(en_p.aux_estrella);
                            Label6.Text = Convert.ToString(en_p.aux_media);
                            Label7.Text = "Ha puntuado correctamente con " + en_p.aux_estrella;
                            if (en_p.aux_estrella == 1)
                            {
                                Label7.Text += "estrella";
                            }
                            else
                            {
                                Label7.Text += "estrellas";
                            }
                        }
                        else
                        {
                            Label7.Text = "Ha habido un error, compruebe que haya seleccionado una opción";
                        }
                    }
                    else
                    {
                        Label7.Text = "Busque un producto válido antes de puntuar con el botón buscar";
                    }
                }
                else
                {
                    Label7.Text = "Busque un producto antes de puntuar";
                }
            }
        }

        protected void PrimeroClick(object sender, EventArgs e)
        {
            if (TBBuscar.Text != "")
            {
                ENProducto en_prod = new ENProducto();
                en_prod.setCodigo(int.Parse(TBBuscar.Text));
                en_prod.readProducto();
                ENComentario en = new ENComentario();
                en.aux_item = en_prod.getCodigo();
                if (en.FirstComment() == true)
                {
                    Comentarios.Text = en.aux_comentario;
                    Label10.Text = Convert.ToString(en.aux_likes);
                    Label11.Text = Convert.ToString(en.aux_dislikes);
                }
                else
                {
                    Label12.Text = "No hay comentarios";
                }
            }
            else
            {
                Label9.Text = "Busque un Producto, por favor";
            }
        }
        protected void SiguienteClick(object sender, EventArgs e)
        {
            if (TBBuscar.Text != "")
            {
                ENProducto en_prod = new ENProducto();
                en_prod.setCodigo(int.Parse(TBBuscar.Text));
                en_prod.readProducto();
                ENComentario en = new ENComentario();
                en.aux_item = en_prod.getCodigo();
                if (Comentarios.Text == "")
                {
                    Label12.Text = "No hay comentarios, pruebe a leer el primer comentario";
                }
                else
                {
                    en.aux_comentario = Comentarios.Text;
                    en.aux_likes = int.Parse(Label10.Text);
                    en.aux_dislikes = int.Parse(Label11.Text);
                    if (en.PrevComment() == true)
                    {
                        Comentarios.Text = en.aux_comentario;
                        Label10.Text = Convert.ToString(en.aux_likes);
                        Label11.Text = Convert.ToString(en.aux_dislikes);
                    }
                    else
                    {
                        Label12.Text = "No es posible acceder a esta posición(Anterior)";
                    }
                }
            }
            else
            {
                Label9.Text = "Busque un Producto, por favor";
            }
        }

        protected void AnteriorClick(object sender, EventArgs e)
        {
            if (TBBuscar.Text != "")
            {
                ENProducto en_prod = new ENProducto();
                en_prod.setCodigo(int.Parse(TBBuscar.Text));
                en_prod.readProducto();
                ENComentario en = new ENComentario();
                en.aux_item = en_prod.getCodigo();
                if (Comentarios.Text == "")
                {
                    Label12.Text = "No hay comentarios, pruebe a leer el primer comentario";
                }
                else
                {
                    en.aux_comentario = Comentarios.Text;
                    en.aux_likes = int.Parse(Label10.Text);
                    en.aux_dislikes = int.Parse(Label11.Text);
                    if (en.NextComment() == true)
                    {
                        Comentarios.Text = en.aux_comentario;
                        Label10.Text = Convert.ToString(en.aux_likes);
                        Label11.Text = Convert.ToString(en.aux_dislikes);
                    }
                    else
                    {
                        Label12.Text = "No es posible acceder a esta posición(Siguiente)";
                    }
                }
            }
            else
            {
                Label9.Text = "Busque un Producto, por favor";
            }
        }

        protected void EliminarPClick(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                //Se asegura de que haya buscado un producto válido antes de puntuar
                if (Label6.Text != "" && TBBuscar.Text != "")
                {
                    ENProducto en_prod = new ENProducto();
                    en_prod.setCodigo(int.Parse(TBBuscar.Text));
                    if (en_prod.readProducto())
                    {
                        ENUsuario en_u = new ENUsuario();
                        en_u.nombre = (string)Session["username"];
                        en_u.readUsuario();
                        ENPuntuacion en_p = new ENPuntuacion();
                        en_p.aux_estrella = int.Parse(Label3.Text);
                        en_p.aux_id_user = en_u.id;
                        en_p.aux_item = en_prod.getCodigo();
                        if (en_p.eliminatePuntuacion() == true)
                        {
                            Label7.Text = "La puntuación se ha eliminado correctamente";
                        }
                        else
                        {
                            Label7.Text = "Ha habido un error, compruebe que haya seleccionado una opción";
                        }
                    }
                    else
                    {
                        Label7.Text = "Busque un producto válido antes de eliminar puntuación con el botón buscar";
                    }
                }
                else
                {
                    Label7.Text = "Busque un producto antes de eliminar puntuación";
                }
            }
        }

        protected void ComentarClick(object sender, EventArgs e)
        {
            //Comprueba que se haya registrado
            if (Session["username"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                //Se comprueba que se haya puntuado y buscado un item previamente
                if (Label6.Text != "" && TBBuscar.Text != "" && Label3.Text != "")
                {
                    ENProducto en_prod = new ENProducto();
                    en_prod.setCodigo(int.Parse(TBBuscar.Text));
                    if (en_prod.readProducto())
                    {
                        ENUsuario en_u = new ENUsuario();
                        en_u.nombre = (string)Session["username"];
                        en_u.readUsuario();
                        ENComentario en_c = new ENComentario();
                        en_c.aux_estrellas = int.Parse(Label3.Text);
                        en_c.aux_item = en_prod.getCodigo();
                        en_c.aux_id_user = en_u.id;
                        en_c.aux_comentario = TBComentario.Text;
                        if (en_c.createComment() == true)
                        {
                            TBComentario.Text = en_c.aux_comentario;
                            Label1.Text = "Se ha creado el comentario correctamente";
                        }
                        else
                        {
                            Label1.Text = "Ha habido un error, compruebe que no haya superado el máximo de carácteres (200)";
                        }
                    }
                    else
                    {
                        Label9.Text = "Busque un producto válido antes de comentar con el botón buscar";
                    }
                }
                else
                {
                    Label9.Text = "Busque un producto antes de comentar";
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
                //Se comprueba que se haya puntuado, comentado y buscado un item previamente
                if (Label6.Text != "" && TBBuscar.Text != "" && Label3.Text != "" && TBComentario.Text != "")
                {
                    ENProducto en_prod = new ENProducto();
                    en_prod.setCodigo(int.Parse(TBBuscar.Text));
                    if (en_prod.readProducto())
                    {
                        ENUsuario en_u = new ENUsuario();
                        en_u.nombre = (string)Session["username"];
                        en_u.readUsuario();
                        ENComentario en_c = new ENComentario();
                        en_c.aux_estrellas = int.Parse(Label3.Text);
                        en_c.aux_item = en_prod.getCodigo();
                        en_c.aux_id_user = en_u.id;
                        en_c.aux_comentario = TBComentario.Text;
                        if (en_c.eliminateComment() == true)
                        {
                            Label2.Text = "Se ha eliminado el comentario correctamente";
                        }
                        else
                        {
                            Label2.Text = "Ha habido un error, compruebe que haya comentado y esté con sus credenciales";
                        }
                    }
                    else
                    {
                        Label9.Text = "Busque un producto válido antes de eliminar el comentario con el botón buscar";
                    }
                }
                else
                {
                    Label9.Text = "Busque un producto antes de eliminar";
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
                //Se comprueba que se haya puntuado, comentado y buscado un item previamente
                if (Label6.Text != "" && TBBuscar.Text != "" && Label3.Text != "" && TBComentario.Text != "")
                {
                    ENProducto en_prod = new ENProducto();
                    en_prod.setCodigo(int.Parse(TBBuscar.Text));
                    if (en_prod.readProducto())
                    {
                        ENUsuario en_u = new ENUsuario();
                        en_u.nombre = (string)Session["username"];
                        en_u.readUsuario();
                        ENComentario en_c = new ENComentario();
                        en_c.aux_estrellas = int.Parse(Label3.Text);
                        en_c.aux_item = en_prod.getCodigo();
                        en_c.aux_id_user = en_u.id;
                        en_c.aux_comentario = TBComentario.Text;
                        if (en_c.likesItem() == false)
                        {
                            Label4.Text = "Ha habido un error";
                        }
                        else
                        {
                            Label4.Text = Convert.ToString(en_c.aux_likes);
                        }
                    }
                    else
                    {
                        Label9.Text = "Busque un producto válido con el botón buscar antes de darle a like";
                    }
                }
                else
                {
                    Label9.Text = "Busque un producto antes de darle like";
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
                //Se comprueba que se haya puntuado, comentado y buscado un item previamente
                if (Label6.Text != "" && TBBuscar.Text != "" && Label3.Text != "" && TBComentario.Text != "")
                {
                    ENProducto en_prod = new ENProducto();
                    en_prod.setCodigo(int.Parse(TBBuscar.Text));
                    if (en_prod.readProducto())
                    {
                        ENUsuario en_u = new ENUsuario();
                        en_u.nombre = (string)Session["username"];
                        en_u.readUsuario();
                        ENComentario en_c = new ENComentario();
                        en_c.aux_estrellas = int.Parse(Label3.Text);
                        en_c.aux_item = en_prod.getCodigo();
                        en_c.aux_id_user = en_u.id;
                        en_c.aux_comentario = TBComentario.Text;
                        if (en_c.dislikesItem() == false)
                        {
                            Label5.Text = "Ha habido un error";
                        }
                        else
                        {
                            Label5.Text = Convert.ToString(en_c.aux_dislikes);
                        }
                    }
                    else
                    {
                        Label9.Text = "Busque un producto válido con el botón buscar antes de darle dislike";
                    }
                }
                else
                {
                    Label9.Text = "Busque un producto antes de darle dislike";
                }
            }
        }

        protected void ModificarClick(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                //Se comprueba que se haya puntuado, comentado y buscado un item previamente
                if (Label6.Text != "" && TBBuscar.Text != "" && Label3.Text != "" && TBComentario.Text != "")
                {
                    ENProducto en_prod = new ENProducto();
                    en_prod.setCodigo(int.Parse(TBBuscar.Text));
                    if (en_prod.readProducto())
                    {
                        ENUsuario en_u = new ENUsuario();
                        en_u.nombre = (string)Session["username"];
                        en_u.readUsuario();
                        ENComentario en_c = new ENComentario();
                        en_c.aux_estrellas = int.Parse(Label3.Text);
                        en_c.aux_item = en_prod.getCodigo();
                        en_c.aux_id_user = en_u.id;
                        en_c.aux_comentario = TBComentario.Text;
                        if (en_c.changeComment() == true)
                        {
                            TBModificar.Text = en_c.aux_comentario;
                            Label8.Text = "Se ha modificado el comentario correctamente";
                        }
                        else
                        {
                            Label8.Text = "Ha habido un error, compruebe que haya comentado y esté con sus credenciales";
                        }
                    }
                    else
                    {
                        Label9.Text = "Busque un producto válido antes de modificar el comentario con el botón buscar";
                    }
                }
                else
                {
                    Label9.Text = "Busque un producto antes de modificar el comentario";
                }
            }
        }
    }
}