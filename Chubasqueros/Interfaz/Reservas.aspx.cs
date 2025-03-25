using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;
using System.Configuration;
using System.Data.SqlClient;

namespace Interfaz
{
    public partial class Reservas : System.Web.UI.Page
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
                    if (usuario.esAdmin) { Response.Redirect("Reservasadmin.aspx"); }
                    else
                    {
                        String constring = ConfigurationManager.ConnectionStrings["Database"].ToString();
                        String consultaString = "SELECT * FROM [dbo].[Reservas] WHERE usuario = '" + usuario.id + "';";
                        SqlConnection conexion = new SqlConnection(constring);
                        conexion.Open();
                        ENProducto[] productos = new ENProducto[1];
                        try
                        {

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
                                productos[contador].setCodigo(int.Parse(consultabusqueda["producto"].ToString()));
                                productos[contador].readProducto();
                                productos[contador].cantidad = int.Parse(consultabusqueda["cantidad"].ToString());
                                productos[contador].ptotal = float.Parse(consultabusqueda["ptotal"].ToString());
                                productos[contador].fecha = consultabusqueda["fecha"].ToString();
                                contador++;
                            }
                            consultabusqueda.Close();
                            if (contador == 0) productos = null;
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
            }
        }
        protected void cancelarReserva(object sender, EventArgs ei)
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

                string query = "Select * From [dbo].[producto] Where nombre = '" + text_nombre.Text + "';";
                SqlCommand consulta = new SqlCommand(query, connection);
                SqlDataReader busqueda = consulta.ExecuteReader();
                busqueda.Read();
                if (busqueda["nombre"].ToString() == text_nombre.Text)
                {
                    ENReserva reserva = new ENReserva(int.Parse(busqueda["codigo"].ToString()), usuario.id);
                    existe = true;
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
                if (!existe) Mensaje.Text = "Nombre del producto no válido";
                else Response.Redirect("Reservas.aspx");
            }
        }
        protected void editarReserva(object sender, EventArgs ei)
        {
            try
            {
                if (int.Parse(text_cantidad.Text) < 1) Mensaje.Text = "Cantidad inválida, tiene que ser mayor que 0";
                else
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

                        string query = "Select * From [dbo].[producto] Where nombre = '" + text_nombre.Text + "';";
                        SqlCommand consulta = new SqlCommand(query, connection);
                        SqlDataReader busqueda = consulta.ExecuteReader();
                        busqueda.Read();
                        if (busqueda["nombre"].ToString() == text_nombre.Text)
                        {
                            ENReserva reserva = new ENReserva(int.Parse(busqueda["codigo"].ToString()), usuario.id);
                            existe = true;
                            reserva.readReserva();
                            reserva.cantidadp = int.Parse(text_cantidad.Text);
                            reserva.ptotal = double.Parse(busqueda["precio"].ToString()) * double.Parse(text_cantidad.Text);
                            reserva.updateReserva();
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
                        else Response.Redirect("Reservas.aspx");
                    }
                }
            } catch (Exception e) { Mensaje.Text = "Tiene que introducir un valor numérico para editar la cantidad"; }
            }
    }
}