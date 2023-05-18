using library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using library;
using System.Data.SqlClient;

namespace Interfaz {
    public partial class Servicio : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack)
            {
                CargarServicios();
            }
        }

        protected void CargarServicios()
        {
            // 1. Crear una instancia de la clase ENServicio
            ENServicio enServicio = new ENServicio();

            // 2. Llamar al método createServicio() para obtener los datos de la base de datos
            List<Servicio> servicios = enServicio.createServicio();

            // 3. Asignar la lista de servicios al Repeater
            rptServicios.DataSource = servicios;
            rptServicios.DataBind();
        }



    }
}