using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class ENComentario
    {
        private string id_user;
        private string id_comment;
        private string item;
        private int likes;
        private int dislikes;

        public string aux_id_user
        {
            get { return id_user; }
            set { id_user = value; }
        }

        public string aux_id_comment
        {
            get { return id_comment; }
            set { id_comment = value; }
        }
        public string aux_item
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

        public ENComentario()
        {
            aux_id_user = "";
            aux_id_comment = "";
            aux_item = "";
            aux_likes = 0;
            aux_dislikes = 0;
        }

        public ENComentario(string id_user, string id_comment, string item, int likes, int dislikes)
        {
            aux_id_user = id_user;
            aux_id_comment = id_comment;
            aux_item = item;
            aux_likes = likes;
            aux_dislikes = dislikes;
        }

        public ENComentario(ENComentario en_com)
        {
            aux_id_user = en_com.id_user;
            aux_id_comment = en_com.id_comment;
            aux_item = en_com.item;
            aux_likes = en_com.likes;
            aux_dislikes = en_com.dislikes;
        }

        public bool showComments()
        {
            bool show = false;
            ENComentario aux_EN_Com = new ENComentario(this);
            CADComentario aux_CAD_Com = new CADComentario();
            ENProducto aux_EN_Prod = new ENProducto(item);
            CADProducto aux_CAD_Prod = new CADProducto();
            if (aux_CAD_Prod.read(aux_EN_Prod))
            {
                show = aux_CAD_Com.showComments(this);
            }
            return show;
        }
    }
}
