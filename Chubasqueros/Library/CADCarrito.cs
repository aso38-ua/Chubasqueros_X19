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
        private String conection; //Conexion con la BB.DD
        public CADCarrito()
        {
            
        }


        //Cuenta la cantidad que ha escogido el usuario sobre 1 producto
        public int cuentaCantidad()
        {

        }

        //Añadir producto al carrito
        public bool AñadirProducto()
        {

        }

        //Eliminar producto del carrito
        public bool EliminarProducto()
        {

        }

        //Sacar el producto de la cesta y guardarlo en un subcarrito aparte
        public bool GuardarProducto()
        {

        }


        //Cuenta todos los productos que ha pedido el usuario (Diferentes productos)
        public int ProductosTotales()
        {

        }

        //Calcula el precio total que hay en el carrito
        public int PrecioTotal()
        {

        }


        //Boton de comprar exclusivo para carrito
        public bool Comprar()
        {

        }
    }
}
