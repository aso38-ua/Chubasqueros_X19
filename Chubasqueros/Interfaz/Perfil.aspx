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
                     <asp:Label runat="server" Text="Nombre:" CssClass="neon-label" style="margin-left:15%"></asp:Label>
                        <asp:Label ID="lblUsername" runat="server" Text="John Doe" Style="float:inherit" CssClass="neon-label"></asp:Label>
                        
                        <asp:Button ID="btnChangeName" runat="server" Text="Cambiar Nombre" OnClick="btnName_Click" Style="font-size:15px; margin-left:15%" Height="21px" />
                        <asp:TextBox ID="txtNewUsername" runat="server" Style="width: 100px; height: 18px; font-size:15px"></asp:TextBox>
                        <asp:Label runat="server" Text="" ID="changeName" Style="font-size:15px;"></asp:Label>
                </div>
                <div class="profile-info">
                    <div class="info-row">
                        <asp:Label runat="server" Text="Email:" CssClass="neon-label" style="margin-left:15%"></asp:Label>
                        <asp:Label ID="lblEmail" runat="server" Text="john.doe@example.com" CssClass="neon-label" ></asp:Label>

                        <asp:Button ID="Button1" runat="server" Text="Cambiar email" OnClick="btnEmail_Click" Style="font-size:15px; margin-left:6%" Height="21px" />
                        <asp:TextBox ID="txtNewEmail" runat="server" Style="width: 180px; height: 18px; font-size:15px"></asp:TextBox>
                        <asp:Label runat="server" Text="" ID="changEmail" Style="font-size:15px;"></asp:Label>
                    </div>
                    <div class="info-row">
                        <asp:Label runat="server" Text="País:" CssClass="neon-label"></asp:Label>
                        <asp:Label ID="lblCountry" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="info-row">
                        <asp:Label runat="server" Text="Teléfono:" CssClass="neon-label"></asp:Label>
                        <asp:Label ID="lblBirthdate" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>

        <div>
           <asp:Label runat="server" Text="Mis seguidores:" CssClass="neon-label"></asp:Label>
           <span id="misSubs" runat="server"></span>
        </div>
        <div>
           <asp:Label runat="server" Text="Mis seguidos:" CssClass="neon-label"></asp:Label>
           <span id="misimp" runat="server"></span>
        </div>
        <br />
        <h2>Buscar usuario</h2>
        

        <div>
            <input type="text" id="txtSeguido" runat="server" />
            <asp:Button ID="btnSeguir" runat="server" Text="Seguir" OnClick="btnSeguir_Click" CssClass="neon-btn" />
        </div>

        <div>
           <asp:Label runat="server" Text="Sus seguidores:" CssClass="neon-label"></asp:Label>
           <span id="lblFollowers" runat="server"></span>
        </div>
        
        
        

        <h2>Cargar imagen de perfil</h2>
                    <div class="upload-form">

                        <asp:FileUpload ID="fileUploadProfileImage" runat="server" CssClass="neon-btn"/>
                        <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" CssClass="neon-btn"/>
                    </div>

                    
        </div>
    <br />
    <div id="divadminaccess" runat="server"  style="display: flex; flex-direction: column; align-items: center; justify-content: center; margin-top:5%; ">
        <label class="neon-label">Opciones administrador</label><br />
        <asp:Button runat="server" OnClick="btn_adminO" Text="Añadir oferta" CssClass="neon-btn"/>
        <asp:Button runat="server" OnClick="btn_adminS" Text="Añadir servicio" CssClass="neon-btn"/>
        </div>

    
    <div id="divUsuariosConMasSeguidores" runat="server"  style="display: flex; flex-direction: column; align-items: center; justify-content: center; margin-top:5%; ">
    <asp:Button ID="btnMostrarUsuarios" runat="server" CssClass="neon-btn" Text="Mostrar Usuarios con Más Seguidores" OnClick="btnMostrarUsuarios_Click" />
        <br /><br />
    <asp:GridView ID="gvUsuariosConMasSeguidores" runat="server" AutoGenerateColumns="False" CssClass="neon-btn">
    <Columns>
        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
        <asp:BoundField DataField="NumeroSeguidores" HeaderText="Seguidores" />
    </Columns>
    </asp:GridView>
        </div>
</asp:Content>
