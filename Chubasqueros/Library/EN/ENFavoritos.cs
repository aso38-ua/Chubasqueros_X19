using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class ENFavoritos
    {
        private int[] productos;
        private int usuario;

        public int[] productop
        {
            get { return productos; }
            set { productos = value; }
        }

        public int usuariop
        {
            get { return usuario; }
            set { usuario = value; }
        }

        public ENFavoritos(int usuario)
        {
            this.productos = new int[0];
            this.usuario = usuario;
        }

        public ENFavoritos(int producto, int usuario)
        {
            this.productos = new int[1];
            this.productos[0] = producto;
            this.usuario = usuario;
        }

        public ENFavoritos(int[] productos, int usuario)
        {
            if (productos != null)
            {
                this.productos = new int[productos.Length];
                for (int i = 0; i < productos.Length; i++)
                {
                    this.productos[i] = productos[i];
                }
            }
            this.usuario = usuario;
        }

        public bool createFavoritos()
        {
            CADFavoritos favorito = new CADFavoritos();
            bool creado = favorito.createFavorites(this);
            return creado;
        }

        public bool readFavoritos()
        {
            CADFavoritos favorito = new CADFavoritos();
            bool leido = favorito.readFavorites(this);
            return leido;
        }

        public bool readFavoritosWithP()
        {
            CADFavoritos favorito = new CADFavoritos();
            bool leido = favorito.readFavoritesWithP(this);
            return leido;
        }

        public bool deleteFavoritos()
        {
            CADFavoritos favorito = new CADFavoritos();
            bool borrado = false;
            if (favorito.readFavorites(this)) borrado = favorito.deleteFavorites(this);
            return borrado;
        }

        public bool deleteProductinBD(int producto) //Borra el producto tanto en la base de datos como en el objeto.
        {
            CADFavoritos favorito = new CADFavoritos();
            ENFavoritos aux = new ENFavoritos(producto, this.usuario);
            bool borrado = false;
            if (aux.readFavoritosWithP())
            {
                borrado = favorito.deleteProduct(aux);
                this.borrarProducto(producto);
            }
            return borrado;
        }

        public bool insertProductinBD(int producto) //Inserta el producto tanto en la base de datos como en el objeto.
        {
            CADFavoritos favorito = new CADFavoritos();
            ENFavoritos aux = new ENFavoritos(producto, this.usuario);
            bool insert = false;
            insert = favorito.insertProduct(aux);
            this.insertarProducto(producto);
            return insert;
        }

        public void insertarProducto(int producto) //Inserta el producto sólo en el objeto.
        {
            int[] aux = new int[this.productos.Length + 1];
            for (int i = 0; i < this.productos.Length; i++)
            {
                aux[i] = this.productos[i];
            }
            aux[this.productos.Length] = producto;
            this.productos = aux;
        }

        public bool borrarProducto(int producto) //Borra el producto sólo en el objeto.
        {
            bool borrado = false;
            int[] aux = new int[this.productos.Length - 1];
            if (this.productos.Contains(producto))
            {
                for (int i = 0; i < this.productos.Length; i++) if (this.productos[i] != producto) aux[i] = this.productos[i];
                borrado = true;
            }
            this.productos = aux;
            return borrado;
        }
    }
}
