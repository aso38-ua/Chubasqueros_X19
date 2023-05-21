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

        public CADOfertas(ENOfertas servicio)
        {
            constring = ConfigurationManager.ConnectionStrings["Database"].ToString();
        }

        public bool createOferta(ENOfertas servicio)
        {
            SqlConnection conn = new SqlConnection(constring);

            try
            {
                conn.Open();
                string query = "INSERT INTO [dbo].[Oferta] (idOferta, porcentajeDescuento, descripcion, img) VALUES ('" + servicio.IdOferta + "', '" + servicio.PorcentajeDescuento + "', '" + servicio.Descripcion + "', '" + servicio.Img + "')";
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

        public bool readOferta(ENOfertas servicio)
        {
            SqlConnection conn = new SqlConnection(constring);

            try
            {
                conn.Open();
                string query = "SELECT * FROM [dbo].[Oferta] WHERE idOferta = '" + servicio.IdOferta + "'";
                SqlCommand comm = new SqlCommand(query, conn);
                SqlDataReader reader = comm.ExecuteReader();
                reader.Read();

                if (reader["idOferta"].ToString() == servicio.IdOferta.ToString())
                {
                    servicio.IdOferta = int.Parse(reader["idOferta"].ToString());
                    servicio.PorcentajeDescuento = int.Parse(reader["porcentajeDescuento"].ToString());
                    servicio.Descripcion = reader["descripcion"].ToString();
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

        public bool updateOferta(ENOfertas servicio)
        {
            SqlConnection conn = new SqlConnection(constring);

            try
            {
                conn.Open();
                string query = "UPDATE [dbo].[Oferta] SET idOferta = '" + servicio.IdOferta + "' , porcentajeDescuento = '" + servicio.PorcentajeDescuento + "' , descripcion = '" + servicio.Descripcion + "' , img = '" + servicio.Img + "' WHERE idOferta = '" + servicio.IdOferta + "'";
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

        public bool deleteOferta(ENOfertas servicio)
        {
            SqlConnection conn = new SqlConnection(constring);
            string query = "DELETE FROM [dbo].[Oferta] WHERE idOferta = '" + servicio.IdOferta + "'";

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
