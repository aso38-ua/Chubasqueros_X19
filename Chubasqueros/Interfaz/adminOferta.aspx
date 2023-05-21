<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminOferta.aspx.cs" Inherits="Interfaz.adminOferta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        input[type="text"] {
            color: #ffa31a;
        }
        
        .form-control {
            margin-bottom: 10px;
        }
        
        .button-row {
            display: flex;
            justify-content: center;
            margin-top: 10px;
        }
        
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
            <asp:Label ID="lblIdOferta" runat="server" Text="ID de oferta" CssClass="neon-label form-control" style="margin-top: 150px;"></asp:Label>
            <asp:TextBox ID="txtIdOferta" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvIdOferta" runat="server" ControlToValidate="txtIdOferta" ErrorMessage="El ID de oferta es obligatorio"/>
            <asp:RegularExpressionValidator ID="revIdOferta" runat="server" ControlToValidate="txtIdOferta" ErrorMessage="El ID de oferta debe ser numérico" ValidationExpression="^\d+$" />

            <asp:Label ID="lblTitle" runat="server" Text="Porcentaje de descuento de la oferta" CssClass="neon-label form-control"></asp:Label>
            <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RangeValidator ID="rvTitle" runat="server" ControlToValidate="txtTitle" ErrorMessage="El porcentaje de descuento debe estar entre 0 y 100" MinimumValue="0" MaximumValue="100" Type="Integer" Text="*" CssClass="error-message" />

            <asp:Label ID="lblDescription" runat="server" Text="Descripción de la oferta" CssClass="neon-label form-control"></asp:Label>
            <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvDescription" runat="server" ControlToValidate="txtDescription" ErrorMessage="La descripción de la oferta es obligatoria" />

            <asp:Label ID="lblImage" runat="server" Text="Ruta de la imagen" CssClass="neon-label form-control"></asp:Label>
            <asp:TextBox ID="txtImage" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvImage" runat="server" ControlToValidate="txtImage" ErrorMessage="La ruta de la imagen es obligatoria" />
            <asp:RegularExpressionValidator ID="revImage" runat="server" ControlToValidate="txtImage" ErrorMessage="Ruta de imagen inválida" ValidationExpression="^\/.*$" />
            <br />

            <div class="button-row">
                <asp:Button ID="btnAddOffer" runat="server" Text="Añadir oferta" OnClick="btnAddOffer_Click" CssClass="neon-btn" />
                <asp:Button ID="btnEditOffer" runat="server" Text="Modificar oferta" OnClick="btnEditOffer_Click" CssClass="neon-btn" />
                <asp:Button ID="btnDeleteOffer" runat="server" Text="Eliminar oferta" OnClick="btnDeleteOffer_Click" CssClass="neon-btn" />
            </div>
             <br />
             <br />
             <br />
             <br />
            <asp:Label ID="mensaje" runat="server" CssClass="neon-label form-control"></asp:Label>
        </div>
    </div>
</asp:Content>
