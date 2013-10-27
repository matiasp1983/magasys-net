﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Site.Master" AutoEventWireup="true"
    CodeBehind="MisReservas.aspx.cs" Inherits="Dyn.Web.User.MisReservas" %>

<%@ Register Src="~/controls/Date.ascx" TagName="Date" TagPrefix="uc1" %>
<%@ Register Src="../controls/BuscarProducto.ascx" TagName="BuscarProducto" TagPrefix="uc5" %>
<%@ Register Src="../controls/BuscarProductoEdicion.ascx" TagName="BuscarProductoEdicion"
    TagPrefix="uc6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 20px;
        }
        .style2
        {
            width: 20px;
            height: 20px;
        }
        .style3
        {
            height: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%;">
        <tr>
            <td class="style1">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;
            </td>
            <td class="art-nav-outer">
                <h2 class="art-postheader">
                    <span class="art-postheadericon">Mi Cuenta </span>
                </h2>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style2">
            </td>
            <td class="style3">
            </td>
            <td class="style3">
            </td>
            <td class="style3">
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;
            </td>
            <td style="font-size: 16px;">
                Aquí podrás ver las compras realizadas que aun no han sido abonadas.
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;
            </td>
            <td>
                <br />
                <table>
                    <tr>
                        <td class="tittleprecios03" align="left" style="width: 115px">
                            <asp:Label ID="lblFecha" runat="server" Text="Fecha de reserva:"></asp:Label>
                        </td>
                        <td class="tittleprecios03" align="left">
                            <uc1:Date ID="calFechaReserva" runat="server" Visible="True" />
                        </td>
                        <td class="tittleprecios03" align="right">
                            <asp:Label ID="lblTipoReserva" runat="server" Text="Tipo de reserva:" Width="120px"></asp:Label>
                            <asp:DropDownList ID="ddlTipoReserva" runat="server">
                                <asp:ListItem>Única</asp:ListItem>
                                <asp:ListItem>Periódica</asp:ListItem>
                            </asp:DropDownList>
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
                            <uc1:Date ID="calFechaInicio" runat="server" Visible="True" />
                        </td>
                        <td>
                            <asp:Label ID="lblFin" runat="server" Text="Fin:"></asp:Label>
                        </td>
                        <td>
                            <uc1:Date ID="calFechaFin" runat="server" Visible="True" />
                        </td>
                    </tr>
                </table>
                <hr />
            </td>
        </tr>
        <tr>
            <td colspan="2" class="tittleproducto">
                <hr />
            </td>
        </tr>
        <tr>
            <td class="tittleprecios03" align="left">
                <asp:RadioButton ID="rdbProducto" runat="server" Text="Producto" Checked="True" GroupName="Producto"
                    onclick="ShowPanel();" />
                <asp:RadioButton ID="rdbEdicion" runat="server" Text="Edici&oacute;n" GroupName="Producto"
                    onclick="ShowPanel();" />
                <div id="pnlBuscarProducto" style="visibility: visible;">
                    <br />
                    <uc5:BuscarProducto ID="ucBuscarProducto" runat="server" /></div>
                <div id="pnlBuscarProductoEdicion" style="visibility: hidden;">
                    <br />
                    <uc6:BuscarProductoEdicion ID="ucBuscarProductoEdicion" runat="server" /></div>
            </td>
        </tr>
        <tr>
            <td class="tittleprecios03" align="left">
                <asp:Label ID="lblCantidad" runat="server" Text="Cantidad: "></asp:Label>
                <asp:TextBox ID="txtCantidad" runat="server" MaxLength="3" Width="25px"></asp:TextBox>
                <asp:CompareValidator ID="cvCantidad" runat="server" ErrorMessage="Debe ingresar una catidad correcta"
                    Display="Dynamic" Operator="DataTypeCheck" ControlToValidate="txtCantidad" CssClass="tittleprecios03"
                    Type="Integer" ForeColor="Red"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btnGuardarReserva" CssClass="adminbutton" runat="server" Text="Guardar"
                    OnClick="btnGuardarReserva_Click" />&nbsp;
                <asp:Button ID="btnCancelar" CssClass="adminbutton" runat="server" Text="Cancelar"
                    OnClick="btnCancelar_Click" />&nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
