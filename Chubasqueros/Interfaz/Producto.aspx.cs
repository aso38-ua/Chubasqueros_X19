using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

using Library;
using System.Data;
using library;

namespace Interfaz
{
    public partial class Producto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //SI NO ESTÁ LOGUEADO
            if (!IsPostBack)
            {
                LoadAllProductos();
            }

            if (Session["username"] == null)
            {
                buttom_Favoritos.Visible = false;
                buttom_Reservar.Visible = false;
                buttom_Comprar.Visible = false;
                buttom_Carrito.Visible = false;
                buttom_Puntuar.Visible = false;

            }
            else
            {
                buttom_Favoritos.Visible = true;
                buttom_Reservar.Visible = true;
                buttom_Comprar.Visible = true;
                buttom_Carrito.Visible = true;
                buttom_Puntuar.Visible = true;

            }

            //OPCIONES ADMIN
            ENUsuario usuario = new ENUsuario();
            usuario.nombre = (string)Session["username"];
            usuario.readUsuario();
            if (!usuario.esAdmin)
            {
                buttom_Crear.Visible = false;
                buttom_Actualizar.Visible = false;
                buttom_Borrar.Visible = false;
            }
            else
            {
                buttom_Crear.Visible = true;
                buttom_Actualizar.Visible = true;
                buttom_Borrar.Visible = true;
            }

