using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace library {
    public class CADOferta {
        private string constring;

        public CADOferta() {
            constring = ConfigurationManager.ConnectionStrings["Database"].ToString();
        }

        public bool createOferta(ENOferta oferta) {
            SqlConnection conn = new SqlConnection(constring);
            string query = "INSERT INTO Oferta (codigoOferta, fechaInicio, fechaFin, porcentajeDescuento) VALUES ('" + oferta.CodigoOferta + "', '" + oferta.FechaInicio + "', " + oferta.FechaFin + ", '" + oferta.PorcentajeDescuento + ")";

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

        public bool readOferta(ENOferta oferta) {
            SqlConnection conn = new SqlConnection(constring);

            string query = "SELECT * FROM Oferta WHERE codigoOferta = '" + oferta.CodigoOferta + "'";

            try
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(query, conn);
                SqlDataReader reader = comm.ExecuteReader();
                reader.Read();

                if (reader["codigoOferta"].ToString() == oferta.CodigoOferta.ToString()) {
                    oferta.CodigoOferta = int.Parse(reader["codigoOferta"].ToString());
                    oferta.FechaInicio = reader["fechaInicio"].ToString();
                    oferta.FechaFin = reader["FechaFin"].ToString();
                    oferta.PorcentajeDescuento = int.Parse(reader["porcentajeDescuento"].ToString());

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

        public bool updateOferta(ENOferta oferta) {
            SqlConnection conn = new SqlConnection(constring);
            string query = "UPDATE Oferta SET codigoOferta = '" + oferta.CodigoOferta + "', fechaInicio =" + oferta.FechaInicio + "', fechaFin =" + oferta.FechaFin + "', porcentajeDescuento = " + oferta.PorcentajeDescuento + "WHERE codigoOferta = '" + oferta.CodigoOferta + "'";

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

        public bool deleteOferta(ENOferta oferta) {
            SqlConnection conn = new SqlConnection(constring);
            string query = "DELETE FROM Oferta WHERE codigoOferta = '" + oferta.CodigoOferta + "'";

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
    }
}
