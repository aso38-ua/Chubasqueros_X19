using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class ENPedido
    {
        private int cantidad; //cantidad de productos pedidos 
        private float total; //precio total
        private int idPedido; //id del Pedido
        private DateTime fechaaprox; //fecha aproximada de llegada

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

        public int idp
        {
            get { return idPedido;  }
            set { idPedido = value; }
        }

        public DateTime fecha
        {
            get { return fechaaprox; }
            set { fechaaprox = value; }
        }

     
        public ENPedido()
        {
            idp = 0;
            c = 0;
            t = 0;
            fecha = DateTime.Now;
        }

        public ENPedido(int CANT, float TOT, int id, DateTime tiempo)
        {
            CANT = c;
            TOT = t;
            id = idp;
            tiempo = fecha;
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

            ped.c = this.c;
            ped.t = this.t;
            ped.idp = this.idp;
            ped.fecha = this.fecha;

            if (pedido.leerPedido(this))
            {
                this.c = ped.c;
                this.t = ped.t;
                this.idp = ped.idp;
                this.fecha = ped.fecha;
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
