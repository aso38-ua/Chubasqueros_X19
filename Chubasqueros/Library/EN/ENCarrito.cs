using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class ENCarrito
    {
        private int cantidadp; //cantidad de productos pedidos
        private float totalp; //precio total
        private int productop; //Producto en el carrito actualmente
        private int idcarritop; //id del carrito (podria ser igual que el id de pedido)
        private int usuariop; //Id del usuario


        public int usuario
        {
            get { return usuariop; }
            set { usuariop = value; }
        }
        public int producto
        {
            get { return productop; }
            set { productop = value; }
        }
 
        public int cantidad
        {
            get { return cantidadp; }
            set { cantidadp = value; }
        }

        public float total
        {
            get { return totalp; }
            set { totalp = value; }
        }

        public int idcarrito
        {
            get { return idcarritop; }
            set { idcarritop = value; }
        }

        /*Constructor: pondra la cantidad a 0, el total a 0,
         la clase se enlazara con usuario y producto*/
        public ENCarrito(int prod, int usu)
        {
            ENProducto product = new ENProducto();
            product.setCodigo(prod);
            product.readProducto();
            total = product.getPrecio();
            cantidad = 1;
            producto = prod;
            usuario = usu;
        }

        public ENCarrito(int cantidad, int producto, int usuario)
        {
            ENProducto product = new ENProducto();
            product.setCodigo(producto);
            product.readProducto();
            this.total = product.getPrecio() * cantidad;
            this.cantidad = cantidad;
            this.producto = producto;
            this.usuario = usuario;
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
            crear = carrito.crearCarrito(this);
            return crear;
        }

        public bool eliminarCarrito()
        {
            CADCarrito carrito = new CADCarrito();
            bool eliminar = false;

            if (carrito.verCarrito(this))
            {
                eliminar = carrito.eliminarCarrito(this);
            }

            return eliminar;
        }
        
        public bool actualizarCarrito()
        {
            ENCarrito carro = new ENCarrito(cantidad, producto, usuario);
            CADCarrito carrito = new CADCarrito();
            bool actualizar = false;

            
            if (carrito.verCarrito(carro))
            {
                carro.cantidad = this.cantidad;
                carro.total = this.total;
                carro.producto = this.producto;
                carro.usuario = this.usuario;
                actualizar = carrito.actualizarCarrito(carro);
            }
            return actualizar;
        }

  
        //Cuenta la cantidad que ha escogido el usuario sobre 1 producto
        public int cuentaCantidad()
        {
            CADCarrito carrito = new CADCarrito();
            ENProducto producto = new ENProducto();
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
            CADCarrito carrito = new CADCarrito();
            ENProducto aux = new ENProducto();
            bool insertar = false;
            
            return insertar;
        }   

        //Eliminar producto del carrito
        public bool EliminarProducto()
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
