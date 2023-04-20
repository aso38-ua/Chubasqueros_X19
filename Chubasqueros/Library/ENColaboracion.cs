using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class ENColaboracion
    {
        //Atributos privados
        private int Id;
        private string Nombre;
        private string Descripcion;
        private float Precio;

        //Getters y setters
        public string intId
        {
            get { return Id; }
            set { Id = value; }
        }

        public string stringNombre
        {
            get { return Nombre; }
            set { Nombre = value; }
        }

        public string stringDescripcion
        {
            get { return Descripcion; }
            set { Descripcion = value; }
        }

        public float floatPrecio
        {
            get { return Precio; }
            set {   Precio = value; }
        }

        //Constructor por defecto
        public ENColaboracion() {
            Id = 0;
            Nombre = string.Empty;
            Descripcion = string.Empty;
            Precio = 0;
        }

        //Constructor copia
        public ENColaboracion(int id, string nombre, string descripcion, float precio) {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
            Precio = precio;
        }

        //Crear colaboracion
        public bool createColaboracion() {
            CADUsuario colab = new CADColaboracion();
            bool create = false;
            if (!user.readColaboracion(this))
                creaate = user.createColaboracion(this);
            return created;
        }

        //Lee una colaboracion de la base de datos
        public bool readColaboracion() {
            CADColaboracion colab = new CADColaboracion();
            bool read = user.readColaboracion(this);
            return read;
        }

        //Modifica la colaboracion
        public bool updateColaboracion() {
            ENColaboracion aux = new ENColaboracion(this);
            CADColaboracion user = new CADColaboracion();
            bool update = false;
            if (user.readColaboracion(aux))
            {
                this.Id = aux.Id;
                this.Nombre = aux.Nombre;
                this.Descripcion = aux.Descripcion;
                this.Precio = aux.Precio;
                updated = user.updateColaboracion(this);
            }
            return update;
        }
        public bool deleteColaboracion() {
            CADUColaboracion colab = new CADColaboracion();
            bool eliminado = false;
            if (colab.readColaboracion(this))
                eliminado = user.deleteColaboracion(this);
            else { return eliminado; }
        }
    }
}
