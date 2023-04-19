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


        /*Constructor: pondra la cantidad a 0, el total a 0, todos los productos (numprod) = 0,
         la clase se enlazara con usuario y producto*/
        public ENCarrito()
        {
            c = 0;
            t = 0;

        }

        public ENCarrito(int cant, int tot, int np)
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
            if (!carrito.verCarrito(this))
            {
                eliminar = carrito.eliminarCarrito(this);
            }
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
