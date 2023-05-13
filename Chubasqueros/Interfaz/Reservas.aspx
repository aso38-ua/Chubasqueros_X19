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
                                 <b><u><span class="name">
                                     <%# Eval("ContactName") %></span></u>
                                     <input style="background-color:white; border-color:black; color:red" align=right id="button" type="button" value="Cancelar Reserva" onclick="cancelarReserva(name)">
                                 </b>
                                 
                             </td>
                         </tr>
                         <tr>
                             <td>
                                 <b>Description: </b><span class="description"><%# Eval("descripcion") %></span><br />
                                 <b>Precio: </b><span class="precio"><%# Eval("precio")%></span><br />
                                 <b>Cantidad: </b><span class="cantidad"><%# Eval("cantidad") %></span><br />
                                 <b>Fecha de reserva: </b><span class="fecha"><%# Eval("fecha") %></span><br />
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