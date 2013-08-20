<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Admin.Master" AutoEventWireup="true"
    CodeBehind="ListadoVenta.aspx.cs" Inherits="Dyn.Web.Admin.ListadoVenta" %>

<%@ MasterType VirtualPath="~/Masters/Admin.Master" %>
<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="act" %>
<%@ Register Src="../controls/Login.ascx" TagName="Login" TagPrefix="uc2" %>
<%@ Register Src="../controls/MenuAdminCategoria.ascx" TagName="MenuAdmin" TagPrefix="uc1" %>
<%@ Register Src="../controls/Date.ascx" TagName="Date" TagPrefix="ucDate" %>
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
                    <td width="100" class="tittleprecios03" align="left" valign="middle">
                        Fecha inicial:
                    </td>
                    <td width="150" align="left" valign="middle">
                        <ucDate:Date ID="calFechaInicial" runat="server" />
                    </td>
                    <td width="100" class="tittleprecios03" align="left" valign="middle">
                        Fecha final:
                    </td>
                    <td width="150" align="left" valign="middle">
                        <ucDate:Date ID="calFechaFinal" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        &nbsp;
                    </td>
                    <td align="left">
                        <asp:Button ID="btnBuscar" CssClass="adminbutton" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
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
                               <%-- <td width="233" class="tittleproducto">
                                    Cliente
                                    <br />
                                    <hr />
                                </td>--%>
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
                                            <%--<td width="233">
                                                <asp:Label ID="lblCliente" CssClass="tittleprecios03" Text='<%# Eval("NombreCliente") %>'
                                                    runat="server"></asp:Label>
                                            </td>--%>
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
