<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EditarPerfil.aspx.cs" Inherits="Interfaz.EditarPerfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">

    <img src="IMGS/change.jpg" style="width:16%; display: flex; justify-content: center; align-items: center; margin-left: 42%; margin-right: 4px;"/>
    <div >
        

        

                  <asp:Button ID="btnChangeName" runat="server" Text="Cambiar Nombre" OnClick="btnName_Click" />  
                  <asp:TextBox ID="txtNewUsername" runat="server"></asp:TextBox>
                  <asp:Label runat="server" Text="" ID="changeName"></asp:Label><br /><br /><br />

                 <asp:Button ID="Button1" runat="server" Text="Volver al perfil" OnClick="volver" />
        

                <h2>Cargar imagen de perfil</h2>
                    <asp:FileUpload ID="fileUploadProfileImage" runat="server" />
                    <asp:Button ID="btnUpload" runat="server" Text="Cargar" OnClick="btnUpload_Click" />
                </div>
</asp:Content>
