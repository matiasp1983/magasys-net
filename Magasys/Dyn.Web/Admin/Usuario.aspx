<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Admin.Master" AutoEventWireup="true"
    CodeBehind="Usuario.aspx.cs" Inherits="Dyn.Web.Admin.Usuario" %>

<%@ MasterType VirtualPath="~/Masters/Admin.Master" %>
<%@ Register Src="../controls/Login.ascx" TagName="Login" TagPrefix="uc2" %>
<%@ Register Src="../controls/MenuAdminCategoria.ascx" TagName="MenuAdmin" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphCentral" runat="server">
    <table width="100%" cellpadding="0" cellspacing="5" border="0">
        <tr>
            <td align="left" class="tittleprecios03">
                Nombre:
            </td>
            <td align="left">
                <asp:TextBox ID="txtNombre" CssClass="tittleprecios03" Text="<%# Entity.nombres %>"
                    MaxLength="50" runat="server"></asp:TextBox><br />
                <asp:RequiredFieldValidator Display="Dynamic" ID="rfvNombres" runat="server" ControlToValidate="txtNombres"
                    CssClass="tittleprecios02" ErrorMessage="Debe ingresar  su nombre"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="left" class="tittleprecios03">
                Apellido:
            </td>
            <td align="left">
                <asp:TextBox ID="txtApellido" CssClass="tittleprecios03" Text="<%# Entity.apellidos%>"
                    MaxLength="50" runat="server"></asp:TextBox><br />
                <asp:RequiredFieldValidator Display="Dynamic" CssClass="tittleprecios02" ID="rfvApellidos"
                    runat="server" ControlToValidate="txtApellidos" ErrorMessage="Debe ingresar su apellido"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="left" class="tittleprecios03">
                Tipo Documento:
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlTipoDoc" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="left" class="tittleprecios03">
                N&uacute;mero Documento:
            </td>
            <td align="left">
                <asp:TextBox ID="txtNroDoc" CssClass="tittleprecios03" Text="<%# Entity.apellidos%>"
                    runat="server"></asp:TextBox><br />
                <asp:RequiredFieldValidator Display="Dynamic" CssClass="tittleprecios02" ID="rfvNroDoc"
                    runat="server" ControlToValidate="txtNroDoc" ErrorMessage="Debe ingresar su N&uacute;mero Documento"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cvPrecio" runat="server" ErrorMessage="Debe ingresar N&uacute;mero Documento correcto"
                    Display="Dynamic" Operator="DataTypeCheck" ControlToValidate="txtNroDoc" CssClass="tittleprecios03"
                    Type="Integer" ForeColor="Red"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td align="left" class="tittleprecios03">
                Login:
            </td>
            <td align="left">
                <asp:TextBox ID="txtLogin" CssClass="tittleprecios03" runat="server" Text="<%# Entity.login %>"></asp:TextBox><br />
                <asp:RequiredFieldValidator Display="Dynamic" ID="rfvLogin" CssClass="tittleprecios02"
                    runat="server" ControlToValidate="txtLogin" ErrorMessage="Debe ingresar su login"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="left" class="tittleprecios03">
                Rol:
            </td>
            <td align="left">
                <asp:DropDownList ID="lstRol" runat="server">
                    <asp:ListItem Value="Usuario">Usuario</asp:ListItem>
                    <asp:ListItem Value="Administrador">Administrador</asp:ListItem>
                    <asp:ListItem>Empleado</asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="lblRolText" runat="server" Text="Usuario" class="tittleprecios03" Enabled="false"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" class="tittleprecios03">
                Password:
            </td>
            <td align="left">
                <asp:TextBox ID="txtPassword" TextMode="Password" CssClass="tittleprecios03" runat="server"></asp:TextBox><br />
                <asp:RequiredFieldValidator Display="Dynamic" CssClass="tittleprecios02" ID="rfvPassword"
                    runat="server" ErrorMessage="Debe ingresar el password" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                <asp:CompareValidator Display="Dynamic" CssClass="tittleprecios02" ID="cvPassword"
                    runat="server" ControlToCompare="txtRepetirPassword" ControlToValidate="txtPassword"
                    ErrorMessage="El password no coincide"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td align="left" class="tittleprecios03">
                Repetir Password:
            </td>
            <td align="left">
                <asp:TextBox ID="txtRepetirPassword" CssClass="tittleprecios03" TextMode="Password"
                    runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="left" colspan="2">
                <asp:Button ID="Aceptar" CssClass="adminbutton" runat="server" Text="Aceptar" OnClick="Aceptar_Click" />&nbsp;
                <asp:Button ID="btnCancelar" CssClass="adminbutton" runat="server" Text="Cancelar"
                    CausesValidation="False" OnClick="btnCancelar_Click" />
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
    <asp:UpdatePanel ID="upMenuAdmin" runat="server">
        <ContentTemplate>
            <uc1:MenuAdmin ID="MenuAdmin1" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
