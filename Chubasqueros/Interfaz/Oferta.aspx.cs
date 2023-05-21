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
    public partial class Oferta : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack)
            {
                LoadAllServices();
            }
        }

        private void LoadAllServices()
        {
            DataTable dataTable = ENOfertas.readAllOffers();

            labelInfo.Text = "";
            int counter = 0;
            string rowHTML = "<div class='row'>"; // Inicia una nueva fila

            foreach (DataRow row in dataTable.Rows)
            {
                string idOferta = row["idOferta"].ToString();
                string porcentajeDescuento = row["porcentajeDescuento"].ToString();
                string descripcion = row["descripcion"].ToString();
                string img = row["img"].ToString();

                string serviceHTML = $@"
                    <div class='col-md-6'>
                        <div class='servicio-container'>
                            <div class='servicio-imagen'>
                                <img src='{img}' alt='Imagen del servicio' class='servicio-imagen-img' />
                            </div>
                            <div class='servicio-contenido'>
                                <p class='p-servicio'>{descripcion}</p>
                            </div>
                        </div>
                    </div>
                ";

                if (counter % 2 == 0 && counter > 0)
                {
                    rowHTML += "</div><div class='row'>"; // Cierra la fila anterior y comienza una nueva
                }

                rowHTML += serviceHTML;

                counter++;
            }

            rowHTML += "</div>"; // Cierra la última fila

            LiteralControl literalControl = new LiteralControl(rowHTML);
            labelInfo.Controls.Add(literalControl);
        }

    }
}