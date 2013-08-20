<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Admin.Master" AutoEventWireup="true"
    CodeBehind="MostrarVenta.aspx.cs" Inherits="Dyn.Web.Admin.MostrarVenta" %>

<%@ MasterType VirtualPath="~/Masters/Admin.Master" %>
<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="act" %>
<%@ Register Src="../controls/Login.ascx" TagName="Login" TagPrefix="uc2" %>
<%@ Register Src="../controls/MenuAdminCategoria.ascx" TagName="MenuAdmin" TagPrefix="uc1" %>
<%@ Register Src="../controls/Date.ascx" TagName="Date" TagPrefix="ucDate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphCentral" runat="server">
    <table border="0" cellpadding="0" cellspacing="5" width="100%">
        <tr>
            <td colspan="2" class="tittleproducto">
                Detalle de la venta
            </td>
        </tr>
        <tr>
            <td colspan="2" class="tittleproducto">
                Informaci&oacute;n
                <hr />
            </td>
        </tr>
        <tr>
            <td class="tittleprecios03" align="left">
                Código de venta:
                <asp:Label runat="server" ID="lblIdVenta"></asp:Label>
            </td>
            <td class="tittleprecios03" align="left">
                Fecha de venta:&nbsp;
                <asp:Label runat="server" ID="lblFechaModificacion"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="tittleproducto">
                <br />
                Items de la venta
                <hr />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Repeater ID="rptItems" runat="server" OnItemDataBound="rpItems_ItemDataBound">
                    <HeaderTemplate>
                        <table width="100%" cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td class="tittleproducto">
                                    IdProducto
                                </td>
                                <td class="tittleproducto">
                                    Nombre
                                </td>
                                <td class="tittleproducto">
                                    Precio unitario
                                </td>
                                <td class="tittleproducto">
                                    Cantidad
                                </td>
                                <td class="tittleproducto">
                                    Valor Total
                                </td>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:Label CssClass="tittleprecios03" ID="lblIdProducto" runat="server" Text='<%# Eval("IdProducto") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label CssClass="tittleprecios03" ID="lblNombre" runat="server" Text='<%# Eval("nombre") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblPesoslblValorUnitario" runat="server" Text="Label" CssClass="tittleprecios03">$ </asp:Label><asp:Label
                                    CssClass="tittleprecios03" ID="lblValorUnitario" runat="server" Text='<%# Convert.ToDouble(Convert.ToDouble(Eval("precioUnidad"))) %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label CssClass="tittleprecios03" ID="lblCantidad" runat="server" Text='<%# Eval("cantidad") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblPesoslblValorTotal" runat="server" Text="Label" CssClass="tittleprecios03">$ </asp:Label>
                                <asp:Label CssClass="tittleprecios03" ID="lblValorTotal" runat="server" Text='<%# Convert.ToDouble(Convert.ToDouble(Eval("subTotal"))) %>'></asp:Label>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table width="100%" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td colspan="4" align="right" class="tittleprecios03">
                        <br />
                            Total:&nbsp;$&nbsp;<asp:Label CssClass="tittleprecios03" ID="lblTotal" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btnVolver" CssClass="adminbutton" runat="server" Text="Volver a listado venta"
                    OnClick="btnVolveralistadoventa_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphReserva" runat="server">
</asp:Content>
