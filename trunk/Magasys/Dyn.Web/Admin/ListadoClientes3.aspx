<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Admin.Master" AutoEventWireup="true"
    CodeBehind="ListadoClientes3.aspx.cs" Inherits="Dyn.Web.Admin.ListadoClientes" %>

<%@ MasterType VirtualPath="~/Masters/Admin.Master" %>
<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="act" %>
<%@ Register Src="../controls/Login.ascx" TagName="Login" TagPrefix="uc2" %>
<%@ Register Src="../controls/MenuAdminCategoria.ascx" TagName="MenuAdmin" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 225px;
        }
    </style>
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
                            Listado de Clientes</h2>
                    </td>
                </tr>
                <tr>
                    <td width="100" align="left" class="tittleprecios03">
                        Tipo Documento
                    </td>
                    <td align="left" class="style1">
                        <asp:DropDownList ID="lstTipoDoc" runat="server" CssClass="tittleprecios03" OnSelectedIndexChanged="lstTipoDoc_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td align="left" class="tittleprecios03" width="100">
                        Numero Documento
                    </td>
                    <td align="left" class="style1">
                        <asp:CompareValidator ID="cvDocumento" runat="server" ControlToValidate="txtNroDocumento"
                            CssClass="tittleprecios03" Display="Dynamic" ErrorMessage="Debe ingresar un numero"
                            ForeColor="Red" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                        <asp:TextBox ID="txtNroDocumento" runat="server" CssClass="tittleprecios03" MaxLength="10"></asp:TextBox>
                        <br />
                    </td>
                    <td width="233" align="left">
                        <asp:Button ID="btnBuscar" CssClass="adminbutton" runat="server" Text="Buscar" OnClick="btnBuscar_Click"
                            ValidationGroup="busqueda" />
                    </td>
                </tr>
                <tr>
                    <td align="left" class="tittleprecios03" width="100">
                        Nombre
                    </td>
                    <td align="left" class="style1">
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="tittleprecios03" MaxLength="50"></asp:TextBox>
                        <br />
                    </td>
                    <td align="left" class="tittleprecios03" width="100">
                        Apellido
                    </td>
                    <td align="left" class="style1">
                        <asp:TextBox ID="txtApellido" runat="server" CssClass="tittleprecios03" MaxLength="50"></asp:TextBox>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td align="left" class="tittleprecios03" width="100">
                        Alias
                    </td>
                    <td align="left" class="style1">
                        <asp:TextBox ID="txtAlias" runat="server" CssClass="tittleprecios03" MaxLength="100"></asp:TextBox>
                        <br />
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td width="700" align="left">
                        <asp:Button ID="btnAdicionarGenero" CssClass="adminbutton" runat="server" Text="Adicionar Cliente"
                            CausesValidation="False" OnClick="btnAdicionarCliente_Click" />
                    </td>
                </tr>
                <tr>
                    <td align="left" class="tittleprecios03" width="100">
                        &nbsp;
                    </td>
                    <td align="left" class="style1">
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td align="left" width="700">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="left" class="tittleprecios03" width="100">
                        &nbsp;
                    </td>
                    <td align="left" class="style3" colspan="3">
                        <asp:GridView ID="gvClientes" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            ForeColor="#333333" GridLines="None" 
                            onselectedindexchanging="gvClientes_SelectedIndexChanging">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:HyperLinkField DataTextField="NroCliente" HeaderText="NroCliente" />
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                                <asp:BoundField DataField="Alias" HeaderText="Alias" />
                                <asp:BoundField DataField="DomicilioCalle" HeaderText="Calle" />
                                <asp:BoundField DataField="DomicilioNro" HeaderText="Numero" />
                                <asp:CommandField ShowSelectButton="True" />
                            </Columns>
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>
                    </td>
                    <td align="left" width="700">
                        &nbsp;
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
