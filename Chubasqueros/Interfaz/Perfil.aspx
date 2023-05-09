<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="Interfaz.Perfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <br /><br /><br /><br /><br /><br /><br />
    <div class="perfil">
            <h1>Perfil</h1>
            <div class="profile-card">
                <div class="profile-header">
                    <img src="profile-picture.jpg" />
                    <label>Nombre:</label>
                        <asp:Label ID="lblUsername" runat="server" Text="John Doe"></asp:Label>
                </div>
                <div class="profile-info">
                    <div class="info-row">
                        <label>Email:</label>
                        <asp:Label ID="lblEmail" runat="server" Text="john.doe@example.com"></asp:Label>
                    </div>
                    <div class="info-row">
                        <label>Country:</label>
                        <asp:Label ID="lblCountry" runat="server" Text="United States"></asp:Label>
                    </div>
                    <div class="info-row">
                        <label>Birthdate:</label>
                        <asp:Label ID="lblBirthdate" runat="server" Text="01/01/1980"></asp:Label>
                    </div>
                </div>
            </div>
        </div>

</asp:Content>
