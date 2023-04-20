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
        private String conection; //Conexion con la BB.DD 
        public CADPedido()
        {

        }
        public bool leerPedido(ENPedido p)
        {
            return true;
        }
        public bool crearPedido(ENPedido p)
        {
            return true;
        }

        public bool eliminarPedido(ENPedido p)
        {
            return true;
        }

        public bool actualizarPedido(ENPedido p)
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
