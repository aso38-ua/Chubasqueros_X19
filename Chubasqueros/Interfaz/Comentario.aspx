<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Comentario.aspx.cs" Inherits="Interfaz.Comentario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="css/Comentario.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">

    <header>
        <nav>
          <!-- Cambiar esto porque "no existe", la estructura es <li> <a .... </a> </li> -->
          <ul>
            <a href="#">Perfil</a>
            <a href="#">Productos</a>
            <a href="#">Ofertas</a>
            <a href="#">Ajustes</a>
            <a href="#">Contacto</a>
          </ul>
        </nav>
    </header>
    <main>
        <!-- PARTE DE PRODUCTO -->
        <div class="producto-div">
          <h1>Producto</h1>
            
            <p>Nombre del producto</p>
            <p>Descripción del producto</p>
            <p>Precio:</p>
        </div>

        <!-- PARTE DE COMENTAR -->
        <div>
            <form id="comentario-formulario">
                <div class="comentario-div">
                    <h1>Comentar</h1>
                    <input type="text" id="title" name="title" placeholder="Título de tu comentario">
                    <textarea id="comentario" name="comentario" rows="5" placeholder="Escribe tu comentario"></textarea>
                    <button type="submit">Publicar</button>
                </div>
            </form>
        </div>

        <!-- PARTE DE COMENTARIOS YA PUBLICADOS -->
        <div class="comentario-div">
            <br />
            <h1>Mira qué opinan los otros usuarios</h1>
        </div>
    </main> 
    

    <!-- FOOTER -->
    <footer>
        <a href="#" class="fa fa-facebook"></a>
        <a href="#" class="fa fa-twitter"></a>
        <a href="#" class="fa fa-instagram"></a>
    </footer>
</asp:Content>