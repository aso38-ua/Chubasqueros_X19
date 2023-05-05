<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="Interfaz.Favoritos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">

    <div id="HFavoritos">
        <h2>Lista de Favoritos</h2>
    </div>
    <div id="list" style="width:90%">
        <asp:ListView ID="listView_Favoritos" runat="server" GroupItemCount="1" GroupPlaceholderID="groupPlaceholder1"  ItemPlaceholderID="itemPlaceholder1">
            <EmptyDataTemplate>
                  <table runat="server">
                    <tr>
                      <td>Lista de Favoritos vacía.</td>
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
                                 </b>
                             </td>
                         </tr>
                         <tr>
                             <td>
                                 <b>Description: </b><span class="description"><%# Eval("descripcion") %></span><br />
                                 <b>Stock: </b><span class="stock"><%# Eval("stock") %></span><br />
                                 <b>Precio: </b><span class="precio"><%# Eval("precio")%></span><br />
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
