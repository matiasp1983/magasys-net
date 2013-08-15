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
            width: 193px;
        }
        .style2
        {
            height: 45 px;
        }
        .style3
        {
            width: 319px;
        }
        .style4
        {
            width: 232px;
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
                    <td  align="left" valign="middle">
                        Proveedor:
                    </td>
            <td class="style4">
                <asp:DropDownList CssClass="tittleprecios03" ID="lstProveedor" runat="server">
                </asp:DropDownList><br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Debe seleccionar un Proveedor"
                    ControlToValidate="lstProveedor" CssClass="tittleprecios03" ForeColor="Red"></asp:RequiredFieldValidator>
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
                            <asp:Repeater ID="repProducto" runat="server">
                                    <HeaderTemplate>
                                        <table width="100%" border="0">
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td width="25">
                                                <asp:LinkButton ID="lnkID" CssClass="tittleprecios03" runat="server" OnClick="hpNombre_Click"
                                                    Text='<%# Eval("IdProducto") %>'></asp:LinkButton>
                                            </td>

                                             <td width="233">
                                                <asp:Label ID="lblNombre" CssClass="tittleprecios03" Text='<%# Eval("Nombre") %>'
                                                    runat="server"></asp:Label>
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
                                                <asp:Label ID="lblProveedor" CssClass="tittleprecios03" Text='<%# Eval("nomProveedor") %>'
                                                    runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </table>
                                    </FooterTemplate>
                                </asp:Repeater>
                            
                    </td>
                </tr>
                </table>

