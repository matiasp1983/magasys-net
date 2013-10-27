<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Site.Master" AutoEventWireup="true"
    CodeBehind="RealizarReserva.aspx.cs" Inherits="Dyn.Web.User.RealizarReserva" %>

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
        .style5
        {
            width: 20px;
        }
        .style6
        {
            width: 20px;
            height: 20px;
        }
    </style>
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
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%;">
        <tr>
            <td class="style5">
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
            <td class="style5">
                &nbsp;
            </td>
            <td class="art-nav-outer">
                <h2 class="art-postheader">
                    <span class="art-postheadericon">Realizar Reserva</span>
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
            <td class="style6">
            </td>
            <td class="style3">
            </td>
            <td class="style3">
            </td>
            <td class="style3">
            </td>
        </tr>
        <tr>
            <td class="style5">
                &nbsp;
            </td>
            <td style="font-size: 16px;">
                Aquí podrás realizar la reserva de productos.
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style5">
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
            <td class="style5">
                &nbsp;
            </td>
            <td>
                <br />
                <table>
                    <tr>
                        <td class="tittleprecios03" align="left">
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
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style5">
                &nbsp;
            </td>
            <td class="tittleproducto">
                <br />
                Per&iacute;odo de reserva
                <hr />
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style5">
                &nbsp;
            </td>
            <td align="left">
                <table>
                    <tr class="tittleprecios03">
                        <td>
                            <asp:Label ID="lblInicio" runat="server" Text="Inicio:"></asp:Label>
                        </td>
                        <td style="width: 120px">
                            <uc1:Date ID="calFechaInicio" runat="server" Visible="True" />
                        </td>
                        <td>
                            <asp:Label ID="lblFin" runat="server" Text="Fin:"></asp:Label>
                        </td>
                        <td style="width: 120px">
                            <uc1:Date ID="calFechaFin" runat="server" Visible="True" />
                        </td>
                    </tr>
                </table>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style5">
                &nbsp;
            </td>
            <td class="tittleproducto">
                <hr />
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style5">
                &nbsp;
            </td>
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
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style5">
                &nbsp;
            </td>
            <td class="tittleprecios03" align="left">
                <asp:Label ID="lblCantidad" runat="server" Text="Cantidad: "></asp:Label>
                <asp:TextBox ID="txtCantidad" runat="server" MaxLength="3" Width="25px"></asp:TextBox>
                <asp:CompareValidator ID="cvCantidad" runat="server" ErrorMessage="Debe ingresar una catidad correcta"
                    Display="Dynamic" Operator="DataTypeCheck" ControlToValidate="txtCantidad" CssClass="tittleprecios03"
                    Type="Integer" ForeColor="Red"></asp:CompareValidator>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style5">
                &nbsp;
            </td>
            <td align="center">
                <asp:Button ID="btnGuardarReserva" CssClass="adminbutton" runat="server" Text="Guardar"
                    OnClick="btnGuardarReserva_Click" />&nbsp;
                <asp:Button ID="btnCancelar" CssClass="adminbutton" runat="server" Text="Cancelar"
                    OnClick="btnCancelar_Click" />&nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style5">
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
    </table>
</asp:Content>
