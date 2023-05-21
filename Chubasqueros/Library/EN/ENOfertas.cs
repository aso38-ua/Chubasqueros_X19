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

        public ENOfertas()
        {
            this.idOferta = -1;
            this.descripcion = "";
            this.porcentajeDescuento = -1;
            this.img = "";
        }

        public ENOfertas(int idOferta, int porcentajeDescuento, string descripcion, string img)
        {
            this.idOferta = idOferta;
            this.porcentajeDescuento = porcentajeDescuento;
            this.descripcion = descripcion;
            this.img = img;
        }

        public ENOfertas(ENOfertas oferta)
        {
            this.idOferta = oferta.idOferta;
            this.porcentajeDescuento = oferta.porcentajeDescuento;
            this.descripcion = oferta.descripcion;
            this.img = oferta.img;
        }

        public bool createOferta()
        {
            CADOfertas oferta = new CADOfertas();

            if (!oferta.readOferta(this))
                return oferta.createOferta(this);

            return false;
        }

        public bool readOferta()
        {
            CADOfertas oferta = new CADOfertas();

            if (oferta.readOferta(this))
                return true;

            return false;
        }

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

        public bool deleteOferta()
        {
            CADOfertas oferta = new CADOfertas();

            if (oferta.readOferta(this))
                return oferta.deleteOferta(this);

            return false;
        }

        public static DataTable readAllOffers()
        {
            DataTable basedatos = new DataTable();
            CADOfertas oferta = new CADOfertas();
            basedatos = oferta.readAllOffers();

            return basedatos;
        }
    }
}