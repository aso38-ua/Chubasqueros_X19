using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;
using System.Configuration;

namespace library
{
    public class CADUsuario
    {
        private String constring;

        public CADUsuario()
        {
            constring = ConfigurationManager.ConnectionStrings["miconexion"].ToString();
        }
        public bool createUsuario(ENUsuario en) { return true; }
        public bool readUsuario(ENUsuario en) { return true; }
        public bool updateUsuario(ENUsuario en) { return true; }
        public bool deleteUsuario(ENUsuario en) { return true; }
    }
}
