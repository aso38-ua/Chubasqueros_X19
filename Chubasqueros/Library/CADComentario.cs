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
    public class CADComentario
    {
        private String conn;

        public CADComentario()
        {
            conn = ConfigurationManager.ConnectionStrings["miconexion"].ToString();
        }

        public bool createComment(ENComentario en)
        {
            bool create = false;
            return create;
        }

        public bool eliminateComment(ENComentario en)
        {
            bool eliminate = false;
            return eliminate;
        }

        public bool changeComment(ENComentario en)
        {
            bool change = false;
            return change;
        }
        public bool showComments(ENComentario en)
        {
            bool create = false;
            return create;
        }

        public bool likesItem(ENComentario en)
        {
            bool like = false;
            return like;
        }

        public bool dislikesItem(ENComentario en)
        {
            bool dislike = false;
            return dislike;
        }
    }
}
