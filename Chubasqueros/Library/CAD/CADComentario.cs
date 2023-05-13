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
    public class CADComentario
    {
        private String conn;

        public CADComentario()
        {
            conn = ConfigurationManager.ConnectionStrings["miconexion"].ToString();
        }

        public bool createComment(ENComentario en)
        {
            bool create = false;
            SqlConnection conexion = null;
            string comando = "insert into [dbo].[Comentario] (id_user, item, estrellas, likes, dislikes, comentario) values (" + en.aux_id_user + ", " + en.aux_item + ", " + en.aux_estrellas + ", " + en.aux_likes + ", " + en.aux_dislikes + ", en.comentario = '" + en.aux_comentario + "')";
            try
            {
                conexion = new SqlConnection(conn);
                conexion.Open();

                SqlCommand consulta = new SqlCommand(comando, conexion);
                consulta.ExecuteNonQuery();
                create = true;
            }
            catch (SqlException sqlex)
            {
                create = false;
                Console.WriteLine("User operation has failed.Error: {0}", sqlex.Message);
            }
            catch (Exception ex)
            {
                create = false;
                Console.WriteLine("User operation has failed.Error: {0}", ex.Message);
            }
            finally
            {
                if (conexion != null) conexion.Close();
            }
            return create;
        }

        public bool eliminateComment(ENComentario en)
        {
            bool eliminate = false;
            SqlConnection conexion = null;
            string comando = "delete from [dbo].[Usuarios] where item = '" + en.aux_item + "'";
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

        public bool changeComment(ENComentario en)
        {
            bool change = false;
            SqlConnection conexion = null;
            string comando = "update [dbo].[Comentario] set comentario = '" + en.aux_comentario + "' where id_user = " + en.aux_id_user + ", item = " + en.aux_item;
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
        public bool showComments(ENComentario en)
        {
            bool show = false;
            SqlConnection conexion = null;
            string comando = "select * from [dbo].[Comentario] where item = " + en.aux_item;
            try
            {
                conexion = new SqlConnection(conn);
                conexion.Open();

                SqlCommand consulta = new SqlCommand(comando, conexion);
                SqlDataReader rd = consulta.ExecuteReader();
                rd.Read();

                if (int.Parse(rd["item"].ToString()) == en.aux_item)
                {
                    show = true;
                    en.aux_id_user = int.Parse(rd["id_user"].ToString());
                    en.aux_estrellas = int.Parse(rd["estrellas"].ToString());
                    en.aux_item = int.Parse(rd["item"].ToString());
                    en.aux_likes = int.Parse(rd["likes"].ToString());
                    en.aux_dislikes = int.Parse(rd["dislikes"].ToString());
                    en.aux_comentario = rd["comentario"].ToString();
                }

                rd.Close();
            }
            catch (SqlException sqlex)
            {
                show = false;
                Console.WriteLine("User operation has failed.Error: {0}", sqlex.Message);
            }
            catch (Exception ex)
            {
                show = false;
                Console.WriteLine("User operation has failed.Error: {0}", ex.Message);
            }
            finally
            {
                if (conexion != null) conexion.Close();
            }
            return show;
        }
            
        public bool likesItem(ENComentario en)
        {
            bool like = false;
            SqlConnection conexion = null;
            string comando = "update [dbo].[Comentario] set likes = '" + en.aux_likes + 1 + "' where item = " + en.aux_item;
            try {
                conexion = new SqlConnection(conn);
                conexion.Open();
                SqlCommand consulta = new SqlCommand(comando, conexion);
                consulta.ExecuteNonQuery();

            }
            catch (SqlException sqlex)
            {
                like = false;
                Console.WriteLine("User operation has failed.Error: {0}", sqlex.Message);
            }
            catch (Exception ex)
            {
                like = false;
                Console.WriteLine("User operation has failed.Error: {0}", ex.Message);
            }
            finally
            {
                if (conexion != null) conexion.Close();
            }
            return like;
        }

        public bool dislikesItem(ENComentario en)
        {
            bool dislike = false;
            SqlConnection conexion = null;
            string comando = "update [dbo].[Comentario] set likes = '" + en.aux_likes + 1 + "' where item = " + en.aux_item;
            try
            {
                conexion = new SqlConnection(conn);
                conexion.Open();
                SqlCommand consulta = new SqlCommand(comando, conexion);
                consulta.ExecuteNonQuery();

            }
            catch (SqlException sqlex)
            {
                dislike = false;
                Console.WriteLine("User operation has failed.Error: {0}", sqlex.Message);
            }
            catch (Exception ex)
            {
                dislike = false;
                Console.WriteLine("User operation has failed.Error: {0}", ex.Message);
            }
            finally
            {
                if (conexion != null) conexion.Close();
            }
            return dislike;
        }
    }
}
