<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="InterfazCarrito.aspx.cs" Inherits="Interfaz.InterfazCarrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <link href ="css/EstiloCarrito.css" rel ="stylesheet" />

    <h1 class = "h1-carrito"><u>Carrito de la compra</u></h1>
    <asp:Label ID ="Message" runat ="server"></asp:Label>
     <asp:Panel  BackColor="LightYellow" runat="server" Height="121px">
        <asp:Image ID="miImagen" runat="server"  Cssclass="imagen-prod" Height="27px" Width="27px"/>
        <asp:Label ID="producto" runat="server" Text="Nombre del producto" CssClass="nprod" ></asp:Label>
        <asp:Label ID="precio" runat="server" Text="Precio: " CssClass="prec" ></asp:Label>
        <asp:Label ID="cantidad" runat="server" Text="Cantidad: "  Columns ="1"  CssClass="cant"></asp:Label>
        <asp:TextBox ID ="boxcantidad" TextMode ="SingleLine" CssClass="box" runat="server" Width="25px"></asp:TextBox>
    </asp:Panel>
     <p class="preciot">
         Precio total: [preciototal]
     </p>
     <asp:Button ID ="botoncompra"  BackColor="LightBlue"  Text="Comprar" runat ="server" onCLick="btn_compra"/>
     <p>
     <asp:Button ID ="botoneliminar" BackColor="LightCoral" Text ="Eliminar del carrito" runat ="server" style="margin-bottom: 0px" onClick="btn_eliminar"/></p>
</asp:Content>
