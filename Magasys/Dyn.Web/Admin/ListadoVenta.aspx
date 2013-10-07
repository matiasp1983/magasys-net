<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Admin.Master" AutoEventWireup="true"
    CodeBehind="ListadoVenta.aspx.cs" Inherits="Dyn.Web.Admin.ListadoVenta" %>

<%@ MasterType VirtualPath="~/Masters/Admin.Master" %>
<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="act" %>
<%@ Register Src="../controls/Login.ascx" TagName="Login" TagPrefix="uc2" %>
<%@ Register Src="../controls/MenuAdminCategoria.ascx" TagName="MenuAdmin" TagPrefix="uc1" %>
<%@ Register Src="../controls/Date.ascx" TagName="Date" TagPrefix="uc3" %>
<%@ Register Src="../controls/BuscarClientes.ascx" TagName="BuscarClientes" TagPrefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphCentral" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table cellpadding="0" width="100%" cellspacing="5" border="0">
                <tr>
                    <td colspan="3">
                        <cc1:CollectionPager ID="CollectionPager" runat="server" PageSize="100" PagingMode="QueryString"
                            LabelText="P&aacute;gina:" NextText="Siguiente »" ResultsFormat="Resultados {0}-{1} (de {2})"
                            BackText="« Anterior" CurrentPage="1" MaxPages="10" SliderSize="10" IgnoreQueryString="False"
                            QueryStringKey="Page">
                        </cc1:CollectionPager>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" class="tittleproducto" width="700" align="left">
                        <h2>
                            Listado de ventas
                        </h2>
                    </td>
                </tr>
                <tr>
                    <td class="tittleprecios03" align="left">
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="lblInicio" runat="server" Text="Fecha Inicial:" Width="139px"></asp:Label>
                                </td>
                                <td width="200">
                                    <uc3:Date ID="calFechaInicial" runat="server" Visible="True" />
                                </td>
                                <td>
                                    <asp:Label ID="lblFin" runat="server" Text="Fecha Final:"></asp:Label>
                                </td>
                                <td>
                                    <uc3:Date ID="calFechaFinal" runat="server" Visible="True" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" class="tittleprecios03" align="left">
                                    <asp:Label ID="lblTipoVenta" runat="server" Text="Forma de Pago:" Width="139px"></asp:Label>
                                    <asp:DropDownList ID="ddlTipoVenta" runat="server">
                                        <asp:ListItem>Cuenta corriente</asp:ListItem>
                                        <asp:ListItem>Contado</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <%--                            <tr>
                                <td colspan="4">
                                    <uc4:BuscarClientes ID="ucBuscarClientes" runat="server" />
                                </td>
                            </tr>--%>
                            <tr>
                                <td>
                                    <asp:Button ID="btnBuscar" CssClass="adminbutton" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
                                </td>
                            </tr>
                        </table>
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td colspan="3" width="700" align="left">
                        <div id="tableHeader">
                        </div>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td width="234" class="tittleproducto">
                                    C&oacute;digo de venta
                                    <br />
                                    <hr />
                                </td>
                                <td width="233" class="tittleproducto">
                                    Fecha venta
                                    <br />
                                    <hr />
                                </td>
                            </tr>
                        </table>
                        <div style="overflow: scroll; height: 295px; width: 100%">
                            <div>
                                <asp:Repeater ID="rptVenta" runat="server">
                                    <HeaderTemplate>
                                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td width="234">
                                                <asp:HyperLink ID="hpCodVenta" CssClass="tittleprecios03" NavigateUrl='<%# "~/Admin/MostrarVenta.aspx?Id=" + Eval("IdVenta") %>'
                                                    Text='<%# Eval("IdVenta") %>' runat="server"></asp:HyperLink>
                                            </td>
                                            <td width="233">
                                                <asp:Label ID="lblFechaVenta" CssClass="tittleprecios03" Text='<%# Eval("Fecha") %>'
                                                    runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </table>
                                    </FooterTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div style="clear: both">
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphReserva" runat="server">
</asp:Content>
<asp:Content ID="Content5" runat="server" ContentPlaceHolderID="cphMenu">
    <!--Control de login de ejemplo-->
    <uc2:Login ID="Login1" runat="server" />
    <br />
    <uc1:MenuAdmin ID="MenuAdmin1" runat="server" />
</asp:Content>
