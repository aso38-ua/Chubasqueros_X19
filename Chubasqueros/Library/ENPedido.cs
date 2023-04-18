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
        public int c
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public float t
        {
            get { return total; }
            set { total = value; }
        }

        public int n
        {
            get { return numprod; }
            set { numprod = value; }
        }
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
            CADPedido pedido = new CADPedido();
            bool leer = pedido.leerPedido(this);
            return leer;
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
            ENPedido ped = new ENPedido();
            CADPedido pedido = new CADPedido();
            bool actualizar = false;

            ped.cantidad = this.cantidad;
            ped.total = this.total;
            ped.numprod = this.numprod;

            if (pedido.leerPedido(this))
            {
                this.cantidad = ped.cantidad;
                this.total = ped.total;
                this.numprod = ped.numprod;
                actualizar = pedido.actualizarPedido(this);
            }
            return actualizar;
        }

        public bool eliminarPedido()
        {
            CADPedido pedido = new CADPedido();
            bool eliminar = false;
            if (!pedido.leerPedido(this))
            {
                eliminar = pedido.eliminarPedido(this);
            }
            return eliminar;
        }

        

        //Añadir producto al carrito
        public bool añadirProducto()
        {
            return true;
        }

        public int cuentaCantidad()
        {
            return 0;
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
