<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CV.aspx.cs" Inherits="Interfaz.CV" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/bootstrap.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
        
            <h2 style="margin-top:1px;">Crear CV</h2>

        <div>
            <img src="/IMGS/fregando.jpg" style="width:18%; position: absolute; top: 55%; left: 50%; transform: translate(-50%, -50%);"/>
        </div>
        
            <div class="form-group">
        <label class="neon-label" for="txtNombre">Nombre:</label>
        <asp:TextBox ID="txtNombre" runat="server" Width="200px"></asp:TextBox>
    </div>

    <div class="form-group">
        <label class="neon-label" for="txtApellido">Apellido:</label>
        <asp:TextBox ID="txtApellido" runat="server" Width="200px"></asp:TextBox>
    </div>

    <div class="form-group">
        <label class="neon-label" for="txtEmail">Email:</label>
        <asp:TextBox ID="txtEmail" runat="server" Width="200px"></asp:TextBox>
        <asp:RegularExpressionValidator ID="regexEmail" runat="server"
        ControlToValidate="txtEmail"
        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
        ErrorMessage="Ingrese un correo electrónico válido"
        Display="Dynamic"
        CssClass="error-message">
    </asp:RegularExpressionValidator>
    </div>

    <div class="form-group">
        <label class="neon-label" for="txtExperiencia">Experiencia:</label>
        <asp:TextBox ID="txtExperiencia" runat="server" TextMode="MultiLine" Width="200px"></asp:TextBox>
    </div>

            <div class="form-group">
        <label class="neon-label" for="txtExperiencia">Teléfono:</label>
        <asp:TextBox ID="txtTelefono" runat="server" TextMode="MultiLine" Width="200px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="regexTelefono" runat="server"
                ControlToValidate="txtTelefono"
                ValidationExpression="^\d{9}$"
                ErrorMessage="Ingrese un número de teléfono válido"
                Display="Dynamic"
                CssClass="error-message">
            </asp:RegularExpressionValidator>
    </div>

    <div class="form-group">
        <label class="neon-label" for="txtEducacion">Educación:</label>
        <asp:TextBox ID="txtEducacion" runat="server" TextMode="MultiLine" Width="200px"></asp:TextBox>
    </div>

    <asp:Button ID="btnGuardar" runat="server" Text="Mandar CV" OnClick="btnGuardar_Click" />
            <asp:Label ID="error" runat="server"></asp:Label>
    
</asp:Content>
