<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Comentario.aspx.cs" Inherits="Interfaz.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <link rel="stylesheet" href="/CSS/Comentario.css" />
    
    <br />
    <asp:Button ID="BtnRegresar" runat="server" Text="Regresar a producto" onClick="RegresarClick" CssClass="btn neon-btn" />
    <br />
    <h2>Producto</h2>
    <div style="text-align: center;">
        ID:
        <asp:TextBox ID="TBBuscar" runat="server" Height="50px" Width="250px" style="border-radius: 10px;"></asp:TextBox>
        <br />
        <asp:Label ID="Label13" runat="server" />
        <asp:Label ID="Label14" runat="server" />
        <br />
        <asp:Label ID="Label15" runat="server" />
        <asp:Label ID="Label16" runat="server" />
        <br />
        <asp:Label ID="Label17" runat="server" />
        <asp:Label ID="Label18" runat="server" />
        <br />
        <asp:Button ID="BtnBuscar" runat="server" Text="Buscar" onClick="BuscarClick" CssClass="btn neon-btn" />
        <br />
        <asp:Label ID="Label9" runat="server" />
    </div>

    <h2>Puntuación</h2>
    <div style="text-align: center;">
        <asp:Button ID="Estrella1" runat="server" Text="☆" onClick="Estrella1Click" CssClass="btn" />
        <br />
        <asp:Button ID="Estrella2" runat="server" Text="☆☆" onClick="Estrella2Click" CssClass="btn" />
        <br />
        <asp:Button ID="Estrella3" runat="server" Text="☆☆☆" onClick="Estrella3Click" CssClass="btn" />
        <br />
        <asp:Button ID="Estrella4" runat="server" Text="☆☆☆☆" onClick="Estrella4Click" CssClass="btn" />
        <br />
        <asp:Button ID="Estrella5" runat="server" Text="☆☆☆☆☆" onClick="Estrella5Click" CssClass="btn" />
        <br />
        <asp:Label ID="Label3" runat="server" />
        <asp:Button ID="BtnPuntuar" runat="server" Text="☆Puntuar☆" onClick="PuntuarClick" CssClass="btn neon-btn" />
        <br />
        <asp:Label ID="Label7" runat="server" />
        <br />
        <asp:Button ID="eliminarP" runat="server" Text="Eliminar Puntuación" onClick="EliminarPClick" CssClass="btn" />
        <br />
        <h3>Puntuación media:</h3>
        <asp:Label ID="Label6" runat="server" />
        <br />
    </div>

    <h2>Comentarios</h2>
    <div style="text-align: center;">
        <br />
        <asp:TextBox ID="Comentarios" runat="server" Height="150px" Width="550px" style="border-radius: 15px;"></asp:TextBox>
        <br />
        <asp:Label ID="Label10" runat="server" />
        <asp:Button ID="Button1" runat="server" Text="Like" onClick="LikeMostrar" CssClass="btn neon-btn" />
        <asp:Label ID="Label11" runat="server" />
        <asp:Button ID="Button2" runat="server" Text="Dislike" onClick="DisLikeMostrar" CssClass="btn neon-btn" />
        <br />
        <asp:Button ID="BtnLeerPrimero" runat="server" Text="Leer Primero" onClick="PrimeroClick" CssClass="btn neon-btn" />
        <asp:Button ID="BtnLeerAnterior" runat="server" Text="Leer Anterior" onClick="AnteriorClick" CssClass="btn neon-btn" />
        <asp:Button ID="BtnLeerSiguiente" runat="server" Text="Leer Siguiente" onClick="SiguienteClick" CssClass="btn neon-btn" />
        <br />
        <asp:Label ID="Label12" runat="server" />
        <br />
        Comentario:&nbsp;&nbsp;&nbsp;
        <br />
        <asp:TextBox ID="TBComentario" runat="server" Height="150px" Width="550px" style="border-radius: 15px;"></asp:TextBox>
        <br />
        <asp:Button ID="BtnComentar" runat="server" Text="Comentar" onClick="ComentarClick" CssClass="btn neon-btn" />
        <br />
        <asp:Label ID="Label1" runat="server" />
        <br />
        <asp:Button ID="BtnEliminar" runat="server" Text="Eliminar" onClick="EliminarClick" CssClass="btn" />
        <br />
        <asp:Label ID="Label2" runat="server" />
        <br />
        <asp:Label ID="Label4" runat="server" />
        <asp:Button ID="Like" runat="server" Text="Like" onClick="LikeClick" CssClass="btn" />
        <asp:Label ID="Label5" runat="server" />
        <asp:Button ID="Dislike" runat="server" Text="Dislike" onClick="DislikeClick" CssClass="btn" />
        <br />
        <br />
        <br />
        <asp:TextBox ID="TBModificar" runat="server" Height="150px" Width="550px" style="border-radius: 15px;"></asp:TextBox>
        <br />
        <asp:Button ID="BtnModificar" runat="server" Text="Modificar" onClick="ModificarClick" CssClass="btn neon-btn" />
        <br />
        <asp:Label ID="Label8" runat="server" />
        <br />
    </div>
</asp:Content>