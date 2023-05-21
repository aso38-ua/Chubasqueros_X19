using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.Data.Common;

namespace Library
{
    public class CADProducto
    {
        private String constring;

        public CADProducto()
        {
            constring = ConfigurationManager.ConnectionStrings["Database"].ToString();
        }


        public bool createProducto(ENProducto en)
        {
            bool creado = false;
            SqlConnection connection = null;
            try
            {

                connection = new SqlConnection(constring);
                connection.Open();

                string query = "Insert INTO [dbo].[Producto] (codigo, nombre, descripcion, stock, precio, codigoCategoria) VALUES (" + en.getCodigo() + ", '" + en.getNombre() + "', '" + en.getDescripcion() + "', " + en.getStock() + ", " + en.getPrecio() + ", " + en.getCodigoCategoria() + ")";
                SqlCommand consulta = new SqlCommand(query, connection);
                consulta.ExecuteNonQuery();
                creado = true;
            }
            catch (SqlException e)
            {
                creado = false;
                Console.WriteLine("User operation has failed.Error: {0}", e.Message);
            }
            catch (Exception e)
            {
                creado = false;
                Console.WriteLine("User operation has failed.Error: {0}", e.Message);
            }
            finally
            {
                connection.Close();
            }

            return creado;
        }

        public bool readProducto(ENProducto en)
        {
            bool creado = true;
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(constring);
                connection.Open();

                string query = "Select * From [dbo].[producto] Where id = " + en.getCodigo() + ";";
                SqlCommand consulta = new SqlCommand(query, connection);
                SqlDataReader busqueda = consulta.ExecuteReader();
                busqueda.Read();

                if (int.Parse(busqueda["id"].ToString()) == en.getCodigo())
                {
                    en.setNombre(busqueda["nombre"].ToString());
                    en.setCodigo(int.Parse(busqueda["id"].ToString()));
                    en.setStock(int.Parse(busqueda["cantidad"].ToString()));
                    en.setDescripcion(busqueda["descripcion"].ToString());
                    en.setPrecio(float.Parse(busqueda["precio"].ToString()));
                    en.setCodigoCategoria(int.Parse(busqueda["codigoCategoria"].ToString()));
                }
                else creado = false;

                busqueda.Close();
            }
            catch (SqlException e)
            {
                creado = false;
                Console.WriteLine("User operation has failed.Error: {0}", e.Message);
            }
            catch (Exception e)
            {
                creado = false;
                Console.WriteLine("User operation has failed.Error: {0}", e.Message);
            }
            finally
            {
                connection.Close();
            }

            return creado;
        }


        public bool updateProducto(ENProducto en)
        {
            bool creado = true;
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(constring);
                connection.Open();

                string query = "UPDATE [dbo].[Producto] SET codigo = " + en.getCodigo() + " ,nombre= '" + en.getNombre() + "' ,descripcion= '" + en.getDescripcion() + "' ,stock= " + en.getStock() + " ,precio= " + en.getPrecio() + " ,codigoCategoria= " + en.getCodigoCategoria() + "WHERE codigo = " + en.getCodigo();
                SqlCommand consulta = new SqlCommand(query, connection);
                consulta.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                creado = false;
                Console.WriteLine("User operation has failed.Error: {0}", e.Message);
            }
            catch (Exception e)
            {
                creado = false;
                Console.WriteLine("User operation has failed.Error: {0}", e.Message);
            }
            finally
            {
                connection.Close();
            }

            return creado;
        }

        public bool deleteProducto(ENProducto en)
        {
            bool eliminado = false;
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(constring);
                connection.Open();

                string query = "DELETE FROM [dbo].[Producto] WHERE codigo = '" + en.getCodigo() + "'";
                SqlCommand consulta = new SqlCommand(query, connection);
                consulta.ExecuteNonQuery();
                eliminado = true;
            }
            catch (SqlException e)
            {
                eliminado = false;
                Console.WriteLine("User operation has failed.Error: {0}", e.Message);
            }
            catch (Exception e)
            {
                eliminado = false;
                Console.WriteLine("User operation has failed.Error: {0}", e.Message);
            }
            finally
            {
                connection.Close();
            }

            return eliminado;
        }

        public ENProducto[] mostrarProductosPorCategoria(ENCategoria en)
        {
            ENProducto[] productos = null;
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(constring);
                connection.Open();

                string query = "Select * From [dbo].[Producto] Where codigoCategoria = " + en.getCodCategoria();
                SqlCommand consulta = new SqlCommand(query, connection);
                SqlDataReader busqueda = consulta.ExecuteReader();
                int contador = 0;

                while (busqueda.Read())
                    contador++;
                busqueda.Close();
                productos = new ENProducto[contador];

                SqlCommand consult = new SqlCommand(query, connection);
                SqlDataReader busqued = consult.ExecuteReader();
                int i = 0;
                while (busqued.Read())
                {
                    productos[i] = new ENProducto();
                    productos[i].setNombre(busqueda["nombre"].ToString());
                    productos[i].setCodigo(int.Parse(busqueda["codigo"].ToString()));
                    productos[i].setStock(int.Parse(busqueda["stock"].ToString()));
                    productos[i].setDescripcion(busqueda["descripcion"].ToString());
                    productos[i].setPrecio(float.Parse(busqueda["precio"].ToString()));
                    productos[i].setCodigoCategoria(int.Parse(busqueda["codigoCategoria"].ToString()));
                    i++;
                }

                busqued.Close();
            }
            catch (SqlException e)
            {
                
                Console.WriteLine("User operation has failed.Error: {0}", e.Message);
            }
            catch (Exception e)
            {
                
                Console.WriteLine("User operation has failed.Error: {0}", e.Message);
            }
            finally
            {
                connection.Close();
            }

            return productos;
        }

    }

}
