<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Admin.Master" AutoEventWireup="true"
    CodeBehind="Diario.aspx.cs" Inherits="Dyn.Web.Admin.Diario" %>

<%@ MasterType VirtualPath="~/Masters/Admin.Master" %>
<%@ Register Src="../controls/Login.ascx" TagName="Login" TagPrefix="uc2" %>
<%@ Register Src="../controls/MenuAdminCategoria.ascx" TagName="MenuAdmin" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphCentral" runat="server">
<table width="100%" cellpadding="0" cellspacing="5" border="0">
        


<%--  Datos Comunes a Todos los Productos --%>


        <tr>
            <td class="tittleprecios03" align="left" width="110">
                Nombre(*)
            </td>
            <td align="left" width="150">
                <asp:TextBox ID="txtNombre" runat="server" CssClass="tittleprecios03" Text="<%# Entity.Nombre %>"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ErrorMessage="Debe ingresar el nombre"
                    ControlToValidate="txtNombre" CssClass="tittleprecios03" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td class="tittleprecios03" align="left" width="110">
                Descripci&oacute;n
            </td>
            <td>
                <asp:TextBox ID="txtDescripcion" runat="server" Height="100px" Width="400px" CssClass="tittleprecios03"
                    Text="<%# Entity.Descripcion %>" TextMode="MultiLine"></asp:TextBox><br />
            </td>
        </tr>

        <tr>
            <td class="tittleprecios03" align="left" width="110">
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
            <td class="tittleprecios03" align="left" width="110">
                Precio Lunes
            </td>
            <td align="left" width="150">
                <asp:TextBox ID="txtLunes" runat="server" CssClass="tittleprecios03" Text="<%# Entity.Nombre %>"></asp:TextBox><br />
            </td>
        </tr>

        <tr>
            <td class="tittleprecios03" align="left" width="110">
                Precio Martes
            </td>
            <td align="left" width="150">
                <asp:TextBox ID="txtMartes" runat="server" CssClass="tittleprecios03" Text="<%# Entity.Nombre %>"></asp:TextBox><br />
            </td>
        </tr>

        <tr>
            <td class="tittleprecios03" align="left" width="110">
                Precio Miercoles
            </td>
            <td align="left" width="150">
                <asp:TextBox ID="txtMiercoles" runat="server" CssClass="tittleprecios03" Text="<%# Entity.Nombre %>"></asp:TextBox><br />
            </td>
        </tr>

        <tr>
            <td class="tittleprecios03" align="left" width="110">
                Precio Jueves
            </td>
            <td align="left" width="150">
                <asp:TextBox ID="txtJueves" runat="server" CssClass="tittleprecios03" Text="<%# Entity.Nombre %>"></asp:TextBox><br />
            </td>
        </tr>

         <tr>
            <td class="tittleprecios03" align="left" width="110">
                Precio Viernes
            </td>
            <td align="left" width="150">
                <asp:TextBox ID="txtViernes" runat="server" CssClass="tittleprecios03" Text="<%# Entity.Nombre %>"></asp:TextBox><br />
            </td>
        </tr>

         <tr>
            <td class="tittleprecios03" align="left" width="110">
                Precio Sabado
            </td>
            <td align="left" width="150">
                <asp:TextBox ID="txtSabado" runat="server" CssClass="tittleprecios03" Text="<%# Entity.Nombre %>"></asp:TextBox><br />
            </td>
        </tr>

         <tr>
            <td class="tittleprecios03" align="left" width="110">
                Precio Domingo
            </td>
            <td align="left" width="150">
                <asp:TextBox ID="txtDomingo" runat="server" CssClass="tittleprecios03" Text="<%# Entity.Nombre %>"></asp:TextBox><br />
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
                    OnClick="btnEliminar_Click" CausesValidation="False" />
            </td>
        </tr>



</table>



</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphReserva" runat="server">
</asp:Content>
