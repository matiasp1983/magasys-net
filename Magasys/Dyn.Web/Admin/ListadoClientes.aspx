<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Admin.Master" AutoEventWireup="true" CodeBehind="ListadoClientes.aspx.cs" Inherits="Dyn.Web.Admin.ListadoClientes2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
    /*-------Custom Style------------*/
<%--    .row
    {
        display: table-row;
    }
    .cell
    {
        display: table-cell;
    }
    
    #search
    {
        display: table;
        border: dashed 1px gray;
    }
    
    .searchcell
    {
        padding: 5px;
    }
    
    #gridcontainer
    {
        display: table;
        width: 100%;
    }
    
    .gridcontainercell
    {
        padding: 5px;
    }
    
    
    #popupcontainer
    {
        display: table;
        border: solid 1px gray;
    }
    
    .popupcontainercell
    {
        padding: 5px;
        border-spacing: 5px;
    }
    
    .popupcontainertitle
    {
        background-color: Gray;
        color: White;
    }
    
    #ordereditcontainer
    {
        display: table;
        width: 100%;
    }
    
    .ordereditcell
    {
        width: 150px;
        font-weight: bold;
    }
    
    .backgroundColor
    {
        background-color: Gray; /*filter: alpha(opacity=70);
        opacity: 0.7;*/
        -moz-opacity: 0.7;
    }
    .button
    {
        font-weight: bold;
        color: #FFFFFF;
        background-color: #555555;
        border-style: solid;
        border-color: #000000;
        border-width: 1px;
    }
    .style1
    {
        font-style: normal;
        color: #7f7f7f; /*font-size: 11px;*/;
        font-weight: bold;
        height: 32px;
    }--%>
    .style1
    {
        width: 48px;
    }
    .style1
    {
        font-weight: bold;
        font-style: normal;
        color: #0e85cd;
        text-decoration: none;
        font-weight: bold;
        width: 51px;
    }
    .style25
    {
        width: 49px;
    }
    .style26
    {
        font-weight: bold;
        font-style: normal;
        color: #0e85cd;
        text-decoration: none;
        font-weight: bold;
        width: 150px;
    }
    .style27
    {
        font-weight: bold;
        font-style: normal;
        color: #0e85cd;
        text-decoration: none;
        font-weight: bold;
        width: 100px;
    }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphCentral" runat="server">
<ContentTemplate>
            <div id="popupcontainer">
                <div class="row popupcontainertitle">
                    <div>
                        Selecci&oacute;n de clientes:
                    </div>
                </div>
                <div class="row">
                    <div class="cell popupcontainercell">
                        <div id="ordereditcontainer">
                            <div class="row">
                                <div class="cell">
                                </div>
                            </div>
                            <div class="row">
                                <div class="cell">
                                    <table cellpadding="0" cellspacing="5" width="100%">
                                        <tr>
                                            <td class="tittleprecios03" align="left">
                                                <asp:Label ID="lblAlias" runat="server" Text="Alias:" Width="105px"></asp:Label>
                                                &nbsp;<asp:TextBox ID="txtAlias" runat="server" Width="150px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style1" align="left">
                                                <asp:Label ID="lblNombre" runat="server" Text="Nombre:" Width="105px"></asp:Label>
                                                &nbsp;<asp:TextBox ID="txtNombre" runat="server" Width="150px"></asp:TextBox>
                                            </td>
                                            <td class="style1" align="left">
                                                <asp:Label ID="lblApellido" runat="server" Text="Apellido:" Width="127px"></asp:Label>
                                                &nbsp;<asp:TextBox ID="txtApellido" runat="server" Width="150px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tittleprecios03" align="left">
                                                <asp:Label ID="lblTipoDoc" runat="server" Text="Tipo Documento: "></asp:Label>
                                                <asp:DropDownList CssClass="tittleprecios03" ID="ddlTipoDoc" runat="server" Width="159px">
                                                </asp:DropDownList>
                                            </td>
                                            <td class="tittleprecios03" align="left">
                                                <asp:Label ID="lblNroDoc" runat="server" Text="N&uacute;mero Documento: "></asp:Label>
                                                <asp:TextBox ID="txtNroDoc" runat="server" Width="150px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tittleprecios03" align="left">
                                                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tittleprecios03" align="left">
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                    <asp:Label ID="lblMensajeError" runat="server" Text="" ForeColor="Red"></asp:Label>
                                    <br />
                                    <br />
                                                <table width="100%">
                                                    <tr>
                                                        <td class="style25">
                                                        </td>
                                                        <td align="left" class="style27">
                                                            Nombre</td>
                                                        <td class="style27" align="left">
                                                            Apellido
                                                         </td>
                                                        <td class="style26" align="left">
                                                            Alias
                                                        </td>
                                                        <td class="style26" align="left">
                                                            Domicilio
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style25">
                                                            &nbsp;</td>
                                                        <td align="left" class="style27">
                                                            &nbsp;</td>
                                                        <td class="style27" align="left">
                                                            &nbsp;</td>
                                                        <td class="style26" align="left">
                                                            &nbsp;</td>
                                                        <td class="style26" align="left">
                                                            &nbsp;</td>
                                                    </tr>
                                                </table>

                                    <div style="overflow: scroll; height: 295px; width: 100%">
                                        <div>
                                            <asp:Repeater ID="rptClientes" runat="server">
                                                <HeaderTemplate>
                                                    <table width="100%" border="0">
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:HyperLink ID="hpNombre" CssClass="tittleprecios03" NavigateUrl='<%# "/Admin/ABMClientes.aspx?Id=" + Eval("nroCliente") %>'
                                                            Text='<%# Eval("nroCliente") %>' runat="server" Width="50"></asp:HyperLink>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label CssClass="tittleprecios03" ID="lblNombre" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "nombre")%>' Width="100"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label CssClass="tittleprecios03" ID="lblApellido" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "apellido")%>' Width="100"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label CssClass="tittleprecios03" ID="lblAlias" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "alias")%>' Width="150"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label CssClass="tittleprecios03" ID="lblDomicilio" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "domCalle")%>' Width="150"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    </table>
                                                </FooterTemplate>
                                            </asp:Repeater>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="cell" align="center">
                                    <asp:Button ID="btnCerrar" runat="server" CausesValidation="false"
                                        OnClick="btnCerrar_Click" Text="Cerrar" Width="130px" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphReserva" runat="server">
</asp:Content>
