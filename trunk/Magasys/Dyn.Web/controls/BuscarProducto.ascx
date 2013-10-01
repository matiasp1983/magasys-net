<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BuscarProducto.ascx.cs"
    Inherits="Dyn.Web.controls.BuscarProducto" %>
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
<asp:UpdatePanel ID="uplProducto" runat="server">
    <contenttemplate>
<table>
    <tr>
        <td>
            <asp:Label ID="lblidProducto" runat="server" Text="C&oacute;digo Producto:" CssClass="tittleprecios03"></asp:Label><br />
            
        </td>
        <td>
            &nbsp;<asp:Label ID="lblidProductoText" runat="server" CssClass="tittleprecios03"></asp:Label><br />
        </td>
        <td>
            &nbsp;<asp:Button ID="btnBuscarProducto" runat="server" Text="Buscar Productos" OnClick="btnBuscarProducto_Click" />
        </td>
    </tr>
    <tr>
    <td><asp:Label ID="lblNombre" runat="server" Text="Nombre:" CssClass="tittleprecios03"></asp:Label></td>
    <td> &nbsp;<asp:Label ID="lblNombreText" runat="server" Text="" CssClass="tittleprecios03"></asp:Label></td>    
    </tr>
</table>
</contenttemplate>
</asp:UpdatePanel>
<asp:HiddenField ID="hfProducto" runat="server" />
<act:ModalPopupExtender ID="mpeProducto" runat="server" PopupControlID="panelProducto"
    TargetControlID="hfProducto" BackgroundCssClass="backgroundColor">
</act:ModalPopupExtender>
<asp:Panel ID="panelProducto" runat="server" BackColor="White">
    <asp:UpdatePanel ID="upProducto" runat="server">
        <ContentTemplate>
            <div id="popupcontainer">
                <div class="row popupcontainertitle">
                    <div class="cell popupcontainercell">
                        Selecci&oacute;n de Productos:
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
                                                <asp:Label ID="lblNombreProd" runat="server" Text="Nombre del producto:" Width="140px"></asp:Label>
                                                &nbsp;<asp:TextBox ID="txtNombreProd" runat="server" Width="150px"></asp:TextBox>
                                            </td>
                                            <td class="tittleprecios03" align="left">
                                                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tittleprecios03" align="left">
                                                <asp:Label ID="lblProveedor" runat="server" Text="Proveedor: " Width="145px"></asp:Label>
                                                <asp:DropDownList CssClass="tittleprecios03" ID="ddlProveedor" runat="server" Width="159px">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:Label ID="lblMensajeError" runat="server" Text="" ForeColor="Red"></asp:Label>
                                    <br />
                                    <table style="background-color: #006CCC; width: 412px;">
                                        <tr>
                                            <td class="tittleproducto">
                                                &nbsp; &nbsp;
                                            </td>
                                            <td class="tittleproducto" style="background-color: #006CCC; color: White" 
                                                width="100">
                                                <table style="width: 200px">
                                                    <tr>
                                                        <td>
                                                            Nombre
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td class="tittleproducto" style="background-color: #006CCC; color: White">
                                                Precio<br />
                                                unitario
                                            </td>
                                            <td class="tittleproducto" style="background-color: #006CCC; color: White">
                                                Stock
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                    <div style="overflow: scroll; height: 295px; width: 100%">
                                        <div>
                                            <asp:Repeater ID="rptProductos" runat="server">
                                                <HeaderTemplate>
                                                    <table width="100%" style="background-color: #8ABAFF" border="0">
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr>
                                                        <td>
                                                            <asp:RadioButton ID="rdbProductoSeccionado" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "idProducto")%>'
                                                                Font-Size="0px" OnCheckedChanged="rdbProductoSeccionado_OnCheckedChanged" AutoPostBack="true" />
                                                        </td>
                                                        <td>
                                                            <asp:Label CssClass="tittleprecios03" ID="lblNombre" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "nombre")%>' Width="125"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblPesosPrecioUnitario" runat="server" Text="Label" CssClass="tittleprecios03">$ </asp:Label><asp:Label
                                                                CssClass="tittleprecios03" ID="lblPrecioUnitario" runat="server" Text='<%#String.Format("{0:0.00}",DataBinder.Eval(Container.DataItem, "precio"))%>'></asp:Label>
                                                        </td>
                                                        <td style="width: 40px;" align="center">
                                                            <asp:Label CssClass="tittleprecios03" ID="lblStock" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "cantidadDisponible")%>'></asp:Label>
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
                                        Style="margin-right: 10px;" Text="Agregar producto" Width="130px" />
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
