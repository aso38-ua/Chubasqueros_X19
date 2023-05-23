<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Comentario.aspx.cs" Inherits="Interfaz.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <br />
    <asp:Button ID="BtnRegresar" runat="server" Text="Regresar a producto" onClick="RegresarClick" BackColor="#33cc33" BorderColor="Green" BorderStyle="Groove"/>
    <br />
    <h2>Producto</h2>
    ID: 
    <asp:TextBox ID="TBBuscar" runat="server" Height="50px" Width="250px"></asp:TextBox>
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
    <asp:Button ID="BtnBuscar" runat="server" Text="Buscar" onClick="BuscarClick" BackColor="#ff33cc" BorderColor="Pink" BorderStyle="Groove"/>
    <br />
    <asp:Label ID="Label9" runat="server" />
    <h2> Puntuación</h2>

    <asp:Button ID="Estrella1" runat="server" Text="☆" onClick="Estrella1Click" BackColor="#ff0000" BorderColor="#FFCC00"/>
    <br />
    <asp:Button ID="Estrella2" runat="server" Text="☆☆" onClick="Estrella2Click" BackColor="#ff6600" BorderColor="#FFCC00"/>
    <br />
    <asp:Button ID="Estrella3" runat="server" Text="☆☆☆" onClick="Estrella3Click" BackColor="#ff9933" BorderColor="#FFCC00"/>
    <br />
    <asp:Button ID="Estrella4" runat="server" Text="☆☆☆☆" onClick="Estrella4Click" BackColor="#ffcc00" BorderColor="#FFCC00"/>
    <br />
    <asp:Button ID="Estrella5" runat="server" Text="☆☆☆☆☆" onClick="Estrella5Click" BackColor="Yellow" BorderColor="#FFCC00" BorderStyle="NotSet"/>
    <br />
    <asp:Label ID="Label3" runat="server" />
    <asp:Button ID="BtnPuntuar" runat="server" Text="☆Puntuar☆" onClick="PuntuarClick" BackColor= "#0099ff" BorderStyle="Groove" BorderColor="#9966ff"/>
    <asp:Label ID="Label7" runat="server" />
    <br />
    <asp:Button ID="eliminarP" runat="server" Text="Eliminar Puntuación" onClick="EliminarPClick" BackColor="#ff3300" BorderColor="Red" BorderStyle="Groove" Height="36px" Width="279px"/>
    <br />
    <h3>Puntuación media:</h3>
    <asp:Label ID="Label6" runat="server" />
    <br />
    <h2>Comentarios</h2>
    <br />
        <asp:TextBox ID="Comentarios" runat="server" Height="150px" Width="550px"></asp:TextBox>
    <br />
    <asp:Label ID="Label10" runat="server" />
    <asp:Button ID="Button1" runat="server" Text="Like" onClick="LikeMostrar" BackColor= "#00ff00"/>
    <asp:Label ID="Label11" runat="server" />
    <asp:Button ID="Button2" runat="server" Text="Dislike" onClick="DisLikeMostrar" BackColor= "#ff0000"/>
    <br />
    <asp:Button ID="BtnLeerPrimero" runat="server" Text="Leer Primero" onClick="PrimeroClick"/>
    <asp:Button ID="BtnLeerAnterior" runat="server" Text="Leer Anterior" onClick="AnteriorClick"/>
    <asp:Button ID="BtnLeerSiguiente" runat="server" Text="Leer Siguiente" onClick="SiguienteClick"/>
    <br />
    <asp:Label ID="Label12" runat="server" />
    <br />
    Comentario:&nbsp;&nbsp;&nbsp;
    <br />
        <asp:TextBox ID="TBComentario" runat="server" Height="150px" Width="550px"></asp:TextBox>
    <br />
    <asp:Label ID="Label1" runat="server" />
    <asp:Button ID="BtnComentar" runat="server" Text="Comentar" onClick="ComentarClick" BackColor="#0099FF" BorderColor="Blue" BorderStyle="Groove"/>
    <br />
    <asp:Label ID="Label2" runat="server" />
    <asp:Button ID="BtnEliminar" runat="server" Text="Eliminar" onClick="EliminarClick" BackColor="#ff3300" BorderColor="Red" BorderStyle="Groove"/>
    <br />
    <asp:Label ID="Label4" runat="server" />
    <asp:Button ID="Like" runat="server" Text="Like" onClick="LikeClick" BackColor= "#00ff00"/>
    <asp:Label ID="Label5" runat="server" />
    <asp:Button ID="Dislike" runat="server" Text="Dislike" onClick="DislikeClick" BackColor= "#ff0000"/>
    <br />
    <br />
    <br />
    <asp:TextBox ID="TBModificar" runat="server" Height="150px" Width="550px"></asp:TextBox>
    <br />
    <asp:Label ID="Label8" runat="server" />
    <asp:Button ID="BtnModificar" runat="server" Text="Modificar" onClick="ModificarClick" BackColor="#ff9933" BorderColor="Red" BorderStyle="Groove"/>
    <br />
    <body-style = "backgroud-color:rgb(208, 171, 255)"></body-style>
</asp:Content>
