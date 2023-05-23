using library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using Library;

namespace Interfaz {
    public partial class Servicio : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Llama a la función al cargar la página
                LoadAllServices();
            }
        }

        // Carga la información de la BD 
        private void LoadAllServices()
        {
            // Llama a la implementación de coger toda la info de la BD
            DataTable dataTable = ENServicio.readAllServices();

            labelInfo.Text = "";
            // Iteración por cada fila en DataTable y se saca la info 
            foreach (DataRow row in dataTable.Rows)
            {
                // Obtiene los valores de las columnas de la fila actual
                string idServicio = row["idServicio"].ToString();
                string titulo = row["titulo"].ToString();
                string descripcion = row["descripcion"].ToString();
                string img = row["img"].ToString();

                // Crea el HTML para mostrar cada servicio con sus datos correspondientes
                string innerHTML = $@"
                    <div class='servicio-container'>
                        <div class='servicio-imagen'>
                            <img src='{img}' alt='Imagen del servicio' class='servicio-imagen-img' />
                        </div>
                        <div class='servicio-contenido'>
                            <h2 class='h2-servicio'>{titulo}</h2>
                            <p class='p-servicio'>{descripcion}</p>
                        </div>
                    </div>
                ";

                // Crea un control literal para mostrar tal cual el HTML 
                LiteralControl literalControl = new LiteralControl(innerHTML);
                labelInfo.Controls.Add(literalControl);
            }
        }
    }
}