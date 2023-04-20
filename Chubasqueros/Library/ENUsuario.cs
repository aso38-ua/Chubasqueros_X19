using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class ENUsuario
    {
        private int id;
        private string nombre;
        private string apellido;
        private string email;
        private string contraseña;

        public ENUsuario(int id, string nombre, string apellido, string email, string contraseña)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.email = email;
            this.contraseña = contraseña;
        }

        // Create
        public static void CrearUsuario(string nombre, string apellido, string email, string contraseña)
        {
            CADUsuario.CrearUsuario(nombre, apellido, email, contraseña);
        }

        // Read
        public static ENUsuario ObtenerUsuarioPorId(int id)
        {
            return CADUsuario.ObtenerUsuarioPorId(id);
        }

        public static ENUsuario ObtenerUsuarioPorEmail(string email)
        {
            return CADUsuario.ObtenerUsuarioPorEmail(email);
        }

        public static List<ENUsuario> ObtenerTodosLosUsuarios()
        {
            return CADUsuario.ObtenerTodosLosUsuarios();
        }

        // Update
        public void ActualizarNombre(string nuevoNombre)
        {
            this.nombre = nuevoNombre;
            CADUsuario.ActualizarUsuario(this);
        }

        public void ActualizarApellido(string nuevoApellido)
        {
            this.apellido = nuevoApellido;
            CADUsuario.ActualizarUsuario(this);
        }

        public void ActualizarEmail(string nuevoEmail)
        {
            this.email = nuevoEmail;
            CADUsuario.ActualizarUsuario(this);
        }

        public void ActualizarContraseña(string nuevaContraseña)
        {
            this.contraseña = nuevaContraseña;
            CADUsuario.ActualizarUsuario(this);
        }

        // Delete
        public void Eliminar()
        {
            CADUsuario.EliminarUsuario(this.id);
        }
    }
}
