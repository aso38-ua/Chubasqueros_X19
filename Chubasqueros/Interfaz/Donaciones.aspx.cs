using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;

namespace Interfaz
{
    public partial class Donaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MostrarMsg.Text = "";
            }
        }

        protected void ComprobarDonar(object sender, EventArgs e)
        {
            if (tarjeta.Text == "" || cantidad.Text == "" || seguridad.Text == "")
            {
                MostrarMsg.Text = "Campo vacío";
            }
            else
            {
                if (tarjeta.Text.Length != 16 || seguridad.Text.Length != 3 || (cantidad.Text.Length == 1 && cantidad.Text[0] <= 1))
                {
                    MostrarMsg.Text = "Número incorrecto de cifras";
                }
                else
                {
                    if (!IsNumeric(tarjeta.Text) || !IsNumeric(seguridad.Text) || !IsValid(cantidad.Text))
                        MostrarMsg.Text = "Has introducido un carácter no numerico";
                }
            }
        }
        //Comprueba la tarjeta y el código de seguridad
        private static bool IsNumeric(string value)
        {
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
    }
}