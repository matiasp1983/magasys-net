<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Ventas.ascx.cs" Inherits="Dyn.Web.controls.Ventas" %>
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
        background-color: Gray;
        filter: alpha(opacity=70);
        opacity: 0.7;
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
<table cellpadding="0" cellspacing="5" width="100%">
    <tr>
        <td class="tittleprecios03" align="left">
            Proveedor:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlProveedor" runat="server" Width="157px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="tittleprecios03" align="left">
            Nombre producto:
            <asp:TextBox ID="txtProducto" runat="server" Width="150px"></asp:TextBox>
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
        </td>
    </tr>
    <tr>
        <td colspan="2" class="tittleproducto" align="center">
            <br />
            Items de la venta
            <hr />
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:UpdatePanel ID="upItems" runat="server">
                <ContentTemplate>
                    <div id="tableHeader">
                    </div>
                    <table width="100%" cellpadding="0" cellspacing="0">
                        <tr>
                            <td class="tittleproducto" style="width: 155px; display: none;">
                                idProducto
                            </td>
                            <td class="tittleproducto" style="width: 300px">
                                Nombre
                            </td>
                            <td class="tittleproducto" style="width: 160px">
                                Edici&oacute;n
                            </td>
                            <td class="tittleproducto" style="width: 160px">
                                Precio unitario
                            </td>
                            <td class="tittleproducto" style="width: 160px">
                                Cantidad
                            </td>
                            <td class="tittleproducto" style="width: 160px">
                                Valor Total
                            </td>
                            <td class="tittleproducto" style="width: 160px">
                                Acci&oacute;n
                            </td>
                        </tr>
                    </table>
                    <hr />
                    <div style="overflow: scroll; height: 295px; width: 100%">
                        <div>
                            <asp:Repeater ID="rptItems" runat="server" OnItemCommand="rptItems_ItemCommand">
                                <HeaderTemplate>
                                    <table border="0" cellpadding="0" cellspacing="0">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td style="display: none;">
                                            <asp:Label CssClass="tittleprecios03" ID="lblidProducto" runat="server" Text='<%# Eval("idProducto") %>'></asp:Label>
                                        </td>
                                        <td style="width: 175px">
                                            <table style="width: 200px">
                                                <tr>
                                                    <td>
                                                        <asp:Label CssClass="tittleprecios03" ID="lblNombre" runat="server" Text='<%# Eval("nombre") %>'></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td style="width: 120px">
                                            <asp:Label CssClass="tittleprecios03" ID="lblEdicion" runat="server" Text='<%# Eval("idProductoEdicion") %>'></asp:Label>
                                        </td>
                                        <td style="width: 100px">
                                            <asp:Label ID="lblPesosValorUnitario" runat="server" Text="Label" CssClass="tittleprecios03">$ </asp:Label><asp:Label
                                                CssClass="tittleprecios03" ID="lblValorUnitario" runat="server" Text='<%#String.Format("{0:0.00}", Eval("precioUnidad")) %>'></asp:Label>
                                        </td>
                                        <td style="width: 120px">
                                            <asp:Label CssClass="tittleprecios03" ID="lblCantidad" runat="server" Text='<%# Eval("cantidad") %>'></asp:Label>
                                        </td>
                                        <td style="width: 110px">
                                            <asp:Label ID="lblPesosValorTotal" runat="server" Text="Label" CssClass="tittleprecios03">$ </asp:Label>
                                            <asp:Label CssClass="tittleprecios03" ID="lblValorTotal" runat="server" Text='<%# Convert.ToDouble(Convert.ToDouble(Eval("subTotal"))) %>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="btnImbEliminar" CommandName="Detete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "idProducto")%>'
                                                Height="30px" Width="30px" runat="server" ImageUrl="~/images/eliminar.jpg" ToolTip="Eliminar"
                                                OnClientClick="javascript:return confirm('¿Desea confirmar la eliminación del registro?');"
                                                BorderStyle="None" />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td colspan="4" align="right" class="tittleprecios03">
            <br />
            <asp:UpdatePanel ID="uplblTotal" runat="server">
                <ContentTemplate>
                    Total:&nbsp;$&nbsp;<asp:Label CssClass="tittleprecios03" ID="lblTotal" runat="server"
                        Text="0"></asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
</table>
<asp:HiddenField ID="hfProductos" runat="server" />
<act:ModalPopupExtender ID="mpeProductos" runat="server" PopupControlID="panelProductos"
    TargetControlID="hfProductos" BackgroundCssClass="backgroundColor">
</act:ModalPopupExtender>
<asp:Panel ID="panelProductos" runat="server" BackColor="White">
    <asp:UpdatePanel ID="upProductos" runat="server">
        <ContentTemplate>
            <div id="popupcontainer">
                <div class="row popupcontainertitle">
                    <div class="cell popupcontainercell">
                        Selecci&oacute;n de productos:
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
                                    <asp:Label ID="lblMensajeError" runat="server" Text="" ForeColor="Red"></asp:Label>
                                    <br />
                                    <br />
                                    <table style="background-color: #006CCC; width: 412px;">
                                        <tr>
                                            <td class="tittleproducto">
                                                &nbsp; &nbsp;
                                            </td>
                                            <td class="tittleproducto" style="background-color: #006CCC; color: White">
                                                <table style="width: 200px">
                                                    <tr>
                                                        <td>
                                                            Nombre
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td class="tittleproducto" style="background-color: #006CCC; color: White">
                                                Edici&oacute;n
                                            </td>
                                            <td class="tittleproducto" style="background-color: #006CCC; color: White">
                                                Precio<br />
                                                unitario
                                            </td>
                                            <td class="tittleproducto" style="background-color: #006CCC; color: White">
                                                Stock
                                            </td>
                                            <td class="tittleproducto" style="background-color: #006CCC; color: White">
                                                Cantidad
                                            </td>
                                        </tr>
                                    </table>
                                    <div style="overflow: scroll; height: 295px; width: 100%">
                                        <div>
                                            <asp:Repeater ID="rptProductos" runat="server">
                                                <HeaderTemplate>
                                                    <table width="100%" style="background-color: #8ABAFF" border="0">
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr>
                                                        <td>
                                                            <asp:CheckBox ID="chkProductoSeleccionado" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "idProductoEdicion")%>'
                                                                Font-Size="0px" />
                                                        </td>
                                                        <td>
                                                            <asp:Label CssClass="tittleprecios03" ID="lblIdProducto" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "idProducto")%>'
                                                                Font-Size="0px"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label CssClass="tittleprecios03" ID="lblNombre" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "nombre")%>'></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label CssClass="tittleprecios03" ID="lblEdicion" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "idProductoEdicion")%>'></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblPesosPrecioUnitario" runat="server" Text="Label" CssClass="tittleprecios03">$ </asp:Label><asp:Label
                                                                CssClass="tittleprecios03" ID="lblPrecioUnitario" runat="server" Text='<%#String.Format("{0:0.00}",DataBinder.Eval(Container.DataItem, "precio"))%>'></asp:Label>
                                                        </td>
                                                        <td style="width: 40px;" align="center">
                                                            <asp:Label CssClass="tittleprecios03" ID="lblStock" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "cantidadDisponible")%>'></asp:Label>
                                                        </td>
                                                        <td align="center">
                                                            <asp:TextBox ID="txtCantidad" runat="server" Width="55px"></asp:TextBox>
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
