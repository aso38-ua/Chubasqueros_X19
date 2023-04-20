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
            return true;
        }

        public bool eliminarCarrito(ENCarrito c)
        {
            return true;
        }

        public bool actualizarCarrito(ENCarrito c)
        {
            return true;
        }

        //Cuenta la cantidad que ha escogido el usuario sobre 1 producto
        public int cuentaCantidad()
        {
            return 0;
        }

        //Añadir producto al carrito
        public bool AñadirProducto()
        {
            return true;
        }

        //Eliminar producto del carrito
        public bool EliminarProducto()
        {
            return true;
        }

        //Sacar el producto de la cesta y guardarlo en un subcarrito aparte
        public bool GuardarProducto()
        {
            return true;
        }


        //Cuenta todos los productos que ha pedido el usuario (Diferentes productos)
        public int ProductosTotales()
        {
            return 0;
        }

        //Calcula el precio total que hay en el carrito
        public float PrecioTotal()
        {
            return 0;
        }


        //Boton de comprar exclusivo para carrito
        public bool Comprar()
        {
            return true;
        }
    }
}
