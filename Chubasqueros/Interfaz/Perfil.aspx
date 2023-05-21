<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="Interfaz.Perfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <asp:Label ID="lblImagePath" runat="server"></asp:Label>
    <asp:Label ID="lblDebug" runat="server"></asp:Label>

    <div class="perfil">
            <h2>Perfil</h2>
            <div class="profile-card">
                <div class="profile-header">
                    <asp:Image ID="imgProfile" runat="server" Width="400px" Height="300px" Style="float:inherit"/><br />
                    <label Style="margin-left:20%">Nombre:</label>
                        <asp:Label ID="lblUsername" runat="server" Text="John Doe" Style="float:inherit"></asp:Label>
                        
                        <asp:Button ID="btnChangeName" runat="server" Text="Cambiar Nombre" OnClick="btnName_Click" Style="font-size:15px; margin-left:15%" Height="21px" />
                        <asp:TextBox ID="txtNewUsername" runat="server" Style="width: 100px; height: 18px; font-size:15px"></asp:TextBox>
                        <asp:Label runat="server" Text="" ID="changeName" Style="font-size:15px;"></asp:Label>
                </div>
                <div class="profile-info">
                    <div class="info-row">
                        <label Style="margin-left:23%">Email:</label>
                        <asp:Label ID="lblEmail" runat="server" Text="john.doe@example.com"></asp:Label>

                        <asp:Button ID="Button1" runat="server" Text="Cambiar email" OnClick="btnEmail_Click" Style="font-size:15px; margin-left:6%" Height="21px" />
                        <asp:TextBox ID="txtNewEmail" runat="server" Style="width: 180px; height: 18px; font-size:15px"></asp:TextBox>
                        <asp:Label runat="server" Text="" ID="changEmail" Style="font-size:15px;"></asp:Label>
                    </div>
                    <div class="info-row">
                        <label>Apellido:</label>
                        <asp:Label ID="lblCountry" runat="server" Text="wfgh"></asp:Label>
                    </div>
                    <div class="info-row">
                        <label>Birthdate:</label>
                        <asp:Label ID="lblBirthdate" runat="server" Text="01/01/1980"></asp:Label>
                    </div>
                </div>
            </div>

        <h2>Cargar imagen de perfil</h2>
                    <div class="upload-form">

                        <asp:FileUpload ID="fileUploadProfileImage" runat="server" />
                        <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />
                    </div>

                    
        </div>

</asp:Content>
