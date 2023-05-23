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

        public bool ReadUsuario(ENUsuario en)
        {
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

        public static bool ValidarCredenciales(string username, string password)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM usuario WHERE (nombre = @username OR email = @username) AND contraseña = @password";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);

                    connection.Open();
                    int count = (int)command.ExecuteScalar();

                    return count > 0; // Retorna true si se encontró un registro, o false si no se encontró
                }
            }
        }

        public static string ObtenerEmailPorUsuario(string username)
        {
            string email = string.Empty;

            if (EsCorreoElectronico(username))
            {
                return username; // El 'username' ya es un correo electrónico, devolverlo directamente
            }

            string connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT email FROM usuario WHERE nombre = @username";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);

                    connection.Open();
                    email = (string)command.ExecuteScalar();
                }
            }

            return email;
        }

        public static string ObtenerUsuarioPorEmail(string email)
        {
            string username = string.Empty;

            string connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT nombre FROM usuario WHERE email = @email";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@email", email);

                    connection.Open();
                    username = (string)command.ExecuteScalar();
                }
            }

            return username;
        }

        public static string ObtenerRutaImagenPerfil(string username)
        {
            string imagePath = string.Empty;

            string connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT ImagenPerfil FROM usuario WHERE nombre = @username";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);

                    connection.Open();
                    imagePath = command.ExecuteScalar() as string;
                }
            }

            // Verifica si la ruta de la imagen de perfil está vacía o nula
            if (!string.IsNullOrEmpty(imagePath))
            {
                // La ruta de la imagen de perfil existe, convierte la ruta hexadecimal a una cadena
                byte[] bytes = CADUsuario.HexToBytes(imagePath);
                string rutaCadena = Encoding.UTF8.GetString(bytes);

                return rutaCadena;
            }
            else
            {
                // La ruta de la imagen de perfil está vacía o nula, puedes retornar una ruta predeterminada o mostrar una imagen por defecto
                return "~/ProfileImages/Profile.jpg";
            }
        }

        public static bool VerificarNombreUsuarioExistente(string newUsername)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM usuario WHERE nombre = @newUsername";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@newUsername", newUsername);

                    connection.Open();
                    int count = (int)command.ExecuteScalar();

                    return count > 0;
                }
            }
        }

        public static void ActualizarNombreUsuario(string currentUsername, string newUsername)
        {
            // Consulta SQL para actualizar el nombre de usuario en la base de datos
            string connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE usuario SET nombre = @newUsername WHERE nombre = @currentUsername";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@newUsername", newUsername);
                    command.Parameters.AddWithValue("@currentUsername", currentUsername);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public static bool VerificarEmailExistente(string newEmail)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM usuario WHERE email = @newEmail";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@newEmail", newEmail);

                    connection.Open();
                    int count = (int)command.ExecuteScalar();

                    return count > 0;
                }
            }
        }

        public static void ActualizarEmail(string currentEmail, string newEmail)
        {
            if (EsCorreoElectronico(newEmail))
            {
                // Consulta SQL para actualizar el nombre de usuario en la base de datos
                string connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE usuario SET email = @newEmail WHERE email = @currentEmail";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@newEmail", newEmail);
                        command.Parameters.AddWithValue("@currentEmail", currentEmail);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }

        }

        private static byte[] HexToBytes(string hex)
        {
            int length = hex.Length / 2;
            byte[] bytes = new byte[length];

            for (int i = 0; i < length; i++)
            {
                bytes[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }

            return bytes;
        }

        public static bool EsCorreoElectronico(string input)
        {
            try
            {
                var email = new System.Net.Mail.MailAddress(input);
                return email.Address == input;
            }
            catch
            {
                return false;
            }
        }
    }
}
