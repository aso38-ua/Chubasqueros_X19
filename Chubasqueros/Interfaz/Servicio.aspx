<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Servicio.aspx.cs" Inherits="Interfaz.Servicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <link href="css/Servicio.css" rel="stylesheet" />

    <h1 class="h1-servicio">Nuestros servicios</h1>
    <div class="container-servicio">
      <!-- PRIMERA FILA -->
      <div class="row-servicio">
        <div class="col-servicio">
          <asp:Image ID="imgServicio1" runat="server" CssClass="img-servicio" />
        </div>
        <div class="col-servicio">     
          <h2 class="h2-servicio"><asp:Label ID="lblTitulo1" runat="server" CssClass="h2-servicio"></asp:Label></h2>
          <p class="p-servicio"><asp:Label ID="lblDescripcion1" runat="server" CssClass="p-servicio"></asp:Label></p>
        </div>
      </div>
      <!-- SEGUNDA FILA -->
      <div class="row-servicio">
        <div class="col-servicio">
          <asp:Image ID="imgServicio2" runat="server" CssClass="img-servicio" />
        </div>
        <div class="col-servicio">
          <h2 class="h2-servicio"><asp:Label ID="lblTitulo2" runat="server" CssClass="h2-servicio"></asp:Label></h2>
          <p class="p-servicio"><asp:Label ID="lblDescripcion2" runat="server" CssClass="p-servicio"></asp:Label></p>
        </div>
      </div>
      <!-- TERCERA FILA -->
      <div class="row-servicio">
        <div class="col-servicio">
          <asp:Image ID="imgServicio3" runat="server" CssClass="img-servicio" />
        </div>
        <div class="col-servicio">
          <h2 class="h2-servicio"><asp:Label ID="lblTitulo3" runat="server" CssClass="h2-servicio"></asp:Label></h2>
          <p class="p-servicio"><asp:Label ID="lblDescripcion3" runat="server" CssClass="p-servicio"></asp:Label></p>
        </div>
      </div>
      <!-- CUARTA FILA -->
      <div class="row-servicio">
        <div class="col-servicio">
          <asp:Image ID="imgServicio4" runat="server" CssClass="img-servicio" />
        </div>
        <div class="col-servicio">
          <h2 class="h2-servicio"><asp:Label ID="lblTitulo4" runat="server" CssClass="h2-servicio"></asp:Label></h2>
          <p class="p-servicio"><asp:Label ID="lblDescripcion4" runat="server" CssClass="p-servicio"></asp:Label></p>
        </div>
      </div>
      <!-- QUINTA FILA -->
      <div class="row-servicio">
        <div class="col-servicio">
          <asp:Image ID="imgServicio5" runat="server" CssClass="img-servicio" />
        </div>
        <div class="col-servicio">
          <h2 class="h2-servicio"><asp:Label ID="lblTitulo5" runat="server" CssClass="h2-servicio"></asp:Label></h2>
          <p class="p-servicio"><asp:Label ID="lblDescripcion5" runat="server" CssClass="p-servicio"></asp:Label></p>
        </div>
      </div>
      <!-- SEXTA FILA -->
      <div class="row-servicio">
        <div class="col-servicio">
          <asp:Image ID="imgServicio6" runat="server" CssClass="img-servicio" />
        </div>
        <div class="col-servicio">
          <h2 class="h2-servicio"><asp:Label ID="lblTitulo6" runat="server" CssClass="h2-servicio"></asp:Label></h2>
          <p class="p-servicio"><asp:Label ID="lblDescripcion6" runat="server" CssClass="p-servicio"></asp:Label></p>
        </div>
      </div>
    </div>
</asp:Content>
