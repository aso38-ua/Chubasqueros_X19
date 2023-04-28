using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library {
    public class ENForo {
        // Variables para comentarios
        private int idUsuario;
        private DateTime fechaPublicacion;
        private string comentario;

        // Variables para preguntas y respuestas
        private string titulo;
        private string pregunta;
        private string respuesta;
        private DateTime fechaPregunta;
        private DateTime fechaRespuesta;

        // Getters y setters para comentarios
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

        // Getters y setters para preguntas y respuestas
        public string Titulo {
            get {
                return titulo;
            }

            set {
                titulo = value;
            }
        }

        public string Pregunta {
            get {
                return pregunta;
            }

            set {
                pregunta = value;
            }
        }

        public string Respuesta {
            get {
                return respuesta;
            }

            set {
                respuesta = value;
            }
        }

        public DateTime FechaPregunta {
            get {
                return fechaPregunta;
            }

            set {
                fechaPregunta = value;
            }
        }

        public DateTime FechaRespuesta {
            get {
                return fechaRespuesta;
            }

            set {
                fechaRespuesta = value;
            }
        }

        // Constructores
        public ENForo() {
            idUsuario = -1;
            fechaPublicacion = DateTime.Now;
            comentario = "";
            titulo = "";
            pregunta = "";
            respuesta = "";
            fechaPregunta = DateTime.Now;
            fechaRespuesta = DateTime.Now;
        }

        public ENForo(int idUsuario, DateTime fechaPublicacion, string titulo, string comentario, string pregunta, string respuesta, DateTime fechaPregunta, DateTime fechaRespuesta) {
            this.idUsuario = idUsuario;
            this.fechaPublicacion = fechaPublicacion;
            this.comentario = comentario;
            this.titulo = titulo;
            this.pregunta = pregunta;
            this.respuesta = respuesta;
            this.fechaPregunta = fechaPregunta;
            this.fechaRespuesta = fechaRespuesta;
        }

        public ENForo(ENForo foro) {
            this.idUsuario = foro.idUsuario;
            this.fechaPublicacion = foro.fechaPublicacion;
            this.comentario = foro.comentario;
            this.titulo = foro.titulo;
            this.pregunta = foro.pregunta;
            this.respuesta = foro.respuesta;
            this.fechaPregunta = foro.fechaPregunta;
            this.fechaRespuesta = foro.fechaRespuesta;
        }

        // Operaciones CRUD para comentarios
        public bool createComentario() {
            CADForo foro = new CADForo();

            if(!foro.readComentario(this))
                return foro.createComentario(this);

            return false;
        }

        public bool readComentario() {
            CADForo foro = new CADForo();

            if(foro.readComentario(this))
                return true;

            return false;
        }

        public bool updateComentario() {
            ENForo foroaux = new ENForo(this);
            CADForo oferta = new CADForo();

            if(oferta.readComentario(this)) {
                this.idUsuario = foroaux.idUsuario;
                this.fechaPublicacion = foroaux.fechaPublicacion;
                this.comentario = foroaux.comentario;

                return oferta.updateComentario(this);
            }

            return false;
        }

        public bool deleteComentario() {
            CADForo foro = new CADForo();

            if(foro.readComentario(this))
                return foro.deleteComentario(this);

            return false;
        }

        // Otras operaciones para comentarios
        public bool readNextComentario() {
            CADForo foro = new CADForo();

            if(foro.readComentario(this))
                return foro.readNextComentario(this);

            return false;
        }

        public bool readFirstComentario() {
            CADForo foro = new CADForo();

            if(foro.readFirstComentario(this))
                return true;

            return false;
        }

        // Operaciones CRUD para preguntas y respuestas
        public bool createPregResp() {
            CADForo foro = new CADForo();

            if(!foro.readPregResp(this))
                return foro.createPregResp(this);

            return false;
        }

        public bool readPregResp() {
            CADForo foro = new CADForo();

            if(foro.readPregResp(this))
                return true;

            return false;
        }

        public bool updatePregResp() {
            ENForo foroaux = new ENForo();
            CADForo foro = new CADForo();


            if(foro.readPregResp(this)) {
                this.pregunta = foroaux.pregunta;
                this.respuesta = foroaux.respuesta;
                this.fechaPregunta = foroaux.fechaPregunta;
                this.fechaRespuesta = foroaux.fechaRespuesta;

                return foro.updatePregResp(this);
            }

            return false;
        }

        public bool deletePregResp() {
            CADForo foro = new CADForo();

            if(foro.readPregResp(this))
                return foro.deletePregResp(this);

            return false;
        }

        // Otras operaciones
        public bool readNextPregResp() {
            CADForo foro = new CADForo();

            if(foro.readPregResp(this))
                return foro.readNextPregResp(this);

            return false;

        }

        public bool readFirstPregResp() {
            CADForo foro = new CADForo();

            if(foro.readFirstPregResp(this))
                return true;

            return false;

        }
    }
}
