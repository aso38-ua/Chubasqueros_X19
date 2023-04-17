using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class ENFavoritos
    {
        private string[] productos;
        private string usuario;

        public string[] productop
        {
            get { return productos; }
            set { productos = value; }
        }

        public string usuariop
        {
            get { return usuario; }
            set { usuario = value; }
        }

        public ENFavoritos(string usuario)
        {
            this.productos = new string[0];
            this.usuario = usuario;
        }

        public ENFavoritos(string producto, string usuario)
        {
            this.productos = new string[1];
            this.productos[0] = producto;
            this.usuario = usuario;
        }

        public ENFavoritos(string[] productos, string usuario)
        {
            this.productos = new string[productos.Length];
            for(int i = 0; i < productos.Length; i++)
            {
                this.productos[i] = productos[i];
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

        public bool deleteFavoritos()
        {
            CADFavoritos favorito = new CADFavoritos();
            bool borrado = false;
            if (favorito.readFavorites(this)) borrado = favorito.deleteFavorites(this);
            return borrado;
        }

        public bool deleteProductinBD(string producto) //Borra el producto tanto en la base de datos como en el objeto.
        {
            CADFavoritos favorito = new CADFavoritos();
            ENFavoritos aux = new ENFavoritos(producto, this.usuario);
            bool borrado = false;
            if (favorito.readFavorites(this))
            {
                borrado = favorito.deleteProduct(aux);
                this.borrarProducto(producto);
            }
            return borrado;
        }

        public bool insertProductinBD(string producto) //Inserta el producto tanto en la base de datos como en el objeto.
        {
            CADFavoritos favorito = new CADFavoritos();
            ENFavoritos aux = new ENFavoritos(producto, this.usuario);
            bool insert = false;
            insert = favorito.insertProduct(aux);
            this.insertarProducto(producto);
            return insert;
        }

        public void insertarProducto(string producto) //Inserta el producto sólo en el objeto.
        {
            string[] aux = new string[this.productos.Length + 1];
            for (int i = 0; i < this.productos.Length; i++)
            {
                aux[i] = this.productos[i];
            }
            aux[this.productos.Length] = producto;
            this.productos = aux;
        }

        public bool borrarProducto(string producto) //Borra el producto sólo en el objeto.
        {
            bool borrado = false;
            string[] aux = new string[this.productos.Length - 1];
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
