using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class ENCarrito
    {
        private int cantidad; //cantidad de productos pedidos
        private float total; //precio total
        private ENProducto producto; //Producto en el carrito actualmente
        private int idcarrito; //id del carrito (podria ser igual que el id de pedido)

        public ENProducto p
        {
            get { return producto; }
            set { producto = value; }
        }
 
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

        public int idc
        {
            get { return idcarrito; }
            set { idcarrito = value; }
        }

        /*Constructor: pondra la cantidad a 0, el total a 0,
         la clase se enlazara con usuario y producto*/
        public ENCarrito()
        {
            c = 0;
            t = 0;
            producto = new ENProducto();
        }

        public ENCarrito(int cant, int tot)
        {
            c = cant;
            t = tot;
        }
        public bool verCarrito()
        {
            CADCarrito carrito = new CADCarrito();
            bool ver = carrito.verCarrito(this);
            return ver;
        }
        public bool crearCarrito()
        {
            CADCarrito carrito = new CADCarrito();
            bool crear = false;
            if (!carrito.verCarrito(this))
            {
                crear = carrito.crearCarrito(this);
            }
            return crear;
        }

        public bool eliminarCarrito()
        {
            CADCarrito carrito = new CADCarrito();
            bool eliminar = false;
            ENProducto pr = new ENProducto();
            /*
            if (pr = null)
            {
                eliminar = carrito.eliminarCarrito(this);
            }
            */
            carrito.crearCarrito(this);
            return eliminar;
        }
        
        public bool actualizarCarrito()
        {
            ENCarrito carro = new ENCarrito();
            CADCarrito carrito = new CADCarrito();
            bool actualizar = false;

            carro.cantidad = this.cantidad;
            carro.total = this.total;

            if (carrito.verCarrito(this))
            {
                this.cantidad = carro.cantidad;
                this.total = carro.total;
                actualizar = carrito.actualizarCarrito(this);
            }
            return actualizar;
        }

       

        //Cuenta la cantidad que ha escogido el usuario sobre 1 producto
        public int cuentaCantidad()
        {
            CADCarrito carrito = new CADCarrito();
            int cant = 0;
            for(int i = 0; i < carrito.cuentaCantidad(); i++)
            {
                cant++;
            }
            return cant;
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

        //Calcula el precio total que hay en el carrito
        public float PrecioTotal()
        {
            CADCarrito carrito = new CADCarrito();
            float precio = 0;
            return precio;
        }


        //Boton de comprar exclusivo para carrito
        public bool Comprar()
        {
            return true;
        }
   
    }
}
