<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SiteLogin.ascx.cs" Inherits="Dyn.Web.controls.SiteLogin" %>
<%@ Import Namespace="Dyn.Web.weblogic" %>
<style type="text/css">
    div.art-block img
    {
        border-width: 0;
        margin: 0px;
        margin-bottom:-03px;
    }
</style>
<asp:Panel ID="AnonymousUser" BorderWidth="0" runat="server" Width="184px">
    <table width="184" border="0" cellspacing="0" cellpadding="0" style="margin-top: 5px;">
        <tr>
            <td>
                <img src="/Siteimages/BarraTituloLogin.jpg" width="184" height="33" />
            </td>
        </tr>
        <tr>
            <td height="148" align="center" valign="top" style="background: url(/images/PixelContentIzq.jpg) repeat-y;">
                <table width="140" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="tittleprecios03">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="tittleprecios03">
                            Login:<asp:RequiredFieldValidator ID="EmailRequired" runat="server" ErrorMessage="(*)"
                                ControlToValidate="txtLogin" Display="Dynamic" CssClass="tittleprecios02" ValidationGroup="AuthenticationGrop"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td height="30">
                            <asp:TextBox CssClass="inputtype1" runat="server" ID="txtLogin" ValidationGroup="AuthenticationGrop"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="tittleprecios03">
                            Contrase&ntilde;a:<asp:RequiredFieldValidator ID="PasswordRequired" runat="server"
                                ErrorMessage="(*)" ControlToValidate="txtUserPassword" CssClass="tittleprecios02"
                                Display="Dynamic" ValidationGroup="AuthenticationGrop"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td height="30">
                            <asp:TextBox TextMode="Password" runat="server" ID="txtUserPassword" ValidationGroup="AuthenticationGrop" /><br />
                            <asp:CustomValidator runat="server" ID="UserNotvalid" ErrorMessage="Usuario o password no valido"
                                Display="Dynamic" ForeColor="" ValidationGroup="AuthenticationGrop" CssClass="tittleprecios02" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td height="24" align="center" valign="middle">
                            <asp:Button ID="UserLogin" runat="server" OnClick="UserLogin_ServerClick" CssClass="adminbutton"
                                Text="Iniciar sesión" ValidationGroup="AuthenticationGrop" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td height="0" align="left" valign="top" style="margin-bottom: 5px;">
                <img alt="TopInferiorContentIzq.jpg" src="/images/TopInferiorContentIzq.jpg" width="184" height="5" style="margin-bottom: 9px;"/>
            </td>
        </tr>
    </table>
</asp:Panel>
&nbsp;
<asp:Panel ID="AuthenticatedUser" runat="server" Width="184px">
    <div style="width: 100%; height: 10px; clear: both; display: block">
        <label class="tittleproducto">
            BIENVENIDO</label></div>
    <br />
    <span class="tittleprecios03" style="display: block">
        <% Response.Write(CurrentUser.Instance.Usuario.NombreUsuario);%>
    </span>
    <asp:LinkButton ID="SignOut" CssClass="tittleprecios03" runat="server" OnClick="SignOut_Click">Cerrar sesi&oacute;n</asp:LinkButton></asp:Panel>
