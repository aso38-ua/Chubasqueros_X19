using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;

namespace Interfaz
{
    public partial class Reservas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ENUsuario usuario = new ENUsuario();
                usuario.nombre = (string)Session["username"];
                usuario.readUsuario();
                String constring = ConfigurationManager.ConnectionStrings["Database"].ToString();
                String consultaString = "SELECT * FROM [dbo].[Reservas] WHERE usuario = '" + usuario.id + "';";
                SqlConnection conexion = new SqlConnection(constring);
                conexion.Open();
                ENProducto[] productos = new ENProducto[1];
                try { 

                    SqlCommand consulta = new SqlCommand(consultaString, conexion);
                    SqlDataReader consultabusqueda = consulta.ExecuteReader();
                    int contador = 0;
                    while (consultabusqueda.Read())
                    {
                        contador++;
                    }
                    productos = new ENProducto[contador];
                    contador = 0;
                    consultabusqueda.Close();
                    consultabusqueda = consulta.ExecuteReader();
                    while (consultabusqueda.Read())
                    {
                        productos[contador] = new ENProducto();
                        productos[contador].setNombre(consultabusqueda["nombre"].ToString());
                        productos[contador].setCodigo(int.Parse(consultabusqueda["codigo"].ToString()));
                        productos[contador].setStock(int.Parse(consultabusqueda["stock"].ToString()));
                        productos[contador].setDescripcion(consultabusqueda["descripcion"].ToString());
                        productos[contador].setPrecio(float.Parse(consultabusqueda["precio"].ToString()));
                        productos[contador].setCodigoCategoria(int.Parse(consultabusqueda["codigoCategoria"].ToString()));
                        contador++;
                    }
                    consultabusqueda.Close();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Favorites operation has failed. Error: {0} ", ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Favorites operation has failed. Error: {0} ", ex.Message);
                }
                finally
                {
                    conexion.Close();
                }
                listView_Reservas.DataSource = productos;
                listView_Reservas.DataBind();
            }
        }
        protected void cancelarReserva(String name)
        {
            ENUsuario usuario = new ENUsuario();
            usuario.nombre = (string)Session["username"];
            usuario.readUsuario();
            String constring = ConfigurationManager.ConnectionStrings["Database"].ToString();
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(constring);
                connection.Open();

                string query = "Select * From [dbo].[Producto] Where nombre = " + name;
                SqlCommand consulta = new SqlCommand(query, connection);
                SqlDataReader busqueda = consulta.ExecuteReader();
                busqueda.Read();

                if (busqueda["nombre"].ToString() == name)
                {
                    ENReserva reserva = new ENReserva(usuario.id, int.Parse(busqueda["codigo"].ToString()));
                    reserva.deleteReserva();
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
            }
        }
    }
}