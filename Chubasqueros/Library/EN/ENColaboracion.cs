using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class ENColaboracion
    {
        //Atributos
        private int Id;
        private string Nombre;
        public string Descripcion;
        public float Precio;

        public int id
        {
            get => Id;
            set => Id = value;
        }

        public string nombre
        {
            get => Nombre;
            set => Nombre = value;
        }

        public string descripcion
        {
            get => Descripcion;
            set => Descripcion = value;
        }

        public float precio
        {
            get => Precio;
            set => Precio = value;
        }

        //Constructor por defecto
        public ENColaboracion() {
            Id = 0;
            Nombre = string.Empty;
            Descripcion = string.Empty;
            Precio = 0;
        }

        //Constructor con parámetros
        public ENColaboracion(int id, string nombre, string descripcion, float precio) {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
            Precio = precio;
        }

        //Crear colaboracion
        public bool createColaboracion() {
            CADColaboracion colab = new CADColaboracion();
            bool create = false;
            if (!colab.readColaboracion(this))
                create = colab.createColaboracion(this);
            return create;
        }

        //Lee una colaboracion de la base de datos
        public bool readColaboracion() {
            CADColaboracion colab = new CADColaboracion();
            bool read = colab.readColaboracion(this);
            return read;
        }

        //Modifica la colaboracion
        public bool updateColaboracion() {
            ENColaboracion aux = new ENColaboracion();
            CADColaboracion user = new CADColaboracion();
            bool update = false;
            if (user.readColaboracion(aux))
            {
                this.Id = aux.Id;
                this.Nombre = aux.Nombre;
                this.Descripcion = aux.Descripcion;
                this.Precio = aux.Precio;
                update = user.updateColaboracion(this);
            }
            return update;
        }
        public bool deleteColaboracion() {
            CADColaboracion colab = new CADColaboracion();
            bool eliminado = false;
            if (colab.readColaboracion(this))
            {
                eliminado = colab.deleteColaboracion(this);
                return eliminado;
            }
            else { return eliminado; }
        }

      
    }
}