            outputMsg.Text = "";
        }

        private void LoadAllProductos()
        {
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                // Si se ha realizado una búsqueda, ocultar el contenido anterior
                labelInfo.Visible = false;
                return;
            }

            DataTable dataTable = ENProducto.readAllServices();

            labelInfo.Text = "";
            foreach (DataRow row in dataTable.Rows)
            {
                string codigo = row["codigo"].ToString();
                string nombre = row["nombre"].ToString();
                string descripcion = row["descripcion"].ToString();
                string precio = row["precio"].ToString();
                string stock = row["stock"].ToString();
                string img = row["img"].ToString();

                string innerHTML = $@"
            <div class='producto-container'>
                <div class='producto-imagen'>
                    <img src='{img}' alt='Imagen del producto' class='producto-imagen-img' />
                </div>
                <div class='producto-contenido'>
                    <p class='h2-producto'>{nombre}</p>
                    <p class='p-producto'>Descripción: {descripcion}</p>
                    <p class='p-producto'>Precio: {precio}</p>
                    <p class='p-producto'>Stock: {stock}</p>
                </div>
            </div>
        ";

                LiteralControl literalControl = new LiteralControl(innerHTML);
                labelInfo.Controls.Add(literalControl);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text;
            DataTable searchResult = ENProducto.BuscarProductosPorNombre(searchTerm);

            // Limpiar los resultados anteriores
            labelInfo.Controls.Clear();

            foreach (DataRow row in searchResult.Rows)
            {
                string codigo = row["codigo"].ToString();
                string nombre = row["nombre"].ToString();
                string descripcion = row["descripcion"].ToString();
                string precio = row["precio"].ToString();
                string stock = row["stock"].ToString();
                string img = row["img"].ToString();

                string innerHTML = $@"
            <div class='producto-container'>
                <div class='producto-imagen'>
                    <img src='{img}' alt='Imagen del producto' class='producto-imagen-img' />
                </div>
                <div class='producto-contenido'>
                    <p class='h2-producto'>{nombre}</p>
                    <p class='p-producto'>Descripción: {descripcion}</p>
                    <p class='p-producto'>Precio: {precio}</p>
                    <p class='p-producto'>Stock: {stock}</p>
                </div>
            </div>
        ";

                LiteralControl literalControl = new LiteralControl(innerHTML);
                labelInfo.Controls.Add(literalControl);
            }
        }


        protected void onLeer(object sender, EventArgs e)
        {
            if (text_codigo.Text == "")
                outputMsg.Text = "Clave primaria de producto no introducida.";
            else
            {
                ENProducto producto = new ENProducto();
                producto.setCodigo(int.Parse(text_codigo.Text));

                if (producto.readProducto())
                {
                    text_nombre.Text = producto.getNombre();
                    text_codigo.Text = producto.getCodigo().ToString();
                    text_descripcion.Text = producto.getDescripcion();
                    text_stock.Text = producto.getStock().ToString();
                    text_precio.Text = producto.getPrecio().ToString();
                    text_codigoCategoria.Text = producto.getCodigoCategoria().ToString();
                    outputMsg.Text = "Producto " + producto.getNombre() + ", " + producto.getCodigo();
                }
                else outputMsg.Text = "Producto no encontrado en la B.D.";
            }
        }

        protected void onCrear(object sender, EventArgs e)
        {
            if (text_nombre.Text != "" && text_codigo.Text != "" && text_descripcion.Text != "" && text_stock.Text != "" && text_precio.Text != "" && text_codigoCategoria.Text != "")
            {
                ENProducto producto = new ENProducto(int.Parse(text_codigo.Text), text_nombre.Text, text_descripcion.Text, int.Parse(text_stock.Text), float.Parse(text_precio.Text), int.Parse(text_codigoCategoria.Text));

                if (producto.createProducto())
                    outputMsg.Text = "Producto " + producto.getCodigo() + " insertado en la B.D.";
                else outputMsg.Text = "No es posible insertar el producto.";
            }

            else outputMsg.Text = "Alguno de los campos no estan especificados.";
        }

        protected void onActualizar(object sender, EventArgs e)
        {
            if (text_nombre.Text != "" && text_codigo.Text != "" && text_descripcion.Text != "" && text_stock.Text != "" && text_precio.Text != "" && text_codigoCategoria.Text != "")
            {
                ENProducto producto = new ENProducto(int.Parse(text_codigo.Text), text_nombre.Text, text_descripcion.Text, int.Parse(text_stock.Text), float.Parse(text_precio.Text), int.Parse(text_codigoCategoria.Text));

                if (producto.updateProducto())
                {
                    outputMsg.Text = "Producto " + producto.getCodigo() + " actualizado";
                }
                else outputMsg.Text = "Este producto no existe en la B.D.";
            }

            else outputMsg.Text = "Alguno de los campos no estan especificados.";

        }

        protected void onBorrar(object sender, EventArgs e)
        {
            if (text_nombre.Text != "" && text_codigo.Text != "")
            {
                ENProducto producto = new ENProducto(int.Parse(text_codigo.Text), text_nombre.Text, text_descripcion.Text, int.Parse(text_stock.Text), float.Parse(text_precio.Text), int.Parse(text_codigoCategoria.Text));

                if (producto.deleteProducto())
                    outputMsg.Text = "Producto " + producto.getCodigo() + " borrado";
                else outputMsg.Text = "No es posible borrar el producto " + producto.getCodigo();

            }

            else outputMsg.Text = "Alguno de los campos no estan especificados.";
        }

       

        protected void onComprar(object sender, EventArgs e)
        {

            if (text_codigo.Text == "")
                outputMsg.Text = "Clave primaria de producto no introducida.";
            else
            {
                ENProducto producto = new ENProducto();
                producto.setCodigo(int.Parse(text_codigo.Text));

                if (producto.readProducto())
                {
                    if (producto.getStock() <= 0)
                        outputMsg.Text = "Este producto no está en stock.";
                    else
                    {
                        producto.setStock(producto.getStock() - 1);
                        //saldoUsuario - precio
                        outputMsg.Text = "Producto " + producto.getCodigo() + " con un precio de " + producto.getPrecio() + "€ comprado con éxito";
                        producto.updateProducto();
                        //Mandar email al usuario confirmando su compra posible mejora


                    }
                }
                else outputMsg.Text = "Producto no encontrado en la B.D.";
            }


        }

        protected void onCarrito(object sender, EventArgs e)
        {
            ENUsuario usuario = new ENUsuario();
            usuario.nombre = (string)Session["username"];
            usuario.readUsuario();
            ENCarrito carrito = new ENCarrito(int.Parse(text_codigo.Text), usuario.id);
            if (!carrito.readCarritoinProduct())
            {
                carrito.AñadirProductoBD(int.Parse(text_codigo.Text));
                Mensaje.Text = "Producto agregado al carrito.";
            }
            else
            {
                Mensaje.Text = "Ya tienes este producto en el carrito.";
            }

        }

        protected void onFavoritos(object sender, EventArgs e)
        {
            ENUsuario usuario = new ENUsuario();
            usuario.nombre = (string)Session["username"];
            usuario.readUsuario();
            ENFavoritos favoritos = new ENFavoritos(int.Parse(text_codigo.Text),usuario.id);
            if (!favoritos.readFavoritosWithP())
            {
                favoritos.insertProductinBD(int.Parse(text_codigo.Text));
                Mensaje.Text = "Producto agregado a lista de favoritos.";
            }
            else
            {
                Mensaje.Text = "El producto ya estaba en su lista de favoritos.";
            }
        }

        protected void onPuntuar(object sender, EventArgs e)
        { //en otro lado?


        }

        protected void onReservar(object sender, EventArgs e)
        {
            DateTime thisDay = DateTime.Today;
            ENUsuario usuario = new ENUsuario();
            usuario.nombre = (string)Session["username"];
            usuario.readUsuario();
            ENReserva reserva = new ENReserva(int.Parse(text_codigo.Text),usuario.id);
            if (!reserva.readReserva())
            {
                reserva.fechap = thisDay.ToString("d");
                reserva.createReserva();
                Mensaje.Text = "Reserva creada";
            }
            else
            {
                ENProducto producto = new ENProducto();
                producto.setCodigo(reserva.productop);
                producto.readProducto();
                reserva.cantidadp = reserva.cantidadp + 1;
                reserva.ptotal = producto.getPrecio() * reserva.cantidadp;
                reserva.updateReserva();
                Mensaje.Text = "Reserva actualizada, añadida una cantidad más a la antigua reserva";
            }

        }

        protected void onCategoria(object sender, EventArgs e)
        {
            if (text_codigoCategoria.Text == "")
                outputMsg.Text = "Clave de la categoría no introducida";
            else
            {
                ENCategoria en = new ENCategoria();
                en.setCodCategoria(int.Parse(text_codigoCategoria.Text));

                if (en.readCategoria())
                {
                    ENProducto producto = new ENProducto();
                    ENProducto[] productos = producto.mostrarProductosPorCategoria(en);
                    if (productos.Length == 0)
                        outputMsg.Text = "La categoría " + en.getNombre() + " con código " + en.getCodCategoria() + " carece de productos";
                    else
                    {
                        outputMsg.Text = "Mostrando productos de la categoría " + en.getNombre() + " con código " + en.getCodCategoria();
                        //text_codigoCategoria.Text += " "; para mostrar todos concatenados
                        for (int i = 0; i < productos.Length; i++)
                        {
                            //así los muestra todos pero en la misma TextBox, lo que queria era que fuese 1 a 1, pero no funcionan los Sleeps() ni llamar a nada y database peta 
                            //entonces directamente muestra el último, o los muestra todos pero concatenándolos en la misma TextBox :(
                            /**text_nombre.Text += productos[i].getNombre() + " ";
                            text_codigo.Text += productos[i].getCodigo().ToString() + " ";
                            text_descripcion.Text += productos[i].getDescripcion() + " ";
                            text_stock.Text += productos[i].getStock().ToString() + " ";
                            text_precio.Text += productos[i].getPrecio().ToString() + " ";
                            text_codigoCategoria.Text += productos[i].getCodigoCategoria().ToString() + " ";*/

                            text_nombre.Text = productos[i].getNombre();
                            text_codigo.Text = productos[i].getCodigo().ToString();
                            text_descripcion.Text = productos[i].getDescripcion();
                            text_stock.Text = productos[i].getStock().ToString();
                            text_precio.Text = productos[i].getPrecio().ToString();
                            text_codigoCategoria.Text = productos[i].getCodigoCategoria().ToString();

                        }
                        

                    }

                }
                else outputMsg.Text = "Categoría inexistente en la B.D.";
                


            }
        }

    }
}
