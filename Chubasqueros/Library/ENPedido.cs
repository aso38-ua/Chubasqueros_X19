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
        private int idPedido;
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

        public int id
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
            idPedido = 0;
            cantidad = 0;
            total = 0;
            fechaaprox = DateTime.Now;
        }

        public ENPedido(int CANT, float TOT, int id, DateTime tiempo)
        {
            CANT = cantidad;
            TOT = total;
            id = idPedido;
            tiempo = fechaaprox;
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
            ped.idPedido = this.idPedido;
            ped.fechaaprox = this.fechaaprox;

            if (pedido.leerPedido(this))
            {
                this.cantidad = ped.cantidad;
                this.total = ped.total;
                this.idPedido = ped.idPedido;
                this.fechaaprox = ped.fechaaprox;
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
