<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Admin.Master" AutoEventWireup="true" CodeBehind="Proveedor.aspx.cs" Inherits="Dyn.Web.Admin.Proveedor" %>

<%@ MasterType VirtualPath="~/Masters/Admin.Master" %>
<%@ Register Src="../controls/Login.ascx" TagName="Login" TagPrefix="uc2" %>
<%@ Register Src="../controls/MenuAdminCategoria.ascx" TagName="MenuAdmin" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphCentral" runat="server">

 <table width="100%" cellpadding="0" cellspacing="5" border="0">

        <tr>
            <td class="tittleprecios03" align="left" width="100">
                CUIT(*)
            </td>
            <td align="left" width="150">
                <asp:TextBox ID="txtCuit" runat="server" CssClass="tittleprecios03" Text="<%# Entity.Cuit %>"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Debe ingresar Razon Social"
                    ControlToValidate="txtCuit" CssClass="tittleprecios03" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td class="tittleprecios03" align="left" width="100">
                Razon Social(*)
            </td>
            <td align="left" width="150">
                <asp:TextBox ID="txtRazonSocial" runat="server" CssClass="tittleprecios03" Text="<%# Entity.RazonSocial %>"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ErrorMessage="Debe ingresar Razon Social"
                    ControlToValidate="txtRazonSocial" CssClass="tittleprecios03" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td class="tittleprecios03" align="left" width="100">
                Detalle
            </td>
            <td>
                <asp:TextBox ID="txtDetalle" runat="server" Height="100px" Width="400px" CssClass="tittleprecios03"
                    Text="<%# Entity.Detalle %>" TextMode="MultiLine"></asp:TextBox><br />
            </td>
        </tr>

                <tr>
            <td class="tittleprecios03" align="left" width="100">
                Correo Electronico(*)
            </td>
            <td align="left" width="150">
                <asp:TextBox ID="txtEMail" runat="server" CssClass="tittleprecios03" Text="<%# Entity.Email %>"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Debe ingresar Razon Social"
                    ControlToValidate="txtEMail" CssClass="tittleprecios03" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td class="tittleprecios03" align="left" width="100">
                Telefono
            </td>
            <td align="left" width="150">
                <asp:TextBox ID="txtTelefono" runat="server" CssClass="tittleprecios03" Text="<%# Entity.Telefono %>"></asp:TextBox><br />
            </td>
        </tr>

        <tr>
            <td class="tittleprecios03" align="left" width="100">
                
            </td>
        </tr>
        <tr>
            <td class="tittleprecios03" align="left" width="100">
                Direccion
            </td>
        </tr>

        <tr>
            <td class="tittleprecios03" align="left" width="100">
                Calle
            </td>
            <td align="left" width="400">
                <asp:TextBox ID="txtCalle" runat="server" CssClass="tittleprecios03" Text="<%# Entity.Nombre %>"></asp:TextBox><br />
            </td>
        </tr>

                <tr>
            <td class="tittleprecios03" align="left" width="100">
                Numero
            </td>
            <td align="left" width="400">
                <asp:TextBox ID="txtNumero" runat="server" CssClass="tittleprecios03" Text="<%# Entity.Nombre %>"></asp:TextBox><br />
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
