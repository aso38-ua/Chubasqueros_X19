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
    public partial class InterfazPedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ENUsuario usuario = new ENUsuario();
            usuario.nombre = (string)Session["username"];
            usuario.readUsuario();
            
            if (usuario.esAdmin) { Response.Redirect(""); }
            else
            {

                String constring = ConfigurationManager.ConnectionStrings["Database"].ToString();
                String consultaString = "SELECT * FROM [dbo].[pedido] WHERE usuario = '" + usuario.id + "';";
                SqlConnection conexion = new SqlConnection(constring);
                conexion.Open();
                ENProducto[] prod = new ENProducto[1];
                try
                {

                    SqlCommand consulta = new SqlCommand(consultaString, conexion);
                    SqlDataReader consultabusqueda = consulta.ExecuteReader();
                    int contador = 0;
                    while (consultabusqueda.Read())
                    {
                        contador++;
                    }
                    prod = new ENProducto[contador];
                    contador = 0;
                    consultabusqueda.Close();
                    consultabusqueda = consulta.ExecuteReader();
                    while (consultabusqueda.Read())
                    {
                        prod[contador] = new ENProducto();
                        prod[contador].setCodigo(int.Parse(consultabusqueda["producto"].ToString()));
                        prod[contador].readProducto();
                        prod[contador].cantidad = int.Parse(consultabusqueda["cantidad"].ToString());
                        prod[contador].ptotal = double.Parse(consultabusqueda["ptotal"].ToString());
                        prod[contador].fecha = consultabusqueda["fecha"].ToString();
                        contador++;
                    }
                    consultabusqueda.Close();
                    if (contador == 0) prod = null;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Order operation has failed. Error: {0} ", ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Order operation has failed. Error: {0} ", ex.Message);
                }
                finally
                {
                    conexion.Close();
                }
                //Contenedor del producto (uso de ListView)
                ListView_Pedido.DataSource = prod;
                ListView_Pedido.DataBind();

                ListView_PedUsuario.DataSource = usuario;
                ListView_PedUsuario.DataBind();
            }
            
        }

        protected void btn_pagar(object sender, EventArgs e)
        {
            
            ENUsuario usuario = new ENUsuario();
            ENProducto producto = new ENProducto();
            ENPedido pedido = new ENPedido(producto.getCodigo(), usuario.id);
            String cons = ConfigurationManager.ConnectionStrings["Database"].ToString();
            SqlConnection conectsql = null;
            conectsql = new SqlConnection(cons);
            string cout = "INSERT INTO pedido (producto_id, preciotot, cantidad) VALUES (@producto_id, @preciotot, @cantidad)";
            
            using (SqlCommand command = new SqlCommand(cout, conectsql))
            {
                command.Parameters.AddWithValue("@producto_id", pedido.producto);
                command.Parameters.AddWithValue("@preciotot", pedido.total);
                command.Parameters.AddWithValue("@cantidad", pedido.cantidad);

                conectsql.Open();
                command.ExecuteNonQuery();
            }
            //Llevaria a otra interfaz de pagar
            Response.Redirect("");
            //Response.Redirect("InterfazPedido.aspx");
        }

        protected void btn_cancelar(object sender, EventArgs e)
        {
            bool existe = false;
            ENUsuario usuario = new ENUsuario();
            usuario.nombre = (string)Session["username"];
            usuario.readUsuario();
            String constring = ConfigurationManager.ConnectionStrings["Database"].ToString();
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(constring);
                connection.Open();

                string query = "DELETE * FROM [dbo].[pedido] WHERE usuario = '" + usuario.id + "';";
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
                if (!existe) Message.Text = "No se ha podido cancelar el pedido";
                else Response.Redirect("InterfazCarrito.aspx");
            }
        }
    }
}