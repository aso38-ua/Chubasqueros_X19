<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Servicio.aspx.cs" Inherits="Interfaz.Servicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater ID="rptServicios" runat="server">
        <ItemTemplate>
            <div class="row-servicio">
                <div class="col-servicio">
                    <asp:Image ID="imgServicio" runat="server" CssClass="img-servicio" ImageUrl='<%# Eval("img") %>' />
                </div>
                <div class="col-servicio">
                    <h2 class="h2-servicio"><%# Eval("titulo") %></h2>
                    <p class="p-servicio"><%# Eval("descripcion") %></p>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <link href="css/Servicio.css" rel="stylesheet" />

    <h1 class="h1-servicio">Nuestros servicios</h1>
    <div class="container-servicio">
    </div>
</asp:Content>

