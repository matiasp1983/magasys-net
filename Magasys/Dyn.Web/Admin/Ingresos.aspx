<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Admin.Master" AutoEventWireup="true"
    CodeBehind="Ingresos.aspx.cs" Inherits="Dyn.Web.Admin.Ingresos" %>

<%@ MasterType VirtualPath="~/Masters/Admin.Master" %>
<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="act" %>
<%@ Register Src="../controls/Login.ascx" TagName="Login" TagPrefix="uc2" %>
<%@ Register Src="../controls/MenuAdminCategoria.ascx" TagName="MenuAdmin" TagPrefix="uc1" %>
<%@ Register Src="../controls/WUCBuscarProducto.ascx" TagName="WUCBuscarProducto"
    TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            font-style: normal;
            color: #7f7f7f; /*font-size: 11px;*/
            font-weight: bold;
            height: 45px;
        }
        .style2
        {
            height: 45px;
        }
        .style3
        {
            height: 565px;
        }
        .style8
        {
            font-weight: bold;
            font-style: normal;
            color: #0e85cd;
            text-decoration: none;
            font-weight: bold;
            width: 92px;
        }
        .style9
        {
            font-weight: bold;
            font-style: normal;
            color: #0e85cd;
            text-decoration: none;
            font-weight: bold;
            width: 100px;
        }
        .style10
        {
            font-weight: bold;
            font-style: normal;
            color: #0e85cd;
            text-decoration: none;
            font-weight: bold;
            width: 287px;
        }
        .style11
        {
            font-weight: bold;
            font-style: normal;
            color: #0e85cd;
            text-decoration: none;
            font-weight: bold;
            width: 190px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphCentral" runat="server">
    <table width="100%" cellpadding="0" cellspacing="5" border="0">
        <tr>
            <td class="style1" align="left">
                Numero de Venta:
            </td>
            <td align="left" width="150">
                <asp:TextBox ID="txtNumeroVenta" runat="server" CssClass="tittleprecios03" 
                    Enabled="False"></asp:TextBox><br />
            </td>
        </tr>

                <tr>
            <td class="style1" align="left">
                Cliente:
            </td>
            <td align="left" width="150">
                <asp:TextBox ID="txtCliente" runat="server" CssClass="tittleprecios03" 
                    Enabled="False"></asp:TextBox><br />
            </td>
        </tr>

        <tr>
            <td class="style1" align="left">
                Fecha (*)
            </td>
            <td>
                <asp:Calendar ID="calFecha" runat="server"></asp:Calendar>
            </td>
        </tr>
        <tr>
            <td colspan="2">
               <%-- <asp:Button CssClass="adminbutton" ID="btnMostrarProductos" runat="server" Text="MostrarProductos"
                    OnClick="btnGuardar_Click" />&nbsp;--%>
                     <asp:Button CssClass="adminbutton" ID="btnMostrarProductos" runat="server" 
                    Text="MostrarProductos" onclick="btnMostrarProductos_Click"
                   />&nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2" class="style3">
                <uc3:WUCBuscarProducto ID="WUCBuscarProducto1" runat="server" Visible="False" />
            </td>
        </tr>

        <tr>
                    <td colspan="3" width="700" align="left">
&nbsp;<div id="tableHeader">
                        </div>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="style11">
                                    Nombre
                                    <br />
                                    <hr />
                                </td>
                                <td class="style10">
                                    Descripci&oacute;n
                                    <br />
                                    <hr />
                                </td>
                                <%-- <td width="233" class="tittleproducto">
                                    Cantidad
                                    <br />
                                    <hr />
                                </td>--%>
                                <td class="style8">
                                    Precio
                                    <br />
                                    <hr style="margin-right: 52px" />
                                </td>
                                <td class="style9">
                                    Cantidad
                                    <br />
                                    <hr />
                                </td>
                                <td width="233" class="tittleproducto">
                                    Subtotal
                                    <br />
                                    <hr />
                                </td>
                            </tr>
                        </table>
                        <div style="overflow: scroll; height: 295px; width: 100%">
                            <div>
                                <asp:Repeater ID="repDetalle" runat="server">
                                    <HeaderTemplate>
                                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblProducto" CssClass="tittleprecios03" Text='<%# Eval("Nombre") %>' runat="server" Width="100"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblDescripcion" CssClass="tittleprecios03" Text='<%# Eval("Descripcion") %>'
                                                    runat="server" Width="150"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtPrecio" CssClass="tittleprecios03" runat="server" Width="50"></asp:TextBox>
                                                    
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCantidad" CssClass="tittleprecios03" runat="server" Width="50"></asp:TextBox>
                                                    
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtSubtotal" CssClass="tittleprecios03" runat="server" Enabled="False" Width="50"></asp:TextBox>
                                                    
                                            </td>
                                            <td>
                                               <asp:Button CssClass="adminbutton" ID="btnQuitar" runat="server" Text="Quitar"
                    />&nbsp;
                                            </td>


                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </table>
                                    </FooterTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </td>
                </tr>
        <%--  Control de Botones --%>
        <tr>
            <td colspan="2" style="height: 24px">
                <br />
                     <asp:Button CssClass="adminbutton" ID="btnGuardar" runat="server" Text="Guardar"
                    />&nbsp;
                <asp:Button CssClass="adminbutton" ID="btnCancelar" runat="server" Text="Cancelar"
                    CausesValidation="False" />&nbsp;
                <asp:Button CssClass="adminbutton" ID="btnEliminar" runat="server" Text="Anular"
                    CausesValidation="False" OnClientClick="javascript:return confirm('Desea eliminar la Coleccion?');"
                    Visible="False" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphReserva" runat="server">
</asp:Content>
<asp:Content ID="Content5" runat="server" ContentPlaceHolderID="cphMenu">
    <!--Control de login de ejemplo-->
    <uc2:Login ID="Login1" runat="server" />
    <br />
    <uc1:MenuAdmin ID="MenuAdmin1" runat="server" />
</asp:Content>
