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
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphCentral" runat="server">
    <table width="100%" cellpadding="0" cellspacing="5" border="0">
        <tr>
            <td class="style1" align="left">
                Numero de Venta:
            </td>
            <td align="left" width="150">
               <%-- <asp:TextBox ID="txtNumeroVenta" runat="server" CssClass="tittleprecios03" Text="<%# Entity.Nombre %>"></asp:TextBox><br />--%>
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
                     <asp:Button CssClass="adminbutton" ID="btnMostrarProductos" runat="server" Text="MostrarProductos"
                   />&nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <uc3:WUCBuscarProducto ID="WUCBuscarProducto1" runat="server" />
            </td>
        </tr>
        <%--  Control de Botones --%>
        <tr>
            <td colspan="2" style="height: 24px">
                <br />
               <%-- <asp:Button CssClass="adminbutton" ID="btnGuardar" runat="server" Text="Guardar"
                    OnClick="btnGuardar_Click" />&nbsp;
                <asp:Button CssClass="adminbutton" ID="btnCancelar" runat="server" Text="Cancelar"
                    OnClick="btnCancelar_Click" CausesValidation="False" />&nbsp;
                <asp:Button CssClass="adminbutton" ID="btnEliminar" runat="server" Text="Anular"
                    OnClick="btnEliminar_Click" CausesValidation="False" OnClientClick="javascript:return confirm('Desea eliminar la Coleccion?');"
                    Visible="False" />--%>
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
