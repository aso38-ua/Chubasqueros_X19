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
            constring = ConfigurationManager.ConnectionStrings["miconexion"].ToString();
        }
        public bool verCarrito(ENCarrito c)
        {
            return true;
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

                string cout = "DELETE * FROM [dbo].[carrito]";
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

        //Cuenta la cantidad que ha escogido el usuario sobre 1 producto
        public int cuentaCantidad()
        {
            return 0;
        }

        //Añadir producto desde favoritos al carrito
        public bool AñadirProducto(ENCarrito c)
        {
            bool aprod = false;
            try
            {
                SqlConnection conectsql = null;
                conectsql = new SqlConnection(constring);
                conectsql.Open();

                string cout = "INSERT INTO [dbo].[carrito] (producto, usuario) VALUES ('" + c.producto + "', " + c.usuario + "';";
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
        public bool EliminarProducto()
        {
            return true;
        }

        //Cuenta todos los productos que ha pedido el usuario (Diferentes productos)
        public int ProductosTotales()
        {
            return 0;
        }

        //Calcula el precio total que hay en el carrito
        public float PrecioTotal(ENCarrito c)
        {
            ENProducto producto = new ENProducto();

            try
            {
                SqlConnection conectsql = null;
                conectsql = new SqlConnection(constring);
                conectsql.Open();
                
                string cout = "SELECT PRECIO FROM PRODUCTO";
                SqlCommand consulta = new SqlCommand(cout, conectsql);
                consulta.ExecuteNonQuery();
               
                conectsql.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine("Cart operation has failed.Error: {0}", e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Cart operation has failed.Error: {0}", e.Message);
            }
            return 0;
        }

    }
}
