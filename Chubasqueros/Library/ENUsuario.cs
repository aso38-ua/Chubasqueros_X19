using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class ENUsuario
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string email { get; set; }
        public string contraseña { get; set; }

        public ENUsuario()
        {
            this.id = 0;
            this.nombre = "";
            this.apellido = "";
            this.email = "";
            this.contraseña="";
        }

        public ENUsuario(int id, string nombre, string apellido, string email, string contraseña)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.email = email;
            this.contraseña = contraseña;
        }

        //Crear usuario
        public bool createUsuario()
        {
            CADUsuario user = new CADUsuario();
            bool create = false;
            if (!user.readUsuario(this))
                create = user.createUsuario(this);
            return create;
        }

        //Lee un usuario de la base de datos
        public bool readUsuario()
        {
            CADUsuario user = new CADUsuario();
            bool read = user.readUsuario(this);
            return read;
        }

        //Modifica un usuario
        public bool updateUsuario()
        {
            ENUsuario aux = new ENUsuario();
            CADUsuario user = new CADUsuario();
            bool update = false;
            if (user.readUsuario(aux))
            {
                this.id = id;
                this.nombre = nombre;
                this.apellido = apellido;
                this.email = email;
                this.contraseña = contraseña;
                update = user.updateUsuario(this);
            }
            return update;
        }

        //Elimina un usuario
        public bool deleteUsuario()
        {
            CADUsuario user = new CADUsuario();
            bool eliminado = false;
            if (user.readUsuario(this))
                eliminado = user.deleteUsuario(this);
            return eliminado;
        }

        // Create
        public static void CrearUsuario(int id, string nombre, string apellido, string email, string contraseña)
        {
            ENUsuario nuevoUsuario = new ENUsuario(id, nombre, apellido, email, contraseña);
            CADUsuario.CrearUsuario(nuevoUsuario);
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
