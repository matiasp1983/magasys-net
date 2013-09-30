<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Admin.Master" AutoEventWireup="true"
    CodeBehind="Reserva.aspx.cs" Inherits="Dyn.Web.Admin.Reserva" %>

<%@ MasterType VirtualPath="~/Masters/Admin.Master" %>
<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="act" %>
<%@ Register Src="../controls/Login.ascx" TagName="Login" TagPrefix="uc2" %>
<%@ Register Src="../controls/MenuAdminCategoria.ascx" TagName="MenuAdmin" TagPrefix="uc1" %>
<%@ Register Src="../controls/Date.ascx" TagName="Date" TagPrefix="uc1" %>
<%@ Register Src="../controls/Ventas.ascx" TagName="Ventas" TagPrefix="uc3" %>
<%@ Register Src="../controls/BuscarClientes.ascx" TagName="BuscarClientes" TagPrefix="uc4" %>
<%@ Register Src="../controls/BuscarProducto.ascx" TagName="BuscarProducto" TagPrefix="uc5" %>
<%@ Register Src="../controls/BuscarProductoEdicion.ascx" TagName="BuscarProductoEdicion"
    TagPrefix="uc6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" language="javascript">
        function ShowPanel() {
            var rdbProducto = document.getElementById("<%=rdbProducto.ClientID %>");
            var pnlProducto = document.getElementById("pnlBuscarProducto");

            var rdbEdicion = document.getElementById("<%=rdbEdicion.ClientID %>");
            var pnlEdicion = document.getElementById("pnlBuscarProductoEdicion");


            if (rdbProducto.checked) {
                pnlProducto.style.visibility = "visible";
                pnlEdicion.style.visibility = "hidden";
                pnlEdicion.style.width = "0px";
                pnlEdicion.style.height = "0px";
                pnlProducto.style.width = "757px";
                pnlProducto.style.height = "90px";

            } else if (rdbEdicion.checked) {
                pnlEdicion.style.visibility = "visible";
                pnlProducto.style.visibility = "hidden";
                pnlProducto.style.width = "0px";
                pnlProducto.style.height = "0px";
                pnlEdicion.style.width = "757px";
                pnlEdicion.style.height = "90px";
            }
        }
    </script>
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
<asp:Content ID="Content4" ContentPlaceHolderID="cphReserva" runat="server">
</asp:Content>
