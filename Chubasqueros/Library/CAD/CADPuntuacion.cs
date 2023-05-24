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
            conn = ConfigurationManager.ConnectionStrings["Database"].ToString();
        }

        //Crea una puntuación
        public bool createPuntuacion(ENPuntuacion en)
        {
            bool puntuar = false;
            SqlConnection conexion = null;
            string comando = "insert into [dbo].[Puntuacion] (estrellas, id_user, item, media, contador) values (" + en.aux_estrella + ", " + en.aux_id_user + ", " + en.aux_item + ", " + en.aux_media + ", " + en.aux_contador + ")";
            try
            {
                conexion = new SqlConnection(conn);
                conexion.Open();

                SqlCommand consulta = new SqlCommand(comando, conexion);
                consulta.ExecuteNonQuery();
                puntuar = true;
            }
            catch (SqlException sqlex)
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

        //Elimina una puntuación
        public bool eliminatePuntuacion(ENPuntuacion en)
        {
            bool eliminate = false;
            SqlConnection conexion = null;
            string comando = "delete from [dbo].[Puntuacion] where id_user = " + en.aux_id_user + "and estrellas = " + en.aux_estrella + "and item = " + en.aux_item;
            try
            {
                eliminate = true;
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

        //Modifica una puntuación
        public bool changePuntuacion(ENPuntuacion en)
        {
            bool change = false;
            SqlConnection conexion = null;
            string comando = "update [dbo].[Puntuacion] set estrellas = " + en.aux_estrella + " where id_user = " + en.aux_id_user + "and item = " + en.aux_item;
            try
            {
                change = true;
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

        //Calcula la media de las puntuaciones
        public bool mediaPuntuacion(ENPuntuacion en)
        {
            bool mediaP = false;
            SqlConnection conexion = null;
            string comando = "update [dbo].[Puntuacion] set media = " + en.aux_estrella / en.aux_contador + "where item = " + en.aux_item;
            try
            {
                mediaP = true;
                conexion = new SqlConnection(conn);
                conexion.Open();
                SqlCommand consulta = new SqlCommand(comando, conexion);
                consulta.ExecuteNonQuery();

            }
            catch (SqlException sqlex)
            {
                mediaP = false;
                Console.WriteLine("User operation has failed.Error: {0}", sqlex.Message);
            }
            catch (Exception ex)
            {
                mediaP = false;
                Console.WriteLine("User operation has failed.Error: {0}", ex.Message);
            }
            finally
            {
                if (conexion != null) conexion.Close();
            }
            return mediaP;
        }

        //Calcula el número total de estrellas de un item
        public bool totalEstrellas(ENPuntuacion en)
        {
            bool totalE = false;
            int aux = 0;
            SqlConnection conexion = null;
            string comando = "select SUM(estrellas) AS aux from [dbo].[Puntuacion] where item = " + en.aux_item;
            try
            {
                conexion = new SqlConnection(conn);
                conexion.Open();

                SqlCommand consulta = new SqlCommand(comando, conexion);
                SqlDataReader rd = consulta.ExecuteReader();
                rd.Read();

                if (int.Parse(rd["item"].ToString()) == en.aux_item)
                {
                    totalE = true;
                    en.aux_estrella = aux;
                }
            }
            catch (SqlException sqlex)
            {
                totalE = false;
                Console.WriteLine("User operation has failed.Error: {0}", sqlex.Message);
            }
            catch (Exception ex)
            {
                totalE = false;
                Console.WriteLine("User operation has failed.Error: {0}", ex.Message);
            }
            finally
            {
                if (conexion != null) conexion.Close();
            }
            return totalE;
        }

        //Obtienes los datos de la puntuación de un objeto
        public bool findItem(ENPuntuacion en)
        {
            bool find = false;
            SqlConnection conexion = null;
            string comando = "select * from [dbo].[Puntuacion] where item = " + en.aux_item + "and id_user = " + en.aux_id_user;
            try
            {
                conexion = new SqlConnection(conn);
                conexion.Open();

                SqlCommand consulta = new SqlCommand(comando, conexion);
                SqlDataReader rd = consulta.ExecuteReader();
                rd.Read();

                if (int.Parse(rd["item"].ToString()) == en.aux_item && int.Parse(rd["id_user"].ToString()) == en.aux_id_user)
                {
                    find = true;
                    en.aux_id_user = int.Parse(rd["id_user"].ToString());
                    en.aux_estrella = int.Parse(rd["estrellas"].ToString());
                    en.aux_item = int.Parse(rd["item"].ToString());
                    en.aux_media = int.Parse(rd["media"].ToString());
                    en.aux_contador = int.Parse(rd["contador"].ToString());
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

        public bool findItemSinUser(ENPuntuacion en)
        {
            bool findU = false;
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
                    findU = true;
                    en.aux_id_user = int.Parse(rd["id_user"].ToString());
                    en.aux_estrella = int.Parse(rd["estrellas"].ToString());
                    en.aux_item = int.Parse(rd["item"].ToString());
                    en.aux_media = int.Parse(rd["media"].ToString());
                    en.aux_contador = int.Parse(rd["contador"].ToString());
                }

                rd.Close();
            }
            catch (SqlException sqlex)
            {
                findU = false;
                Console.WriteLine("User operation has failed.Error: {0}", sqlex.Message);
            }
            catch (Exception ex)
            {
                findU = false;
                Console.WriteLine("User operation has failed.Error: {0}", ex.Message);
            }
            finally
            {
                if (conexion != null) conexion.Close();
            }
            return findU;
        }
    }
}
