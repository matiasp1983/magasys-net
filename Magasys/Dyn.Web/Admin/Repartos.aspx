<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Admin.Master" AutoEventWireup="true"
    CodeBehind="Repartos.aspx.cs" Inherits="Dyn.Web.Admin.Repartos" %>

<%@ Register Src="../controls/Date.ascx" TagName="Date" TagPrefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style17
        {
            font-style: normal;
            color: #7f7f7f;
            font-weight: bold;
            height: 45px;
        }
        .style19
        {
            font-style: normal;
            color: #7f7f7f;
            font-weight: bold;
            height: 45px;
            width: 35px;
        }
        .style22
        {
            width: 10px;
        }
        .style23
        {
        }
        .style24
        {
            font-style: normal;
            color: #7f7f7f;
            font-weight: bold;
            height: 45px;
            }
        .style25
        {
            width: 556px;
        }
        .style27
        {
            font-style: normal;
            color: #7f7f7f;
            font-weight: bold;
            height: 45px;
            width: 541px;
        }
        .style28
        {
            width: 541px;
        }
        .style29
        {
            font-style: normal;
            color: #7f7f7f;
            font-weight: bold;
            height: 45px;
            width: 61px;
        }
        .style30
        {
            width: 35px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphCentral" runat="server">
    <table style="width: 100%;">
        <tr>
            <td class="style22">
                &nbsp;
            </td>
            <td class="style23">
                &nbsp;
            </td>
            <td class="style25">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style22">
                &nbsp;
            </td>
            <td class="style24">
                Fecha:
            </td>
            <td class="tittleprecios03" align="left" style="width: 180px">
                <uc4:Date ID="calFecha" runat="server" Visible="True" />
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style22">
                &nbsp;
            </td>
            <td class="style17" colspan="3">
                <asp:Panel ID="panSeleccion" runat="server">
                    <table style="width: 100%;">
                        <tr>
                            <td class="style22">
                                &nbsp;
                            </td>
                            <td class="style19">
                                Proveedor:
                            </td>
                            <td class="style27">
                                <asp:DropDownList ID="lstProveedores" runat="server" CssClass="style19" Height="45px"
                                    Width="200px" AutoPostBack="True" 
                                    OnSelectedIndexChanged="lstProveedores_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
        <tr>
            <td class="style22">
                &nbsp;
            </td>
            <td class="style19">
                &nbsp;<asp:Label ID="lbNombre" runat="server" Text="Nombre Producto:" Visible="False"></asp:Label>
            </td>
            <td class="style27">
                <asp:TextBox ID="txtNombreProd" runat="server" MaxLength="50" Width="192px" Visible="False"
                    CssClass="style19" Height="35px"></asp:TextBox>
            </td>
            <td class="style21">
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click"
                    Visible="False" />
            </td>
        </tr>
        <tr>
            <td class="style22">
                &nbsp;
            </td>
            <td class="style30">
                &nbsp;
            </td>
            <td class="style28">
                <asp:GridView ID="gvProductos" runat="server" Visible="False" CellPadding="4" ForeColor="#333333"
                    GridLines="None" AutoGenerateColumns="False" 
                    OnSelectedIndexChanging="gvProductos_SelectedIndexChanging" 
                    style="margin-right: 0px">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="IdProducto" HeaderText="N&uacute;mero Producto" >
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" >
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripci&oacute;n" >
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:CommandField ShowSelectButton="True" ButtonType="Image" 
                            SelectImageUrl="~/images/Iconos/next.png" >
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:CommandField>
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    </asp:Panel> </td> </tr>
    <tr>
        <td class="style22">
            &nbsp;</td>
        <td class="style24" colspan="3">
            <asp:Panel ID="panProductos" runat="server" Visible="False">
                <table style="width:100%;">
<tr>
        <td class="style22">
            &nbsp;
        </td>
        <td class="style29">
            <asp:Label ID="lbNombre0" runat="server" Text="Nombre Producto:"></asp:Label>
        </td>
        <td class="style25">
            <asp:GridView ID="gvBusqueda" runat="server" CellPadding="4" ForeColor="#333333"
                GridLines="None" AutoGenerateColumns="False" 
                OnSelectedIndexChanging="gvProductos_SelectedIndexChanging">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="IdProducto" HeaderText="N&uacute;mero Producto" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Descripcion" HeaderText="Descripci&oacute;n" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
        </td>
        <td>
            <asp:Button ID="btnBuscarRepartos" runat="server" Text="Buscar Repartos" 
                onclick="btnBuscarRepartos_Click" />
        </td>
    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    
    <tr>
        <td class="style22">
            &nbsp;
        </td>
        <td class="style23" colspan="2">
            <asp:Panel ID="panListadoRepartos" runat="server" Visible="False">
                <table style="width:100%;">
<tr>
        <td class="style22">
            &nbsp;
        </td>
        <td class="style23">
            &nbsp;
        </td>
        <td class="tittleproducto">
            Listado de Repartos para los Productos
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td class="style22">
            &nbsp;
        </td>
        <td class="style23">
            &nbsp;
        </td>
        <td class="style25">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td class="style22">
            &nbsp;
        </td>
        <td class="style23">
            &nbsp;
        </td>
        <td class="style25">
            <asp:GridView ID="gvRepartos" runat="server" CellPadding="4" 
                ForeColor="#333333" GridLines="None" AutoGenerateColumns="False">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="Cliente.Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Cliente.Apellido" HeaderText="Apellido" />
                    <asp:BoundField DataField="Cliente.Alias" HeaderText="Alias" />
                    <asp:BoundField DataField="Cliente.DomicilioCalle" HeaderText="Calle" />
                    <asp:BoundField DataField="Cliente.DomicilioNro" HeaderText="Numero" />
                    <asp:BoundField DataField="ProductoEdicion.Producto.Nombre" 
                        HeaderText="Producto" />
                    <asp:BoundField DataField="ProductoEdicion.Descripcion" 
                        HeaderText="Descripcion" />
                    <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                    <asp:CheckBoxField HeaderText="Entregado" />
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
                    <tr>
                        <td class="style22">
                            &nbsp;</td>
                        <td class="style23">
                            &nbsp;</td>
                        <td class="style25">
                            <asp:Button ID="btnImprimir" runat="server" onclick="btnImprimir_Click" 
                                Text="Guardar Listado" />
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </asp:Panel>
            &nbsp;
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    
    <tr>
        <td class="style22">
            &nbsp;
        </td>
        <td class="style23">
            &nbsp;
        </td>
        <td class="style25">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphReserva" runat="server">
</asp:Content>
