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


        public ENCategoria()
        {
            this.codCategoria = 0;
            this.nombre = string.Empty;
        }
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
            CADCategoria categoria = new CADCategoria();
            bool creado = false;
            if (!categoria.readCategoria(this))
                creado = categoria.createCategoria(this);
            return creado;
        }

        public bool deleteCategoria()
        {
            CADCategoria categoria = new CADCategoria();
            bool read = false;
            if (categoria.readCategoria(this))
                read = categoria.deleteCategoria(this);
            return read;
        }

        public bool readCategoria()
        {
            CADCategoria categoria = new CADCategoria();
            bool read = categoria.readCategoria(this);
            return read;
        }

        public bool updateCategoria()
        {
            ENCategoria aux = new ENCategoria();
            CADCategoria categoria = new CADCategoria();

            bool updated = false;
            aux.codCategoria = this.codCategoria;
            aux.nombre = this.nombre;
          
            if (categoria.readCategoria(this))
            {
                this.codCategoria = aux.codCategoria;
                this.nombre = aux.nombre;
                updated = categoria.updateCategoria(this);
            }

            return updated;
        }
    }
}
