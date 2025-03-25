using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace library
{
    public class ENServicio
    {
        private int idServicio;
        private string titulo;
        private string descripcion;
        private string img;

        // Propiedades para acceder a los campos privados
        public int IdServicio
        {
            get
            {
                return idServicio;
            }

            set
            {
                idServicio = value;
            }
        }

        public string Titulo
        {
            get
            {
                return titulo;
            }

            set
            {
                titulo = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return descripcion;
            }

            set
            {
                descripcion = value;
            }
        }

        public string Img
        {
            get
            {
                return img;
            }

            set
            {
                img = value;
            }
        }

        // Constructor sin parámetros
        public ENServicio()
        {
            this.idServicio = -1;
            this.descripcion = "";
            this.titulo = "";
            this.img = "";
        }

        // Constructor con parámetros
        public ENServicio(int idServicio, string titulo, string descripcion, string img)
        {
            this.idServicio = idServicio;
            this.titulo = titulo;
            this.descripcion = descripcion;
            this.img = img;
        }

        // Constructor de copia
        public ENServicio(ENServicio servicio)
        {
            this.idServicio = servicio.idServicio;
            this.titulo = servicio.titulo;
            this.descripcion = servicio.descripcion;
            this.img = servicio.img;
        }

        // MÉTODOS CRUD 
        // Crea un servicio en la BD
        public bool createServicio()
        {
            CADServicio servicio = new CADServicio();

            if (!servicio.readServicio(this))
                return servicio.createServicio(this);

            return false;
        }

        // Lee un servicio de la BD
        public bool readServicio()
        {
            CADServicio servicio = new CADServicio();

            if (servicio.readServicio(this))
                return true;

            return false;
        }

        // Actualiza un servicio en la BD
        public bool updateServicio()
        {
            ENServicio servicioaux = new ENServicio(this);
            CADServicio servicio = new CADServicio();

            if (servicio.readServicio(this))
            {
                this.idServicio = servicioaux.idServicio;
                this.titulo = servicioaux.titulo;
                this.descripcion = servicioaux.descripcion;
                this.img = servicioaux.img;

                return servicio.updateServicio(this);
            }

            return false;
        }

        // Elimina un servicio de la BD
        public bool deleteServicio()
        {
            CADServicio servicio = new CADServicio();

            if (servicio.readServicio(this))
                return servicio.deleteServicio(this);

            return false;
        }

        // Lee todos los servicios de la BD y las devuelve en un DataTable
        public static DataTable readAllServices()
        {
            DataTable basedatos = new DataTable();
            CADServicio servicio = new CADServicio();
            basedatos = servicio.readAllServices();

            return basedatos;
        }
    }
}