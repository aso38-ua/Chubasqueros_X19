<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Producto.aspx.cs" Inherits="Interfaz.Producto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <div>
        <h2> Productos </h2>
        <p>
            codigo: &nbsp;<asp:TextBox ID="text_codigo" runat="server" Height="25px" style="color:deeppink; margin-top: 10px; margin-left: 15px;" Width="200px"></asp:TextBox>
        </p>
        <p>
            nombre: &nbsp;<asp:TextBox ID="text_nombre" runat="server" Height="25px" style="color:deeppink; margin-top: 10px; margin-left: 15px;" Width="200px"></asp:TextBox>
        </p>
        <p>
            descripcion: &nbsp;<asp:TextBox ID="text_descripcion" runat="server" Height="25px" style="color:deeppink; margin-top: 10px; margin-left: 15px;" Width="200px"></asp:TextBox>
        </p>
        <p>
            stock: &nbsp;<asp:TextBox ID="text_stock" runat="server" Height="25px" style="color:deeppink; margin-top: 10px; margin-left: 15px;" Width="200px"></asp:TextBox>
        </p>
        <p>
            precio: &nbsp;<asp:TextBox ID="text_precio" runat="server" Height="25px" style="color:deeppink; margin-top: 10px; margin-left: 15px;" Width="200px"></asp:TextBox>
        </p>
         <p>
            codigoCategoria: &nbsp;<asp:TextBox ID="text_codigoCategoria" runat="server" Height="25px" style="color:deeppink; margin-top: 10px; margin-left: 15px;" Width="200px"></asp:TextBox>
        </p>
    </div>
  
    <asp:Label ID="outputMsg" runat="server"></asp:Label><br />
    

    <asp:Button text="Ver/Leer producto" onClick="onLeer" ID="buttom_Leer" runat="server" Width="127px" />
    <asp:Button text="Filtrar por categoría" onClick="onCategoria" ID="buttom_Categoria" runat="server" Width="135px" />
    <asp:Button text="Comprar producto" onClick="onComprar" ID="buttom_Comprar" runat="server" Width="123px" />
    <asp:Button text="Añadir al carrito" onClick="onCarrito" ID="buttom_Carrito" runat="server" Width="114px" />
    <asp:Button text="Añadir a favoritos" onClick="onFavoritos" ID="buttom_Favoritos" runat="server" Width="116px" />
    <asp:Button text="Puntuar producto" onClick="onPuntuar" ID="buttom_Puntuar" runat="server" Width="124px" />
    <asp:Button text="Reservar producto" onClick="onReservar" ID="buttom_Reservar" runat="server" Width="147px" />
    <asp:Button text="Crear producto" onClick="onCrear" ID="buttom_Crear" runat="server" />
    <asp:Button text="Actualizar producto" onClick="onActualizar" ID="buttom_Actualizar" runat="server" Width="148px" />
    <asp:Button text="Borrar producto" onClick="onBorrar" ID="buttom_Borrar" runat="server" Width="130px" />

</asp:Content>
