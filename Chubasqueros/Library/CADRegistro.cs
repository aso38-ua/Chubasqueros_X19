using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class CADRegistro
    {
        //private string constring { get; set; }

        public CADRegistro()
        {

        }
        public void Registrar(ENRegistro registro)
        {
            if (!ValidarRegistro(registro))
            {

            }
        }

        // Método para validar el registro antes de realizarlo
        private bool ValidarRegistro(ENRegistro registro)
        {
            return true;
        }

        // Método para validar el formato del email
        private bool ValidarFormatoEmail(string email)
        {
            return true;
        }
    }
}
