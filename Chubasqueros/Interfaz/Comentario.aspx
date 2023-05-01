<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Comentario.aspx.cs" Inherits="Interfaz.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <h2>Producto</h2>
    Nombre: 
    <br />
    Imagen:
    <h2> Comentarios</h2>

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
    <asp:Button ID="BtnPuntuar" runat="server" Text="☆Puntuar☆" onClick="PuntuarClick" BackColor= "#0099ff" BorderStyle="Groove" BorderColor="#9966ff"/>
    <br />
    Comentario:&nbsp;&nbsp;&nbsp;
    <br />
        <asp:TextBox ID="TBComentario" runat="server" Height="150px" Width="550px"></asp:TextBox>
     <br />
    <asp:Button ID="BtnComentar" runat="server" Text="Comentar" onClick="ComentarClick" BackColor="#0099FF" BorderColor="Blue" BorderStyle="Groove"/>
    <br />
    <asp:Button ID="Like" runat="server" Text="Like" onClick="LikeClick" BackColor= "#00ff00"/>
    <asp:Button ID="Dislike" runat="server" Text="Dislike" onClick="DislikeClick" BackColor= "#ff0000"/>
    <br />
    Responder:&nbsp;&nbsp;&nbsp;
    <br />
        <asp:TextBox ID="TextBox1" runat="server" Height="150px" Width="550px"></asp:TextBox>
    <br />
    <asp:Button ID="BtnRespuesta" runat="server" Text="Responder" onClick="RespuestaClick"/>
    <div>
        .innermainbg{
            backgroud-image: url('https://www.aquariumcostadealmeria.com/wp-content/uploads/2018/02/fondo-rocoso-2.jpg');
        }
    </div>
    <body-style = "backgroud-color:rgb(208, 171, 255)"></body-style>
</asp:Content>
