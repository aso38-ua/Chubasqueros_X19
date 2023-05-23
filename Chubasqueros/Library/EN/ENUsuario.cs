using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Library
{
    public class ENUsuario
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string email { get; set; }
        public string contraseña { get; set; }
        public bool esAdmin { get; set; }

        public ENUsuario()
        {
            this.id = 0;
            this.nombre = "";
            this.apellido = "";
            this.email = "";
            this.contraseña = "";
            this.esAdmin = false;
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

        public bool VerificarNombreUsuarioExistente(string newUsername)
        {
            return CADUsuario.VerificarNombreUsuarioExistente(newUsername);
        }

        public bool VerificarEmailExistente(string newEmail)
        {
            return CADUsuario.VerificarEmailExistente(newEmail);
        }

        public void ActualizarNombreUsuario(string currentUsername, string newUsername)
        {
            CADUsuario.ActualizarNombreUsuario(currentUsername, newUsername);

            // Actualizar el valor en la sesión
            HttpContext.Current.Session["username"] = newUsername;
        }

        public void ActualizarEmail(string currentEmail, string newEmail)
        {
            CADUsuario.ActualizarEmail(currentEmail, newEmail);

            // Actualizar el valor en la sesión
            HttpContext.Current.Session["email"] = newEmail;
        }

    }
}
