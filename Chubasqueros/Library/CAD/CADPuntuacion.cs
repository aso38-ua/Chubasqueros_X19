using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;
using System.Configuration;

namespace library
{
    public class CADPuntuacion
    {
        private String conn;

        public CADPuntuacion()
        {
            conn = ConfigurationManager.ConnectionStrings["miconexion"].ToString();
        }

        public bool createPuntuacion(ENPuntuacion en)
        {
            bool puntuar = false;
            SqlConnection conexion = null;
            string comando = "insert into [dbo].[Puntuacion] (estrellas, id_user, item) values (" + en.aux_estrella + ", " + en.aux_id_user + ", " + en.aux_item + ")";
            try
            {
                conexion = new SqlConnection(conn);
                conexion.Open();

                SqlCommand consulta = new SqlCommand(comando, conexion);
                consulta.ExecuteNonQuery();
                puntuar = true;
            }
            catch(SqlException sqlex)
            {
                puntuar = false;
                Console.WriteLine("User operation has failed.Error: {0}", sqlex.Message);
            }
            catch (Exception ex)
            {
                puntuar = false;
                Console.WriteLine("User operation has failed.Error: {0}", ex.Message);
            }
            finally
            {
                if (conexion != null) conexion.Close();
            }
            return puntuar;
        }

        public bool eliminatePuntuacion(ENPuntuacion en)
        {
            bool eliminate = false;
            SqlConnection conexion = null;
            string comando = "delete from [dbo].[Puntuacion] where id_user = " + en.aux_id_user + ", estrellas = " + en.aux_estrella + ", item = " + en.aux_item;
            try
            {
                conexion = new SqlConnection(conn);
                conexion.Open();
                SqlCommand consulta = new SqlCommand(comando, conexion);
                consulta.ExecuteNonQuery();

            }
            catch (SqlException sqlex)
            {
                eliminate = false;
                Console.WriteLine("User operation has failed.Error: {0}", sqlex.Message);
            }
            catch (Exception ex)
            {
                eliminate = false;
                Console.WriteLine("User operation has failed.Error: {0}", ex.Message);
            }
            finally
            {
                if (conexion != null) conexion.Close();
            }
            return eliminate;
        }

        public bool changePuntuacion(ENPuntuacion en)
        {
            bool change = false;
            SqlConnection conexion = null;
            string comando = "update [dbo].[Puntuacion] set estrellas = " + en.aux_estrella + " where id_user = " + en.aux_id_user + ", item = " + en.aux_item;
            try
            {
                conexion = new SqlConnection(conn);
                conexion.Open();
                SqlCommand consulta = new SqlCommand(comando, conexion);
                consulta.ExecuteNonQuery();

            }
            catch (SqlException sqlex)
            {
                change = false;
                Console.WriteLine("User operation has failed.Error: {0}", sqlex.Message);
            }
            catch (Exception ex)
            {
                change = false;
                Console.WriteLine("User operation has failed.Error: {0}", ex.Message);
            }
            finally
            {
                if (conexion != null) conexion.Close();
            }
            return change;
        }

        public bool mediaPuntuacion(ENPuntuacion en)
        {
            bool media = false;
            return media;
        }

        public bool findItem(ENPuntuacion en)
        {
            bool find = false;
            SqlConnection conexion = null;
            string comando = "select * from [dbo].[Puntuacion] where item = " + en.aux_item;
            try
            {
                conexion = new SqlConnection(conn);
                conexion.Open();

                SqlCommand consulta = new SqlCommand(comando, conexion);
                SqlDataReader rd = consulta.ExecuteReader();
                rd.Read();

                if (int.Parse(rd["item"].ToString()) == en.aux_item)
                {
                    find = true;
                    en.aux_id_user = int.Parse(rd["id_user"].ToString());
                    en.aux_estrella = int.Parse(rd["estrellas"].ToString());
                    en.aux_item = int.Parse(rd["item"].ToString());
                }

                rd.Close();
            }
            catch (SqlException sqlex)
            {
                find = false;
                Console.WriteLine("User operation has failed.Error: {0}", sqlex.Message);
            }
            catch (Exception ex)
            {
                find = false;
                Console.WriteLine("User operation has failed.Error: {0}", ex.Message);
            }
            finally
            {
                if (conexion != null) conexion.Close();
            }
            return find;
        }
    }
}
