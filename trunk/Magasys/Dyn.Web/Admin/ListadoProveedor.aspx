<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Admin.Master" AutoEventWireup="true" CodeBehind="ListadoProveedor.aspx.cs" Inherits="Dyn.Web.Admin.ListadoProveedor" %>
<%@ MasterType VirtualPath="~/Masters/Admin.Master" %>

<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="act" %>
<%@ Register src="../controls/Login.ascx" tagname="Login" tagprefix="uc2" %>
<%@ Register src="../controls/MenuAdminCategoria.ascx" tagname="MenuAdmin" tagprefix="uc1" %>


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
                        Listado de proveedores</h2>
                    </td>
                </tr>
                <tr>
                    <td width="233" class="tittleprecios03" align="left" valign="middle">
                        Nombre de proveedor:
                    </td>
                    <td width="234" align="left" valign="middle">
                        <asp:TextBox ID="txtNombreProveedor" runat="server" CssClass="tittleprecios03" ValidationGroup="busqueda" Width="234"></asp:TextBox><br />
                       <%-- <act:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" MinimumPrefixLength="1"
                            TargetControlID="txtNombreProveedor" ServicePath="~/WebService/AutoComplete.asmx"
                            ServiceMethod="" CompletionInterval="1000" CompletionSetCount="12"
                            UseContextKey="True">
                        </act:AutoCompleteExtender>--%>
                    </td>
                    <td width="233" align="left">
                        <asp:Button ID="btnBuscar" CssClass="adminbutton" runat="server" Text="Buscar" OnClick="btnBuscar_Click"
                            ValidationGroup="busqueda" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3" width="700" align="left">
                        <asp:Button ID="btnAdicionarGenero" CssClass="adminbutton" runat="server" Text="Nuevo Proveedor"
                            CausesValidation="False" onclick="btnAdicionarGenero_Click" />
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
                                <td width="233" class="tittleproducto">                                    
                                    &nbsp;
                                    <br />
                                    <hr />
                                </td>
                            </tr>
                        </table>
                        <div style="overflow: scroll; height: 295px; width: 100%">
                            <div>
                                <asp:Repeater ID="repProveedor" runat="server">
                                    <HeaderTemplate>
                                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td width="234">
                                             <asp:HyperLink ID="hpNombre" CssClass="tittleprecios03" NavigateUrl='<%# "~/Admin/Proveedor.aspx?Id=" + Eval("idProveedor") %>'
                                                    Text='<%# Eval("RazonSocial") %>' runat="server"></asp:HyperLink>
                                            </td>                                            
                                            <td width="233">
                                             <asp:Label ID="lblDescripcion" CssClass="tittleprecios03" Text='<%# Eval("Detalle") %>'
                                                    runat="server"></asp:Label>
                                            </td>
                                            <td width="233">
                                            <%--<asp:Label ID="lblEstado" CssClass="tittleprecios03" Text='<%# Enum.Parse(typeof(Dyn.Database.entities.Genero.GeneroEstado),Convert.ToString(Eval("estado"))) %>'
                                                    runat="server"></asp:Label>--%>
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
