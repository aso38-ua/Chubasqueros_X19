<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Oferta.aspx.cs" Inherits="Interfaz.Oferta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .servicio-container {
            display: flex;
            flex-direction: column;
            align-items: center; /* Centra los elementos verticalmente */
            text-align: center; /* Centra el texto horizontalmente */
        }

        .servicio-imagen-img {
            margin-bottom: 20px; /* Ajusta el margen inferior de la imagen según tus necesidades */
            width: 500px;
            height: auto;
        }

        .p-servicio {
            font-size: 25px;
            margin: 0; /* Elimina los márgenes para tener el texto justo debajo de la imagen */
            margin-bottom: 40px;
        }

        h2 {
            color: #ffa31a;
            text-align: center;
            font-size: 50px;
            text-shadow: 0 0 10px #ffa31a, 0 0 20px #ffa31a, 0 0 30px #ffa31a, 0 0 40px #ffa31a;
            animation: neon 1.5s ease-in-out infinite alternate;
        }

    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">

    <h2>Descuentos y ofertas</h2>

    <div class="container-servicio">
        <div>
            <br />
            <br />
            <asp:Label ID="labelInfo" runat="server" Text=""></asp:Label>
        </div>
    </div>
</asp:Content>
