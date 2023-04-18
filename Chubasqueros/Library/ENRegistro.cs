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

        public void Registrar(string nombre, string apellido, string email, string contraseña)
        {
            //ENUsuario nuevoUsuario = new ENUsuario(nombre, apellido, email, contraseña);

            /*if (!ValidarRegistro(nuevoUsuario))
            {
                // Realizar acciones en caso de registro inválido
            }
            else
            {
                // Realizar acciones en caso de registro válido
            }*/
        }

        public void Actualizar(int id, string nombre, string apellido, string email, string contraseña)
        {
            //ENUsuario usuario = ObtenerUsuarioPorId(id);
           /* if (usuario != null)
            {
                // Actualizar los datos del usuario
                usuario.Nombre = nombre;
                usuario.Apellido = apellido;
                usuario.Email = email;
                usuario.Contraseña = contraseña;
                // Guardar los cambios en la base de datos o en la estructura de datos utilizada
            }
            else
            {
                
            }*/
        }

        public void Eliminar(int id)
        {
            /*ENUsuario usuario = ObtenerUsuarioPorId(id);
            if (usuario != null)
            {
                // Eliminar el usuario de la base de datos o de la estructura de datos utilizada
            }
            else
            {
                // Realizar acciones en caso de que no se encuentre el usuario
            }*/
        }

        /*public ENUsuario ObtenerUsuarioPorId(int id)
        {
            // Obtener el usuario por su ID de la base de datos o de la estructura de datos utilizada
            return null;
        }*/

        /*public List<ENUsuario> ObtenerTodosLosUsuarios()
        {
            // Obtener todos los usuarios de la base de datos o de la estructura de datos utilizada
            return new List<ENUsuario>();
        }*/

        /*private bool ValidarRegistro(ENUsuario usuario)
        {
            // Realizar validaciones del registro del usuario, como comprobar si ya existe en la base de datos
            return true;
        }*/

        /*private bool ValidarFormatoEmail(string email)
        {
            // Validar el formato del email utilizando expresiones regulares u otros métodos
            return true;
        }*/
    }
}
