using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class ENUsuario
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

        public ENUsuario(int id, string nombre, string email, string contraseña)
        {
            this.id = id;
            this.nombre = nombre;
            this.email = email;
            this.contraseña = contraseña;
        }

        //Lee un usuario de la base de datos
        public bool readUsuario()
        {
            CADUsuario user = new CADUsuario();
            bool read = user.ReadUsuario(this);
            return read;
        }

        //Modifica un usuario
        public bool updateUsuario()
        {
            ENUsuario aux = new ENUsuario();
            CADUsuario user = new CADUsuario();
            bool update = false;
            if (user.ReadUsuario(aux))
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
            if (user.ReadUsuario(this))
                eliminado = user.deleteUsuario(this);
            return eliminado;
        }

        // Create
        public bool CrearUsuario(int id, string nombre, string email, string contraseña)
        {
            CADUsuario user = new CADUsuario();
            bool created = false;

            if (!user.ReadUsuario(this))
            {
                created = user.CrearUsuario(this);
            }

            return created;
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

        public bool ValidarCredenciales(string nombre, string contraseña)
        {
            return CADUsuario.ValidarCredenciales(nombre, contraseña);
        }

        public string ObtenerEmailPorUsuario(string username)
        {
            return CADUsuario.ObtenerEmailPorUsuario(username);
        }

        public string ObtenerUsuarioPorEmail(string email)
        {
            return CADUsuario.ObtenerUsuarioPorEmail(email);
        }

        public string ObtenerRutaImagenPerfil(string username)
        {
            return CADUsuario.ObtenerRutaImagenPerfil(username);
        }
    }
}
