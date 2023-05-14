using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace Library
{
    class CADReserva
    {
        private string constring;

        public CADReserva()
        {
            constring = ConfigurationManager.ConnectionStrings["Database"].ToString();
        }

        public bool createReserva(ENReserva en)
        {
            bool creado = false;
            try
            {
                String consultaString = "INSERT INTO [dbo].[Reservas] (cantidad,fecha,producto,usuario,ptotal) VALUES (" + en.cantidadp + ", '" + en.fechap + "', " + en.productop + ", " + en.usuariop + ", " + en.ptotal + ");";
                SqlConnection conexion = new SqlConnection(constring);
                conexion.Open();

                SqlCommand consulta = new SqlCommand(consultaString, conexion);
                consulta.ExecuteNonQuery();
                creado = true;
                conexion.Close();
            }
            catch (SqlException ex)
            {
                creado = false;
                Console.WriteLine("Booking operation has failed. Error: {0} ", ex.Message);
            }
            catch (Exception ex)
            {
                creado = false;
                Console.WriteLine("Booking operation has failed. Error: {0} ", ex.Message);
            }
            return creado;
        }

        public bool readReserva(ENReserva en)
        {
            bool leido = false;
            try
            {
                String consultaString = "SELECT * FROM [dbo].[Reservas] WHERE usuario = " + en.usuariop + " AND producto = " + en.productop + ";";
                SqlConnection conexion = new SqlConnection(constring);
                conexion.Open();

                SqlCommand consulta = new SqlCommand(consultaString, conexion);
                SqlDataReader consultabusqueda = consulta.ExecuteReader();
                consultabusqueda.Read();

                if (int.Parse(consultabusqueda["usuario"].ToString()) == en.usuariop)
                {
                    leido = true;
                    en.cantidadp = int.Parse(consultabusqueda["cantidad"].ToString());
                    en.fechap = consultabusqueda["fecha"].ToString();
                    en.productop = int.Parse(consultabusqueda["producto"].ToString());
                    en.usuariop = int.Parse(consultabusqueda["usuario"].ToString());
                    en.ptotal = float.Parse(consultabusqueda["ptotal"].ToString());
                }

                consultabusqueda.Close();
                conexion.Close();
            }
            catch (SqlException ex)
            {
                leido = false;
                Console.WriteLine("Booking operation has failed. Error: {0} ", ex.Message);
            }
            catch (Exception ex)
            {
                leido = false;
                Console.WriteLine("Booking operation has failed. Error: {0} ", ex.Message);
            }
            return leido;
        }

        public bool updateReserva(ENReserva en)
        {
            bool actualizado = false;
            try
            {
                String consultaString = "UPDATE [dbo].[Reservas] SET cantidad = " + en.cantidadp + " ,ptotal = " + en.ptotal + " WHERE usuario = " + en.usuariop + " AND producto = " + en.productop + ";";
                SqlConnection conexion = new SqlConnection(constring);
                conexion.Open();

                SqlCommand consulta = new SqlCommand(consultaString, conexion);
                consulta.ExecuteNonQuery();
                actualizado = true;
                conexion.Close();
            }
            catch (SqlException ex)
            {
                actualizado = false;
                Console.WriteLine("Booking operation has failed. Error: {0} ", ex.Message);
            }
            catch (Exception ex)
            {
                actualizado = false;
                Console.WriteLine("Booking operation has failed. Error: {0} ", ex.Message);
            }
            return actualizado;
        }

        public bool deleteReserva(ENReserva en)
        {
            bool borrado = false;
            try
            {
                String consultaString = "DELETE FROM [dbo].[Reservas] WHERE usuario = " + en.usuariop + " AND producto = " + en.productop + ";";
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
                Console.WriteLine("Booking operation has failed. Error: {0} ", ex.Message);
            }
            catch (Exception ex)
            {
                borrado = false;
                Console.WriteLine("Booking operation has failed. Error: {0} ", ex.Message);
            }
            return borrado;
        }
    }
}
