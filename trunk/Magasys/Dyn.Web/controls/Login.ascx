<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Login.ascx.cs" Inherits="Dyn.Web.controls.Login" %>
<%@ Import Namespace="Dyn.Web.weblogic" %>
<asp:Panel ID="AuthenticatedUser" runat="server" Width="184px">
    <div style="width: 100%; height: 18px; clear: both; display: block">
        <label class="tittleproducto" style="font-size: 13px;">
            BIENVENIDO</label></div>
    <span class="tittleprecios03" style="display: block">
        <% Response.Write(CurrentUser.Instance.Usuario.NombreUsuario);%>
    </span>
    <br />
    <asp:LinkButton ID="SignOut" CssClass="tittleprecios03" runat="server" OnClick="SignOut_Click">Cerrar sesi&oacute;n</asp:LinkButton></asp:Panel>
