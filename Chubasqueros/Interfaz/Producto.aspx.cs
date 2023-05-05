using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Interfaz
{
    public partial class Producto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            outputMsg.Text = "";
        }

        protected void onLeer(object sender, EventArgs e)
        {
            /**if (text_codigo.Text == "")
                outputMsg.Text = "Clave primaria de producto no introducida.";
            else
            {
                ENProducto producto = new ENProducto();
                producto.setCodigo(text_codigo.Text);

                if (producto.readProducto())
                {
                    text_nombre.Text = producto.getNombre();
                    text_codigo.Text = producto.getCodigo();
                    text_descripcion.Text = producto.getDescripcion();
                    text_stock.Text = producto.getStock();
                    text_precio.Text = producto.getPrecio();
                    text_codigoCategoria = producto.getCodigoCategoria();
                    outputMsg.Text = "Producto " + producto.getNombre() + ", " + producto.getCodigo();
                }
                else outputMsg.Text = "Producto no encontrado en la B.D.";
            }*/
        }

        protected void onCrear(object sender, EventArgs e)
        {
            /**if (text_nombre.Text != "" && text_codigo.Text != "" && text_descripcion.Text != "" && text_stock.Text != "" && text_precio.Text != "" && text_codigoCategoria.Text != "")
            {
                ENProducto producto = new ENProducto(text_codigo.Text, text_nombre.Text, text_descripcion.Text, text_stock.Text, text_precio.Text, text_codigoCategoria.Text);

                if (producto.createProducto())
                    outputMsg.Text = "Producto " + producto.getCodigo() + " insertado en la B.D.";
                else outputMsg.Text = "No es posible insertar el producto.";
            }

            else outputMsg.Text = "Alguno de los campos no estan especificados.";*/
        }

        protected void onActualizar(object sender, EventArgs e)
        {
            /**if (text_nombre.Text != "" && text_codigo.Text != "" && text_descripcion.Text != "" && text_stock.Text != "" && text_precio.Text != "" && text_codigoCategoria.Text != "")
            {
                ENProducto producto = new ENProducto(text_codigo.Text, text_nombre.Text, text_descripcion.Text, text_stock.Text, text_precio.Text, text_codigoCategoria.Text);

                if (producto.updateProducto())
                {
                    outputMsg.Text = "Producto " + producto.getCodigo() + " actualizado";
                }
                else outputMsg.Text = "Este producto no existe en la B.D.";
            }

            else outputMsg.Text = "Alguno de los campos no estan especificados.";*/

        }

        protected void onBorrar(object sender, EventArgs e)
        {
            /**if (text_nombre.Text != "" && text_codigo.Text != "")
            {
                ENProducto producto = new ENProducto(text_codigo.Text, text_nombre.Text, text_descripcion.Text, text_stock.Text, text_precio.Text, text_codigoCategoria.Text);

                if (producto.deleteProducto())
                    outputMsg.Text = "Producto " + producto.getCodigo() + " borrado";
                else outputMsg.Text = "No es posible borrar el producto " + producto.getCodigo();

            }

            else outputMsg.Text = "Alguno de los campos no estan especificados.";*/
        }

        protected void onComprar(object sender, EventArgs e)
        {
            //if stock > 0 then stock - 1 y saldoCliente - precio, else no hay stock para el producto

        }

        protected void onCarrito(object sender, EventArgs e)
        {


        }

        protected void onFavoritos(object sender, EventArgs e)
        {


        }

        protected void onPuntuar(object sender, EventArgs e)
        {


        }

        protected void onReservar(object sender, EventArgs e)
        {


        }

        protected void onCategoria(object sender, EventArgs e)
        {
            /**if (text_codigo.Text == "" || text_codigoCategoria.Text == "")
                outputMsg.Text = "Clave primaria de producto no introducida.";
            else
            {
                ENProducto producto = new ENProducto();
                producto.setCodigo(text_codigo.Text);
                producto.setCodigoCategoria(text_codigoCategoria.Text);
                ENCategoria en = new ENCategoria();
                ENProducto[] productos = producto.mostrarProductosPorCategoria(en);

                outputMsg.Text = "Mostrando productos de la categoría " + producto.getCodigoCategoria();
                for (int i = 0; i < productos.Length; i++)
                {
                    if (productos[i].readProducto())
                    {

                        text_nombre.Text = productos[i].getNombre();
                        text_codigo.Text = productos[i].getCodigo();
                        text_descripcion.Text = productos[i].getDescripcion();
                        text_stock.Text = productos[i].getStock();
                        text_precio.Text = productos[i].getPrecio();
                        text_codigoCategoria.Text = productos[i].getCodigoCategoria();
                        outputMsg.Text = "Producto " + producto.getNombre() + ", " + producto.getCodigo();
                    }
                    else outputMsg.Text = "Producto no encontrado en la B.D.";

                }

            }*/
        }

    }
}