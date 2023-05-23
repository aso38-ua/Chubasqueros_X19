<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Colaboracion.aspx.cs" Inherits="Interfaz.Colaboracion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">

<link rel="stylesheet" href="CSS/Colaboracion.css">
<center><h2>Ropa</h2></center>
<br /><br />

<div class="fila">
    <div class="columna">
        <img class="imagen" src="IMGS/adidas.jpeg"/>
        <p class="parrafo1">Chubasquero para peces & Adidas</p>
    </div>
    <div class="columna">
        <img class="imagen" src="IMGS/zara.jpeg"/>
        <p class="parrafo1">Chubasquero para peces & Zara</p>
    </div>  
    <div class="columna">
        <img class="imagen" src="IMGS/mayka.jpeg" />
        <p class="parrafo1">Chubasquero para peces & Mayka</p>
    </div>
</div>

<br /><br />
<center><h2>Accesorios</h2></center>
<br /><br />

<div class="fila">
    <div class="columna"> 
        <img class="imagen" src="IMGS/sombrero.png"/>
        <p class="parrafo1">Chubasqueros para peces & Brent Black</p>
    </div>
    <div class="columna">
        <img class="imagen" src="IMGS/zyro-image.png"/>
        <p class="parrafo1">Chubasqueros para peces & Pull and Bear</p>
    </div>
</div>
</asp:Content>
