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
    public class CADPuntuacion
    {
        private String conn;

        public CADPuntuacion()
        {
            conn = ConfigurationManager.ConnectionStrings["miconexion"].ToString();
        }

        public bool createPuntuacion(ENPuntuacion en)
        {
            bool puntuar = false;
            return puntuar;
        }

        public bool eliminatePuntuacion(ENPuntuacion en)
        {
            bool eliminate = false;
            return eliminate;
        }

        public bool changePuntuacion(ENPuntuacion en)
        {
            bool change = false;
            return change;
        }

        public bool mediaPuntuacion(ENPuntuacion en)
        {
            bool media = false;
            return media;
        }

        public bool findItem(ENPuntuacion en)
        {
            bool find = false;
            return find;
        }
    }
}
