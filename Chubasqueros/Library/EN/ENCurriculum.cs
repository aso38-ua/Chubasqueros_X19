using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class ENCurriculum
    {
        // Atributos
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Experiencia { get; set; }
        public string Educacion { get; set; }

        // Constructor
        public ENCurriculum()
        {
            // Constructor por defecto
        }

        // Métodos CRUD
        public void CrearCurriculum()
        {
            CADCurriculum cadCurriculum = new CADCurriculum();
            // Lógica para crear un nuevo curriculum en la base de datos utilizando el CADCurriculum
            cadCurriculum.CrearCurriculum(this);
            Console.WriteLine("Curriculum creado exitosamente.");
        }

        public void LeerCurriculum()
        {
            CADCurriculum cadCurriculum = new CADCurriculum();
            // Lógica para leer un curriculum de la base de datos utilizando el CADCurriculum
            ENCurriculum curriculum = cadCurriculum.LeerCurriculum(this.Id);
            if (curriculum != null)
            {
                this.Nombre = curriculum.Nombre;
                this.Apellido = curriculum.Apellido;
                this.Experiencia = curriculum.Experiencia;
                Console.WriteLine("Curriculum leído exitosamente.");
            }
            else
            {
                Console.WriteLine("El curriculum no existe.");
            }
        }

        public void ActualizarCurriculum()
        {
            CADCurriculum cadCurriculum = new CADCurriculum();
            // Lógica para actualizar un curriculum en la base de datos utilizando el CADCurriculum
            cadCurriculum.ActualizarCurriculum(this);
            Console.WriteLine("Curriculum actualizado exitosamente.");
        }

        public void BorrarCurriculum()
        {
            CADCurriculum cadCurriculum = new CADCurriculum();
            // Lógica para borrar un curriculum de la base de datos utilizando el CADCurriculum
            cadCurriculum.BorrarCurriculum(this.Id);
            Console.WriteLine("Curriculum borrado exitosamente.");
        }
    }
}
