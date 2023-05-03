<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Oferta.aspx.cs" Inherits="Interfaz.Oferta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <link href="css/Oferta.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">

    <h1>Descuentos y ofertas</h1>
    <div class="container">
        <!-- PRIMERA FILA -->
        <div class="row">
        <div class="col">
            <img src="../img/bienvenida.jfif">
            <h2>Descuento nuevo cliente</h2>
            <p>Por la compra de un chubasquero, llévate otro chubasquero gratis</p>
        </div>
        <div class="col">
            <img src="../img/5descuento.jfif">
            <h2>Descuento del 5%</h2>
            <p>Llévate un 5% de descuento por compartir una foto de tu pez con su chubasquero en las redes sociales y etiquetarnos</p>
        </div>
        <div class="col">
            <img src="../img/10descuento.jfif">
            <h2>Descuento del 10%</h2>
            <p>Llévate un 10% de descuento por comprar dos o más chubasqueros de diferentes colores o modelos</p>
        </div>
        </div>
        <!-- SEGUNDA FILA -->
        <div class="row">
        <div class="col">
            <img src="../img/15descuento.jfif">
            <h2>Descuento del 15%</h2>
            <p>Llévate un 15% de descuento por comprar cinco o más chubasqueros de diferentes colores o modelos</p>
        </div>
        <div class="col">
            <img src="../img/20descuento.jfif">
            <h2>Descuento del 20%</h2>
            <p>Llévate un 20% de descuento si recomiendas nuestra tienda a un amigo y hace una compra superior a 50€</p>
        </div>
        <div class="col">
            <img src="../img/especial.jfif">
            <h2>Oferta especial</h2>
            <p>El primer día de cada mes, los chubasqueros a mitad de precio</p>
        </div>
        </div>
        <!-- TERCERA FILA -->
        <div class="row">
        <div class="col">
            <img src="../img/tarjetaregalo.jfif">
            <h2>Oferta tarjeta regalo</h2>
            <p>Compra una tarjeta regalo en la segunda semana del mes y llévate un regalo</p>
        </div>
        <div class="col">
            <img src="../img/epocalluvia.jfif">
            <h2>Oferta época de lluvia</h2>
            <p>Compra un chubasquero para tu pez en época de lluvia y te costará la mitad que el resto del año</p>
        </div>
        <div class="col">
        </div>
        </div>
    </div>
</asp:Content>
