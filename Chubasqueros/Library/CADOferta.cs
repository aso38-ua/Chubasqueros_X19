using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace library {
    public class CADOferta {
        private string constring;

        public CADOferta() {
            constring = ConfigurationManager.ConnectionStrings["miconexion"].ToString();
        }

        public bool createOferta(ENOferta oferta) {

            return true;
        }

        public bool readOferta(ENOferta oferta) {

            return true;
        }

        public bool updateOferta(ENOferta oferta) {

            return true;
        }

        public bool deleteOferta(ENOferta oferta) {

            return true;
        }
    }
}