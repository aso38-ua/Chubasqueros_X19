<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Oferta.aspx.cs" Inherits="Interfaz.Oferta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .servicio-container {
            display: flex;
            flex-direction: column;
            align-items: center;
            text-align: center;
        }

        .servicio-imagen-img {
            margin-bottom: 20px; 
            width: 500px;
            height: auto;
        }

        .p-servicio {
            font-size: 25px;
            margin: 0;
            margin-bottom: 130px;
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
