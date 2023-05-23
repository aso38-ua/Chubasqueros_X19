using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class ENSeguidores
    {
        public int Id { get; set; }
        public string UsernameSeguidor { get; set; }
        public string UsernameSeguido { get; set; }

        public string Nombre { get; set; }

        public ENSeguidores()
        {
            
        }

        public bool AgregarSeguido(string usernameSeguidor, string usernameSeguido)
        {
            CADSeguidores seguidor = new CADSeguidores();
            return seguidor.AgregarSeguido(usernameSeguidor, usernameSeguido);
        }

        public bool EliminarSeguidor(string usernameSeguidor, string usernameSeguido)
        {
            CADSeguidores seguidor = new CADSeguidores();
            return seguidor.EliminarSeguidor(usernameSeguidor, usernameSeguido);
        }

        public int ObtenerNumeroSeguidores(string username)
        {
            CADSeguidores seguidor = new CADSeguidores();
            return seguidor.ObtenerNumeroSeguidores(username);
        }

        public int ObtenerNumeroSeguidos(string username)
        {
            CADSeguidores seguidor = new CADSeguidores();
            return seguidor.ObtenerNumeroSeguidos(username);
        }

        public List<UsuarioConSeguidores> ObtenerUsuariosConMasSeguidores(int cantidad)
        {
            CADSeguidores seguidor = new CADSeguidores();
            List<UsuarioConSeguidores> usuarios = seguidor.ObtenerUsuariosConMasSeguidores(cantidad);
            return usuarios;
        }

        public int MisSeguidores(string username)
        {
            CADSeguidores seguidor = new CADSeguidores();
            return seguidor.MisSeguidores(username);
        }

        public int Simpeando(string username)
        {
            CADSeguidores seguidor = new CADSeguidores();
            return seguidor.Simpeando(username);
        }
    }
}
