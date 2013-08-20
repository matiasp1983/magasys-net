<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Admin.Master" AutoEventWireup="true"
    CodeBehind="Venta.aspx.cs" Inherits="Dyn.Web.Admin.Venta" %>

<%@ MasterType VirtualPath="~/Masters/Admin.Master" %>
<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="act" %>
<%@ Register Src="../controls/Login.ascx" TagName="Login" TagPrefix="uc2" %>
<%@ Register Src="../controls/MenuAdminCategoria.ascx" TagName="MenuAdmin" TagPrefix="uc1" %>
<%@ Register Src="../controls/Date.ascx" TagName="Date" TagPrefix="uc1" %>
<%@ Register Src="../controls/Ventas.ascx" TagName="Ventas" TagPrefix="uc3" %>
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
            <td class="tittleprecios03" align="left">
                Código de venta:
                <asp:Label runat="server" ID="lblIdVenta"></asp:Label>
            </td>
            <td class="tittleprecios03" align="left">
                Fecha de venta:&nbsp;<uc1:Date ID="calFechaVenta" runat="server" />                
            </td>
        </tr>
        <%--Se comenta el campo cliente en la iteración 1, no borrar se utilizara en las proximas iteraciones.--%>
       <%-- <tr>
            <td class="tittleprecios03" align="left" colspan="2">
                Nombre de cliente:&nbsp;<asp:Label runat="server" ID="lblNomCliente" Text='<%# Entity.NombreCliente %>'></asp:Label>
                <br />
                <br />
            </td>
        </tr>--%>
        <tr>
            <td colspan="2" class="tittleproducto">
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
