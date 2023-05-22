<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Interfaz.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">

    <div class="container">
        <div class="form-group">

        <style>
            input[type="text"] {
                color: #ffa31a;
            }
        </style>

        <asp:Label ID="username" runat="server" Text="Nombre de usuario o email" CssClass="neon-label" ></asp:Label>
        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUsername" ErrorMessage="Por favor, introduzca un nombre de usuario o correo." ValidationGroup="vgRegister"></asp:RequiredFieldValidator>
        

         <asp:Label ID="Label2" runat="server" Text="Contraseña" CssClass="neon-label"></asp:Label>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPassword" ErrorMessage="Por favor, introduzca una contraseña." ValidationGroup="vgRegister"></asp:RequiredFieldValidator>
        <br />

            <asp:Label ID="message" runat="server"></asp:Label>
            <br />

            <asp:Button ID="btnRegister" runat="server" Text="Entrar" OnClick="btnLogin_Click" CssClass="neon-btn" /><br /><br />
        <asp:Button ID="Button1" runat="server" Text="¿Aún no estás registrado?" PostBackUrl="~/Registro.aspx" CssClass="neon-btn" />

            </div>
        </div>
</asp:Content>
