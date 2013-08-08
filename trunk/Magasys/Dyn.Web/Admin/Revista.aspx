<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Admin.Master" AutoEventWireup="true"
    CodeBehind="Revista.aspx.cs" Inherits="Dyn.Web.Admin.Revista" %>

<%@ MasterType VirtualPath="~/Masters/Admin.Master" %>
<%@ Register Src="../controls/Login.ascx" TagName="Login" TagPrefix="uc2" %>
<%@ Register Src="../controls/MenuAdminCategoria.ascx" TagName="MenuAdmin" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphCentral" runat="server">
    <table width="100%" cellpadding="0" cellspacing="5" border="0">
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
                Descripci&oacute;n(*)
            </td>
            <td>
                <asp:TextBox ID="txtDescripcion" runat="server" Height="100px" Width="400px" CssClass="tittleprecios03"
                    Text="<%# Entity.Descripcion %>" TextMode="MultiLine"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="rfvDescripcion" runat="server" ErrorMessage="Debe ingresar la descripci&oacute;n"
                    ControlToValidate="txtDescripcion" CssClass="tittleprecios03" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="tittleprecios03" align="left" width="100">
                Proveedor
            </td>
            <td align="left" width="150">
                <asp:DropDownList CssClass="tittleprecios03" ID="lstProveedor" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="tittleprecios03" align="left" width="100">
                D&iacute;a de semana(*)
            </td>
            <td align="left" width="150">
                <asp:TextBox ID="txtDiaSemana" runat="server" CssClass="tittleprecios03" Text="<%# Entity.DiaSemana %>"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="rfvDiaSemana" runat="server" ErrorMessage="Debe ingresar el d&iacute;a de la semana"
                    ControlToValidate="txtDiaSemana" CssClass="tittleprecios03" Display="Dynamic"
                    ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td class="tittleprecios03" align="left" width="100">
                Periodicidad
            </td>
            <td align="left" width="150">
                <asp:DropDownList CssClass="tittleprecios03" ID="lstPeriodicidad" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="tittleprecios03" align="left" width="100">
                G&eacute;nero
            </td>
            <td align="left" width="150">
                <asp:DropDownList CssClass="tittleprecios03" ID="lstGenero" runat="server">
                </asp:DropDownList>
            </td>
            <td class="tittleprecios03" align="left">
                Precio(*)
            </td>
            <td align="left" width="150">
                <asp:TextBox ID="txtPrecio" runat="server" CssClass="tittleprecios03" Text="<%# Entity.Precio %>"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="rfvPrecio" runat="server" ErrorMessage="Debe ingresar el precio"
                    ControlToValidate="txtPrecio" CssClass="tittleprecios03" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="height: 24px">
                <br />
                <asp:Button CssClass="adminbutton" ID="btnGuardar" runat="server" Text="Guardar"
                    OnClick="btnGuardar_Click" />&nbsp;
                <asp:Button CssClass="adminbutton" ID="btnCancelar" runat="server" Text="Cancelar"
                    OnClick="btnCancelar_Click" CausesValidation="False" />&nbsp;
                <asp:Button CssClass="adminbutton" ID="btnEliminar" runat="server" Text="Eliminar"
                    OnClick="btnEliminar_Click" CausesValidation="False" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphReserva" runat="server">
</asp:Content>
