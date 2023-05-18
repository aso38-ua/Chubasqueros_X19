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

        /*
         Servicio servicio = new Servicio();
         servicio.Img = "~/IMGS/nombreimagen.jpg";
        */

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

        public ENServicio()
        {
            this.idServicio = -1;
            this.descripcion = "";
            this.titulo = "";
            this.img = "";
        }

        public ENServicio(int idServicio, string titulo, string descripcion, string img)
        {
            this.idServicio = idServicio;
            this.titulo = titulo;
            this.descripcion = descripcion;
            this.img = img;
        }

        public ENServicio(ENServicio servicio)
        {
            this.idServicio = servicio.idServicio;
            this.titulo = servicio.titulo;
            this.descripcion = servicio.descripcion;
            this.img = servicio.img;
        }

        public bool createServicio()
        {
            CADServicio servicio = new CADServicio();

            if (!servicio.readServicio(this))
                return servicio.createServicio(this);

            return false;
        }

        public bool readServicio()
        {
            CADServicio servicio = new CADServicio();

            if (servicio.readServicio(this))
                return true;

            return false;
        }

        public bool updateServicio()
        {
            ENServicio servicioaux = new ENServicio(this);
            CADServicio oferta = new CADServicio();

            if (oferta.readServicio(this))
            {
                this.idServicio = servicioaux.idServicio;
                this.titulo = servicioaux.titulo;
                this.descripcion = servicioaux.descripcion;
                this.img = servicioaux.img;

                return oferta.updateServicio(this);
            }

            return false;
        }

        public bool deleteServicio()
        {
            CADServicio servicio = new CADServicio();

            if (servicio.readServicio(this))
                return servicio.deleteServicio(this);

            return false;
        }

       /* public static DataTable readAllServices()
        {
            DataTable basedatos = new DataTable();
            CADServicio servicio = new CADServicio();
            basedatos = servicio.readAllServices();

            return basedatos;
        }*/
    }
}