<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Categoria.aspx.cs" Inherits="Interfaz.Categoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    
    <div>
        <p>
            codCategoria: &nbsp;<asp:TextBox ID="text_codCategoria" runat="server" Height="40px" style="margin-top: 10px; margin-left: 50px;" Width="400px"></asp:TextBox>
        </p>
        <p>
            nombre: &nbsp;<asp:TextBox ID="text_nombre" runat="server" Height="40px" style="margin-top: 10px; margin-left: 50px;" Width="400px"></asp:TextBox>
        </p>
    </div>
  
    <asp:Label ID="outputMsg" runat="server"></asp:Label><br />
    

    <asp:Button text="Leer categoría" onClick="onLeer" ID="buttom_Leer" runat="server"  />
    <asp:Button text="Crear categoría" onClick="onCrear" ID="buttom_Crear" runat="server" />
    <asp:Button text="Actualizar categoría" onClick="onActualizar" ID="buttom_Actualizar" runat="server" />
    <asp:Button text="Borrar categoría" onClick="onBorrar" ID="buttom_Borrar" runat="server" />


</asp:Content>
