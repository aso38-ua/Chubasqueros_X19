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
    public class CADDonacion
    {
        private String constring;

        public CADDonacion()
        {
            constring = ConfigurationManager.ConnectionStrings["Database"].ToString();
        }
        public bool createDonacion(ENDonacion en)
        {
            int filas = 0;
            if (existeDonacion(en.id))
            {
                Console.WriteLine("Ya existe el id de esa donacion");
                return false;
            }
            //Establecemos conexión
            using (SqlConnection conexion = new SqlConnection(constring))
            {   //Creamos una consulta sql
                string query = "INSERT INTO Donacion (Id,Tarjeta,Seguridad,Cantidad)" + "VALUES (@id,@tarjeta,@seguridad,@cantidad)";
                //Creamos la consulta como comando
                SqlCommand command = new SqlCommand(query, conexion);
                //Ejecutamos el comando
                filas = command.ExecuteNonQuery();
                return true;
            }
        }
        public bool readDonacion(ENDonacion en)
        {
            bool leido = false;

            //Edtablecemos conexión
            using (SqlConnection connection = new SqlConnection(constring))
            {
                //Creamos una consulta sql
                string query = "SELECT * FROM Donacion WHERE Id = @id";
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
                        en.tarjeta = reader["Tarjeta"].ToString();
                        en.seguridad = reader["Deguridad"].ToString();
                        en.cantidad = reader["Cantidad"].ToString();
                        leido = true;
                    }
                    //Cerramos el lector
                    reader.Close();
                }
                //Si no se ha podido leer lanza un error
                catch (SqlException e)
                {
                    leido = false;
                    Console.WriteLine("Donacion fallida", e.Message);
                }
            }
            return leido;
        }
        public bool existeDonacion(int id)
        {
            bool existe = false;

            //Establecemos  conexión con la base de datos
            using (SqlConnection conexion = new SqlConnection(constring))
            {
                //Creamos una consulta sql
                string query = "SLECT COUNT(*) FROM donacion where Id=@id";
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
