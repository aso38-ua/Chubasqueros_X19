<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Interfaz.Registro" %>

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

        <asp:Label ID="username" runat="server" Text="Nombre de usuario" CssClass="neon-label" ></asp:Label>
        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUsername" ErrorMessage="Por favor, introduzca un nombre de usuario." ValidationGroup="vgRegister"></asp:RequiredFieldValidator>
        
            
            
        <asp:Label ID="Label4" runat="server" Text="Email" CssClass="neon-label"></asp:Label>
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>

            <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail"
            ErrorMessage="Ingrese un correo electrónico válido" ValidationExpression="^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"
            Display="Dynamic"></asp:RegularExpressionValidator>

             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmail" ErrorMessage="Por favor, introduzca un email." ValidationGroup="vgRegister"></asp:RequiredFieldValidator>
        
                
                
        <asp:Label ID="Label2" runat="server" Text="Contraseña" CssClass="neon-label"></asp:Label>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPassword" ErrorMessage="Por favor, introduzca una contraseña." ValidationGroup="vgRegister"></asp:RequiredFieldValidator>
                    
                    
        <asp:Label ID="Label3" runat="server" Text="Confirme contraseña" CssClass="neon-label"></asp:Label>
        <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>

            <asp:CompareValidator ID="cvPassword" runat="server" ControlToValidate="txtConfirmPassword" ControlToCompare="txtPassword" ErrorMessage="Las contraseñas no coinciden." ValidationGroup="vgRegister"></asp:CompareValidator>
        <br /><br />
    
        <asp:Button ID="btnRegister" runat="server" Text="Registrarse" OnClick="btnRegister_Click" CssClass="neon-btn" /><br /><br />
        <asp:Button ID="Button1" runat="server" Text="¿Ya estás registrado?" PostBackUrl="~/Login.aspx" CssClass="neon-btn" />
        </div>
    </div>
</asp:Content>
