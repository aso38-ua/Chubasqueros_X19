using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class ENDonacion
    {
        //Atributos
        private int Id;
        private string Tarjeta;
        private string Seguridad;
        private string Cantidad;

        public int id
        {
            get => Id;
            set => Id = value;
        }

        public string tarjeta
        {
            get => Tarjeta;
            set
            {
                if (value.Length == 16 && IsNumeric(value))
                {
                    Tarjeta = value;
                }
            }

        }

        public string seguridad
        {
            get => Seguridad;
            set
            {
                if (value.Length == 3 && IsNumeric(value))
                {
                    Seguridad = value;
                }
            }

        }

        public string cantidad
        {
            get => Cantidad;
            set
            {
                if (IsValid(value))
                {
                    if (value.Length == 1 && value[0] >= 1)
                    {
                        Cantidad = value;
                    }
                    Cantidad = value;
                }
            }

        }
        
        //Comprueba la tarjeta y el código de seguridad
        private static bool IsNumeric(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }

            foreach (char c in value)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        //Comprueba la cantidad introducida
        private static bool IsValid(string value)
        {
            //Comprueba que no sea nulo ni vacio
            if (string.IsNullOrEmpty(value))
            {
                // Verificar si es un número se puede pasar a decimal, el decimal es mount
                if (!decimal.TryParse(value, out decimal amount))
                {
                    return false;
                }

                // Verificar si es un valor positivo
                if (amount <= 0)
                {
                    return false;
                }
                return true;
            }
            return false;
        }

        //Constructor por defecto
        public ENDonacion()
        {
            id = 0;
            tarjeta = "";
            seguridad = "";
            cantidad = "";
        }

        //Constructor con parámetros
        public ENDonacion(int Id, string Tarjeta,string Seguridad,string Cantidad)
        {
            this.id = Id;
            this.tarjeta=Tarjeta;
            this.seguridad=Seguridad;
            this.cantidad = Cantidad;
        }

        //Crea una donacion
        public bool createDonacion()
        {
            CADDonacion colab = new CADDonacion();
            bool create = false;
            if (!colab.readDonacion(this))
                create = colab.createDonacion(this);
            return create;
        }

        //Lee una donacion de la base de datos
        public bool readDonacion()
        {
            CADDonacion colab = new CADDonacion();
            bool read = colab.readDonacion(this);
            return read;
        }
    }
}
