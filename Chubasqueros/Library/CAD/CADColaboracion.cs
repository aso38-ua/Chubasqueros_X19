using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;
using System.Configuration;

namespace Library
{
    public class CADColaboracion
    {
        private String constring;

        public CADColaboracion()
        {
            constring = ConfigurationManager.ConnectionStrings["miconexion"].ToString();
        }
        public bool createColaboracion(ENColaboracion en) { return true; }
        public bool readColaboracion(ENColaboracion en) { return true; }
        public bool updateColaboracion(ENColaboracion en) { return true; }
        public bool deleteColaboracion(ENColaboracion en) { return true; }
    }
}
