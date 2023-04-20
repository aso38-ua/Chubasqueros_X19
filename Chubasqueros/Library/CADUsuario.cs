using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class CADUsuario
    {
        private String constring;
        public CADUsuario()
        {
            constring = ConfigurationManager.ConnectionStrings["miconexion"].ToString();
        }
        public bool createUsuario(ENUsuario en) { return true; }
        public bool readUsuario(ENUsuario en) { return true; }
        public bool updateUsuario(ENUsuario en) { return true; }
        public bool deleteUsuario(ENUsuario en) { return true; }
        // Create
        public static void CrearUsuario(ENUsuario en)
        {
            throw new NotImplementedException();
        }

        // Read
        public static ENUsuario ObtenerUsuarioPorId(int id)
        {
            throw new NotImplementedException();
        }

        public static ENUsuario ObtenerUsuarioPorEmail(string email)
        {
            throw new NotImplementedException();
        }

        public static List<ENUsuario> ObtenerTodosLosUsuarios()
        {
            throw new NotImplementedException();
        }

        // Update
        public static void ActualizarUsuario(ENUsuario usuario)
        {
            throw new NotImplementedException();
        }

        // Delete
        public static void EliminarUsuario(int id)
        {
            throw new NotImplementedException();
        }
    }
}
