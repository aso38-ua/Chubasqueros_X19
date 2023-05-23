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
    public class CADCategoria
    {
        private String constring;

        public CADCategoria()
        {
            constring = ConfigurationManager.ConnectionStrings["Database"].ToString();
        }


        public bool createCategoria(ENCategoria en)
        {
            bool creado = false;
            SqlConnection connection = null;
            try
            {

                connection = new SqlConnection(constring);
                connection.Open();

                string query = "Insert INTO [dbo].[Categoría] (codCategoria, nombre) VALUES (" + en.getCodCategoria() + ", '" + en.getNombre() + "')";
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

        public bool deleteCategoria(ENCategoria en)
        {
            bool eliminado = true;
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(constring);
                connection.Open();

                string query = "DELETE FROM [dbo].[Categoría] WHERE codCategoria = '" + en.getCodCategoria() + "'";
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

        public bool readCategoria(ENCategoria en)
        {
            bool creado = true;
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(constring);
                connection.Open();

                string query = "Select * From [dbo].[Categoría] Where codCategoria = " + en.getCodCategoria();
                SqlCommand consulta = new SqlCommand(query, connection);
                SqlDataReader busqueda = consulta.ExecuteReader();
                busqueda.Read();

                if (int.Parse(busqueda["codCategoria"].ToString()) == en.getCodCategoria())
                {
                    en.setNombre(busqueda["nombre"].ToString());
                    en.setCodCategoria(int.Parse(busqueda["codCategoria"].ToString()));

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

        public bool updateCategoria(ENCategoria en)
        {
            bool creado = true;
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(constring);
                connection.Open();

                string query = "UPDATE [dbo].[Categoría] SET codCategoria = " + en.getCodCategoria() + " ,nombre= '" + en.getNombre() + "' WHERE codCategoria = " + en.getCodCategoria();
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

    }

}
