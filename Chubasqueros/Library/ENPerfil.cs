using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class ENPerfil
    {
        public int IdPerfil { get; set; }
        public int IdUsuario { get; set; }
        public string NombreCompleto { get; set; }
        public string Direccion { get; set; }
        public string NumeroTelefono { get; set; }

        public ENPerfil()
        {

        }

        public ENPerfil ObtenerPerfilPorIdUsuario(int idUsuario)
        {
            CADPerfil cadPerfil = new CADPerfil();
            return cadPerfil.ObtenerPerfilPorIdUsuario(idUsuario);
        }

        // Método para actualizar el perfil de un usuario
        public void ActualizarPerfil()
        {
            //CADPerfil cadPerfil = new CADPerfil();
            //cadPerfil.ActualizarPerfil(this);
        }
    }
}
