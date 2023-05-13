using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class ENReserva
    {
        private int cantidad;
        private string fecha;
        private int producto;
        private int usuario;

        public int cantidadp
        {
            get { return cantidad;}
            set { cantidad = value;}
        }

        public string fechap
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public int productop
        {
            get { return producto; }
            set { producto = value; }
        }

        public int usuariop
        {
            get { return usuario; }
            set { usuario = value; }
        }

        public ENReserva(int producto, int usuario)
        {
            this.cantidad = 0;
            this.fecha = "00/00/0000";
            this.producto = producto;
            this.usuario = usuario;
        }

        public ENReserva(int cantidad, string fecha, int producto, int usuario)
        {
            this.cantidad = cantidad;
            this.fecha = fecha;
            this.producto = producto;
            this.usuario = usuario;
        }

        public bool createReserva()
        {
            CADReserva reserva = new CADReserva();
            bool creado = reserva.createReserva(this);
            return creado;
        }

        public bool readReserva()
        {
            CADReserva reserva = new CADReserva();
            bool leido = reserva.readReserva(this);
            return leido;
        }

        public bool updateReserva()
        {
            CADReserva reserva = new CADReserva();
            ENReserva aux = new ENReserva(cantidad,fecha,producto,usuario);
            bool actualizado = false;

            if (reserva.readReserva(aux))
            {
                aux.cantidad = cantidad;
                aux.fecha = fecha;
                aux.producto = producto;
                aux.usuario = usuario;
                actualizado = reserva.updateReserva(aux);
            }

            return actualizado;
        }

        public bool deleteReserva()
        {
            CADReserva reserva = new CADReserva();
            bool borrado = false;
            if (reserva.readReserva(this)) borrado = reserva.deleteReserva(this);
            return borrado;
        }
    }
}
