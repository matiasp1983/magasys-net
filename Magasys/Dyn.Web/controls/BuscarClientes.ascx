<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BuscarClientes.ascx.cs"
    Inherits="Dyn.Web.controls.BuscarClientes" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="act" %>
<style type="text/css">
    /*-------Custom Style------------*/
    .row
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
</style>
<asp:UpdatePanel ID="uplCliente" runat="server">
    <contenttemplate>
<table>
    <tr>
        <td>
            <asp:Label ID="lblNroCliente" runat="server" Text="N&uacute;mero de Cliente:" CssClass="tittleprecios03"></asp:Label><br />
            
        </td>
        <td>
            &nbsp;<asp:Label ID="lblNroClienteText" runat="server" CssClass="tittleprecios03"></asp:Label><br />
           
        </td>
        <td>
            &nbsp;<asp:Button ID="btnBuscarClientes" runat="server" Text="Buscar" OnClick="btnBuscarClientes_Click" />
        </td>
    </tr>
    <tr>
    <td><asp:Label ID="lblNombreApellido" runat="server" Text="Nombre y apellido:" CssClass="tittleprecios03"></asp:Label></td>
    <td> &nbsp;<asp:Label ID="lblNombreApellidoText" runat="server" Text="" CssClass="tittleprecios03"></asp:Label></td>    
    </tr>
</table>
</contenttemplate>
</asp:UpdatePanel>
<asp:HiddenField ID="hfClientes" runat="server" />
<act:ModalPopupExtender ID="mpeClientes" runat="server" PopupControlID="panelClientes"
    TargetControlID="hfClientes" BackgroundCssClass="backgroundColor">
</act:ModalPopupExtender>
<asp:Panel ID="panelClientes" runat="server" BackColor="White">
    <asp:UpdatePanel ID="upClientes" runat="server">
        <ContentTemplate>
            <div id="popupcontainer">
                <div class="row popupcontainertitle">
                    <div class="cell popupcontainercell">
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
                                            <td class="tittleprecios03" align="left">
                                                <asp:Label ID="lblNombre" runat="server" Text="Nombre:" Width="105px"></asp:Label>
                                                &nbsp;<asp:TextBox ID="txtNombre" runat="server" Width="150px"></asp:TextBox>
                                            </td>
                                            <td class="tittleprecios03" align="left">
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
                                    </table>
                                    <asp:Label ID="lblMensajeError" runat="server" Text="" ForeColor="Red"></asp:Label>
                                    <br />
                                    <br />
                                    <table style="background-color: #006CCC; width: 100%;">
                                        <tr>
                                            <td class="tittlecliente">
                                                &nbsp; &nbsp;
                                            </td>
                                            <td class="tittlecliente" style="background-color: #006CCC; color: White">
                                                <table style="width: 70px">
                                                    <tr>
                                                        <td>
                                                            Nombre
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td class="tittlecliente" style="background-color: #006CCC; color: White">
                                                Apellido
                                            </td>
                                            <td class="tittlecliente" style="background-color: #006CCC; color: White" align="center">
                                                Alias
                                            </td>
                                            <td class="tittlecliente" style="background-color: #006CCC; color: White" align="center">
                                                Domicilio
                                            </td>
                                        </tr>
                                    </table>
                                    <div style="overflow: scroll; height: 295px; width: 100%">
                                        <div>
                                            <asp:Repeater ID="rptClientes" runat="server">
                                                <HeaderTemplate>
                                                    <table width="100%" style="background-color: #8ABAFF" border="0">
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr>
                                                        <td>
                                                            <asp:RadioButton ID="rdbClienteSeccionado" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "nroCliente")%>'
                                                                Font-Size="0px" OnCheckedChanged="rdbClienteSeccionado_OnCheckedChanged" AutoPostBack="true" />
                                                        </td>
                                                        <td>
                                                            <asp:Label CssClass="tittleprecios03" ID="lblNombre" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "nombre")%>'></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label CssClass="tittleprecios03" ID="lblApellido" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "apellido")%>'></asp:Label>
                                                        </td>
                                                        <td style="width: 40px;" align="center">
                                                            <asp:Label CssClass="tittleprecios03" ID="lblAlias" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "alias")%>'></asp:Label>
                                                        </td>
                                                        <td align="center">
                                                            <asp:Label CssClass="tittleprecios03" ID="lblDomicilio" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "domCalle")%>'></asp:Label>
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
                                    <asp:Button ID="btnAgregar" runat="server" CssClass="button" OnClick="btnAgregar_Click"
                                        Style="margin-right: 10px;" Text="Agregar cliente" Width="130px" />
                                    <asp:Button ID="btnCerrar" runat="server" CausesValidation="false" CssClass="button"
                                        OnClick="btnCerrar_Click" Text="Cerrar" Width="130px" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Panel>
