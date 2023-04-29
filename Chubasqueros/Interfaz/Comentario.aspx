<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Comentario.aspx.cs" Inherits="Interfaz.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <h2> Comentarios</h2>

    <asp:Button ID="BtnPuntuar" runat="server" Text="Puntuar" onClick="PuntuarClick" BackColor= "#00ffff"/>
    <asp:Button ID="Estrella1" runat="server" Text="Estrella1" onClick="Estrella1Click" BackColor="Yellow"/>
    <asp:Button ID="Estrella2" runat="server" Text="Estrella2" onClick="Estrella2Click" BackColor="Yellow"/>
    <asp:Button ID="Estrella3" runat="server" Text="Estrella3" onClick="Estrella3Click" BackColor="Yellow"/>
    <asp:Button ID="Estrella4" runat="server" Text="Estrella4" onClick="Estrella4Click" BackColor="Yellow"/>
    <asp:Button ID="Estrella5" runat="server" Text="Estrella5" onClick="Estrella5Click" BackColor="Yellow"/>
    <br />
    <asp:Button ID="BtnComentar" runat="server" Text="Comentar" onClick="ComentarClick"/>
    <br />
    Comentario:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TBComentario" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="Like" runat="server" Text="Like" onClick="LikeClick" BackColor= "#00ff00"/>
    <asp:Button ID="Dislike" runat="server" Text="Dislike" onClick="DislikeClick" BackColor= "#ff0000"/>
    <br />
    <asp:Button ID="BtnRespuesta" runat="server" Text="Responder" onClick="RespuestaClick"/>
    <br />
    Responder:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
</asp:Content>
