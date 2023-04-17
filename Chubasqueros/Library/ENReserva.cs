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
        private string producto;
        private string usuario;

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

        public string productop
        {
            get { return producto; }
            set { producto = value; }
        }

        public string usuariop
        {
            get { return usuario; }
            set { usuario = value; }
        }

        public ENReserva(int cantidad, string fecha, string producto, string usuario)
        {
            this.cantidad = cantidad;
            this.fecha = fecha;
            this.producto = producto;
            this.usuario = usuario;
        }

        public bool createReserva()
        {
            CADReserva usuario = new CADReserva();
            bool creado = usuario.createReserva(this);
            return creado;
        }

        public bool readReserva()
        {
            CADReserva usuario = new CADReserva();
            bool leido = usuario.readReserva(this);
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
