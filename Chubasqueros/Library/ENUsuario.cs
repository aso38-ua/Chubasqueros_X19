using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;
using System.Configuration;

namespace Library
{
    class ENUsuario
    {
        //Atributos privados
        private int Id;
        private string Nombre;
        private string Apellidos;
        private string Email;
        private string Contraseña;

        //Getters y setters
        public string intId
        {
            get { return Id; }
            set { Id = value; }
        }

        public string stringNombre
        {
            get { return Nombre; }
            set { Nombre = value; }
        }

        public string stringApellidos
        {
            get { return Apellidos; }
            set { Apellidos = value; }
        }

        public string stringEmail
        {
            get { return Email; }
            set { Email = value; }
        }

        public string stringContraseña
        {
            get { return Contraseña; }
            set { Contraseña = value; }
        }


        //Constructor por defecto
        public ENUsuario() {
            Id = 0;
            Nombre = string.Empty;
            Apellidos = string.Empty;
            Email = string.Empty;
            Contraseña = string.Empty;
        }

        //Constructor copia
        public ENUsuario(int id, string email, string nombre,string apellidos, string contraseña) {
            Id = id;
            Nombre = nombre;
            Apellidos = apellidos;
            Email = email;
            Contraseña = contraseña;
        }

        //Crear un usuario
        public bool createUsuario() {
            CADUsuario user = new CADUsuario();
            bool create = false;
            if (!user.readUsuario(this))
                creaate = user.createUsuario(this);
            return created; 
        }

        //Leer un usuario de la  base de datos
        public bool readUsuario() {
            CADUsuario user = new CADUsuario();
            bool read = user.readUsuario(this);
            return read; 
        }

        //Modificar un usuario
        public bool updateUsuario() {
            ENUsuario aux = new ENUsuario(this);
            CADUsuario user = new CADUsuario();
            bool update = false;
            if (user.readReserva(aux))
            {
                this.Id = aux.Id;
                this.Nombre = aux.Nombre;
                this.Apellidos = aux.Apellidos;
                this.Email = aux.Email;
                this.Contraseña=aux.Contraseña
                updated = user.updateUsuario(this);
            }
            return update;
        }
        
        //Elimina un usuario
        public bool deleteUsuario() {
            CADUsuario user = new CADUsuario();
            bool eliminado = false;
            if (user.readUsuario(this))
                eliminado = user.deleteUsuario(this);
            else{return eliminado;} 
        }
    }
}
