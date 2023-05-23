using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class CADSeguidores
    {
        private string connectionString;

        public CADSeguidores()
        {
            connectionString = ConfigurationManager.ConnectionStrings["Database"].ToString();
        }

        public bool AgregarSeguido(string usernameSeguidor, string usernameSeguido)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string checkUserQuery = "SELECT COUNT(*) FROM usuario WHERE nombre = @usernameSeguido";
                string checkFollowQuery = "SELECT COUNT(*) FROM seguidores WHERE username_seguidor = @usernameSeguidor AND username_seguido = @usernameSeguido";
                string insertQuery = "INSERT INTO seguidores (username_seguidor, username_seguido) VALUES (@usernameSeguidor, @usernameSeguido); " +
                                     "UPDATE usuario SET seguidos = seguidos + 1 WHERE nombre = @usernameSeguido";

                using (SqlCommand checkUserCommand = new SqlCommand(checkUserQuery, connection))
                {
                    checkUserCommand.Parameters.AddWithValue("@usernameSeguido", usernameSeguido);

                    connection.Open();
                    int userCount = (int)checkUserCommand.ExecuteScalar();

                    if (userCount > 0)
                    {
                        using (SqlCommand checkFollowCommand = new SqlCommand(checkFollowQuery, connection))
                        {
                            checkFollowCommand.Parameters.AddWithValue("@usernameSeguidor", usernameSeguidor);
                            checkFollowCommand.Parameters.AddWithValue("@usernameSeguido", usernameSeguido);

                            int followCount = (int)checkFollowCommand.ExecuteScalar();

                            if (followCount == 0)
                            {
                                using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                                {
                                    insertCommand.Parameters.AddWithValue("@usernameSeguidor", usernameSeguidor);
                                    insertCommand.Parameters.AddWithValue("@usernameSeguido", usernameSeguido);

                                    insertCommand.ExecuteNonQuery();
                                }

                                return true;
                            }
                        }
                    }
                }
            }

            return false;
        }



        public List<UsuarioConSeguidores> ObtenerUsuariosConMasSeguidores(int cantidad)
        {
            List<UsuarioConSeguidores> usuarios = new List<UsuarioConSeguidores>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT TOP (@cantidad) u.nombre " +
                               "FROM usuario u " +
                               "INNER JOIN seguidores s ON u.nombre = s.username_seguido " +
                               "GROUP BY u.nombre " +
                               "ORDER BY COUNT(s.username_seguido) DESC";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@cantidad", cantidad);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string nombreUsuario = reader.GetString(reader.GetOrdinal("nombre"));
                            int numeroSeguidores = ObtenerNumeroSeguidores(nombreUsuario); // Obtener el número de seguidores para el usuario
                            usuarios.Add(new UsuarioConSeguidores { Nombre = nombreUsuario, NumeroSeguidores = numeroSeguidores });
                        }
                    }
                }
            }

            return usuarios;
        }





        public bool EliminarSeguidor(string usernameSeguidor, string usernameSeguido)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM seguidores WHERE username_seguidor = @usernameSeguidor AND username_seguido = @usernameSeguido";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@usernameSeguidor", usernameSeguidor);
                    command.Parameters.AddWithValue("@usernameSeguido", usernameSeguido);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
                return true;
            }
        }

        public int ObtenerNumeroSeguidores(string username)
        {
            int numeroSeguidores = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM seguidores WHERE username_seguido = @username";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);

                    connection.Open();
                    numeroSeguidores = (int)command.ExecuteScalar();
                }
            }

            return numeroSeguidores;
        }

        public int ObtenerNumeroSeguidos(string username)
        {
            int numeroSeguidos = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM seguidores WHERE username_seguidor = @username";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);

                    connection.Open();
                    numeroSeguidos = (int)command.ExecuteScalar();
                }
            }

            return numeroSeguidos;
        }

        public int MisSeguidores(string username)
        {
            int num = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM seguidores WHERE username_seguido = @username";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);

                    connection.Open();
                    num = (int)command.ExecuteScalar();
                }
            }

            return num;
        }

        public int Simpeando(string username)
        {
            int num = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM seguidores WHERE username_seguidor = @username";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);

                    connection.Open();
                    num = (int)command.ExecuteScalar();
                }
            }

            return num;
        }
    }
}
