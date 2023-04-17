using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class ENCarrito
    {
        private int cantidad;
        private int total; //precio total
        private int numprod; //numero de productos totales que hay


        public int c
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public int t
        {
            get { return total; }
            set { total = value; }
        }

        public int n
        {
            get { return numprod; }
            set { numprod = value; }
        }

        /*Constructor: pondra la cantidad a 0, el total a 0, todos los productos (numprod) = 0,
         la clase se enlazara con usuario y producto*/
        public ENCarrito()
        {
            c = 0;
            t = 0;
            numprod = 0;

        }

        public ENCarrito(int cant, int tot, int np)
        {
            c = cant;
            t = tot;
            n = np;
        }

        //Cuenta la cantidad que ha escogido el usuario sobre 1 producto
        public int cuentaCantidad()
        {

        }

        //Añadir producto al carrito
        public AñadirProducto()
        {

        }   

        //Eliminar producto del carrito
        public EliminarProducto()
        {

        }

        //Sacar el producto de la cesta y guardarlo en un subcarrito aparte
        public GuardarProducto()
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
        public Comprar()
        {

        }
   



    }
}
