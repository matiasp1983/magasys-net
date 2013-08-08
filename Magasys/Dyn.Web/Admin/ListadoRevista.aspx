<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Admin.Master" AutoEventWireup="true"
    CodeBehind="ListadoRevista.aspx.cs" Inherits="Dyn.Web.Admin.ListadoRevista" %>

<%@ MasterType VirtualPath="~/Masters/Admin.Master" %>
<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="act" %>
<%@ Register Src="../controls/Login.ascx" TagName="Login" TagPrefix="uc2" %>
<%@ Register Src="../controls/MenuAdminCategoria.ascx" TagName="MenuAdmin" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphCentral" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table width="100%" cellpadding="0" cellspacing="5">
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
                            Listado de revistas</h2>
                    </td>
                </tr>
                <tr>
                    <td width="233" class="tittleprecios03" align="left" valign="middle">
                        Nombre de proveedor:
                    </td>
                    <td width="234" align="left" valign="middle">
                        <asp:TextBox ID="txtNombreRevista" runat="server" CssClass="tittleprecios03" ValidationGroup="busqueda"
                            Width="234"></asp:TextBox><br />
                        <act:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" MinimumPrefixLength="1"
                            TargetControlID="txtNombreRevista" ServicePath="~/WebService/AutoComplete.asmx"
                            ServiceMethod="InformacionAutocompletarRevistasPorProveedor" CompletionInterval="1000"
                            CompletionSetCount="12" UseContextKey="True">
                        </act:AutoCompleteExtender>
                    </td>
                    <td width="233" align="left">
                        <asp:Button ID="btnBuscar" CssClass="adminbutton" runat="server" Text="Buscar" OnClick="btnBuscar_Click"
                            ValidationGroup="busqueda" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3" width="700" align="left">
                        <asp:Button ID="btnAdicionarRevista" CssClass="adminbutton" runat="server" Text="Adicionar Revista"
                            CausesValidation="False" OnClick="btnAdicionarRevista_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3" width="700" align="left">
                        <div id="tableHeader">
                        </div>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td width="234" class="tittleproducto">
                                    Nombre
                                    <br />
                                    <hr />
                                </td>
                                <td width="233" class="tittleproducto">
                                    Descripci&oacute;n
                                    <br />
                                    <hr />
                                </td>
                                <%-- <td width="233" class="tittleproducto">
                                    Cantidad
                                    <br />
                                    <hr />
                                </td>--%>
                                <td width="233" class="tittleproducto">
                                    Proveedor
                                    <br />
                                    <hr />
                                </td>
                            </tr>
                        </table>
                        <div style="overflow: scroll; height: 295px; width: 100%">
                            <div>
                                <asp:Repeater ID="repRevistas" runat="server">
                                    <HeaderTemplate>
                                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td width="234">
                                                <asp:HyperLink ID="hpNombre" CssClass="tittleprecios03" NavigateUrl='<%# "~/Admin/Revista.aspx?Id=" + Eval("IdRevista") %>'
                                                    Text='<%# Eval("Nombre") %>' runat="server"></asp:HyperLink>
                                            </td>
                                            <td width="233">
                                                <asp:Label ID="lblDescripcion" CssClass="tittleprecios03" Text='<%# Eval("Descripcion") %>'
                                                    runat="server"></asp:Label>
                                            </td>
                                            <%--                                            <td width="233">
                                                <asp:Label ID="lblCantidad" CssClass="tittleprecios03" Text='<%# Eval("Cantidaddisponible") %>'
                                                    runat="server"></asp:Label>
                                            </td>--%>
                                            <td width="233">
                                                <asp:Label ID="lblProveedor" CssClass="tittleprecios03" Text='<%# Eval("NombreProv") %>'
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
