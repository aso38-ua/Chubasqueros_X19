<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Producto.aspx.cs" Inherits="Interfaz.Producto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">

    <p>Visita nuestras colaboraciones con las mejores marcas</p>
        <a href="Colaboracion.aspx" style="margin-left:0%;filter: hue-rotate(10deg);">
                    <span></span>
                    <span></span>
                    <span></span>
                    <span></span>
                    Marcas
                </a>

    <div class="container-producto">
        <div>
            <div class='producto-imagen'>
                <br />
                <br />
                <asp:Label ID="labelInfo" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </div>

    <div>
        <h2> Productos </h2>
        <asp:Label ID="Mensaje" runat="server"></asp:Label><br/>
        
         <p>
            codigo: &nbsp;<asp:TextBox ID="text_codigo" runat="server" Height="28px" style="color:deeppink; margin-top: 10px; margin-left: 15px;" Width="287px"></asp:TextBox>
        </p>
        <p>
            nombre: &nbsp;<asp:TextBox ID="text_nombre" runat="server" Height="33px" style="color:deeppink; margin-top: 10px; margin-left: 15px;" Width="277px"></asp:TextBox>
        </p>
        <p>
            descripcion: &nbsp;<asp:TextBox ID="text_descripcion" runat="server" Height="57px" style="color:deeppink; margin-top: 10px; margin-left: 15px;" Width="892px"></asp:TextBox>
        </p>
        <p>
            stock: &nbsp;<asp:TextBox ID="text_stock" runat="server" Height="37px" style="color:deeppink; margin-top: 10px; margin-left: 15px;" Width="245px"></asp:TextBox>
        </p>
        <p>
            precio: &nbsp;<asp:TextBox ID="text_precio" runat="server" Height="44px" style="color:deeppink; margin-top: 10px; margin-left: 15px;" Width="265px"></asp:TextBox>
        </p>
         <p>
            codigoCategoria: &nbsp;<asp:TextBox ID="text_codigoCategoria" runat="server" Height="46px" style="color:deeppink; margin-top: 10px; margin-left: 15px;" Width="272px"></asp:TextBox>
        </p>
    </div>
  
    <asp:Label ID="outputMsg" runat="server"></asp:Label><br />
    

    <asp:Button text="Ver/Leer producto" onClick="onLeer" ID="buttom_Leer" runat="server" Width="137px" style="color:red" />
    <asp:Button text="Crear producto" onClick="onCrear" ID="buttom_Crear" runat="server" style="color:red" Width="143px" /><br /><br />
    <asp:Button text="Filtrar por categoría" onClick="onCategoria" ID="buttom_Categoria" runat="server" Width="157px" style="color:red" />
    <asp:Button text="Actualizar producto" onClick="onActualizar" ID="buttom_Actualizar" runat="server" Width="148px" style="color:red" /><br /><br />
    <asp:Button text="Comprar producto" onClick="onComprar" ID="buttom_Comprar" runat="server" Width="148px" style="color:red" />
    <asp:Button text="Borrar producto" onClick="onBorrar" ID="buttom_Borrar" runat="server" Width="147px" style="color:red" /><br /><br />
    <asp:Button text="Añadir al carrito" onClick="onCarrito" ID="buttom_Carrito" runat="server" Width="136px" style="color:red" /><br /><br />
    <asp:Button text="Añadir a favoritos" onClick="onFavoritos" ID="buttom_Favoritos" runat="server" Width="139px" style="color:red" /><br /><br />
    <asp:Button text="Puntuar producto" onClick="onPuntuar" ID="buttom_Puntuar" runat="server" Width="136px" style="color:red" /><br /><br />
    <asp:Button text="Reservar producto" onClick="onReservar" ID="buttom_Reservar" runat="server" Width="144px" style="color:red" /><br /><br />
    
    

</asp:Content>
