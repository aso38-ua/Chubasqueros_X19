using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;
using System.Configuration;
using System.Data.SqlTypes;

namespace Library
{
    public class CADColaboracion
    {
        private String constring;

        public CADColaboracion()
        {
            constring = ConfigurationManager.ConnectionStrings["Database"].ToString();
        }
        public bool createColaboracion(ENColaboracion en)
        {
            int filas = 0;
            if (existeColaboracion(en.id))
            {
                Console.WriteLine("Ya existe esa colaboracion");
                return false;
            }
            //Establecemos conexión
            using (SqlConnection conexion = new SqlConnection(constring))
            {   //Creamos una consulta sql
                string query = "INSERT INTO colaboracion (Id,Nombre,Descripcion,Precio)" + "VALUES (@Id,@Nombre,@Descripcion,@Precio)";
                //Creamos la consulta como comando
                SqlCommand command = new SqlCommand(query, conexion);
                //Ejecutamos el comando
                filas = command.ExecuteNonQuery();
                return true;
            }
        }
        public bool readColaboracion(ENColaboracion en)
        {
            bool leido = false;

            //Edtablecemos conexión
            using (SqlConnection connection = new SqlConnection(constring))
            {
                //Creamos una consulta sql
                string query = "SELECT * FROM colaboracion WHERE Id = @Id";
                //Creamos la consulta como comando
                SqlCommand command = new SqlCommand(query, connection);

                try
                {   //Abrimos conexión
                    connection.Open();
                    //Creamos el comando para leer
                    SqlDataReader reader = command.ExecuteReader();

                    //Devolvemos lo leido
                    if (reader.Read())
                    {   //Convertimos los valores
                        en.id = Convert.ToInt32(reader["Id"]);
                        en.nombre = reader["Nombre"].ToString();
                        en.descripcion = reader["Descripcion"].ToString();
                        en.precio = Convert.ToInt32(reader["Precio"]);
                        leido = true;
                    }
                    //Cerramos el lector
                    reader.Close();
                }
                //Si no se ha podido leer lanza un error
                catch (SqlException e)
                {
                    leido = false;
                    Console.WriteLine("Colaboration operation has failed. Error: {0}", e.Message);
                }
            }
            return leido;
        }
        public bool updateColaboracion(ENColaboracion en)
        {
            bool modificado = false;
            int filas = 0;

            //Edtablecemos conexión
            using (SqlConnection connection = new SqlConnection(constring))
            {
                //Creamos una consulta sql
                string query = "UPDATE FROM colaboracion WHERE Id = @Id";
                //Creamos la consulta como comando
                SqlCommand command = new SqlCommand(query, connection);

                try
                {   //Abrimos conexión
                    connection.Open();
                    //Ejecutamos el comando 
                    filas = command.ExecuteNonQuery();
                    if (filas > 0) { modificado = true; }
                }
                //Si no se ha podido leer lanza un error
                catch (SqlException e)
                {
                    modificado = false;
                    Console.WriteLine("Colaboration operation has failed. Error: {0}", e.Message);
                }
                return modificado;
            }
        }
        public bool deleteColaboracion(ENColaboracion en)
        {
            bool eliminado = false;
            int filas = 0;

            //Edtablecemos conexión
            using (SqlConnection connection = new SqlConnection(constring))
            {
                //Creamos una consulta sql
                string query = "DELETE FROM colaboracion WHERE Id = @Id";
                //Creamos la consulta como comando
                SqlCommand command = new SqlCommand(query, connection);

                try
                {   //Abrimos conexión
                    connection.Open();
                    //Ejecutamos el comando 
                    filas = command.ExecuteNonQuery();
                    if (filas > 0) { eliminado = true; }
                }
                //Si no se ha podido leer lanza un error
                catch (SqlException e)
                {
                    eliminado = false;
                    Console.WriteLine("Colaboration operation has failed. Error: {0}", e.Message);
                }
                return eliminado;
            }

        }

        public bool existeColaboracion(int id)
        {
            bool existe = false;

            //Establecemos  conexión con la base de datos
            using (SqlConnection conexion = new SqlConnection(constring))
            {
                //Creamos una consulta sql
                string query = "SLECT COUNT(*) FROM colaboracion where Id=@id";
                //Creamos la consulta como comando en sql
                using (SqlCommand command = new SqlCommand(query, conexion))
                {   //Abrir la conexión
                    conexion.Open();
                    //Ejecutar consulta y devolver el resultado
                    int num = (int)command.ExecuteScalar();
                    if (num == 0) { existe = true; }
                }
            }
            return existe;
        }
    }
}
