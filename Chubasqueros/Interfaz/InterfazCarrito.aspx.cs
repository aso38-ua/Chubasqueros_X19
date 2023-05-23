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
					prod[i].readProducto();
					prod[i].setStock(carrito.producto[i]);
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
            ENCarrito carrito = new ENCarrito(usuario.id);
            String cons = ConfigurationManager.ConnectionStrings["Database"].ToString();
            SqlConnection conectsql = null;
            conectsql = new SqlConnection(cons);
            conectsql.Open();
            string cout = "INSERT INTO carrito (producto_id, preciotot, cantidad) VALUES (@producto_id, @preciotot, @cantidad)";
            SqlCommand command = new SqlCommand(cout, conectsql);
            using (command)
            {
                command.Parameters.AddWithValue("@producto_id", carrito.producto);
                command.Parameters.AddWithValue("@preciotot", carrito.total);
            }

            SqlDataReader cant = command.ExecuteReader();
            cant.Read();
            //Este valor es para convertir el textbox en int
            int valorEntero;
            //Comprueba si la conversion se puede realizar
            if(int.TryParse(textBox.Text, out valorEntero))
            {
                carrito.cantidad = valorEntero;
            }
            else
            {
                Message.Text = "La cantidad introducida no es correcta";
            }
            
            conectsql.Close();
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
            try
            {
                connection = new SqlConnection(cons);
                connection.Open();

                string query = "DELETE * FROM [dbo].[carrito] WHERE usuario = '" + usuario.id + "';";
                SqlCommand consulta = new SqlCommand(query, connection);

                connection.Close();
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
            Response.Redirect("Producto.aspx");
        }

        protected void ListView_Carrito_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        

    }
}
