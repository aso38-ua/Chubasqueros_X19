using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class ENPedido
    {
        private int cantidad;
        private float total; //precio total
        private int numprod; //numero de productos totales que hay
        public ENPedido()
        {
            cantidad = 0;
            total = 0;
            numprod = 0;
        }

        public ENPedido(int CANT, float TOT, int NUMPROD)
        {
            CANT = cantidad;
            TOT = total;
            NUMPROD = numprod;
        }

        public bool leerPedido()
        {
            return true;
        }
        public bool crearPedido()
        {
            CADPedido pedido = new CADPedido();
            bool crear = false;
            if (!pedido.leerPedido(this))
            {
                crear = pedido.crearPedido(this);
            }
            return crear;
        }

       

        public bool actualizarPedido()
        {
            return true;
        }

        public bool eliminarPedido()
        {
            return true;
        }

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
