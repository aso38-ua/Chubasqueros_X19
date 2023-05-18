<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Servicio.aspx.cs" Inherits="Interfaz.Servicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <link href="css/Servicio.css" rel="stylesheet" />

    <h1 class="h1-servicio">Nuestros servicios</h1>
    
    <div class="container">
        <div>
            <h1> Aquí aparecería todo dinámicamente</h1>
            <br />
            <br />
            <asp:Label ID="labelInfo" runat="server" Text=""></asp:Label>
        </div>
    </div>

</asp:Content>

