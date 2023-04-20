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

        }

        public bool readComentario() {
            CADForo foro = new CADForo


        }

        public bool updateComentario() {
            CADForo foro = new CADForo();

        }

        public bool deleteComentario() {
            CADForo foro = new CADForo();

        }

        // Otras operaciones para comentarios
        public bool readNextComentario() {
            CADForo foro = new CADForo();

        }

        public bool readFirstComentario() {
            CADForo foro = new CADForo();

        }

        // Operaciones CRUD para preguntas y respuestas
        public bool createPregResp() {
            CADForo foro = new CADForo();

        }

        public bool readPregResp() {
            CADForo foro = new CADForo


        }

        public bool updatePregResp() {
            CADForo foro = new CADForo();

        }

        public bool deletePregResp() {
            CADForo foro = new CADForo();

        }

        // Otras operaciones
        public bool readNextPregResp() {
            CADForo foro = new CADForo();

        }

        public bool readFirstPregResp() {
            CADForo foro = new CADForo();

        }
    }
}
