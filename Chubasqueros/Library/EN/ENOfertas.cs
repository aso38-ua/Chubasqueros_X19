using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace library
{
    public class ENOfertas
    {
        private int idOferta;
        private int porcentajeDescuento;
        private string descripcion;
        private string img;

        // Propiedades para acceder a los campos privados
        public int IdOferta
        {
            get
            {
                return idOferta;
            }

            set
            {
                idOferta = value;
            }
        }

        public int PorcentajeDescuento
        {
            get
            {
                return porcentajeDescuento;
            }

            set
            {
                porcentajeDescuento = value;
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
        public ENOfertas()
        {
            this.idOferta = -1;
            this.descripcion = "";
            this.porcentajeDescuento = -1;
            this.img = "";
        }

        // Constructor con parámetros
        public ENOfertas(int idOferta, int porcentajeDescuento, string descripcion, string img)
        {
            this.idOferta = idOferta;
            this.porcentajeDescuento = porcentajeDescuento;
            this.descripcion = descripcion;
            this.img = img;
        }

        // Constructor de copia
        public ENOfertas(ENOfertas oferta)
        {
            this.idOferta = oferta.idOferta;
            this.porcentajeDescuento = oferta.porcentajeDescuento;
            this.descripcion = oferta.descripcion;
            this.img = oferta.img;
        }

        // MÉTODOS CRUD 
        // Crea una oferta en la BD
        public bool createOferta()
        {
            CADOfertas oferta = new CADOfertas();

            if (!oferta.readOferta(this))
                return oferta.createOferta(this);

            return false;
        }

        // Lee una oferta de la BD
        public bool readOferta()
        {
            CADOfertas oferta = new CADOfertas();

            if (oferta.readOferta(this))
                return true;

            return false;
        }

        // Actualiza una oferta en la BD
        public bool updateOferta()
        {
            ENOfertas ofertaaux = new ENOfertas(this);
            CADOfertas oferta = new CADOfertas();

            if (oferta.readOferta(this))
            {
                this.idOferta = ofertaaux.idOferta;
                this.porcentajeDescuento = ofertaaux.porcentajeDescuento;
                this.descripcion = ofertaaux.descripcion;
                this.img = ofertaaux.img;

                return oferta.updateOferta(this);
            }

            return false;
        }

        // Elimina una oferta de la BD
        public bool deleteOferta()
        {
            CADOfertas oferta = new CADOfertas();

            if (oferta.readOferta(this))
                return oferta.deleteOferta(this);

            return false;
        }

        // Lee todas las ofertas de la BD y las devuelve en un DataTable
        public static DataTable readAllOffers()
        {
            DataTable basedatos = new DataTable();
            CADOfertas oferta = new CADOfertas();
            basedatos = oferta.readAllOffers();

            return basedatos;
        }
    }
}