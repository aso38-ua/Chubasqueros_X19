using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class ENRegistro
    {
        public ENRegistro()
        {

        }
        public void Registrar()
        {
            //ENUsuario nuevoUsuario = new ENUsuario(nombre, apellido, email, contraseña);

            if (!ValidarRegistro())
            {

            }
        }

        private bool ValidarRegistro()
        {
            return true;
        }

        private bool ValidarFormatoEmail(string email)
        {
            // var emailRegex = new Regex(@"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$");
            // return emailRegex.IsMatch(email);
            return true;
        }
    }
}
