<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Admin.Master" AutoEventWireup="true"
    CodeBehind="Venta.aspx.cs" Inherits="Dyn.Web.Admin.Venta" %>

<%@ MasterType VirtualPath="~/Masters/Admin.Master" %>
<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="act" %>
<%@ Register Src="../controls/Login.ascx" TagName="Login" TagPrefix="uc2" %>
<%@ Register Src="../controls/MenuAdminCategoria.ascx" TagName="MenuAdmin" TagPrefix="uc1" %>
<%@ Register Src="../controls/Date.ascx" TagName="Date" TagPrefix="uc1" %>
<%@ Register Src="../controls/Ventas.ascx" TagName="Ventas" TagPrefix="uc3" %>
<%@ Register Src="../controls/BuscarClientes.ascx" TagName="BuscarClientes" TagPrefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphCentral" runat="server">
    <table border="0" cellpadding="0" cellspacing="5" width="100%">
        <tr>
            <td colspan="2" class="tittleproducto">
                Informaci&oacute;n
                <hr />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table>
                    <tr>
                        <td class="tittleprecios03" align="left">
                            Código de venta:
                            <asp:Label runat="server" ID="lblIdVenta"></asp:Label>
                        </td>
                        <td class="tittleprecios03" align="right" style="width: 300px">
                            <asp:Label ID="lblFecha" runat="server" Text="Fecha de venta:"></asp:Label>
                        </td>
                        <td class="tittleprecios03" align="left">
                            <uc1:Date ID="calFechaVenta" runat="server" Visible="True" />
                        </td>
                    </tr>
                    <tr>
                        <td class="tittleprecios03" align="left">
                            <asp:Label ID="lblTipoVenta" runat="server" Text="Forma de Pago:"></asp:Label>
                            <asp:DropDownList ID="ddlTipoVenta" runat="server">
                                <asp:ListItem>Cuenta corriente</asp:ListItem>
                                <asp:ListItem>Contado</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="tittleprecios03" align="left">
                            <asp:Label ID="lblEntrega" runat="server" Text="Entrega:" Width="100px"></asp:Label>
                            <asp:RadioButton ID="rdbSiEntrega" runat="server" Text="Si" Checked="True" GroupName="Entrega" />
                            <asp:RadioButton ID="rdbNoEntrega" runat="server" Text="No" GroupName="Entrega" />
                        </td>
                        <td class="tittleprecios03" align="left">
                            <asp:Label ID="lblPagado" runat="server" Text="Pagado:"></asp:Label>
                            <asp:RadioButton ID="rdbSiPagado" runat="server" Text="Si" Checked="True" GroupName="Pagado" />
                            <asp:RadioButton ID="rdbNoPagado" runat="server" Text="No" GroupName="Pagado" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="tittleproducto">
                <br />
                Selecci&oacute;n de Cliente
                <hr />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <uc4:BuscarClientes ID="ucBuscarClientes" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2" class="tittleproducto">
                <br />
                Selecci&oacute;n de Productos
                <hr />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <uc3:Ventas ID="ucVentas" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btnGuardarVenta" CssClass="adminbutton" runat="server" Text="Guardar"
                    OnClick="btnGuardarVenta_Click" />&nbsp;
                <asp:Button ID="btnCancelar" CssClass="adminbutton" runat="server" Text="Cancelar"
                    OnClick="btnCancelar_Click" />&nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphReserva" runat="server">
</asp:Content>
