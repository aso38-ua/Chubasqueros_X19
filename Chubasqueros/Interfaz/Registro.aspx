<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Interfaz.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">

    <br /><br /><br /><br />
    <div class="container">
        <div class="form-group">

        <style>
            input[type="text"] {
                color: #ffa31a;
            }
        </style>

        <asp:Label ID="username" runat="server" Text="Nombre de usuario" CssClass="neon-label" ></asp:Label>
        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
        <br /><br />
            
            
        <asp:Label ID="Label4" runat="server" Text="Email" CssClass="neon-label"></asp:Label>
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <br /><br />
                
                
        <asp:Label ID="Label2" runat="server" Text="Contraseña" CssClass="neon-label"></asp:Label>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
        <br /><br />
                    
                    
        <asp:Label ID="Label3" runat="server" Text="Confirme contraseña" CssClass="neon-label"></asp:Label>
        <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
        <br /><br />
    
        <asp:Button ID="btnRegister" runat="server" Text="Registrarse" OnClick="btnRegister_Click" CssClass="neon-btn" /><br /><br />
        <asp:Button ID="Button1" runat="server" Text="¿Ya estás registrado?" PostBackUrl="~/Login.aspx" CssClass="neon-btn" />
        </div>
    </div>
</asp:Content>
