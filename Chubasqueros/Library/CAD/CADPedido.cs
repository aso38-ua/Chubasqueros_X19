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
    class CADPedido
    {
        private String constring; //Conexion con la BB.DD 
        public CADPedido()
        {
            constring = ConfigurationManager.ConnectionStrings["miconexion"].ToString();
        }

        //Para ver los pedidos realizados y consultar de nuevo la fecha de llegada del pedido
        public bool leerPedido(ENPedido p)
        {
            bool create = true;
            try
            {
                SqlConnection conectsql = null;
                conectsql = new SqlConnection(constring);
                conectsql.Open();

                string cout = "";
                SqlCommand consult = new SqlCommand(cout, conectsql);
                SqlDataReader search = consult.ExecuteReader();
                search.Read();


                /*
                if (search["nif"].ToString() == p.)
                {
                    en.NOMBRE = search["nombre"].ToString();
                    en.NIF = search["NIF"].ToString();
                    en.EDAD = int.Parse(search["edad"].ToString());
                }
                else
                {
                    create = false;
                }
                */
                search.Close();
                conectsql.Close();
            }
            catch (SqlException e)
            {
                create = false;
                Console.WriteLine("Order operation has failed.Error : {0}", e.Message);
            }
            catch (Exception e)
            {
                create = false;
                Console.WriteLine("Order operation has failed.Error : {0}", e.Message);
            }
            return create;
        }
        public bool crearPedido(ENPedido p)
        {
            bool create = false;
            try
            {
                SqlConnection conectsql = null;
                conectsql = new SqlConnection(constring);
                conectsql.Open();

                //el ID es un numero aleatorio
                string cout = "INSERT INTO [dbo].[pedido] (id) VALUES ('" + p.idPedido + "')";
                SqlCommand consult = new SqlCommand(cout, conectsql);
                consult.ExecuteNonQuery();
                create = true;
                conectsql.Close();
            }
            catch (SqlException e)
            {
                create = false;
                Console.WriteLine("Order operation has failed.Error: {0}", e.Message);
            }
            catch (Exception e)
            {
                create = false;
                Console.WriteLine("Order operation has failed.Error: {0}", e.Message);
            }
            return create;
        }

        public bool eliminarPedido(ENPedido p)
        {
            bool delete = true;
            try
            {
                SqlConnection conectsql = null;
                conectsql = new SqlConnection(constring);
                conectsql.Open();

                string cout = "DELETE FROM [dbo].[pedido] where producto_id is not NULL";
                SqlCommand consulta = new SqlCommand(cout, conectsql);
                consulta.ExecuteNonQuery();
                delete = true;
                conectsql.Close();
            }
            catch (SqlException e)
            {
                delete = false;
                Console.WriteLine("Order operation has failed.Error: {0}", e.Message);
            }
            catch (Exception e)
            {
                delete = false;
                Console.WriteLine("Order operation has failed.Error: {0}", e.Message);
            }
            return delete;
        }

        public bool actualizarPedido(ENPedido p)
        {
            bool update = true;
            try
            {
                SqlConnection conectsql = null;
                conectsql = new SqlConnection(constring);
                conectsql.Open();

                string cout = "UPDATE [dbo].[pedido] set ";
                SqlCommand consulta = new SqlCommand(cout, conectsql);
                consulta.ExecuteNonQuery();
                update = true;
                conectsql.Close();
            }
            catch (SqlException e)
            {
                update = false;
                Console.WriteLine("Order operation has failed.Error: {0}", e.Message);
            }
            catch (Exception e)
            {
                update = false;
                Console.WriteLine("Order operation has failed.Error: {0}", e.Message);
            }
            return update;
        }

        //Cuenta la cantidad que ha escogido el usuario sobre 1 producto
        public int cuentaCantidad()
        {
            return 0;
        }

        //Añadir producto desde favoritos al carrito
        public bool AñadirProducto()
        {
            return true;
        }

        //Eliminar producto del carrito
        public bool EliminarProducto()
        {
            return true;
        }

        //Calcula el precio total que hay en el carrito
        public float PrecioTotal()
        {
            return 0;
        }
    }
}

