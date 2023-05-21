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
    public partial class InterfazPedido : System.Web.UI.Page
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
            else
            {

            }
            */
        }

        protected void btn_pagar(object sender, EventArgs e)
        {
            Response.Redirect("");
        }

        protected void btn_cancelar(object sender, EventArgs e)
        {
            bool existe = false;
            ENUsuario usuario = new ENUsuario();
            usuario.nombre = (string)Session["username"];
            usuario.readUsuario();
            String constring = ConfigurationManager.ConnectionStrings["Database"].ToString();
            SqlConnection connection = null;
            /*
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
                    ENPedido pedido = new ENPedido(int.Parse(busqueda["id"].ToString()), usuario.id);
                    existe = true;
                    pedido.eliminarPedido();
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
                if (!existe) Message.Text = "No se ha podido cancelar el pedido";
                else Response.Redirect("Reservas.aspx");
            */
                Response.Redirect("InterfazCarrito.aspx");
           
        }
    }
}