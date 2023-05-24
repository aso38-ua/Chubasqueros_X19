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
                // Llama a la función al cargar la página
                LoadAllOffers();
            }
        }

        // Carga la información de la BD 
        private void LoadAllOffers()
        {
            // Llama a la implementación de coger toda la info de la BD
            DataTable dataTable = ENOfertas.readAllOffers();

            labelInfo.Text = "";
            int counter = 0;
            string rowHTML = "<div class='row'>"; 

            // Iteración por cada fila en DataTable y se saca la info 
            foreach (DataRow row in dataTable.Rows)
            {
                // Obtiene los valores de las columnas de la fila actual
                string idOferta = row["idOferta"].ToString();
                string porcentajeDescuento = row["porcentajeDescuento"].ToString();
                string descripcion = row["descripcion"].ToString();
                string img = row["img"].ToString();

                // Crea el HTML para mostrar cada oferta con sus datos correspondientes
                string offerHTML = $@"
                    <div class='col-md-6'>
                        <div class='oferta-container'>
                            <div class='oferta-imagen'>
                                <img src='{img}' alt='Imagen de la oferta' class='oferta-imagen-img' />
                            </div>
                            <div class='oferta-contenido'>
                                <p class='p-oferta'>{descripcion}</p>
                            </div>
                        </div>
                    </div>
                ";

                // Para que se hagan dos columnas por cada fila 
                if (counter % 2 == 0 && counter > 0)
                {
                    rowHTML += "</div><div class='row'>";
                }

                rowHTML += offerHTML;

                counter++;
            }

            rowHTML += "</div>";

            // Crea un control literal para mostrar tal cual el HTML 
            LiteralControl literalControl = new LiteralControl(rowHTML);
            labelInfo.Controls.Add(literalControl);
        }
    }
}