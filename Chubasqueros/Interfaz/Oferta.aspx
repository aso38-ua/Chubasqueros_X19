<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Oferta.aspx.cs" Inherits="Interfaz.Oferta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <link href="css/Oferta.css" rel="stylesheet" />
    <br /><br />
    <h1 class="h1-oferta">Descuentos y ofertas</h1>
    <div class="container-oferta">
        <!-- PRIMERA FILA -->
        <div class="row-oferta">
        <div class="col-oferta">
            <img src="IMGS/bienvenida.jfif" class="img-oferta">
            <h2 class="h2-oferta">Descuento nuevo cliente</h2>
            <p class="p-oferta">Por la compra de un chubasquero, llévate otro chubasquero gratis</p>
        </div>
        <div class="col-oferta">
            <img src="IMGS/5descuento.jfif" class="img-oferta">
            <h2 class="h2-oferta">Descuento del 5%</h2>
            <p class="p-oferta">Llévate un 5% de descuento por compartir una foto de tu pez con su chubasquero en las redes sociales y etiquetarnos</p>
        </div>
        <div class="col-oferta">
            <img src="IMGS/10descuento.jfif" class="img-oferta">
            <h2 class="h2-oferta">Descuento del 10%</h2>
            <p class="p-oferta">Llévate un 10% de descuento por comprar dos o más chubasqueros de diferentes colores o modelos</p>
        </div>
        </div>
        <!-- SEGUNDA FILA -->
        <div class="row-oferta">
        <div class="col-oferta">
            <img src="IMGS/15descuento.jfif" class="img-oferta">
            <h2 class="h2-oferta">Descuento del 15%</h2>
            <p class="p-oferta">Llévate un 15% de descuento por comprar cinco o más chubasqueros de diferentes colores o modelos</p>
        </div>
        <div class="col-oferta">
            <img src="IMGS/20descuento.jfif" class="img-oferta">
            <h2 class="h2-oferta">Descuento del 20%</h2>
            <p class="p-oferta">Llévate un 20% de descuento si recomiendas nuestra tienda a un amigo y hace una compra superior a 50€</p>
        </div>
        <div class="col-oferta">
            <img src="IMGS/especial.jfif" class="img-oferta">
            <h2 class="h2-oferta">Oferta especial</h2>
            <p class="p-oferta">El primer día de cada mes, los chubasqueros a mitad de precio</p>
        </div>
        </div>
        <!-- TERCERA FILA -->
        <div class="row-oferta">
        <div class="col-oferta">
            <img src="IMGS/tarjetaregalo.jfif" class="img-oferta">
            <h2 class="h2-oferta">Oferta tarjeta regalo</h2>
            <p class="p-oferta">Compra una tarjeta regalo en la segunda semana del mes y llévate un regalo</p>
        </div>
        <div class="col-oferta">
            <img src="IMGS/epocalluvia.jfif" class="img-oferta">
            <h2 class="h2-oferta">Oferta época de lluvia</h2>
            <p class="p-oferta">Compra un chubasquero para tu pez en época de lluvia y te costará la mitad que el resto del año</p>
        </div>
        <div class="col-oferta">
        </div>
        </div>
    </div>
</asp:Content>
