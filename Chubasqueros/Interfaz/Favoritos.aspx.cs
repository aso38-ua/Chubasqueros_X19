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
                if (Session["username"] == null)
                {
                    // El usuario no ha iniciado sesión, redirigir a la página de inicio de sesión
                    Response.Redirect("Login.aspx");
                }
                else
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
                            productos[i].setStock(favoritos.productop[i]);
                        }
                        listView_Favoritos.DataSource = productos;
                        listView_Favoritos.DataBind();
                    }
                }
            }
        }

        protected void eliminardeFavoritos(object sender, EventArgs ei)
        {
            bool existe = false;
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
                if (!existe) Mensaje.Text = "Nombre del producto no válido";
                else Response.Redirect("Favoritos.aspx");
            }
        }
    }

    
}