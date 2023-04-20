using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class ENProducto
    {
        private int codigo;
        private string nombre;
        private string descripcion;
        private int stock;
        private float precio;


        public ENProducto(int codigo, string nombre, string descripcion, int stock, float precio)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.stock = stock;
            this.precio = precio;
        }

        public int getCodigo()
        {
            return this.codigo;
        }

        public void setCodigo(int cod)
        {
            this.codigo = cod;
        }

        public string getNombre()
        {
            return this.nombre;
        }

        public void setNombre(string nombre)
        {
            this.nombre = nombre;
        }

        public string getDescripcion()
        {
            return this.descripcion:
        }

        public void setDescripcion(string desc)
        {
            this.descripcion = desc;
        }

        public int getStock()
        {
            return this.stock;
        }

        public void setStock(int stock)
        {
            this.stock = stock;
        }

        public float getPrecio()
        {
            return this.precio;
        }

        public void setPrecio(float precio)
        {
            this.precio = precio;
        }

        public bool createProducto()
        {
            CADProducto producto = new CADProducto();
            bool creado = false;
            if (!producto.readProducto(this))
                creado = producto.createProducto(this);
            return creado;
        }

        public bool updateProducto()
        {
            ENProducto aux = new ENProducto();
            CADProducto producto = new CADProducto();

            bool updated = false;
            aux.codigo = this.codigo
            aux.nombre = this.nombre;
            aux.descripcion = this.descripcion;
            aux.stock = this.stock;
            aux.precio; = this.precio;

            if (producto.readProducto(this))
            {
                this.codigo = aux.codigo
                this.nombre = aux.nombre;
                this.descripcion = aux.descripcion;
                this.stock = aux.stock;
                this.precio; = aux.precio;
                updated = producto.updateProducto(this);
            }

            return updated;
        }

        public bool deleteProducto()
        {
            CADUsuario producto = new CADProducto();
            bool read = false;
            if (producto.readProducto(this))
                read = producto.deleteProducto(this);
            return read;
        }

        public bool readProducto()
        {
            CADProducto producto = new CADProducto();
            bool read = producto.readProducto(this);
            return read;
        }
    } 
}
