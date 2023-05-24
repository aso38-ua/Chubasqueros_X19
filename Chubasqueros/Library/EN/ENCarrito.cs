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
        private int[] productop; //Producto en el carrito actualmente
        //private int productop; //Producto en el carrito actualmente
        private int idcarritop; //id del carrito (podria ser igual que el id de pedido)
        private int usuariop; //Id del usuario


        public int usuario
        {
            get { return usuariop; }
            set { usuariop = value; }
        }
        public int[] producto
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


        public ENCarrito(int usu)
        {
            this.producto = new int[0];
            this.usuario = usu;
        }


        /*Constructor: pondra la cantidad a 0, el total a 0,
         la clase se enlazara con usuario y producto*/
        public ENCarrito(int prod, int usu)
        {
            /*
            ENProducto product = new ENProducto();
            product.setCodigo(prod);
            product.readProducto();
            total = product.getPrecio();
            */
            cantidad = 1;
            this.producto = new int[1];
            this.producto[0] = prod;
            usuario = usu;
        }

        public ENCarrito(int[] prod, int usu)
        {
            if(prod != null)
            {
                this.producto = new int[prod.Length];
                for (int i = 0; i < prod.Length; i++)
                {
                    this.producto[i] = prod[i];
                }
                this.usuario = usu;
            }
            
        }

        public ENCarrito(int cantidad, int producto, int usuario)
        {
            /*
            ENProducto product = new ENProducto();
            product.setCodigo(producto);
            product.readProducto();
            this.total = product.getPrecio() * cantidad;
            */
            this.cantidad = cantidad;
            this.producto = new int[1];
            this.producto[0] = producto;
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

        public bool readCarritoinProduct()
        {
            CADCarrito carrito = new CADCarrito();
            bool leido = carrito.readCarritoinProduct(this);
            return leido;
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

        public bool eliminarCarritoBD(int producto)
        {
            CADCarrito carrito = new CADCarrito();
            ENCarrito aux = new ENCarrito(producto, this.usuario);
            bool eliminar = false;

            if (carrito.verCarrito(this))
            {
                eliminar = carrito.eliminarCarrito(this);
                this.EliminarProducto(producto);
            }

            return eliminar;
        }
        
        public bool actualizarCarrito()
        {
            ENCarrito carro = new ENCarrito(producto, usuario);
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

        public void AñadirProducto(int producto)
        {
            int[] aux = new int[this.producto.Length + 1];
            for(int i = 0; i < this.producto.Length; i++){
                aux[i] = this.producto[i];
            }
            aux[this.producto.Length] = producto;
            this.producto = aux;

        }

        //Añadir producto al carrito
        public bool AñadirProductoBD(int producto)
        {
            CADCarrito carrito = new CADCarrito();
            ENCarrito carro = new ENCarrito(producto, this.usuario);
            bool insertar = false;
            insertar = carrito.AñadirProducto(carro);
            this.AñadirProducto(producto);
            return insertar;
        }   

        //Eliminar producto del carrito
        public bool EliminarProducto(int producto)
        {
            bool borrar = false;
            int[] aux = new int[this.producto.Length - 1];
            if (this.producto.Contains(producto))
            {
                for(int i = 0; i < this.producto.Length; i++)
                {
                    if(this.producto[i] != producto)
                    {
                        aux[i] = this.producto[i];
                    }
                }
            }
            this.producto = aux;
            
            return borrar;
        }


        //Calcula el precio total que hay en el carrito
        public bool PrecioTotal()
        {
            CADCarrito carrito = new CADCarrito();
            bool precio = false;
            return precio;
        }

        //Cuenta la cantidad que ha escogido el usuario sobre 1 producto
        public bool cuentaCantidad()
        {
            CADCarrito carrito = new CADCarrito();
            ENProducto producto = new ENProducto();
            bool cant = false;

            return cant;
        }

    }
}
