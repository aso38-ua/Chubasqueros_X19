<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminServicio.aspx.cs" Inherits="Interfaz.adminServicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* Color de texto para inputs de tipo texto */
        input[type="text"] {
            color: black;
        }
        
        /* Márgenes de abajo */
        .form-control {
            margin-bottom: 10px;
        }
        
        /* Para los botones */
        .button-row {
            display: flex;
            justify-content: center;
            margin-top: 10px;
        }
        
        /* Margen horizontal botones */
        .button-row button {
            margin: 0 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <div class="container">
        <div class="form-group">
            <!-- Campo de ID del servicio -->
            <asp:Label ID="lblIdServicio" runat="server" Text="ID de servicio" CssClass="neon-label form-control" style="margin-top: 150px;"></asp:Label>
            <asp:TextBox ID="txtIdServicio" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvIdServicio" runat="server" ControlToValidate="txtIdServicio" ErrorMessage="El ID de servicio es obligatorio"/>
            <asp:RegularExpressionValidator ID="revIdServicio" runat="server" ControlToValidate="txtIdServicio" ErrorMessage="El ID de servicio debe ser numérico" ValidationExpression="^\d+$" />

            <!-- Campo del título del servicio  -->
            <asp:Label ID="lblTitle" runat="server" Text="Título de la oferta" CssClass="neon-label form-control"></asp:Label>
            <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvTitle" runat="server" ControlToValidate="txtTitle" ErrorMessage="El título de la oferta es obligatorio" />

            <!-- Campo de descripción del servicio -->
            <asp:Label ID="lblDescription" runat="server" Text="Descripción de la oferta" CssClass="neon-label form-control"></asp:Label>
            <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvDescription" runat="server" ControlToValidate="txtDescription" ErrorMessage="La descripción de la oferta es obligatoria" />

            <!-- Campo de ruta de la imagen -->
            <asp:Label ID="lblImage" runat="server" Text="Ruta de la imagen" CssClass="neon-label form-control"></asp:Label>
            <asp:TextBox ID="txtImage" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvImage" runat="server" ControlToValidate="txtImage" ErrorMessage="La ruta de la imagen es obligatoria" />
            <asp:RegularExpressionValidator ID="revImage" runat="server" ControlToValidate="txtImage" ErrorMessage="Ruta de imagen inválida" ValidationExpression="^\/.*$" />

            <!-- Botones -->
            <div class="button-row">
                <asp:Button ID="btnAddService" runat="server" Text="Añadir servicio" OnClick="btnAddService_Click" CssClass="neon-btn" />
                <asp:Button ID="btnEditService" runat="server" Text="Modificar servicio" OnClick="btnEditService_Click" CssClass="neon-btn" />
                <asp:Button ID="btnDeleteService" runat="server" Text="Eliminar servicio" OnClick="btnDeleteService_Click" CssClass="neon-btn" />
            </div>
            
            <!-- Mostrar mensajes -->
            <asp:Label ID="mensaje" runat="server" CssClass="neon-label form-control" style="margin-bottom: 200px; margin-top: 10px;"></asp:Label>
        </div>
    </div>
</asp:Content>