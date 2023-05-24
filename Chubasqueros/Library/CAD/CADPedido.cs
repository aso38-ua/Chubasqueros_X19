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
            constring = ConfigurationManager.ConnectionStrings["Database"].ToString();
        }

        //Para ver los pedidos realizados y consultar de nuevo la fecha de llegada del pedido
        public bool leerPedido(ENPedido p)
        {
            bool leido = true;
            try
            {
                SqlConnection conectsql = null;
                conectsql = new SqlConnection(constring);
                conectsql.Open();

                string cout = "SELECT * FROM [dbo].[pedido] WHERE usuario = '" + p.usuario + "' AND producto = '" + p.producto + "';";
                SqlCommand consult = new SqlCommand(cout, conectsql);
                SqlDataReader search = consult.ExecuteReader();
                search.Read();

                if(int.Parse(search["usuario"].ToString()) == p.usuario)
                {
                    leido = true;
                    p.cantidad = int.Parse(search["cantidad"].ToString());
                    //p.fechaaprox = search["fecha"].ToString();
                    p.producto = int.Parse(search["producto"].ToString());
                    p.usuario = int.Parse(search["usuario"].ToString());
                }

              
                search.Close();
                conectsql.Close();
            }
            catch (SqlException e)
            {
                leido = false;
                Console.WriteLine("Order operation has failed.Error : {0}", e.Message);
            }
            catch (Exception e)
            {
                leido = false;
                Console.WriteLine("Order operation has failed.Error : {0}", e.Message);
            }
            return leido;
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
                String cout = "INSERT INTO [dbo].[pedido] (cantidad, fecha, producto, usuario) VALUES ('" + p.cantidad + "', '" + p.fechaaprox + "', '" + p.producto + "', '" + p.usuario + "')";
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

                string cout = "DELETE FROM [dbo].[pedido] where usuario ='" + p.usuario + " AND producto ='" + p.producto + "';";
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
            bool update = false;
            try
            {
                SqlConnection conectsql = null;
                conectsql = new SqlConnection(constring);
                conectsql.Open();

                string cout = "UPDATE [dbo].[pedido] SET cantidad = '" + p.cantidad + "', producto = " + p.producto + " WHERE usuario = '" + p.usuario + " AND producto = '" + p.producto + "';"; 
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

        //Calcula el precio total que hay en el carrito
        public float PrecioTotal()
        {
            return 0;
        }
    }
}

