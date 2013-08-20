<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Admin.Master" AutoEventWireup="true" CodeBehind="Devoluciones.aspx.cs" Inherits="Dyn.Web.Admin.Devoluciones" %>

<%@ MasterType VirtualPath="~/Masters/Admin.Master" %>
<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="act" %>

<%@ Register Src="../controls/Login.ascx" TagName="Login" TagPrefix="uc2" %>
<%@ Register Src="../controls/MenuAdminCategoria.ascx" TagName="MenuAdmin" TagPrefix="uc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .style1
        {
            font-style: normal;
            color: #7f7f7f; /*font-size: 11px;*/;
            font-weight: bold;
            height: 45px;
            width: 328px;
        }
        .style16
        {
        }
        .style17
        {
            height: 45px;
        }
    </style>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphCentral" runat="server">
    <table width="100%" cellpadding="0" cellspacing="5" border="0">
        <tr>
            <td class="style1" align="left">
                Numero de Devoluci&oacute;n:
            </td>
            <td align="left" width="150">
                <asp:TextBox ID="txtNumeroDevolucion" runat="server" CssClass="tittleprecios03" 
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
            <td class="style1" align="left" valign="middle">
                        Proveedor:
            </td>
            <td class="style17">
                <asp:DropDownList CssClass="tittleprecios03" ID="lstProveedor" runat="server">
                </asp:DropDownList><br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Debe seleccionar un Proveedor"
                    ControlToValidate="lstProveedor" CssClass="tittleprecios03" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>

            <td>
                <asp:Button CssClass="adminbutton" ID="btnSeleccionarProveedor" runat="server" 
                    Text="Seleccionar Proveedor" onclick="btnSeleccionarProveedor_Click"
                    />&nbsp;
            </td>
         </tr>

         <tr>
            <td class="style16" colspan="3">
            
                <asp:GridView ID="gvDetalles" runat="server" AutoGenerateColumns="False" 
                    onrowcancelingedit="gvDetalles_RowCancelingEdit" 
                    onrowdeleting="gvDetalles_RowDeleting" onrowediting="gvDetalles_RowEditing" 
                    onrowupdating="gvDetalles_RowUpdating">
                    <Columns>
                        <asp:BoundField DataField="Producto.Nombre" HeaderText="Producto" 
                            ReadOnly="True" />
                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                        <asp:CommandField ShowEditButton="True" />
                        <asp:CommandField ShowDeleteButton="True" />
                    </Columns>
                </asp:GridView>
            
            </td>


         </tr>

         <tr>

            <td class="style1" align="left">
                Cantidad a Devolver:
            </td>
            <td align="left" width="150">
                <asp:TextBox ID="txtCantidad" runat="server" CssClass="tittleprecios03" 
                    Enabled="False"></asp:TextBox><br />
            </td>
         <td>
         <asp:Button CssClass="adminbutton" ID="btnCambiarCantidad" runat="server" 
                    Text="CambiarCantidad" onclick="btnCambiarCantidad_Click"
                    />&nbsp;
         
         </td>
         </tr>

         <tr>
            <td class="style16" colspan="3">
            
                <asp:Button CssClass="adminbutton" ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click"
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
