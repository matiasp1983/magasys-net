<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WUCBuscarProducto.ascx.cs" Inherits="Dyn.Web.controls.WUCBuscarProducto" %>

<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="act" %>
<%@ Register src="Login.ascx" tagname="Login" tagprefix="uc2" %><%@ Register src="MenuAdminCategoria.ascx" tagname="MenuAdmin" tagprefix="uc1" %>


    <style type="text/css">
        .style1
        {
            font-style: normal;
            color: #7f7f7f;
            font-weight: bold;
            height: 45px;
            width: 194px;
        }
        .style2
        {
            height: 45 px;
        }
        .style3
        {
            width: 37px;
        }
        .style5
        {
            height: 45 px;
            width: 232px;
        }
    </style>

        <table width="100%">
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
                            Listado de Productos</h2>
                    </td>
                </tr>
            <tr>
                    <td class="style1" align="left" valign="middle">
                        Nombre Producto:
                    </td>
                    <td align="left" valign="middle" class="style5">
                        <asp:TextBox ID="txtNombreProducto" runat="server" CssClass="tittleprecios03" ValidationGroup="busqueda"
                            Width="234"></asp:TextBox><br />
                        <act:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" MinimumPrefixLength="1"
                            TargetControlID="txtNombreProducto" ServicePath="~/WebService/AutoComplete.asmx"
                            ServiceMethod="InformacionAutocompletarRevistasPorProveedor" CompletionInterval="1000"
                            CompletionSetCount="12" UseContextKey="True">
                        </act:AutoCompleteExtender>
                    </td>
                    <td width="233" align="left" class="style2">
                        <%-- <asp:Button ID="Button1" CssClass="adminbutton" runat="server" Text="Buscar" OnClick="btnBuscar_Click"
                            ValidationGroup="busqueda" />--%>
                            <asp:Button ID="Button2" CssClass="adminbutton" runat="server" Text="Buscar" 
                            ValidationGroup="busqueda" onclick="Button2_Click" />
                    </td>
                </tr>
                                <tr>
                    <td align="left" colspan="2">
                       <table width="100%" border="0">
                            <tr>
                                <td class="style3">
                                    &nbsp;</td>
                                <td width="233" class="tittleproducto" style="width: 466px">
                                    <asp:GridView ID="gvProductos" runat="server" AutoGenerateColumns="False" 
                                        Width="450px">
                                        <Columns>
                                            <asp:BoundField HeaderText="Nombre" />
                                            <asp:BoundField HeaderText="Descripcion" />
                                            <asp:CommandField ShowSelectButton="True" />
                                        </Columns>
                                    </asp:GridView>
                                </td>
                                <%-- <td width="233" class="tittleproducto">
                                    Cantidad
                                    <br />
                                    <hr />
                                </td>--%>
                            </tr>
                        </table>
                            
                    </td>
                </tr>
                </table>

