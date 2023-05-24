<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Donaciones.aspx.cs" Inherits="Interfaz.Donaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <link rel="stylesheet" href="CSS/Donaciones.css">

    <h2>Donaciones</h2>
    <center>
        <div class="etiqueta">
            <asp:Label ID="MostrarMsg" runat="server"></asp:Label><br />
        </div>
        <p class="etiqueta">Nº Tarjeta:<asp:TextBox ID="tarjeta" runat="server" Height="24px" Width="274px" /></p>
        <label class="etiqueta" for="caducidad">Caducidad:</label>
        <input type="month" min="2023-05" />
        <p class="etiqueta">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; CVV: <asp:TextBox ID="seguridad" runat="server" Height="24px" Width="274px" /></p>
        <p class="etiqueta">Cantidad: <asp:TextBox ID="cantidad" runat="server" Height="24px" Width="274px" /></p>
        <br />
        <asp:Button class="boton" id="donar" onclick="ComprobarDonar" runat="server" Text="Donar" Height="64px" Width="232px"></asp:Button>
     </center>

</asp:Content>
