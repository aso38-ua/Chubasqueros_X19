<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="InterfazPedido.aspx.cs" Inherits="Interfaz.InterfazPedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <h1 style="color: blue"><u>Pedido</u></h1>
    <asp:Label ID="Message" runat ="server"></asp:Label>
    <asp:Panel id ="CajaProducto" BackColor="LightYellow" runat="server">
     <asp:Image ID="miImagen" runat="server" Height="27px" Width="27px" />
     Nombre del producto
     <p> 
         Precio: [precio]
     </p>
 
        <p>
            Cantidad: [cantidad]
        </p>
    </asp:Panel>


    <asp:Panel id ="CajaUsuario" BackColor="LightBlue" runat="server">
        <p>
            Nombre del comprador: [usuario]
        </p>
        <p>
            Email: [email]
        </p>

        <p>
             Fecha de llegada aproximada: [dia]/[mes]/[año]
        </p>
    </asp:Panel>
   

     <p>
         Precio total: [preciototal]
     </p>
     <asp:Button ID ="botoncompra" BackColor="LightBlue" Text ="Pagar" runat ="server" onClick="btn_pagar"/>
    <p>
      <asp:Button ID ="botoncancelar" BackColor="LightCoral" Text="Cancelar Pedido" runat="server" onClick="btn_cancelar"/>
    </p>
</asp:Content>
