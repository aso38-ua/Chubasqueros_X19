using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library {
    public class ENOferta {
        // Variables 
        private string fechaInicio;
        private string fechaFin;
        private float porcentajeDescuento;

        // Getters y setters
        public string FechaInicio {
            get {
                return fechaInicio;
            }
            set {
                fechaInicio = value;
            }
        }

        public string FechaFin {
            get {
                return fechaFin;
            }
            set {
                fechaFin = value;
            }
        }

        public float PorcentajeDescuento {
            get {
                return porcentajeDescuento;
            }
            set {
                porcentajeDescuento = value;
            }
        }

        // Constructores 
        public ENOferta(string fechaInicio, string fechaFin, float porcentajeDescuento) {
            this.fechaInicio = fechaInicio;
            this.fechaFin = fechaFin;
            this.porcentajeDescuento = porcentajeDescuento;
        }

        public ENOferta(ENOferta oferta) {
            this.fechaInicio = oferta.fechaInicio;
            this.fechaFin = oferta.fechaFin;
            this.porcentajeDescuento = oferta.porcentajeDescuento;
        }

        // Operaciones CRUD
        public bool createOferta() {
            CADOferta oferta = new CADOferta();

            if(!oferta.readOferta(this)) 
                return oferta.createOferta(this);

            return false;
        }

        public bool readOferta() {
            CADOferta oferta = new CADOferta();

            if(oferta.readOferta(this))
                return true;

            return false;
        }

        public bool updateOferta() {
            ENOferta ofertaaux = new ENOferta(this);
            CADOferta oferta = new CADOferta();

            if(oferta.readOferta(this)) {
                this.porcentajeDescuento = ofertaaux.porcentajeDescuento;
                this.fechaInicio = ofertaaux.fechaInicio;
                this.fechaFin = ofertaaux.fechaFin;

                return oferta.updateOferta(this);
            }

            return false;
        }

        public bool deleteOferta() {
            CADOferta oferta = new CADOferta();

            if(oferta.readOferta(this))
                return oferta.deleteOferta(this);

            return false;
        }
    }
}
