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
using System.Web.UI.HtmlControls;
using Library;

namespace Interfaz {
    public partial class Servicio : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAllServices();
            }
        }

        private void LoadAllServices()
        {
            DataTable dataTable = ENServicio.readAllServices();

            labelInfo.Text = "";
            foreach (DataRow row in dataTable.Rows)
            {
                string idServicio = row["idServicio"].ToString();
                string titulo = row["titulo"].ToString();
                string descripcion = row["descripcion"].ToString();
                string img = row["img"].ToString();

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

                LiteralControl literalControl = new LiteralControl(innerHTML);
                labelInfo.Controls.Add(literalControl);
            }
        }
    }
}