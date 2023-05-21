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
        <label for="txtNombre">Nombre:</label>
        <asp:TextBox ID="txtNombre" runat="server" Width="200px"></asp:TextBox>
    </div>

    <div class="form-group">
        <label for="txtApellido">Apellido:</label>
        <asp:TextBox ID="txtApellido" runat="server" Width="200px"></asp:TextBox>
    </div>

    <div class="form-group">
        <label for="txtEmail">Email:</label>
        <asp:TextBox ID="txtEmail" runat="server" Width="200px"></asp:TextBox>
    </div>

    <div class="form-group">
        <label for="txtExperiencia">Experiencia:</label>
        <asp:TextBox ID="txtExperiencia" runat="server" TextMode="MultiLine" Width="200px"></asp:TextBox>
    </div>

            <div class="form-group">
        <label for="txtExperiencia">Teléfono:</label>
        <asp:TextBox ID="txtTelefono" runat="server" TextMode="MultiLine" Width="200px"></asp:TextBox>
    </div>

    <div class="form-group">
        <label for="txtEducacion">Educación:</label>
        <asp:TextBox ID="txtEducacion" runat="server" TextMode="MultiLine" Width="200px"></asp:TextBox>
    </div>

    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
            <asp:Label ID="error" runat="server"></asp:Label>
    
</asp:Content>
