using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class ENComentario
    {
        private int id_user;
        private int item;
        private int likes;
        private int dislikes;
        private int estrellas;
        private string comentario;

        public int aux_id_user
        {
            get { return id_user; }
            set { id_user = value; }
        }

        public int aux_item
        {
            get { return item; }
            set { item = value; }
        }
        public int aux_likes
        {
            get { return likes; }
            set { likes = value; }
        }

        public int aux_dislikes
        {
            get { return dislikes; }
            set { dislikes = value; }
        }

        public int aux_estrellas
        {
            get { return estrellas; }
            set { estrellas = value; }
        }
        public string aux_comentario
        {
            get { return comentario; }
            set { comentario = value; }
        }

        //Constructor por defecto
        public ENComentario()
        {
            aux_id_user = 0;
            aux_item = 0;
            aux_likes = 0;
            aux_dislikes = 0;
            ENPuntuacion en = new ENPuntuacion(aux_estrellas, aux_item, aux_id_user);
            aux_estrellas = en.aux_estrella;
            comentario = "";
        }
        //Constructor parametrizado
        public ENComentario(int id_user, int item, int likes, int dislikes, int estrellas, string comentario)
        {
            aux_id_user = id_user;
            aux_item = item;
            aux_likes = likes;
            aux_dislikes = dislikes;
            ENPuntuacion en = new ENPuntuacion(aux_estrellas, aux_item, aux_id_user);
            aux_estrellas = en.aux_estrella;
            aux_comentario = comentario;
        }
        //Constructor copia
        public ENComentario(ENComentario en_com)
        {
            aux_id_user = en_com.id_user;
            aux_item = en_com.item;
            aux_likes = en_com.likes;
            aux_dislikes = en_com.dislikes;
            ENPuntuacion en = new ENPuntuacion(aux_estrellas, aux_item, aux_id_user);
            aux_estrellas = en.aux_estrella;
            aux_comentario = en_com.comentario;
        }
        //Crea un comentario
        public bool createComment()
        {
            bool create = false;
            ENComentario aux_EN_Com = new ENComentario(this);
            CADComentario aux_CAD_Com = new CADComentario();

            if (estrellas > 0 && estrellas < 5)
            {
                create = aux_CAD_Com.createComment(this);
            }
            return create;
        }
        //Elimina un comentario
        public bool eliminateComment()
        {
            bool eliminate = false;
            ENComentario aux_EN_Com = new ENComentario(this);
            CADComentario aux_CAD_Com = new CADComentario();
            ENPuntuacion aux_EN_Pun = new ENPuntuacion(aux_estrellas, aux_item, aux_id_user);
            CADPuntuacion aux_CAD_Pun = new CADPuntuacion();

            if (aux_CAD_Pun.findItem(aux_EN_Pun))
            {
                eliminate = aux_CAD_Com.eliminateComment(this);
            }
            return eliminate;
        }
        //Modifica un comentario
        public bool changeComment()
        {
            bool change = false;
            ENComentario aux_EN_Com = new ENComentario(this);
            CADComentario aux_CAD_Com = new CADComentario();
            ENPuntuacion aux_EN_Pun = new ENPuntuacion(aux_estrellas, aux_item, aux_id_user);
            CADPuntuacion aux_CAD_Pun = new CADPuntuacion();

            if (aux_CAD_Pun.findItem(aux_EN_Pun))
            {
                change = aux_CAD_Com.changeComment(this);
            }
            return change;
        }
        //Muestra comentarios del item
        public bool showComments()
        {
            bool show = false;

            ENComentario aux_EN_Com = new ENComentario(this);
            CADComentario aux_CAD_Com = new CADComentario();
            ENProducto aux_EN_Prod = new ENProducto();
            CADProducto aux_CAD_Prod = new CADProducto();
            aux_EN_Prod.setCodigo(item);
            if (aux_CAD_Prod.readProducto(aux_EN_Prod))
            {
                show = aux_CAD_Com.showComments(this);
            }
            return show;
        }
        //Obtine los datos de un comentario según el item y el usuario
        public bool readComment()
        {
            bool read = false;

            ENComentario aux_EN_Com = new ENComentario(this);
            CADComentario aux_CAD_Com = new CADComentario();
            ENProducto aux_EN_Prod = new ENProducto();
            CADProducto aux_CAD_Prod = new CADProducto();
            aux_EN_Prod.setCodigo(item);
            if (aux_CAD_Prod.readProducto(aux_EN_Prod))
            {
                read = aux_CAD_Com.readComment(this);
            }
            return read;
        }
        //muestra el primer comentario
        public bool FirstComment()
        {
            bool first = false;
            ENComentario en_c = new ENComentario();
            CADComentario cad_c = new CADComentario();
            first = cad_c.FirstComment(this);
            return first;
        }
        //Accede al comentario anterior
        public bool PrevComment()
        {
            bool prev = false;
            ENComentario en_c = new ENComentario();
            CADComentario cad_c = new CADComentario();
            if (cad_c.FirstComment(en_c) && aux_id_user != en_c.aux_id_user)
            {
                prev = cad_c.PrevComment(this);
            }
            return prev;
        }
        //Accede al comentario siguiente
        public bool NextComment()
        {
            bool next = false;
            ENComentario en_c = new ENComentario(this);
            CADComentario cad_c = new CADComentario();
            if (cad_c.FirstComment(en_c) && aux_id_user != en_c.aux_id_user)
            {
                next = cad_c.NextComment(this);
            }
            return next;
        }
        //Suma likes
        public bool likesItem()
        {
            bool like = false;
            ENComentario aux_EN_Com = new ENComentario(this);
            CADComentario aux_CAD_Com = new CADComentario();
            ENProducto aux_EN_Prod = new ENProducto();
            CADProducto aux_CAD_Prod = new CADProducto();
            aux_EN_Prod.setCodigo(item);
            if (aux_CAD_Prod.readProducto(aux_EN_Prod))
            {
                like = aux_CAD_Com.likesItem(this);
            }
            return like;
        }
        //Suma dislikes
        public bool dislikesItem()
        {
            bool dislike = false;
            ENComentario aux_EN_Com = new ENComentario(this);
            CADComentario aux_CAD_Com = new CADComentario();
            ENProducto aux_EN_Prod = new ENProducto();
            CADProducto aux_CAD_Prod = new CADProducto();
            aux_EN_Prod.setCodigo(item);
            if (aux_CAD_Prod.readProducto(aux_EN_Prod))
            {
                dislike = aux_CAD_Com.dislikesItem(this);
            }
            return dislike;
        }
    }
}
