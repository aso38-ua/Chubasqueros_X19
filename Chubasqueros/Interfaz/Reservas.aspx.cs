using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Interfaz
{
    public partial class Reservas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ENUsuario usuario = new ENUsuario();
                usuario.nombre = Session['username'];
                usuario.readusuario();
                ENReservas reservas = new ENReservas(usuario.id);
                reservas.readFavoritos();
                /*if (reservas.productop != null)
                {
                    int cantidadP = favoritos.productop.Length;
                    ENProducto[] productos = new ENProducto[cantidadP];
                    for (int i = 0; i < cantidadP; i++)
                    {
                        productos[i] = new ENProducto();
                        productos[i].setCodigo(favoritos.productop[i]);
                        productos[i].readProducto();
                    }
                    listView_Favoritos.DataSource = favoritos;
                    listView_Favoritos.DataBind();
                }*/
            }
        }
    }


    //Falta poner un botón para cancelar una reserva.
}