using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;
using System.Configuration;

namespace Library
{
    public class CADUsuario
    {
        private String constring;
        public CADUsuario()
        {
            constring = ConfigurationManager.ConnectionStrings["Database"].ToString();
        }
        
        
        // Create
        public bool CrearUsuario(ENUsuario en)
        {

            // Validación de nombre de usuario
            if (existeNombreUsuario(en.nombre))
            {
                Console.WriteLine("Ya existe este nombre de usuario");
                return false;
            }

            // Validación de correo electrónico
            if (existeCorreoUsuario(en.email))
            {
                // Mostrar mensaje de error indicando que el correo electrónico ya está en uso
                return false;
            }

            bool resultado = false;
            string query = "INSERT INTO usuario (nombre, contraseña, email) " +
                           "VALUES (@Nombre, @Contraseña, @Email)";

            using (SqlConnection connection = new SqlConnection(constring))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nombre", en.nombre);
                command.Parameters.AddWithValue("@Contraseña", en.contraseña);
                command.Parameters.AddWithValue("@Email", en.email);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    resultado = rowsAffected > 0;
                }
                catch (SqlException e)
                {
                    resultado = false;
                    Console.WriteLine("User operation has failed. Error: {0}", e.Message);
                }
                catch (Exception e)
                {
                    resultado = false;
                    Console.WriteLine("User operation has failed. Error: {0}", e.Message);
                }
            }

            return resultado;
        }

        public bool ReadUsuario(ENUsuario en) {
            bool resultado = false;
            string query = "SELECT * FROM usuario WHERE nombre = @Nombre";

            using (SqlConnection connection = new SqlConnection(constring))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nombre", en.nombre);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        en.id = Convert.ToInt32(reader["id"]);
                        en.nombre = reader["nombre"].ToString();
                        en.contraseña = reader["contraseña"].ToString();
                        en.email = reader["email"].ToString();
                        en.esAdmin = bool.Parse(reader["esAdmin"].ToString());
                        resultado = true;
                    }

                    reader.Close();
                }
                catch (SqlException e)
                {
                    resultado = false;
                    Console.WriteLine("User operation has failed. Error: {0}", e.Message);
                }
                catch (Exception e)
                {
                    resultado = false;
                    Console.WriteLine("User operation has failed. Error: {0}", e.Message);
                }
            }

            return resultado;
        }

        public bool updateUsuario(ENUsuario en) 
        {
            bool result = false;

            using (SqlConnection connection = new SqlConnection(constring))
            {
                string query = "UPDATE Usuario SET Nombre = @Nombre, Apellido = @Apellido, Email = @Email WHERE IdUsuario = @IdUsuario";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nombre", en.nombre);
                command.Parameters.AddWithValue("@Apellido", en.apellido);
                command.Parameters.AddWithValue("@Email", en.email);
                command.Parameters.AddWithValue("@IdUsuario", en.id);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // La actualización fue exitosa
                        result = true;
                    }
                }
                catch (Exception ex)
                {
                    // Manejar la excepción en caso de algún error
                    Console.WriteLine("Error al actualizar el usuario: " + ex.Message);
                }
            }

            return result;
        }

        public bool deleteUsuario(ENUsuario en) 
        {
            bool result = false;

            using (SqlConnection connection = new SqlConnection(constring))
            {
                string query = "DELETE FROM Usuario WHERE IdUsuario = @IdUsuario";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdUsuario", en.id);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // La eliminación fue exitosa
                        result = true;
                    }
                }
                catch (Exception ex)
                {
                    // Manejar la excepción en caso de algún error
                    Console.WriteLine("Error al eliminar el usuario: " + ex.Message);
                }
            }

            return result;
        }


        private bool existeNombreUsuario(string nombreUsuario)
        {
            bool existeUsuario = false;

            // Conexión a la base de datos
            using (SqlConnection connection = new SqlConnection(constring))
            {
                // Consulta SQL para verificar la existencia del usuario
                string query = "SELECT COUNT(*) FROM usuario WHERE nombre = @nombreUsuario";

                // Crear el comando SQL
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Agregar parámetro
                    command.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);

                    // Abrir conexión
                    connection.Open();

                    // Ejecutar consulta y obtener el resultado
                    int count = (int)command.ExecuteScalar();

                    // Verificar si existe un usuario con el mismo nombre
                    existeUsuario = (count > 0);
                }
            }

            return existeUsuario;
        }

        private bool existeCorreoUsuario(string correoUsuario)
        {
            bool existeUsuario = false;

            // Conexión a la base de datos
            using (SqlConnection connection = new SqlConnection(constring))
            {
                // Consulta SQL para verificar la existencia del usuario
                string query = "SELECT COUNT(*) FROM usuario WHERE email = @correoUsuario";

                // Crear el comando SQL
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Agregar parámetro
                    command.Parameters.AddWithValue("@correoUsuario", correoUsuario);

                    // Abrir conexión
                    connection.Open();

                    // Ejecutar consulta y obtener el resultado
                    int count = (int)command.ExecuteScalar();

                    // Verificar si existe un usuario con el mismo nombre
                    existeUsuario = (count > 0);
                }
            }

            return existeUsuario;
        }



        public static ENUsuario ObtenerUsuarioPorId(int id)
        {
            throw new NotImplementedException();
        }

        public static ENUsuario ObtenerUsuarioPorEmail(string email)
        {
            throw new NotImplementedException();
        }

        public static List<ENUsuario> ObtenerTodosLosUsuarios()
        {
            throw new NotImplementedException();
        }

        // Update
        public static void ActualizarUsuario(ENUsuario usuario)
        {
            throw new NotImplementedException();
        }

        // Delete
        public static void EliminarUsuario(int id)
        {
            throw new NotImplementedException();
        }
    }
}
