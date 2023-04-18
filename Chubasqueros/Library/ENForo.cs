using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library {
    public class ENForo {
        // Variables
        private int idUsuario;
        private DateTime fechaPublicacion;
        private string comentario;

        // Getters y setters
        public int IdUsuario {
            get {
                return idUsuario;
            }

            set {
                idUsuario = value;
            }
        }

        public DateTime FechaPublicacion {
            get {
                return fechaPublicacion;
            }

            set {
                fechaPublicacion = value;
            }
        }

        public string Comentario {
            get {
                return comentario;
            }

            set {
                comentario = value;
            }
        }

        // Constructores
        public ENForo() {
            idUsuario = -1;
            fechaPublicacion = DateTime.Now;
            comentario = "";
        }

        public ENForo(int idUsuario, DateTime fechaPublicacion, string comentario) {
            this.idUsuario = idUsuario;
            this.fechaPublicacion = fechaPublicacion;
            this.comentario = comentario;
        }

        public ENForo(ENForo foro) {
            this.idUsuario = foro.idUsuario;
            this.fechaPublicacion = foro.fechaPublicacion;
            this.comentario = foro.comentario;
        }

        // Operaciones CRUD 
        public bool createForo() {
            CADForo foro = new CADForo();

        }

        public bool readForo() {
            CADForo foro = new CADForo();

        }

        public bool updateForo() {
            CADForo foro = new CADForo();

        }

        public bool deleteForo() {
            CADForo foro = new CADForo();

        }

        // Otras operaciones
        public bool readNextForo() {
            CADForo foro = new CADForo();

        }

        public bool readFirstForo() {
            CADForo foro = new CADForo();

        }
    }
}