using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Interfaz
{
    public partial class Categoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            outputMsg.Text = "";
        }

        protected void onLeer(object sender, EventArgs e)
        {
            /**if (text_NIF.Text == "")
                outputMsg.Text = "Clave primaria de categoría no introducida.";
            else
            {
                ENCategoria categoria = new ENCategoria();
                categoria.setCodCategoria(text_codCategoria.Text);

                if (categoria.readCategoria())
                {
                    text_nombre.Text = categoria.getNombre();
                    text_codCategoria.Text = categoria.getCodCategoria();
                    outputMsg.Text = "Categoría " + categoria.getNombre() + ", " + categoria.getCodCategoria();
                }
                else outputMsg.Text = "Categoría no encontrada en la B.D.";
            }*/
        }

        protected void onCrear(object sender, EventArgs e)
        {
            /**if (text_nombre.Text != "" && text_codCategoria.Text != "")
            {
                ENCategoria categoria = new ENCategoria(text_codCategoria.Text, text_nombre.Text);

                if (categoria.createCategoria())
                    outputMsg.Text = "Categoría " + categoria.getCodCategoria() + " insertada en la B.D.";
                else outputMsg.Text = "No es posible insertar la categoría.";
            }

            else outputMsg.Text = "Alguno de los campos no estan especificados.";*/
        }

        protected void onActualizar(object sender, EventArgs e)
        {
            /**if (text_nombre.Text != "" && text_codCategoria.Text != "")
            {
                ENCategoria categoria = new ENCategoria(text_codCategoria.Text, text_nombre.Text);

                if (categoria.updateCategoria())
                {
                    outputMsg.Text = "Categoría " + categoria.getCodCategoria() + " actualizada";
                }
                else outputMsg.Text = "Esta categoría no existe en la B.D.";
            }

            else outputMsg.Text = "Alguno de los campos no estan especificados.";*/

        }

        protected void onBorrar(object sender, EventArgs e)
        {
            /**if (text_nombre.Text != "" && text_codCategoria.Text != "")
            {
                ENCategoria categoria = new ENCategoria(text_codCategoria.Text, text_nombre.Text);

                if (categoria.deleteCategoria())
                    outputMsg.Text = "Categoría " + categoria.getCodCategoria() + " borrada";
                else outputMsg.Text = "No es posible borrar la categoría " + categoria.getCodCategoria();

            }

            else outputMsg.Text = "Alguno de los campos no estan especificados.";*/
        }
    }
}