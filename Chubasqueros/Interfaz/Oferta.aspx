<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Oferta.aspx.cs" Inherits="Interfaz.Oferta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        /* Contenedor */
        .oferta-container {
            display: flex;
            flex-direction: column;
            align-items: center;
            text-align: center;
        }

        /* Imagen */
        .oferta-imagen-img {
            margin-bottom: 20px; 
            width: 500px;
            height: auto;
        }

        /* Descripción */
        .p-oferta {
            font-size: 25px;
            margin: 0;
            margin-bottom: 130px;
        }

        /* Título de la página */
        h2 {
            color: #FF86FF;
            text-align: center;
            font-size: 50px;
            text-shadow: 0 0 10px #B25FB0, 0 0 20px #FF86FF, 0 0 30px #B25FB0, 0 0 40px #FF86FF;
            animation: neon 1.5s ease-in-out infinite alternate;
            font-weight: bold;
        }

    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">

    <h2>Descuentos y ofertas</h2>

    <!-- Muestra dinámicamente lo que devuelve loadAllOffers en formato de HTML -->
    <div class="container-oferta">
        <div>
            <br />
            <br />
            <asp:Label ID="labelInfo" runat="server" Text=""></asp:Label>
        </div>
    </div>
</asp:Content>
