<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Admin.Master" AutoEventWireup="true" CodeBehind="Coleccion.aspx.cs" Inherits="Dyn.Web.Admin.Coleccion" %>
<%@ MasterType VirtualPath="~/Masters/Admin.Master" %>
<%@ Register Src="../controls/Login.ascx" TagName="Login" TagPrefix="uc2" %>
<%@ Register Src="../controls/MenuAdminCategoria.ascx" TagName="MenuAdmin" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphCentral" runat="server">
<table width="100%" cellpadding="0" cellspacing="5" border="0">
        


<%--  Datos Comunes a Todos los Productos --%>


        <tr>
            <td class="tittleprecios03" align="left" width="100">
                Nombre(*)
            </td>
            <td align="left" width="150">
                <asp:TextBox ID="txtNombre" runat="server" CssClass="tittleprecios03" Text="<%# Entity.Nombre %>"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ErrorMessage="Debe ingresar el nombre"
                    ControlToValidate="txtNombre" CssClass="tittleprecios03" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td class="tittleprecios03" align="left" width="100">
                Descripci&oacute;n
            </td>
            <td>
                <asp:TextBox ID="txtDescripcion" runat="server" Height="100px" Width="400px" CssClass="tittleprecios03"
                    Text="<%# Entity.Descripcion %>" TextMode="MultiLine"></asp:TextBox><br />
            </td>
        </tr>

        <tr>
            <td class="tittleprecios03" align="left" width="100">
                Proveedor(*)
            </td>
            <td>
                <asp:DropDownList CssClass="tittleprecios03" ID="lstProveedor" runat="server">
                </asp:DropDownList><br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Debe seleccionar un Genero"
                    ControlToValidate="lstProveedor" CssClass="tittleprecios03" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>

        </tr>




<%--  Datos Particulares del Tipo de Producto --%>

        <tr>
            <td class="tittleprecios03" align="left" width="100">
                Genero(*)
            </td>
            <td>
                <asp:DropDownList CssClass="tittleprecios03" ID="lstGenero" runat="server">
                </asp:DropDownList><br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Debe seleccionar un Genero"
                    ControlToValidate="lstGenero" CssClass="tittleprecios03" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td class="tittleprecios03" align="left" width="100">
                Periodicidad(*)
            </td>
            <td>
                <asp:DropDownList CssClass="tittleprecios03" ID="lstPeriodicidad" runat="server">
                </asp:DropDownList><br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Debe seleccionar una Periodicidad"
                    ControlToValidate="lstPeriodicidad" CssClass="tittleprecios03" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>


        <tr>
            <td class="tittleprecios03" align="left" width="100">
                Precio(*)
            </td>
            <td align="left" width="150">
                <asp:TextBox ID="txtPrecio" runat="server" CssClass="tittleprecios03" Text="<%# Entity.Precio %>"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Debe ingresar el Precio"
                    ControlToValidate="txtPrecio" CssClass="tittleprecios03" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>


        <tr>
            <td class="tittleprecios03" align="left" width="100">
                Cantidad de Entregas(*)
            </td>
            <td align="left" width="150">
                <asp:TextBox ID="txtCantidad" runat="server" CssClass="tittleprecios03" Text="<%# Entity.CantidadEntregas %>"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Debe ingresar el Cantidad de Entregas"
                    ControlToValidate="txtCantidad" CssClass="tittleprecios03" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>




<%--  Control de Botones --%>

       <tr>
            <td colspan="2" style="height: 24px">
                <br />
                <asp:Button CssClass="adminbutton" ID="btnGuardar" runat="server" Text="Guardar"
                    OnClick="btnGuardar_Click" />&nbsp;
                <asp:Button CssClass="adminbutton" ID="btnCancelar" runat="server" Text="Cancelar"
                    OnClick="btnCancelar_Click" CausesValidation="False" />&nbsp;
                <asp:Button CssClass="adminbutton" ID="btnEliminar" runat="server" Text="Eliminar" 
                   OnClick="btnEliminar_Click" CausesValidation="False" OnClientClick="javascript:return confirm('Desea eliminar la Coleccion?');"/> 
            </td>
        </tr>




</table>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphReserva" runat="server">
</asp:Content>
