﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Admin.Master" AutoEventWireup="true"
    CodeBehind="EditarReserva.aspx.cs" Inherits="Dyn.Web.Admin.EditarReserva" %>

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
                            <asp:Label ID="lblFechaText" runat="server" Text="<%# Entity.FechaReserva %>" 
                                Width="160px"></asp:Label>
                        </td>
                        <td class="tittleprecios03" align="left">
                            <asp:Label ID="lblTipoReserva" runat="server" Text="  Tipo de reserva:" Width="120px"></asp:Label>
                        </td>
                        <td class="tittleprecios03" align="left">
                            <asp:DropDownList ID="ddlTipoReserva" runat="server">
                                <asp:ListItem>Única</asp:ListItem>
                                <asp:ListItem>Periódica</asp:ListItem>
                            </asp:DropDownList>
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
                            <uc1:Date ID="calFechaInicio" runat="server" Visible="True" CalendarDate="<%# Entity.FechaInicio %>" />
                        </td>
                        <td>
                            <asp:Label ID="lblFin" runat="server" Text="Fin:"></asp:Label>
                        </td>
                        <td>
                            <uc1:Date ID="calFechaFin" runat="server" Visible="True" CalendarDate="<%# Entity.FechaFin %>" />
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
                </table>
                <hr />
            </td>
        </tr>
        <tr>
            <td class="tittleprecios03" align="left">
                <div id="pnlBuscarProducto" style="visibility: visible;">
                    <br />
                    <uc5:BuscarProducto ID="ucBuscarProducto" runat="server" /></div>
            </td>
        </tr>
        <tr>
            <td class="tittleprecios03" align="left">
                <asp:Label ID="lblCantidad" runat="server" Text="Cantidad: "></asp:Label>
                <asp:TextBox ID="txtCantidad" runat="server" Text="<%# Entity.Cantidad %>" 
                    MaxLength="3" Width="25px"></asp:TextBox>
                <asp:CompareValidator ID="cvCantidad" runat="server" ErrorMessage="Debe ingresar una catidad correcta"
                    Display="Dynamic" Operator="DataTypeCheck" ControlToValidate="txtCantidad" CssClass="tittleprecios03"
                    Type="Integer" ForeColor="Red"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btnGuardar" CssClass="adminbutton" runat="server" Text="Guardar"
                    OnClick="btnGuardar_Click" />&nbsp;
                <asp:Button ID="btnCancelar" CssClass="adminbutton" runat="server" Text="Cancelar"
                    OnClick="btnCancelar_Click" />&nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphReserva" runat="server">
</asp:Content>
