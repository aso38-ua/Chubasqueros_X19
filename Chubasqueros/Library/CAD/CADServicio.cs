using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace library
{
    public class CADServicio
    {
        private string constring;

        public CADServicio()
        {
            constring = ConfigurationManager.ConnectionStrings["miconexion"].ToString();
        }

        public bool createServicio(ENServicio servicio)
        {
            SqlConnection conn = new SqlConnection(constring);
            string query = "INSERT INTO Servicio (idServicio, titulo, descripcion, img) VALUES ('" + servicio.IdServicio + "', '" + servicio.Titulo + "', " + servicio.Descripcion + ", '" + servicio.Img + ")";

            try
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(query, conn);
                comm.ExecuteNonQuery();
                conn.Close();

                return true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("User operation has failed. Error: {0}", ex.Message);
                conn.Close();

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("User operation has failed. Error: {0}", ex.Message);
                conn.Close();

                return false;
            }
        }

        public bool readServicio(ENServicio servicio)
        {
            SqlConnection conn = new SqlConnection(constring);

            string query = "SELECT * FROM Servicio WHERE idServicio = '" + servicio.IdServicio + "'";

            try
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(query, conn);
                SqlDataReader reader = comm.ExecuteReader();
                reader.Read();

                if (reader["idServicio"].ToString() == servicio.IdServicio.ToString())
                {
                    servicio.IdServicio = int.Parse(reader["idServicio"].ToString());
                    servicio.Titulo = reader["fechaInicio"].ToString();
                    servicio.Descripcion = reader["Descripcion"].ToString();
                    servicio.Img = reader["Img"].ToString();

                    reader.Close();
                    conn.Close();

                    return true;
                }

                reader.Close();
                conn.Close();

                return false;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("User operation has failed. Error: {0}", ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("User operation has failed. Error: {0}", ex.Message);
                return false;
            }
        }

        public bool updateServicio(ENServicio servicio)
        {
            SqlConnection conn = new SqlConnection(constring);
            string query = "UPDATE Servicio SET idServicio = '" + servicio.IdServicio + "', titulo =" + servicio.Titulo + "', descripcion =" + servicio.Descripcion + "', img = " + servicio.Img + "WHERE idServicio = '" + servicio.IdServicio + "'";

            try
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(query, conn);
                comm.ExecuteNonQuery();
                return true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("User operation has failed. Error: {0}", ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("User operation has failed. Error: {0}", ex.Message);
                return false;
            }
        }

        public bool deleteServicio(ENServicio servicio)
        {
            SqlConnection conn = new SqlConnection(constring);
            string query = "DELETE FROM Servicio WHERE idServicio = '" + servicio.IdServicio + "'";

            try
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(query, conn);
                comm.ExecuteNonQuery();
                return true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("User operation has failed. Error: {0}", ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("User operation has failed. Error: {0}", ex.Message);
                return false;
            }
        }

        /*
        public bool readAllServices(ENServicio servicio)
        {
            SqlConnection conn = new SqlConnection(constring);

            string query = "SELECT * FROM Servicio";

            try
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(query, conn);
                SqlDataReader reader = comm.ExecuteReader();
                reader.Read();

                if (reader["idServicio"].ToString() == servicio.IdServicio.ToString())
                {
                    servicio.IdServicio = int.Parse(reader["idServicio"].ToString());
                    servicio.Titulo = reader["fechaInicio"].ToString();
                    servicio.Descripcion = reader["Descripcion"].ToString();
                    servicio.Img = reader["Img"].ToString();

                    reader.Close();
                    conn.Close();

                    return true;
                }

                reader.Close();
                conn.Close();

                return false;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("User operation has failed. Error: {0}", ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("User operation has failed. Error: {0}", ex.Message);
                return false;
            }
        }*/
    }
}
