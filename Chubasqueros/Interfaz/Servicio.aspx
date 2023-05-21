<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Servicio.aspx.cs" Inherits="Interfaz.Servicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <link rel="stylesheet" href="/CSS/Servicio.css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <h2>Nuestros servicios</h2>
    <div class="container-servicio">
        <div>
            <br />
            <br />
            <asp:Label ID="labelInfo" runat="server" Text=""></asp:Label>
        </div>
    </div>

</asp:Content>
