using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;

namespace Interfaz
{
    public partial class Favoritos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ENUsuario usuario = new ENUsuario();
                usuario.nombre = (string)Session["username"];
                usuario.readUsuario();
                ENFavoritos favoritos = new ENFavoritos(usuario.id);
                favoritos.readFavoritos();
                if (favoritos.productop != null)
                {
                    int cantidadP = favoritos.productop.Length;
                    ENProducto[] productos = new ENProducto[cantidadP];
                    for (int i = 0; i < cantidadP; i++)
                    {
                        productos[i] = new ENProducto();
                        productos[i].setCodigo(favoritos.productop[i]);
                        productos[i].readProducto();
                    }
                    listView_Favoritos.DataSource = productos;
                    listView_Favoritos.DataBind();
                }
            }
        }

        protected void eliminardeFavoritos(String name)
        {
            ENUsuario usuario = new ENUsuario();
            usuario.nombre = (string)Session["username"];
            usuario.readUsuario();
            ENFavoritos favoritos = new ENFavoritos(usuario.id);
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
                    favoritos.deleteProductinBD(int.Parse(busqueda["codigo"].ToString()));
                }
                busqueda.Close();
            }
            catch (SqlException e) { 
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