using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace library {
    public class CADForo {
        private string constring;

        public CADForo() {
            constring = ConfigurationManager.ConnectionStrings["miconexion"].ToString();
        }

        public bool createComentario(ENForo foro) {

            return true;
        }

        public bool readComentario(ENForo foro) {

            return true;
        }

        public bool updateComentario(ENForo foro) {

            return true;
        }

        public bool deleteComentario(ENForo foro) {

            return true;
        }

        public bool readNextComentario(ENForo foro) {

            return true;
        }

        public bool readFirstComentario(ENForo foro) {

            return true;
        }

        public bool createComentario(ENForo foro) {

            return true;
        }

        public bool readPregResp(ENForo foro) {

            return true;
        }

        public bool updatePregResp(ENForo foro) {

            return true;
        }

        public bool deletePregResp(ENForo foro) {

            return true;
        }

        public bool readNextPregResp(ENForo foro) {
            
            return true;
        }

        public bool readFirstPregResp(ENForo foro) {
            
            return true;
        }
    }
}