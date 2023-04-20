using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Library
{
    class ENRegistro
    {
        public ENRegistro()
        {
            ENUsuario nuevoUsuario = new ENUsuario();
        }

        public void Registrar(int id,string nombre, string apellido, string email, string contraseña)
        {
            ENUsuario nuevoUsuario = new ENUsuario(id, nombre, apellido, email, contraseña);

            if (!ValidarRegistro(nuevoUsuario))
            {
                Console.WriteLine("El registro no es válido. Por favor, revisa los datos introducidos.");
                return;
            }

            // Si el registro es válido, guardar el usuario en la base de datos o en la estructura de datos utilizada
            CADUsuario.CrearUsuario(nuevoUsuario);

            Console.WriteLine("El usuario ha sido registrado exitosamente.");
        }

        public void Actualizar(int id, string nombre, string apellido, string email, string contraseña)
        {
            ENUsuario usuario = ObtenerUsuarioPorId(id);
            if (usuario != null)
            {
                // Actualizar los datos del usuario
                usuario.id=id;
                usuario.nombre = nombre;
                usuario.apellido = apellido;
                usuario.email = email;
                usuario.contraseña = contraseña;

                CADUsuario.ActualizarUsuario(usuario);
            }
            else
            {
                Console.WriteLine("El usuario ya existe");
            }
        }

        public void Eliminar(int id)
        {
            ENUsuario usuario = ObtenerUsuarioPorId(id);
            if (usuario != null)
            {
                CADUsuario.EliminarUsuario(id);
            }
            else
            {
                Console.WriteLine("El usuario no existe");
            }
        }

        public static ENUsuario ObtenerUsuarioPorId(int id)
        {
            return CADUsuario.ObtenerUsuarioPorId(id);
        }

        public List<ENUsuario> ObtenerTodosLosUsuarios()
        {
            // Obtener todos los usuarios de la base de datos
            return CADUsuario.ObtenerTodosLosUsuarios();
        }

        private bool ValidarRegistro(ENUsuario usuario)
        {
            ENUsuario usuarioExistente = CADUsuario.ObtenerUsuarioPorEmail(usuario.email);
            if (usuarioExistente != null)
            {
                Console.WriteLine("El email introducido ya está en uso. Por favor, introduce otro email.");
                return false;
            }

            // Si se llega hasta aquí, significa que el usuario no existe en la base de datos
            return true;
        }

        private bool ValidarFormatoEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(email);
        }
    }
}
