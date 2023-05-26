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
        private int media;
        private int contador;

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

        public int aux_media
        {
            get { return media; }
            set { media = value; }
        }
        public int aux_contador
        {
            get { return contador; }
            set { contador = value; }
        }

        //Constructor por defecto
        public ENPuntuacion()
        {
            aux_estrella = 0;
            aux_item = 0;
            aux_id_user = 0;
            aux_media = 0;
            aux_contador = 0;
        }

        //COnstructor auxiliar
        public ENPuntuacion(int estrella, int item, int id_user)
        {
            aux_estrella = estrella;
            aux_item = item;
            aux_id_user = id_user;
            aux_media = 0;
            aux_contador = 0;
        }

        //COnstructor copia
        public ENPuntuacion(ENPuntuacion en)
        {
            aux_estrella = en.aux_estrella;
            aux_item = en.aux_item;
            aux_id_user = en.aux_id_user;
            aux_media = en.media;
            aux_contador = en.contador;
        }

        //Crea una puntuación
        public bool createPuntuacion()
        {
            bool puntuar = false;
            ENPuntuacion aux_EN_Pun = new ENPuntuacion(this);
            CADPuntuacion aux_CAD_Pun = new CADPuntuacion();

            puntuar = aux_CAD_Pun.createPuntuacion(this);

            return puntuar;
        }

        //Elimina una puntuación
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

        //Calcula la media de la puntuación
        public bool mediaPuntuacion()
        {
            bool mediaP = false;
            ENPuntuacion aux_EN_Pun = new ENPuntuacion(this);
            CADPuntuacion aux_CAD_Pun = new CADPuntuacion();
            if (aux_CAD_Pun.findItem(aux_EN_Pun))
            {
                mediaP = aux_CAD_Pun.mediaPuntuacion(this);
            }
            return mediaP;
        }

        //Calcula el número total de estrellas del producto
        public bool totalEstrellas()
        {
            bool totalE = false;
            ENPuntuacion aux_EN_Pun = new ENPuntuacion(this);
            CADPuntuacion aux_CAD_Pun = new CADPuntuacion();
            if (aux_CAD_Pun.findItem(aux_EN_Pun))
            {
                totalE = aux_CAD_Pun.totalEstrellas(this);
            }
            return totalE;
        }

        //Encuentra la puntuación según item y user
        public bool findItem()
        {
            bool find = false;
            CADPuntuacion aux_CAD_Pun = new CADPuntuacion();
            find = aux_CAD_Pun.findItem(this);
            return find;
        }

        //Encuentra la puntuación según item
        public bool findItemSinUser()
        {
            bool findU = false;
            CADPuntuacion aux_CAD_Pun = new CADPuntuacion();
            findU = aux_CAD_Pun.findItemSinUser(this);
            return findU;
        }
    }
}
