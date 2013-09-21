<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Admin.Master" AutoEventWireup="true" CodeBehind="ListadoClientes.aspx.cs" Inherits="Dyn.Web.Admin.ListadoClientes" %>
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
                            Listado de Clientes</h2>
                    </td>
                </tr>
                <tr>
                    <td width="100" align="left" class="tittleprecios03">
                        Tipo Documento
                    </td>
                    <td align="left" class="style3">
                        <asp:DropDownList ID="lstTipoDoc" runat="server" CssClass="tittleprecios03" 
                            DataSourceID="DSTipoDocumento" DataTextField="nombre" 
                            DataValueField="idTipoDocumento" 
                            onselectedindexchanged="lstTipoDoc_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="DSTipoDocumento" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:MagasysConnectionString %>" 
                            SelectCommand="SELECT * FROM [TipoDocumento]"></asp:SqlDataSource>
                    </td>
                    <td align="left" class="tittleprecios03" width="100">
                        Numero Documento</td>
                    <td align="left" class="style1">
                        <asp:CompareValidator ID="cvDocumento" runat="server" 
                            ControlToValidate="txtNroDocumento" CssClass="tittleprecios03" 
                            Display="Dynamic" ErrorMessage="Debe ingresar un numero" ForeColor="Red" 
                            Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                        <asp:TextBox ID="txtNroDocumento" runat="server" CssClass="tittleprecios03" 
                            MaxLength="10"></asp:TextBox>
                        <br />
                        
                    </td>
                    <td width="233" align="left">
                        <asp:Button ID="btnBuscar" CssClass="adminbutton" runat="server" Text="Buscar" OnClick="btnBuscar_Click"
                            ValidationGroup="busqueda" />
                    </td>
                </tr>
                <tr>
                    <td align="left" class="tittleprecios03" width="100">
                        Nombre</td>
                    <td align="left" class="style3">
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="tittleprecios03" 
                            MaxLength="50"></asp:TextBox>
                        <br />
                        
                    </td>
                    <td align="left" class="tittleprecios03" width="100">
                        Apellido</td>
                    <td align="left" class="style1">
                        <asp:TextBox ID="txtApellido" runat="server" CssClass="tittleprecios03" 
                            MaxLength="50"></asp:TextBox>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td align="left" class="tittleprecios03" width="100">
                        Alias</td>
                    <td align="left" class="style3">
                        <asp:TextBox ID="txtAlias" runat="server" CssClass="tittleprecios03" 
                            MaxLength="100"></asp:TextBox>
                        <br />
                    </td>
                    <td>
                    
                    </td>

                    <td>
                    
                    </td>

                    <td width="700" align="left">
                        <asp:Button ID="btnAdicionarGenero" CssClass="adminbutton" runat="server" Text="Adicionar Cliente"
                            CausesValidation="False" onclick="btnAdicionarCliente_Click" />
                    </td>
                </tr>




                
                <tr>
                    <td align="left" class="tittleprecios03" width="100">
                        &nbsp;</td>
                    <td align="left" class="style3">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td align="left" width="700">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="left" class="tittleprecios03" width="100">
                        &nbsp;</td>
                    <td align="left" class="style3" colspan="3">
                        <asp:GridView ID="gvClientes" runat="server" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                                <asp:BoundField DataField="DomicilioCalle" HeaderText="Calle" />
                                <asp:BoundField DataField="DomicilioNro" HeaderText="Numero" />
                            </Columns>
                        </asp:GridView>
                    </td>
                    <td align="left" width="700">
                        &nbsp;</td>
                </tr>




                
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div style="clear: both">
    </div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphReserva" runat="server">
</asp:Content>
