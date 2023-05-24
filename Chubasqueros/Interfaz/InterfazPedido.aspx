<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="InterfazPedido.aspx.cs" Inherits="Interfaz.InterfazPedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <h2>Pedido</h2>
    <asp:Label ID="Message" runat ="server"></asp:Label>

     <div id="list" style="width:90%">
        <asp:ListView ID="ListView_Pedido" runat="server" GroupItemCount="1" GroupPlaceholderID="groupPlaceholder1"  ItemPlaceholderID="itemPlaceholder1">
            <EmptyDataTemplate>
                  <table runat="server">
                    <tr>
                      <td>No hay productos en el carrito.</td>
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
                     <table cellpadding="2" cellspacing="0" border="1" style="width: 800px; height: 100px; border: dashed 2px #fabf3e; background-color: #fff6b3">
                         <tr>
                             <td>
                                 <b><u><span style="color:black" class="name">
                                     <%# Eval("auxnombre") %></span></u>
                                 </b>
                                 
                             </td>
                         </tr>
                         <tr>
                             <td>
                                 <b style="color:grey">Description: </b><span style="color:#242424" class="description"><%# Eval("auxdescripcion") %></span><br />
                                 <b style="color:grey">Precio: </b><span style="color:#242424" class="precio"><%# Eval("auxprecio")%></span><br />
                                 <b style="color:grey">Cantidad: </b><span style="color:#242424" class="cantidad"><%# Eval("cantidad") %></span><br />
                                 
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


    <div id="listusu" style="width:90%">
        <asp:ListView ID="ListView_PedUsuario" runat="server" GroupItemCount="1" GroupPlaceholderID="groupPlaceholder1"  ItemPlaceholderID="itemPlaceholder1">
            <EmptyDataTemplate>
                  <table runat="server">
                    <tr>
                      <td style ="color: orange">No se ha podido encontrar el usuario</td>
                    </tr>
                 </table>
            </EmptyDataTemplate>
            <EmptyItemTemplate>
                <td runat="server" />
            </EmptyItemTemplate>
            <LayoutTemplate>
                <div id="cajausuairo" >
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
                     <table cellpadding="2" cellspacing="0" border="1" style="width: 800px; height: 100px; border: dashed 2px #165cb8; background-color: #7ec9f7">
                         <tr>
                             <td>
                                 <b style="color:grey">Nombre del comprador: </b><span style="color:grey" class="usuario"><%# Eval("usuario") %></span><br />
                                 <b style="color:grey">Email:  </b><span style="color:grey" class="email"><%# Eval("email") %></span><br />
                                 <b style="color:grey">Fecha de llegada aproximada  </b><span style="color:grey" class="fecha"><%# Eval("fechaaprox") %></span><br />
                                 
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
    <p style="color:orange">Precio total: </p><span style="color:orange" class="ptotal"><%# ObtenerPrecioTotal() %></span><br />
     
     <asp:Button ID ="botoncompra" BackColor="LightBlue" Text ="Pagar" runat ="server" onClick="btn_pagar"/>
    <p>
      <asp:Button ID ="botoncancelar" BackColor="LightCoral" Text="Cancelar Pedido" runat="server" onClick="btn_cancelar" Height="53px" Width="276px"/>
    </p>
</asp:Content>
