<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuAdmin.ascx.cs" Inherits="Dyn.Web.controls.MenuAdmin" %>
<asp:Repeater runat="server" ID="repMenuAdmin">
    <HeaderTemplate>
        <table width="184" border="0" cellspacing="0" cellpadding="0" style="margin-top: 5px;">
            <tr>
                <td>
                    <img alt="BarraTituloMenuCategorias_03.jpg" src="/images/BarraTituloMenuCategorias_03.jpg" width="184" height="59" /></td>
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td height="28" background="/images/BarraMenuCategorias_02.jpg">
                    <asp:HyperLink ID="lbtnCategoria" CssClass="tittlemenu"   NavigateUrl='<%# "/Admin/" + Eval("Pagina") + ".aspx?IdMenuCategoria=" + Eval("IdMenuCategoria")  %>' runat="server"  Text='<%# Eval("Nombre") %>'></asp:HyperLink>  
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        <tr>
            <td height="0" align="left" valign="top" style="margin-bottom: 5px;">
                <img src="/images/TopInferiorContentIzq.jpg" width="184" height="5" /></td>
        </tr>
        </table>
    </FooterTemplate>
</asp:Repeater>