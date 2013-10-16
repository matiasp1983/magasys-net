<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuAdminCategoria.ascx.cs" Inherits="Dyn.Web.controls.MenuAdminCategoria" %>
<asp:Repeater runat="server" ID="repMenuAdminCategoria" OnItemDataBound="repMenuAdminCategoria_ItemDataBound">
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
                
                    <asp:HyperLink ID="lbtnCategoria" NavigateUrl='<%# "/Admin/" + Eval("Pagina") + ".aspx?IdMenuCategoria=" + Eval("IdMenuCategoria") %>' runat="server" CssClass="tittlemenu" Text='<%# Eval("Nombre") %>'></asp:HyperLink>
                    <asp:Label ID="lblIdCategoria" runat="server" Text='<%# Eval("IdMenuCategoria") %>' Visible="false"></asp:Label>
                
            </td>
        </tr>
        <tr>
            <td align="center" class="tittlecategorias" background="/images/BarraMenuSubCategorias_02.jpg">
                <asp:Repeater runat="server" ID="repSubCategoria">
                    <HeaderTemplate>
                        <table width="164" border="0" cellspacing="3" cellpadding="0">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td width="17" height="28">
                                <img alt="Flecha.gif" src="/images/Flecha.gif" width="13" height="12" /></td>
                            <td width="157" class="tittlemenu" align="left">
                                <a href='<%# "/Admin/" + Eval("Pagina") + ".aspx?IdMenuCategoria=" + Eval("IdMenuCategoria") %>'>
                                    <%# Eval("Nombre").ToString() %>
                                </a>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        <tr>
            <td height="0" align="left" valign="top" style="margin-bottom: 5px;">
                <img alt="TopInferiorContentIzq.jpg" src="/images/TopInferiorContentIzq.jpg" width="184" height="5" /></td>
        </tr>
        </table>
    </FooterTemplate>
</asp:Repeater>