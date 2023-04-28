using Library;
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
        private int item;
        private int id_user;

        public int aux_estrella
        {
            get { return estrellas; }
            set { estrellas = value; }
        }

        public int aux_item
        {
            get { return item; }
            set { item = value; }
        }

        public int aux_id_user
        {
            get { return id_user; }
            set { id_user = value; }
        }

        public ENPuntuacion()
        {
            aux_estrella = 0;
            aux_item = 0;
            aux_id_user = 0;
        }

        public ENPuntuacion(int estrella, int item, int id_user)
        {
            aux_estrella = estrella;
            aux_item = item;
            aux_id_user = id_user;
        }

        public ENPuntuacion(ENPuntuacion en)
        {
            aux_estrella = en.aux_estrella;
            aux_item = en.aux_item;
            aux_id_user = en.aux_id_user;
        }
        public bool createPuntuacion()
        {
            bool puntuar = false;
            ENPuntuacion aux_EN_Pun = new ENPuntuacion(this);
            CADPuntuacion aux_CAD_Pun = new CADPuntuacion();
            ENProducto aux_EN_Prod = new ENProducto();
            CADProducto aux_CAD_Prod = new CADProducto();
            ENUsuario aux_EN_User = new ENUsuario();
            CADUsuario aux_CAD_User = new CADUsuario();
            if (aux_CAD_Prod.readProducto(aux_EN_Prod) && aux_CAD_User.readUsuario(aux_EN_User))
            {
                puntuar = aux_CAD_Pun.createPuntuacion(this);
            }
            return puntuar;
        }

        public bool eliminatePuntuacion()
        {
            bool eliminate = false;
            ENPuntuacion aux_EN_Pun = new ENPuntuacion(this);
            CADPuntuacion aux_CAD_Pun = new CADPuntuacion();
            if (aux_CAD_Pun.findItem(aux_EN_Pun))
            {
                eliminate = aux_CAD_Pun.eliminatePuntuacion(this);
            }
            return eliminate;
        }

        public bool changePuntuacion()
        {
            bool change = false;
            ENPuntuacion aux_EN_Pun = new ENPuntuacion(this);
            CADPuntuacion aux_CAD_Pun = new CADPuntuacion();
            if (aux_CAD_Pun.findItem(aux_EN_Pun))
            {
                change = aux_CAD_Pun.changePuntuacion(this);
            }
            return change;
        }

        public bool mediaPuntuacion()
        {
            bool media = false;
            ENPuntuacion aux_EN_Pun = new ENPuntuacion(this);
            CADPuntuacion aux_CAD_Pun = new CADPuntuacion();
            if (aux_CAD_Pun.findItem(aux_EN_Pun))
            {
                media = aux_CAD_Pun.changePuntuacion(this);
            }
            return media;
        }

        public bool findItem()
        {
            bool find = false;
            CADPuntuacion aux_CAD_Pun = new CADPuntuacion();
            find = aux_CAD_Pun.findItem(this);
            return find;
        }
    }
}
