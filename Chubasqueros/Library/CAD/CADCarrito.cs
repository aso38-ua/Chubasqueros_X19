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
    class CADCarrito
    {
        private String constring; //Conexion con la BB.DD 
        public CADCarrito()
        {
            constring = ConfigurationManager.ConnectionStrings["Database"].ToString();
        }
        public bool verCarrito(ENCarrito c)
        {
            bool leido = false;
            try
            {
                SqlConnection conectsql = null;
                conectsql = new SqlConnection(constring);
                conectsql.Open();

                string cout = "SELECT * FROM[dbo].[carrito] WHERE usuario = '" + c.usuario + "'; ";
                SqlCommand consult = new SqlCommand(cout, conectsql);
                SqlDataReader read = consult.ExecuteReader();
                int contador = 0;
                while (read.Read())
                {
                    if(contador == 0)
                    {
                        c.producto = new int[1];
                        c.producto[0] = int.Parse(read["producto"].ToString());
                        c.usuario = int.Parse(read["usuario"].ToString());
                    }
                    else
                    {
                        c.AñadirProducto(int.Parse(read["producto"].ToString()));
                    }
                    contador++;
                }
                leido = true;
                read.Close();
                conectsql.Close();
               
            }
            catch (SqlException e)
            {
                leido = false;
                Console.WriteLine("Cart operation has failed.Error: {0}", e.Message);
            }
            catch (Exception e)
            {
                leido = false;
                Console.WriteLine("Cart operation has failed.Error: {0}", e.Message);
            }
            return leido ;
        }
        public bool crearCarrito(ENCarrito c)
        {
            bool create = false;
            try
            {
                SqlConnection conectsql = null;
                conectsql = new SqlConnection(constring);
                conectsql.Open();

                string cout = "INSERT INTO[dbo].[carrito] (producto, usuario) VALUES('" + c.producto + "', " + c.usuario + "';";
                SqlCommand consult = new SqlCommand(cout, conectsql);
                consult.ExecuteNonQuery();
                if(c.producto.Length > 1)
                {
                    for(int i = 1; i < c.producto.Length; i++)
                    {
                       cout = "INSERT INTO[dbo].[carrito] (producto, usuario) VALUES('" + c.producto + "', " + c.usuario + "';";
                       consult = new SqlCommand(cout, conectsql);
                       consult.ExecuteNonQuery();
                    }
                }
                create = true;
                conectsql.Close();
            }
            catch (SqlException e)
            {
                create = false;
                Console.WriteLine("Cart operation has failed.Error: {0}", e.Message);
            }
            catch (Exception e)
            {
                create = false;
                Console.WriteLine("Cart operation has failed.Error: {0}", e.Message);
            }
            return create;
        }

        public bool eliminarCarrito(ENCarrito c)
        {
            bool delete = true;
            try
            {
                SqlConnection conectsql = null;
                conectsql = new SqlConnection(constring);
                conectsql.Open();

                string cout = "DELETE * FROM [dbo].[carrito] where usuario '" + c.usuario + ";";
                SqlCommand consulta = new SqlCommand(cout, conectsql);
                consulta.ExecuteNonQuery();
                delete = true;
                conectsql.Close();
            }
            catch (SqlException e)
            {
                delete = false;
                Console.WriteLine("Cart operation has failed.Error: {0}", e.Message);
            }
            catch (Exception e)
            {
                delete = false;
                Console.WriteLine("Cart operation has failed.Error: {0}", e.Message);
            }
            return delete;
        }

        public bool actualizarCarrito(ENCarrito c)
        {
            bool update = true;
            try
            {
                SqlConnection conectsql = null;
                conectsql = new SqlConnection(constring);
                conectsql.Open();

                string cout = "UPDATE * FROM [dbo].[carrito]";
                SqlCommand consulta = new SqlCommand(cout, conectsql);
                consulta.ExecuteNonQuery();
                update = true;
                conectsql.Close();
            }
            catch (SqlException e)
            {
                update = false;
                Console.WriteLine("Cart operation has failed.Error: {0}", e.Message);
            }
            catch (Exception e)
            {
                update = false;
                Console.WriteLine("Cart operation has failed.Error: {0}", e.Message);
            }
            return update;
        }

        //Añadir producto desde el producto al carrito
        public bool AñadirProducto(ENCarrito c)
        {
            bool aprod = false;
            try
            {
                SqlConnection conectsql = null;
                conectsql = new SqlConnection(constring);
                conectsql.Open();

                string cout = "INSERT INTO [dbo].[carrito] (producto, usuario) VALUES ('" + c.producto[0] + "', " + c.usuario + "';";
                SqlCommand consulta = new SqlCommand(cout, conectsql);
                consulta.ExecuteNonQuery();
                aprod = true;
                conectsql.Close();
            }
            catch (SqlException e)
            {
                aprod = false;
                Console.WriteLine("Cart operation has failed.Error: {0}", e.Message);
            }
            catch (Exception e)
            {
                aprod = false;
                Console.WriteLine("Cart operation has failed.Error: {0}", e.Message);
            }
            return aprod;
        }

        //Eliminar producto del carrito
        public bool EliminarProducto(ENCarrito c)
        {
            bool eprod = false;
            try
            {
                SqlConnection conectsql = null;
                conectsql = new SqlConnection(constring);
                conectsql.Open();

                string cout = "DELETE FROM [dbo].[carrito] WHERE producto = '" + c.producto[0] + "' AND usuario ='" + c.usuario + "';";
                SqlCommand consulta = new SqlCommand(cout, conectsql);
                consulta.ExecuteNonQuery();
                eprod = true;
                conectsql.Close();
            }
            catch (SqlException e)
            {
                eprod = false;
                Console.WriteLine("Cart operation has failed.Error: {0}", e.Message);
            }
            catch (Exception e)
            {
                eprod = false;
                Console.WriteLine("Cart operation has failed.Error: {0}", e.Message);
            }
            return eprod;

        }

        public bool readCarritoinProduct(ENCarrito c)
        {
            bool leido = false;
            try
            {
                String consultaString = "SELECT * FROM [dbo].[carrito] WHERE usuario = " + c.usuario + " AND producto = " + c.producto[0] + ";";
                SqlConnection conexion = new SqlConnection(constring);
                conexion.Open();

                SqlCommand consulta = new SqlCommand(consultaString, conexion);
                SqlDataReader consultabusqueda = consulta.ExecuteReader();
                consultabusqueda.Read();
                if (int.Parse(consultabusqueda["usuario"].ToString()) == c.usuario)
                {
                    leido = true;
                }
                consultabusqueda.Close();
                conexion.Close();
            }
            catch (SqlException ex)
            {
                leido = false;
                Console.WriteLine("Cart operation has failed. Error: {0} ", ex.Message);
            }
            catch (Exception ex)
            {
                leido = false;
                Console.WriteLine("Cart operation has failed. Error: {0} ", ex.Message);
            }
            return leido;
        }

        //Calcula el precio total que hay en el carrito
        public bool PrecioTotal(ENCarrito c)
        {

            bool totalprecio = false;
            try
            {
                
                SqlConnection conectsql = null;
                conectsql = new SqlConnection(constring);
                conectsql.Open();
                
                string cout = "SELECT precio FROM [dbo].[producto]";
                SqlCommand consulta = new SqlCommand(cout, conectsql);
                consulta.ExecuteNonQuery();




                
                conectsql.Close();
            }
            catch (SqlException e)
            {
                totalprecio = false;
                Console.WriteLine("Cart operation has failed.Error: {0}", e.Message);
            }
            catch (Exception e)
            {
                totalprecio = false;
                Console.WriteLine("Cart operation has failed.Error: {0}", e.Message);
            }
            return totalprecio;
        }

        //Cuenta la cantidad que ha escogido el usuario sobre 1 producto
        public bool cuentaCantidad(ENCarrito c)
        {
            bool cant = false ;
            try
            {
                SqlConnection conectsql = null;
                conectsql = new SqlConnection(constring);
                conectsql.Open();

                string cout = "INSERT INTO carrito (cantidad) VALUES (@cantidad)";
                using (SqlCommand command = new SqlCommand(cout, conectsql))
                {
                    command.Parameters.AddWithValue("@cantidad", c.cantidad);
                    command.ExecuteNonQuery();
                }
                cant = true;
                conectsql.Close();
            }
            catch (SqlException e)
            {
                cant = false ;
                Console.WriteLine("User operation has failed.Error : {0}", e.Message);
            }
            catch (Exception e)
            {
                cant = false;
                Console.WriteLine("User operation has failed.Error: {0}", e.Message);
            }
            return cant ;
        }

    }
}
