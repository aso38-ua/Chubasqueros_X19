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
    public class CADOfertas
    {
        private string constring;

        public CADOfertas()
        {
            constring = ConfigurationManager.ConnectionStrings["Database"].ToString();
        }

        public CADOfertas(ENOfertas oferta)
        {
            constring = ConfigurationManager.ConnectionStrings["Database"].ToString();
        }

        // Crea una oferta en la BD
        public bool createOferta(ENOfertas oferta)
        {
            SqlConnection conn = new SqlConnection(constring);

            try
            {
                conn.Open();
                string query = "INSERT INTO [dbo].[Oferta] (idOferta, porcentajeDescuento, descripcion, img) VALUES ('" + oferta.IdOferta + "', '" + oferta.PorcentajeDescuento + "', '" + oferta.Descripcion + "', '" + oferta.Img + "')";
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

        // Lee una oferta de la BD
        public bool readOferta(ENOfertas oferta)
        {
            SqlConnection conn = new SqlConnection(constring);

            try
            {
                conn.Open();
                string query = "SELECT * FROM [dbo].[Oferta] WHERE idOferta = '" + oferta.IdOferta + "'";
                SqlCommand comm = new SqlCommand(query, conn);
                SqlDataReader reader = comm.ExecuteReader();
                reader.Read();

                if (reader["idOferta"].ToString() == oferta.IdOferta.ToString())
                {
                    oferta.IdOferta = int.Parse(reader["idOferta"].ToString());
                    oferta.PorcentajeDescuento = int.Parse(reader["porcentajeDescuento"].ToString());
                    oferta.Descripcion = reader["descripcion"].ToString();
                    oferta.Img = reader["Img"].ToString();

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

        // Actualiza una oferta en la BD
        public bool updateOferta(ENOfertas oferta)
        {
            SqlConnection conn = new SqlConnection(constring);

            try
            {
                conn.Open();
                string query = "UPDATE [dbo].[Oferta] SET idOferta = '" + oferta.IdOferta + "' , porcentajeDescuento = '" + oferta.PorcentajeDescuento + "' , descripcion = '" + oferta.Descripcion + "' , img = '" + oferta.Img + "' WHERE idOferta = '" + oferta.IdOferta + "'";
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

        // Elimina una oferta en la BD
        public bool deleteOferta(ENOfertas oferta)
        {
            SqlConnection conn = new SqlConnection(constring);
            string query = "DELETE FROM [dbo].[Oferta] WHERE idOferta = '" + oferta.IdOferta + "'";

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

        // Lee todas las ofertas de la BD
        public DataTable readAllOffers()
        {
            DataTable dataTable = new DataTable();

            SqlConnection conn = new SqlConnection(constring);
            try
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("SELECT * FROM Oferta", conn);
                SqlDataAdapter da = new SqlDataAdapter(comm);
                da.Fill(dataTable);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("The operation has failed. Error: {0}", ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("The operation has failed. Error: {0}", ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return dataTable;
        }
    }
}
