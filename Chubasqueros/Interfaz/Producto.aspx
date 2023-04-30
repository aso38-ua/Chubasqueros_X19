<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Producto.aspx.cs" Inherits="Interfaz.Producto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">

    <div>
        <h1> Producto </h1>
        <p>
            codigo: &nbsp;<asp:TextBox ID="text_codigo" runat="server" Height="15px" style="color:deeppink; margin-top: 10px; margin-left: 15px;" Width="200px"></asp:TextBox>
        </p>
        <p>
            nombre: &nbsp;<asp:TextBox ID="Text_nombre" runat="server" Height="15px" style="color:deeppink; margin-top: 10px; margin-left: 15px;" Width="200px"></asp:TextBox>
        </p>
        <p>
            descripcion: &nbsp;<asp:TextBox ID="Text_descripcion" runat="server" Height="15px" style="color:deeppink; margin-top: 10px; margin-left: 15px;" Width="200px"></asp:TextBox>
        </p>
        <p>
            stock: &nbsp;<asp:TextBox ID="text_stock" runat="server" Height="15px" style="color:deeppink; margin-top: 10px; margin-left: 15px;" Width="200px"></asp:TextBox>
        </p>
        <p>
            precio: &nbsp;<asp:TextBox ID="Text_precio" runat="server" Height="15px" style="color:deeppink; margin-top: 10px; margin-left: 15px;" Width="200px"></asp:TextBox>
        </p>
    </div>
  
    <asp:Label ID="outputMsg" runat="server"></asp:Label><br />
    

    <asp:Button text="Leer producto" onClick="onLeer" ID="buttom_Leer" runat="server"  />
    <asp:Button text="Crear producto" onClick="onCrear" ID="buttom_Crear" runat="server" />
    <asp:Button text="Actualizar producto" onClick="onActualizar" ID="buttom_Actualizar" runat="server" />
    <asp:Button text="Borrar producto" onClick="onBorrar" ID="buttom_Borrar" runat="server" />

</asp:Content>
