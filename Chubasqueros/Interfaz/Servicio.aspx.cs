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
                labelInfo.Text += "<div class='service-container'>";
                labelInfo.Text += "  <div class='image-container'>";
                string imagePath = row["img"].ToString();
                if (!string.IsNullOrEmpty(imagePath))
                {
                    labelInfo.Text += "    <img src='" + imagePath + "' alt='Imagen' />";
                }
                labelInfo.Text += "  </div>";
                labelInfo.Text += "  <div class='content-container'>";
                labelInfo.Text += "    <h3>" + row["titulo"].ToString() + "</h3>";
                labelInfo.Text += "    <p>" + row["descripcion"].ToString() + "</p>";
                labelInfo.Text += "  </div>";
                labelInfo.Text += "  <div class='button-container'>";
                // labelInfo.Text += "    <input type='button' value='Añadir servicio al carrito' onclick='addToCart(" + row["idServicio"].ToString() + ")' class='neon-btn' />";
                labelInfo.Text += "  </div>";
                labelInfo.Text += "</div>";
                labelInfo.Text += "<hr />";
            }
        }
    }
}