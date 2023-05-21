using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using Library;

namespace Interfaz
{
	public partial class InterfazCarrito : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            /*
            if (!IsPostBack)
            {
				if(Session["username"] == null)
                {
					Response.Redirect("Login.aspx");
                }
            }
			ENUsuario usuario = new ENUsuario();
			usuario.nombre = (string)Session["username"];
			usuario.readUsuario();
			ENCarrito carrito = new ENCarrito(usuario.id);
			carrito.verCarrito();
			if(carrito.producto != null)
            {
				int cantidadcarro = carrito.producto.Length;
				ENProducto[] prod = new ENProducto[cantidadcarro];
				for(int i = 0; i < cantidadcarro; i++)
                {
					prod[i] = new ENProducto();
					prod[i].setCodigo(carrito.producto[i]);
					prod[i].readProducto();
					prod[i].setStock(carrito.producto[i]);
                }
				//ListView_Carrito.DataSource = prod;
				//ListView_Carrito.DataBind();
            }
            */
		}

		protected void btn_compra(object sender, EventArgs e)
		{
			Response.Redirect("InterfazPedido.aspx");
		}

		protected void btn_eliminar(object sender, EventArgs e)
		{
			bool existe = false;
			ENUsuario usuario = new ENUsuario();
			usuario.nombre = (string)Session["username"];
			usuario.readUsuario();
			ENCarrito carrito = new ENCarrito(usuario.id);
			String cons = ConfigurationManager.ConnectionStrings["Database"].ToString();
            SqlConnection connection = null;
            /*
            try
            {
                connection = new SqlConnection(cons);
                connection.Open();

                string query = "Select * From [dbo].[producto] Where nombre = '" + text_nombre.Text + "';";
                SqlCommand consulta = new SqlCommand(query, connection);
                SqlDataReader busqueda = consulta.ExecuteReader();
                busqueda.Read();
                if (busqueda["nombre"].ToString() == text_nombre.Text)
                {
                    existe = true;
                    favoritos.deleteProductinBD(int.Parse(busqueda["id"].ToString()));
                }
                busqueda.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine("Product operation has failed.Error: {0}", e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Product operation has failed.Error: {0}", e.Message);
            }
            finally
            {
                connection.Close();
                if (!existe) Mensaje.Text = "Nombre del producto no válido";
                else Response.Redirect("Favoritos.aspx");
            }
            */
        }
    }
}
