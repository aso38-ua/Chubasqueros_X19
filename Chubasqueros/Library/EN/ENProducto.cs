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
        private int cant;
        private string fech;
        private float total;
        public int cantidad { get {return cant; } set {cant = value; } }
        public string fecha { get { return fech; } set { fech = value; } }
        public float ptotal { get { return total; } set { total = value; } }

        private int codigoCategoria;
        public string auxnombre { get {return nombre; }}
        public string auxdescripcion { get {return descripcion; } }
        public int auxstock { get {return stock; } }
        public float auxprecio { get {return precio; } }

        public ENProducto()
        {
            this.codigoCategoria = 0;
            this.codigo = 0;
            this.nombre = string.Empty;
            this.descripcion = string.Empty;
            this.stock = 0;
            this.precio = 0;
        }

        public ENProducto(int codigo, string nombre, string descripcion, int stock, float precio, int codigoCat)
        {
            this.codigoCategoria = codigoCat;
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
            return this.descripcion;
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

        public int getCodigoCategoria()
        {
            return this.codigoCategoria;
        }

        public void setCodigoCategoria(int cod)
        {
            this.codigoCategoria = cod;
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
            aux.codigo = this.codigo;
            aux.nombre = this.nombre;
            aux.descripcion = this.descripcion;
            aux.stock = this.stock;
            aux.precio = this.precio;
            aux.codigoCategoria = this.codigoCategoria;

            if (producto.readProducto(this))
            {
                this.codigo = aux.codigo;
                this.nombre = aux.nombre;
                this.descripcion = aux.descripcion;
                this.stock = aux.stock;
                this.precio = aux.precio;
                this.codigoCategoria = aux.codigoCategoria;
                updated = producto.updateProducto(this);
            }

            return updated;
        }

        public bool deleteProducto()
        {
            CADProducto producto = new CADProducto();
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

        public ENProducto[] mostrarProductosPorCategoria(ENCategoria en)
        {
            CADProducto producto = new CADProducto();
            ENProducto[] productos;
            productos = producto.mostrarProductosPorCategoria(en);
            return productos;
        }
    }
}
