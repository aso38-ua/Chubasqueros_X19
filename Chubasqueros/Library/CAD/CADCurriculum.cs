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
    public class CADCurriculum
    {
        private string constring; // Cadena de conexión a la base de datos
        public CADCurriculum()
        {
            constring = ConfigurationManager.ConnectionStrings["Database"].ToString();
        }

        // Métodos CRUD
        public void CrearCurriculum(ENCurriculum curriculum)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(constring))
                {
                    string query = "INSERT INTO Curriculums (Nombre, Apellido, ExperienciaLaboral) VALUES (@Nombre, @Apellido, @ExperienciaLaboral)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Nombre", curriculum.Nombre);
                    command.Parameters.AddWithValue("@Apellido", curriculum.Apellido);
                    command.Parameters.AddWithValue("@ExperienciaLaboral", curriculum.Experiencia);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al crear el curriculum: " + ex.Message);
            }
        }

        public ENCurriculum LeerCurriculum(int id)
        {
            ENCurriculum curriculum = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(constring))
                {
                    string query = "SELECT Nombre, Apellido, ExperienciaLaboral FROM Curriculums WHERE Id = @Id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", id);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        curriculum = new ENCurriculum();
                        curriculum.Id = id;
                        curriculum.Nombre = reader["Nombre"].ToString();
                        curriculum.Apellido = reader["Apellido"].ToString();
                        curriculum.Experiencia = reader["ExperienciaLaboral"].ToString();
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al leer el curriculum: " + ex.Message);
            }

            return curriculum;
        }

        public void ActualizarCurriculum(ENCurriculum curriculum)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(constring))
                {
                    string query = "UPDATE Curriculums SET Nombre = @Nombre, Apellido = @Apellido, ExperienciaLaboral = @ExperienciaLaboral WHERE Id = @Id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Nombre", curriculum.Nombre);
                    command.Parameters.AddWithValue("@Apellido", curriculum.Apellido);
                    command.Parameters.AddWithValue("@ExperienciaLaboral", curriculum.Experiencia);
                    command.Parameters.AddWithValue("@Id", curriculum.Id);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar el curriculum: " + ex.Message);
            }
        }

        public void BorrarCurriculum(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(constring))
                {
                    string query = "DELETE FROM Curriculums WHERE Id = @Id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", id);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al borrar el curriculum: " + ex.Message);
            }
        }
    }
}
