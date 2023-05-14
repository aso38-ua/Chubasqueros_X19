<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="InterfazCarrito.aspx.cs" Inherits="Interfaz.InterfazCarrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <h1 style="color: blue"><u>Carrito de la compra</u></h1>
    <asp:Label ID ="Message" runat ="server"></asp:Label>
     <asp:Panel id ="CajaProducto" BackColor="LightYellow" runat="server">
     <asp:Image ID="miImagen" runat="server" Height="27px" Width="27px" />
     Nombre del producto
     <p> 
         Precio: [precio]
     </p>
 
     <p>
           Cantidad: <asp:TextBox ID ="boxcantidad" TextMode ="SingleLine" Columns ="1" runat="server"></asp:TextBox>
     </p>
    </asp:Panel>
     <p>
         Precio total: [preciototal]
     </p>
     <asp:Button ID ="botoncompra"  BackColor="LightBlue"  Text="Comprar" runat ="server" onCLick="btn_compra"/>
     <p>
     <asp:Button ID ="botoneliminar" BackColor="LightCoral" Text ="Eliminar del carrito" runat ="server" style="margin-bottom: 0px" onClick="btn_eliminar"/></p>
</asp:Content>
