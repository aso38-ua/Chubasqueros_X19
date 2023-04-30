using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace Library
{
    class CADFavoritos
    {
        private string constring;

        public CADFavoritos()
        {
            constring = ConfigurationManager.ConnectionStrings["miconexion"].ToString();
        }

        public bool createFavorites(ENFavoritos en)
        {
            bool creado = false;
            try
            {
                String consultaString = "INSERT INTO [dbo].[Favoritos] (producto,usuario) VALUES ('" + en.productop[0] + "', " + en.usuariop + ");";
                SqlConnection conexion = new SqlConnection(constring);
                conexion.Open();

                SqlCommand consulta = new SqlCommand(consultaString, conexion);
                consulta.ExecuteNonQuery();
                if(en.productop.Length > 1)
                {
                    for(int i = 1; i < en.productop.Length; i++)
                    {
                        consultaString = "INSERT INTO [dbo].[Favoritos] (producto,usuario) VALUES ('" + en.productop[i] + "', " + en.usuariop + ");";
                        consulta = new SqlCommand(consultaString, conexion);
                        consulta.ExecuteNonQuery();
                    }
                }
                creado = true;
                conexion.Close();
            }
            catch (SqlException ex)
            {
                creado = false;
                Console.WriteLine("Favorites operation has failed. Error: {0} ", ex.Message);
            }
            catch (Exception ex)
            {
                creado = false;
                Console.WriteLine("Favorites operation has failed. Error: {0} ", ex.Message);
            }
            return creado;
        }

        public bool readFavorites(ENFavoritos en)
        {
            bool leido = false;
            try
            {
                String consultaString = "SELECT * FROM [dbo].[Favoritos] WHERE usuario = '" + en.usuariop + "';";
                SqlConnection conexion = new SqlConnection(constring);
                conexion.Open();

                SqlCommand consulta = new SqlCommand(consultaString, conexion);
                SqlDataReader consultabusqueda = consulta.ExecuteReader();
                int contador = 0;
                while (consultabusqueda.Read())
                {
                    if (contador == 0)
                    {
                        en.productop = new int[1];
                        en.productop[0] = int.Parse(consultabusqueda["producto"].ToString());
                        en.usuariop = int.Parse(consultabusqueda["usuario"].ToString());
                    }
                    else
                    {
                        en.insertarProducto(int.Parse(consultabusqueda["producto"].ToString()));
                    }
                }
                leido = true;
                consultabusqueda.Close();
                conexion.Close();
            }
            catch (SqlException ex)
            {
                leido = false;
                Console.WriteLine("Favorites operation has failed. Error: {0} ", ex.Message);
            }
            catch (Exception ex)
            {
                leido = false;
                Console.WriteLine("Favorites operation has failed. Error: {0} ", ex.Message);
            }
            return leido;
        }

        public bool deleteFavorites(ENFavoritos en)
        {
            bool borrado = false;
            try
            {
                String consultaString = "DELETE FROM [dbo].[Favoritos] WHERE usuario = '" + en.usuariop + "';";
                SqlConnection conexion = new SqlConnection(constring);
                conexion.Open();

                SqlCommand consulta = new SqlCommand(consultaString, conexion);
                consulta.ExecuteNonQuery();
                borrado = true;
                conexion.Close();
            }
            catch (SqlException ex)
            {
                borrado = false;
                Console.WriteLine("Favorites operation has failed. Error: {0} ", ex.Message);
            }
            catch (Exception ex)
            {
                borrado = false;
                Console.WriteLine("Favorites operation has failed. Error: {0} ", ex.Message);
            }
            return borrado;
        }

        public bool deleteProduct(ENFavoritos en)
        {
            bool borrado = false;
            try
            {
                String consultaString = "DELETE FROM [dbo].[Favoritos] WHERE usuario = '" + en.usuariop + " AND producto = '" + en.productop[0] + "';";
                SqlConnection conexion = new SqlConnection(constring);
                conexion.Open();

                SqlCommand consulta = new SqlCommand(consultaString, conexion);
                consulta.ExecuteNonQuery();
                borrado = true;
                conexion.Close();
            }
            catch (SqlException ex)
            {
                borrado = false;
                Console.WriteLine("Favorites operation has failed. Error: {0} ", ex.Message);
            }
            catch (Exception ex)
            {
                borrado = false;
                Console.WriteLine("Favorites operation has failed. Error: {0} ", ex.Message);
            }
            return borrado;
        }

        public bool insertProduct(ENFavoritos en)
        {
            bool borrado = false;
            try
            {
                String consultaString = "INSERT INTO [dbo].[Favoritos] (producto,usuario) VALUES ('" + en.productop[0] + "', " + en.usuariop + ");";
                SqlConnection conexion = new SqlConnection(constring);
                conexion.Open();

                SqlCommand consulta = new SqlCommand(consultaString, conexion);
                consulta.ExecuteNonQuery();
                borrado = true;
                conexion.Close();
            }
            catch (SqlException ex)
            {
                borrado = false;
                Console.WriteLine("Favorites operation has failed. Error: {0} ", ex.Message);
            }
            catch (Exception ex)
            {
                borrado = false;
                Console.WriteLine("Favorites operation has failed. Error: {0} ", ex.Message);
            }
            return borrado;
        }
    }
}
