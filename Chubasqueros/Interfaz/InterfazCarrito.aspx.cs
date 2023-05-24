using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using Library;
using library;

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
            */
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
                    prod[i].setStock(carrito.producto[i]);
                    prod[i].readProducto();
					
                }
                //Contenedor del producto (uso de ListView)
				ListView_Carrito.DataSource = prod;
				ListView_Carrito.DataBind();
            }
		}

        private TextBox textBox;
        protected void ListView1_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                //Esto es para que pueda leerme el TextBox de cantidad dentro del listview
                textBox = (TextBox)e.Item.FindControl("boxcantidad");
            }
        }

        protected void btn_compra(object sender, EventArgs e)
		{
            
            bool existe = false;
            ENUsuario usuario = new ENUsuario();
            usuario.nombre = (string)Session["username"];
            usuario.readUsuario();
            String cons = ConfigurationManager.ConnectionStrings["Database"].ToString();
            SqlConnection conectsql = null;

            try
            {
                conectsql = new SqlConnection(cons);
                conectsql.Open();
                string cout = "INSERT INTO [dbo].[carrito] (producto_id, preciotot, cantidad) VALUES (@producto_id, @preciotot, @cantidad)";
                SqlCommand command = new SqlCommand(cout, conectsql);
                SqlDataReader search = command.ExecuteReader();
                search.Read();
                //Este valor es para convertir el textbox en int
                int valorEntero;
                //Comprueba si la conversion se puede realizar
                if (int.TryParse(textBox.Text, out valorEntero))
                {
                    existe = true;
                    ENCarrito carrito = new ENCarrito(int.Parse(search["codigo"].ToString()), usuario.id);
                    carrito.verCarrito();
                    carrito.cantidad = valorEntero;
                    carrito.actualizarCarrito();
                }
                else
                {
                    Message.Text = "La cantidad introducida no es correcta";
                }

            }
            catch (SqlException ex)
            {
                existe = false;
                Console.WriteLine("Product operation has failed.Error: {0}", ex.Message);
            }
            catch (Exception ex)
            {
                existe = false;
                Console.WriteLine("Product operation has failed.Error: {0}", ex.Message);
            }
            conectsql.Close();
            if (!existe) Message.Text = "Nombre del producto no válido";
            
            Response.Redirect("InterfazPedido.aspx");
            
           
        }

		protected void btn_eliminar(object sender, EventArgs e)
		{
			bool existe = false;
			ENUsuario usuario = new ENUsuario();
			usuario.nombre = (string)Session["username"];
            usuario.readUsuario();
			String cons = ConfigurationManager.ConnectionStrings["Database"].ToString();
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(cons);
                connection.Open();

                string query = "DELETE * FROM [dbo].[carrito] WHERE usuario_id = '" + usuario.id + "';";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader search = command.ExecuteReader();
                ENCarrito carrito = new ENCarrito(int.Parse(search["codigo"].ToString()), usuario.id);
                existe = true;
                carrito.eliminarCarrito();
                search.Close();

            }
            catch (SqlException ex)
            {
                existe = false;
                Console.WriteLine("Product operation has failed.Error: {0}", ex.Message);
            }
            catch (Exception ex)
            {
                existe = false;
                Console.WriteLine("Product operation has failed.Error: {0}", ex.Message);
            }
            finally
            {
                connection.Close();
                if (!existe) Message.Text = "No se ha podido eliminar el carrito o no tienes productos asignados";
                else Response.Redirect("InterfazCarrito.aspx");
            }
        }

        protected void btn_producto(object sender, EventArgs e)
        {
            //Es solo para volver a la pagina de productos (aunque aparece en la cabecera, pero podria servir de adorno)
            Response.Redirect("Producto.aspx");
        }

        protected string ObtenerPrecioTotal()
        {
            float total = 0;
            ENUsuario usuario = new ENUsuario();
            usuario.nombre = (string)Session["username"];
            usuario.readUsuario();
            String cons = ConfigurationManager.ConnectionStrings["Database"].ToString();
            SqlConnection conectsql = null;
            try
            {
                conectsql = new SqlConnection(cons);
                conectsql.Open();
                //string cout = "INSERT INTO carrito (producto_id, preciotot, cantidad) VALUES (@producto_id, @preciotot, @cantidad)";
                string cout = "SELECT precio, cantidad from [dbo].[carrito] where usuario_id ='" + usuario.id + "';";
                SqlCommand command = new SqlCommand(cout, conectsql);
                SqlDataReader search = command.ExecuteReader();
                search.Read();
                ENCarrito carrito = new ENCarrito(usuario.id);
                carrito.verCarrito();
                if (carrito.producto != null)
                {
                    int cantidadcarro = carrito.producto.Length;
                    ENProducto[] prod = new ENProducto[cantidadcarro];
                    for (int i = 0; i < cantidadcarro; i++)
                    {
                        total += prod[i].getPrecio();
                    }
                    carrito.total = total;
                }
                search.Close();
                
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Product operation has failed.Error: {0}", ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Product operation has failed.Error: {0}", ex.Message);
            }
            conectsql.Close();
            return total.ToString("C");
        } 

        protected void ListView_Carrito_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        

    }
}
