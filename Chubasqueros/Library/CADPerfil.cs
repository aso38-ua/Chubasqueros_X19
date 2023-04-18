using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class CADPerfil
    {
        //private string constring { get; set; }
        public CADPerfil()
        {
            //constring = ConfigurationManager.ConnectionStrings["Database"].ToString();
        }

        public ENPerfil ObtenerPerfilPorIdUsuario(int idUsuario)
        {
            ENPerfil perfil = new ENPerfil();

            return perfil;
        }

        // Método para actualizar el perfil de un usuario en la base de datos
        public void ActualizarPerfil(ENPerfil perfil)
        {

        }
    }
}
