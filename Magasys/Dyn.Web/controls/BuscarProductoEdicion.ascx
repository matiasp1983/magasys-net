﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BuscarProductoEdicion.ascx.cs"
    Inherits="Dyn.Web.controls.ProductoEdicion" %>
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
    .style1
    {
        width: 213px;
    }
    .style2
    {
        width: 206px;
    }
    .style3
    {
        width: 137px;
    }
    .style4
    {
        width: 77px;
    }
</style>
<asp:UpdatePanel ID="uplProductoEdicion" runat="server">
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
            &nbsp;<asp:Button ID="btnBuscarProductoEdicion" runat="server" Text="Buscar Productos" OnClick="btnBuscarProductoEdicion_Click" />
        </td>
    </tr>
    <tr>
    <td><asp:Label ID="lblNombre" runat="server" Text="Nombre:" CssClass="tittleprecios03"></asp:Label></td>
    <td> &nbsp;<asp:Label ID="lblNombreText" runat="server" Text="" CssClass="tittleprecios03"></asp:Label></td>    
    </tr>
    <tr>
    <td><asp:Label ID="lblEdicion" runat="server" Text="Edici&oacute;n:" CssClass="tittleprecios03"></asp:Label></td>
    <td> &nbsp;<asp:Label ID="lblEdicionText" runat="server" Text="" CssClass="tittleprecios03"></asp:Label></td>    
    </tr>
</table>
</contenttemplate>
</asp:UpdatePanel>
<asp:HiddenField ID="hfProductoEdicion" runat="server" />
<act:ModalPopupExtender ID="mpeProductoEdicion" runat="server" PopupControlID="panelProductoEdicion"
    TargetControlID="hfProductoEdicion" BackgroundCssClass="backgroundColor">
</act:ModalPopupExtender>
<asp:Panel ID="panelProductoEdicion" runat="server" BackColor="White">
    <asp:UpdatePanel ID="upProductoEdicion" runat="server">
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
                                                <asp:Label ID="lblNombreProd" runat="server" Text="Nombre del producto:"></asp:Label>
                                                &nbsp;<asp:TextBox ID="txtNombreProd" runat="server" Width="150px"></asp:TextBox>
                                            </td>
                                            <td class="tittleprecios03" align="left">
                                                <asp:Label ID="lblNroEdicion" runat="server" Text="Edici&oacute;n:"></asp:Label>
                                                &nbsp;<asp:TextBox ID="txtEdicion" runat="server" Width="150px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tittleprecios03" align="left">
                                                <asp:Label ID="lblProveedor" runat="server" Text="Proveedor: " Width="135px"></asp:Label>
                                                <asp:DropDownList CssClass="tittleprecios03" ID="ddlProveedor" runat="server" Width="159px">
                                                </asp:DropDownList>
                                            </td>
                                            <td class="tittleprecios03" align="left">
                                                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:Label ID="lblMensajeError" runat="server" Text="" ForeColor="Red"></asp:Label>
                                    <br />
                                    <br />
                                    <table style="background-color: #006CCC; width: 550px;">
                                        <tr>
                                            <td class="tittleproducto">
                                                &nbsp; &nbsp;
                                            </td>
                                            <td class="style1" style="background-color: #006CCC; color: White">
                                                <table style="width: 211px; height: 23px;">
                                                    <tr>
                                                        <td class="style2">
                                                            Nombre
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td class="style4" style="background-color: #006CCC; color: White">
                                                Edici&oacute;n
                                            </td>
                                            <td class="style3" style="background-color: #006CCC; color: White">
                                                Precio unitario
                                            </td>
                                            <td class="tittleproducto" style="background-color: #006CCC; color: White">
                                                Stock
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
                                                        <td style="width: 30px;">
                                                            <asp:RadioButton ID="rdbProductoSeccionado" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "idProducto")%>'
                                                                Font-Size="0px" OnCheckedChanged="rdbProductoSeccionado_OnCheckedChanged" AutoPostBack="true" />
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
                                                        <td style="width: 40px;">
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
