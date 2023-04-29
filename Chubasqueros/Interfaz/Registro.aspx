<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Interfaz.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <br /><br /><br /><br />
    <asp:Label ID="Label1" runat="server" Text="Nombre de usuario"></asp:Label>
    <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
    <br /><br />
    <asp:Label ID="Label4" runat="server" Text="Email"></asp:Label>
    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
    <br /><br />
    <asp:Label ID="Label2" runat="server" Text="Contraseña"></asp:Label>
    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
    <br /><br />
    <asp:Label ID="Label3" runat="server" Text="Confirme contraseña"></asp:Label>
    <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
    <br /><br />
    <asp:Button ID="btnRegister" runat="server" Text="Registrarse" OnClick="btnRegister_Click" />
</asp:Content>
