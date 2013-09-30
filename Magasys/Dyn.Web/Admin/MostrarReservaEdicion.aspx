<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Admin.Master" AutoEventWireup="true"
    CodeBehind="MostrarReservaEdicion.aspx.cs" Inherits="Dyn.Web.Admin.MostrarReservaEdicion" %>

<%@ MasterType VirtualPath="~/Masters/Admin.Master" %>
<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="act" %>
<%@ Register Src="../controls/Login.ascx" TagName="Login" TagPrefix="uc2" %>
<%@ Register Src="../controls/MenuAdminCategoria.ascx" TagName="MenuAdmin" TagPrefix="uc1" %>
<%@ Register Src="../controls/Date.ascx" TagName="Date" TagPrefix="uc1" %>
<%@ Register Src="../controls/BuscarProducto.ascx" TagName="BuscarProducto" TagPrefix="uc5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphCentral" runat="server">
    <table border="0" cellpadding="0" cellspacing="5" width="100%">
        <tr>
            <td colspan="2">
                <table>
                    <tr>
                        <td class="tittleprecios03" align="left" style="width: 115px">
                            <asp:Label ID="lblFecha" runat="server" Text="Fecha de reserva:"></asp:Label>
                        </td>
                        <td class="tittleprecios03" align="left">
                            <asp:Label ID="lblFechaText" runat="server" Text="<%# Entity.FechaReservaEdicion %>" Width="160px"></asp:Label>
                        </td>
                        <td class="tittleprecios03" align="left">
                            <asp:Label ID="lblTipoReserva" runat="server" Text="  Tipo de reserva:" Width="120px"></asp:Label>
                        </td>
                        <td class="tittleprecios03" align="left">
                            <asp:Label ID="lblTipoReservaText" runat="server" Text="<%# Entity.TipoReserva %>"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="tittleprecios03" align="left">
                            <asp:Label ID="lblNroCliente" runat="server" Text="N&uacute;mero de Cliente:" Width="125px"></asp:Label>
                        </td>
                        <td class="tittleprecios03" align="left">
                            <asp:Label ID="lblNroClienteText" runat="server" Width="160px"></asp:Label>
                        </td>
                        <td class="tittleprecios03" align="left">
                            <asp:Label ID="lblNombApell" runat="server" Text="  Nombre y apellido:" Width="125px"></asp:Label>
                        </td>
                        <td class="tittleprecios03" align="left">
                            <asp:Label ID="lblNombApellText" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="tittleproducto">
                <br />
                Per&iacute;odo de reserva
                <hr />
            </td>
        </tr>
        <tr>
            <td class="tittleprecios03" align="left">
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="lblInicio" runat="server" Text="Inicio:"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblFechaInicio" runat="server" Text="<%# Entity.FechaInicio %>" Width="160px"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblFin" runat="server" Text="Fin:"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblFechaFin" runat="server" Text="<%# Entity.FechaFin %>" Width="160px"></asp:Label>
                        </td>
                    </tr>
                </table>
                <hr />
            </td>
        </tr>
        <tr>
            <td class="tittleprecios03" align="left">
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="lblidProducto" runat="server" Text="C&oacute;digo Producto:"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblidProductoText" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblNombreProducto" runat="server" Text="Nombre:"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblNombreProductoText" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblEdicion" runat="server" Text="Edici&oacute;n:"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblEdicionText" runat="server" Text="<%# Entity.IdProductoEdicion %>"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblCantidad" runat="server" Text="Cantidad: "></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblCantidadText" runat="server" Text="<%# Entity.Cantidad %>" Width="25px"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btnVolver" CssClass="adminbutton" runat="server" Text="Volver a listado reserva"
                    OnClick="btnVolveraListadoReserva_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphReserva" runat="server">
</asp:Content>
