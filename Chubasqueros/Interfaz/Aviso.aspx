<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Aviso.aspx.cs" Inherits="Interfaz.Aviso" %>

<!DOCTYPE html>

<html>
<head>
    <title>Aviso de Alerta</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f2f2f2;
            margin: 0;
            padding: 0;
        }

        .container {
            max-width: 500px;
            margin: 100px auto;
            background-color: #fff;
            border: 1px solid #ccc;
            padding: 20px;
            text-align: center;
        }

        h2 {
            color: #333;
            font-size: 24px;
        }

        p {
            color: #666;
            font-size: 16px;
            margin-bottom: 10px;
        }

        .btn-accept {
            background-color: #4caf50;
            color: #fff;
            border: none;
            padding: 10px 20px;
            font-size: 16px;
            cursor: pointer;
        }

        .btn-cancel {
            background-color: #ccc;
            color: #333;
            border: none;
            padding: 10px 20px;
            font-size: 16px;
            cursor: pointer;
        }
    </style>
    
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>¡Advertencia para personas fotosensibles!</h2>
            <p>Si eres propenso(a) a sufrir epilepsia fotosensible u otros trastornos relacionados por favor le recomendamos no visitar este sitio web ya que poseé fuertes luces neón parpadeantes.</p>
            <p>Haz clic en "Aceptar" para continuar aceptando los riesgos.</p>
            <asp:Button ID="btnAccept" CssClass="btn-accept" runat="server" Text="Aceptar" OnClick="btnAccept_Click" />
        </div>
    </form>

</body>
</html>
