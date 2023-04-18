using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class ENPuntuacion
    {
        private int estrellas;
        private string item;
        private string id_user;

        public int aux_estrella
        {
            get { return estrellas; }
            set { estrellas = value; }
        }

        public string aux_item
        {
            get { return item; }
            set { item = value; }
        }

        public string aux_id_user
        {
            get { return id_user; }
            set { id_user = value; }
        }

        public bool createPuntuacion()
        {
            bool puntuar = false;
            return puntuar;
        }

        public bool eliminatePuntuacion()
        {
            bool eliminate = false;
            return eliminate;
        }

        public bool changePuntuacion()
        {
            bool change = false;
            return change;
        }

        public bool mediaPuntuacion()
        {
            bool media = false;
            return media;
        }
    }
}
