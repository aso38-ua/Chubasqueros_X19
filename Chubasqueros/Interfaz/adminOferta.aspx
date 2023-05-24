<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminOferta.aspx.cs" Inherits="Interfaz.adminOferta" %>
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
    <h2 style="margin-top: -50px; margin-bottom: 100px">Añadir oferta</h2>
    <div class="container">
        <div class="form-group">
            <!-- Campo de ID de oferta -->
            <asp:Label ID="lblIdOferta" runat="server" Text="ID de oferta" CssClass="neon-label form-control" style="margin-top: 150px;"></asp:Label>
            <asp:TextBox ID="txtIdOferta" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvIdOferta" runat="server" ControlToValidate="txtIdOferta" ErrorMessage="El ID de oferta es obligatorio"/>
            <asp:RegularExpressionValidator ID="revIdOferta" runat="server" ControlToValidate="txtIdOferta" ErrorMessage="El ID de oferta debe ser numérico" ValidationExpression="^\d+$" />

            <!-- Campo de porcentaje de descuento de la oferta -->
            <asp:Label ID="lblTitle" runat="server" Text="Porcentaje de descuento de la oferta" CssClass="neon-label form-control"></asp:Label>
            <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RangeValidator ID="rvTitle" runat="server" ControlToValidate="txtTitle" ErrorMessage="El porcentaje de descuento debe estar entre 0 y 100" MinimumValue="0" MaximumValue="100" Type="Integer" CssClass="error-message" />

            <!-- Campo de descripción de la oferta -->
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
                <asp:Button ID="btnAddOffer" runat="server" Text="Añadir oferta" OnClick="btnAddOffer_Click" CssClass="neon-btn" />
                <asp:Button ID="btnEditOffer" runat="server" Text="Modificar oferta" OnClick="btnEditOffer_Click" CssClass="neon-btn" />
                <asp:Button ID="btnDeleteOffer" runat="server" Text="Eliminar oferta" OnClick="btnDeleteOffer_Click" CssClass="neon-btn" />
            </div>

            <!-- Mostrar mensajes -->
            <asp:Label ID="mensaje" runat="server" CssClass="neon-label form-control" style="margin-bottom: 200px; margin-top: 10px;"></asp:Label>
        </div>
    </div>
</asp:Content>
