using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class ENCategoria
    {
        private int codCategoria;
        private string nombre;

        public ENCategoria(int codCategoria, string nombre)
        {
            this.codCategoria = codCategoria;
            this.nombre = nombre;
        }

        public int getCodCategoria()
        {
            return this.codCategoria;
        }

        public void setCodCategoria(int codigoCategoria)
        {
            this.codCategoria = codigoCategoria;
        }

        public string getNombre()
        {
            return this.nombre;
        }

        public void setNombre(string nombre)
        {
            this.nombre = nombre;
        }

        public bool createCategoria()
        {
            CADProducto categoria = new CADCategoria();
            bool creado = false;
            if (!categoria.readCategoria(this))
                creado = categoria.createCategoria(this);
            return creado;
        }

        public bool deleteCategoria()
        {
            CADUsuario categoria = new CADCategoria();
            bool read = false;
            if (categoria.readCategoria(this))
                read = producto.deleteCategoria(this);
            return read;
        }

        public bool readCategoria()
        {
            CADUsuario categoria = new CADCategoria();
            bool read = categoria.readCategoria(this);
            return read;
        }
    }
}
