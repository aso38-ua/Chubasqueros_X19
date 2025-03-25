<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="InterfazCarrito.aspx.cs" Inherits="Interfaz.InterfazCarrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <link href ="css/EstiloCarrito.css" rel ="stylesheet" />

    <h2 class = "h1-carrito">Carrito de la compra</h2>
    <asp:Label ID ="Message" runat ="server"></asp:Label>

      <div id="list" style="width:90%">
        <asp:ListView ID="ListView_Carrito" runat="server" GroupItemCount="1" GroupPlaceholderID="groupPlaceholder1"  ItemPlaceholderID="itemPlaceholder1" OnSelectedIndexChanged="ListView_Carrito_SelectedIndexChanged">
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
                                 <b style="color: grey">Cantidad:</b> <asp:TextBox ID ="boxcantidad" TextMode ="SingleLine"  Columns ="2" runat ="server"></asp:TextBox><br />
                                
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
     <asp:Button ID ="botoncompra"  BackColor="LightBlue"  Text="Comprar" runat ="server" onCLick="btn_compra"/>
     <p>
     <asp:Button ID ="botoneliminar" BackColor="LightCoral" Text ="Eliminar del carrito" runat ="server" style="margin-bottom: 0px" onClick="btn_eliminar" Height="49px" Width="304px"/></p>
    <p>
        <asp:Button ID ="BotonProducto"  BackColor="Orange"  Text="Productos" runat ="server" onCLick="btn_producto"/>
    </p>
</asp:Content>
