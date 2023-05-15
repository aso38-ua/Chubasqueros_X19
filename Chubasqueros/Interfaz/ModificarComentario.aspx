<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ModificarComentario.aspx.cs" Inherits="Interfaz.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
<h2>Producto</h2>
    Nombre: 
    <br />
<h2>Comentario</h2>
    <br />
    <asp:Button ID="BtnRegresar" runat="server" Text="Regresar a comentarios" onClick="RegresarClick" BackColor="#33cc33" BorderColor="Green" BorderStyle="Groove"/>
    <br />
    Comentario:&nbsp;&nbsp;&nbsp;
    <br />
        <asp:TextBox ID="TBComentario" runat="server" Height="150px" Width="550px"></asp:TextBox>
    <br />
<br />
    Modificar:&nbsp;&nbsp;&nbsp;
    <br />
    <asp:TextBox ID="TBModificar" runat="server" Height="150px" Width="550px"></asp:TextBox>
    <br />
    <asp:Label ID="Label1" runat="server" />
    <asp:Button ID="BtnModificar" runat="server" Text="Modificar" onClick="ModificarClick" BackColor="#ff9933" BorderColor="Red" BorderStyle="Groove"/>
    <br />
</asp:Content>
