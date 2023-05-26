<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Reservas.aspx.cs" Inherits="Interfaz.Reservas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <br /><br /><br /><br />
    <div id="HReservas">
        <h2>Lista de Reservas</h2>
    </div>
    <div id="ElimReserva">
        <p>Nombre del producto: &nbsp;<asp:TextBox ID="text_nombre" runat="server" Height="25px" style="color:black; margin-top: 10px; margin-left: 15px;" Width="400px"></asp:TextBox>
            <asp:Button style="background-color:white; border-color:black; color:black; font-weight: bold; margin-top: 10px; margin-left: 15px;" Width="150px" id="button" runat="server" text="Eliminar" CssClass="neon-btn" onClick="cancelarReserva"/></p>
        <p>Número de cantidad: &nbsp;<asp:TextBox ID="text_cantidad" runat="server" Height="25px" style="color:black; margin-top: 10px; margin-left: 15px;" Width="400px">
                                     </asp:TextBox><asp:Button style="background-color:white; border-color:black; color:black; font-weight: bold; margin-top: 10px; margin-left: 15px;" Width="250px" id="button2" runat="server" text="Editar reserva" CssClass="neon-btn" onClick="editarReserva"/></p>
        <asp:Label ID="Mensaje" runat="server"></asp:Label><br/>
    </div>
    <div id="list" style="width:90%">
        <asp:ListView ID="listView_Reservas" runat="server" GroupItemCount="1" GroupPlaceholderID="groupPlaceholder1"  ItemPlaceholderID="itemPlaceholder1">
            <EmptyDataTemplate>
                  <table runat="server">
                    <tr>
                      <td>No hay reservas.</td>
                    </tr>
                 </table>
            </EmptyDataTemplate>
            <EmptyItemTemplate>
                <td runat="server" />
            </EmptyItemTemplate>
            <LayoutTemplate>
                <div id="productos" >
                     <div ID="groupPlaceholder1" style="position:center; text-align:center; width:100%; " runat="server">

                     </div>
                </div>
                </table>
            </LayoutTemplate>

            <GroupTemplate>
                    <div id="columna" style = "margin-right: 50px;">
                        <div ID="itemPlaceholder1" runat="server">

                        </div>
                    </div>
             </GroupTemplate>
             <ItemTemplate>
                 <td>
                     <table cellpadding="2" cellspacing="0" border="1" style="width: 800px; height: 100px; border: dashed 2px #04AFEF; background-color: #B0E2F5">
                         <tr>
                             <td>
                                 <b><u><span style="color:black" class="name">
                                     <%# Eval("auxnombre") %></span></u>
                                 </b>
                                 
                             </td>
                         </tr>
                         <tr>
                             <td>
                                 <b style="color:grey">Description: </b><span style="color:blue" class="description"><%# Eval("auxdescripcion") %></span><br />
                                 <b style="color:grey">Precio: </b><span style="color:blue" class="precio"><%# Eval("auxprecio")%></span><br />
                                 <b style="color:grey">Cantidad: </b><span style="color:blue" class="cantidad"><%# Eval("cantidad") %></span><br />
                                 <b style="color:grey">Precio total: </b><span style="color:blue" class="ptotal"><%# Eval("ptotal") %></span><br />
                                 <b style="color:grey">Fecha de reserva: </b><span style="color:blue" class="fecha"><%# Eval("fecha") %></span><br />
                             </td>
                         </tr>
                     </table>
                 </td>
             </ItemTemplate>

             <GroupSeparatorTemplate>
              <div runat="server">
                <div style="clear:both"><hr /></div>
              </div>
            </GroupSeparatorTemplate>
        </asp:ListView>
    </div>
</asp:Content>