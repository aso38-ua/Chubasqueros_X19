using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class ENPedido
    {
        private int cantidadp; //cantidad de productos pedidos 
        private double totalp; //precio total
        private int idPedidop; //id del Pedido
        private DateTime fechaaproxp; //fecha aproximada de llegada
        private int usuariop;
        private int productop;

        public int cantidad
        {
            get { return cantidadp; }
            set { cantidadp = value; }
        }

        public double total
        {
            get { return totalp; }
            set { totalp = value; }
        }

        public int idPedido
        {
            get { return idPedidop;  }
            set { idPedidop = value; }
        }

        public int producto
        {
            get { return productop; }
            set { productop = value; }
        }

        public int usuario
        {
            get { return usuariop; }
            set { usuariop = value; }
        }

        public DateTime fechaaprox
        {
            get { return fechaaproxp; }
            set { fechaaproxp = value; }
        }


        public ENPedido(DateTime fecha, int producto, int usuario)
        {
            ENProducto product = new ENProducto();
            product.setCodigo(producto);
            product.readProducto();
            this.total = product.getPrecio();
            this.cantidad = 1;
            this.fechaaprox = fecha;
            this.producto = producto;
            this.usuario = usuario;
        }

        public ENPedido(int prod, int usu)
        {
            ENProducto product = new ENProducto();
            product.setCodigo(producto);
            product.readProducto();
            this.total = product.getPrecio();
            this.cantidad = 1;
            this.fechaaprox = DateTime.Now;
            this.producto = producto;
            this.usuario = usuario;
        }

        public ENPedido(int cantidad, DateTime fecha, int producto, int usuario)
        {
            ENProducto product = new ENProducto();
            product.setCodigo(producto);
            product.readProducto();
            this.total = product.getPrecio() * cantidad;
            this.cantidad = cantidad;
            this.fechaaprox = fecha;
            this.producto = producto;
            this.usuario = usuario;
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
            bool crear = pedido.crearPedido(this);
            return crear;
            
        }

        public bool actualizarPedido()
        {
            ENPedido ped = new ENPedido(cantidad, fechaaprox, producto, usuario);
            CADPedido pedido = new CADPedido();
            bool actualizar = false;

            
            if (pedido.leerPedido(ped))
            {
                ped.cantidad = this.cantidad;
                ped.total = this.total;
                ped.idPedido = this.idPedido;
                ped.fechaaprox = this.fechaaprox;
                actualizar = pedido.actualizarPedido(ped);
            }
            return actualizar;
        }

        public bool eliminarPedido()
        {
            CADPedido pedido = new CADPedido();
            bool eliminar = false;
            if (pedido.leerPedido(this))
            {
                eliminar = pedido.eliminarPedido(this);
            }
            return eliminar;
        }

        //Calcula el precio total que hay en el carrito
        public float PrecioTotal(ENCarrito c)
        {
            ENProducto producto = new ENProducto();

            return 0;
        }
        
    }
}
