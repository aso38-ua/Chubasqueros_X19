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
            conn = ConfigurationManager.ConnectionStrings["Database"].ToString();
        }

        //Crea comentario
        public bool createComment(ENComentario en)
        {
            bool create = false;
            SqlConnection conexion = null;
            string comando = "insert into [dbo].[Comentario] (id_user, item, estrellas, likes, dislikes, comentario) values (@id_user, @item, @estrellas, @likes, @dislikes, @comentario)";
            try
            {
                conexion = new SqlConnection(conn);
                conexion.Open();

                SqlCommand consulta = new SqlCommand(comando, conexion);
                consulta.Parameters.AddWithValue("@id_user", en.aux_id_user);
                consulta.Parameters.AddWithValue("@item", en.aux_item);
                consulta.Parameters.AddWithValue("@estrellas", en.aux_estrellas);
                consulta.Parameters.AddWithValue("@likes", en.aux_likes);
                consulta.Parameters.AddWithValue("@dislikes", en.aux_dislikes);
                consulta.Parameters.AddWithValue("@comentario", en.aux_comentario);
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

        //Elimina comentario
        public bool eliminateComment(ENComentario en)
        {
            bool eliminate = false;
            SqlConnection conexion = null;
            string comando = "delete from [dbo].[Comentario] where (item = @item) and (id_user = @id_user) and (estrellas = @estrellas)";
            try
            {
                eliminate = true;
                conexion = new SqlConnection(conn);
                conexion.Open();
                SqlCommand consulta = new SqlCommand(comando, conexion);
                consulta.Parameters.AddWithValue("@item", en.aux_item);
                consulta.Parameters.AddWithValue("@id_user", en.aux_id_user);
                consulta.Parameters.AddWithValue("@estrellas", en.aux_estrellas);
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

        //Modifica comentario
        public bool changeComment(ENComentario en)
        {
            bool change = false;
            SqlConnection conexion = null;
            string comando = "update [dbo].[Comentario] set comentario = '" + en.aux_comentario + "' where id_user = " + en.aux_id_user + "and item = " + en.aux_item;
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
        //Muestra el primer comentario 
        public bool FirstComment(ENComentario en)
        {
            bool first = true;
            SqlConnection conexion = null;
            string comando = "select * from [dbo].[Comentario] where item = " + en.aux_item;
            try
            {
                conexion = new SqlConnection(conn);
                conexion.Open();

                SqlCommand consulta = new SqlCommand(comando, conexion);
                SqlDataReader rd = consulta.ExecuteReader();
                rd.Read();
                en.aux_comentario = rd["comentario"].ToString();
                en.aux_likes = int.Parse(rd["likes"].ToString());
                en.aux_dislikes = int.Parse(rd["dislikes"].ToString());

                rd.Close();
                conexion.Close();
            }
            catch (SqlException sqlex)
            {
                first = false;
                Console.WriteLine("User operation has failed.Error: {0}", sqlex.Message);
            }
            catch (Exception ex)
            {
                first = false;
                Console.WriteLine("User operation has failed.Error: {0}", ex.Message);
            }
            finally
            {
                if (conexion != null) conexion.Close();
            }
            return first;
        }
        //Muestra el comentario anterior
        public bool PrevComment(ENComentario en)
        {
            bool prev = false;
            SqlConnection conexion = null;
            string comando = "select * from [dbo].[Comentario] where item = " + en.aux_item;
            try
            {
                conexion = new SqlConnection(conn);
                conexion.Open();

                SqlCommand consulta = new SqlCommand(comando, conexion);
                SqlDataReader rd = consulta.ExecuteReader();
                rd.Read();
                en.aux_comentario = rd["comentario"].ToString();
                en.aux_likes = int.Parse(rd["likes"].ToString());
                en.aux_dislikes = int.Parse(rd["dislikes"].ToString());

                while (rd.Read() == true && prev == false)
                {
                    if (rd["item"].ToString() == en.aux_item.ToString())
                    {
                        prev = true;
                    }
                    if (prev != true)
                    {
                        en.aux_comentario = rd["comentario"].ToString();
                        en.aux_likes = int.Parse(rd["likes"].ToString());
                        en.aux_dislikes = int.Parse(rd["dislikes"].ToString());
                    }
                }
                if (prev == true)
                {
                    en.aux_comentario = rd["comentario"].ToString();
                    en.aux_likes = int.Parse(rd["likes"].ToString());
                    en.aux_dislikes = int.Parse(rd["dislikes"].ToString());
                }

                rd.Close();
            }
            catch (SqlException sqlex)
            {
                prev = false;
                Console.WriteLine("User operation has failed.Error: {0}", sqlex.Message);
            }
            catch (Exception ex)
            {
                prev = false;
                Console.WriteLine("User operation has failed.Error: {0}", ex.Message);
            }
            finally
            {
                if (conexion != null) conexion.Close();
            }
            return prev;
        }
        //Muestra el comentario siguiente
        public bool NextComment(ENComentario en)
        {
            bool next = false, aux = false;
            SqlConnection conexion = null;
            string comando = "select * from [dbo].[Comentario] where item = " + en.aux_item;
            try
            {
                conexion = new SqlConnection(conn);
                conexion.Open();

                SqlCommand consulta = new SqlCommand(comando, conexion);
                SqlDataReader rd = consulta.ExecuteReader();

                do
                {
                    if (aux == true)
                    {
                        next = true;
                    }
                    else if (rd["id_user"].ToString() == en.aux_id_user.ToString())
                    {
                        aux = true;
                    }
                } while (rd.Read() == true && next == false);

                if (next == true)
                {
                    en.aux_comentario = rd["comentario"].ToString();
                    en.aux_likes = int.Parse(rd["likes"].ToString());
                    en.aux_dislikes = int.Parse(rd["dislikes"].ToString());
                }

                rd.Close();
            }
            catch (SqlException sqlex)
            {
                next = false;
                Console.WriteLine("User operation has failed.Error: {0}", sqlex.Message);
            }
            catch (Exception ex)
            {
                next = false;
                Console.WriteLine("User operation has failed.Error: {0}", ex.Message);
            }
            finally
            {
                if (conexion != null) conexion.Close();
            }
            return next;
        }




        //Muestra comentarios del item
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

        //Obtine los datos de un comentario según el item y el usuario
        public bool readComment(ENComentario en)
        {
            bool read = false;
            SqlConnection conexion = null;
            string comando = "select * from [dbo].[Comentario] where item = " + en.aux_item + "and id_user = " + en.aux_id_user;
            try
            {
                conexion = new SqlConnection(conn);
                conexion.Open();

                SqlCommand consulta = new SqlCommand(comando, conexion);
                SqlDataReader rd = consulta.ExecuteReader();
                rd.Read();

                if (int.Parse(rd["item"].ToString()) == en.aux_item && int.Parse(rd["id_user"].ToString()) == en.aux_id_user)
                {
                    read = true;
                    en.aux_id_user = int.Parse(rd["id_user"].ToString());
                    en.aux_estrellas = int.Parse(rd["estrellas"].ToString());
                    en.aux_item = int.Parse(rd["item"].ToString());
                    en.aux_likes = int.Parse(rd["likes"].ToString());
                    en.aux_dislikes = int.Parse(rd["dislikes"].ToString());
                }

                rd.Close();
            }
            catch (SqlException sqlex)
            {
                read = false;
                Console.WriteLine("User operation has failed.Error: {0}", sqlex.Message);
            }
            catch (Exception ex)
            {
                read = false;
                Console.WriteLine("User operation has failed.Error: {0}", ex.Message);
            }
            finally
            {
                if (conexion != null) conexion.Close();
            }
            return read;
        }


        //Suma 1 al like
        public bool likesItem(ENComentario en)
        {
            bool like = false;
            SqlConnection conexion = null;
            string comando = "update [dbo].[Comentario] set likes = " + en.aux_likes + " where item = " + en.aux_item + "and comentario = '" + en.aux_comentario + "'";
            try
            {
                like = true;
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

        //Suma 1 al dislike
        public bool dislikesItem(ENComentario en)
        {
            bool dislike = false;
            SqlConnection conexion = null;
            string comando = "update [dbo].[Comentario] set likes = '" + en.aux_dislikes + 1 + "' where item = " + en.aux_item + "and comentario = '" + en.aux_comentario + "'";
            try
            {
                dislike = true;
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
