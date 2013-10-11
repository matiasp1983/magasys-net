<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Admin.Master" AutoEventWireup="true"
    CodeBehind="Ingresos.aspx.cs" Inherits="Dyn.Web.Admin.Ingresos" %>

<%@ MasterType VirtualPath="~/Masters/Admin.Master" %>
<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="act" %>
<%@ Register Src="../controls/Login.ascx" TagName="Login" TagPrefix="uc2" %>
<%@ Register Src="../controls/MenuAdminCategoria.ascx" TagName="MenuAdmin" TagPrefix="uc1" %>
<%@ Register Src="../controls/WUCBuscarProducto.ascx" TagName="WUCBuscarProducto"
    TagPrefix="uc3" %>
<%@ Register Src="../controls/Date.ascx" TagName="Date" TagPrefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style17
        {
            font-style: normal;
            color: #7f7f7f;
            font-weight: bold;
            height: 45px;
            width: 59px;
        }
        .style18
        {
            width: 59px;
        }
        .style19
        {
            font-style: normal;
            color: #7f7f7f;
            font-weight: bold;
            height: 45px;
        }
        .style20
        {
            width: 35px;
        }
        .style21
        {
            width: 50px;
        }
        .style22
        {
            height: 21px;
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
            font-style: normal;
            color: #7f7f7f;
            font-weight: bold;
            height: 45px;
            width: 26px;
        }
        .style26
        {
            width: 59px;
            height: 45px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphCentral" runat="server">
    <table width="100%" cellpadding="0" cellspacing="5" border="0">
        <tr>
            <td class="style25" align="left">
                <asp:Label ID="lblNroIngreso" runat="server" Text=" N&uacute;mero de Ingreso:"></asp:Label>
            </td>
            <td align="left" class="style18">
                <asp:TextBox ID="txtNumeroVenta" runat="server" CssClass="tittleprecios03" Enabled="False"
                    Width="157px"></asp:TextBox><br />
            </td>
        </tr>
        <tr>
            <td class="style25" align="left">
                Fecha (*)
            </td>
            <td class="tittleprecios03" align="left" style="width: 180px">
                <uc4:Date ID="calFecha" runat="server" Visible="True" />
            </td>
        </tr>
        <tr>
            <td class="style19" colspan="2">
                <asp:Panel ID="panBusquedaProductos" runat="server">
                    <table>
                        <tr>
                            <td class="tittleprecios03" align="left">
                                <asp:Label ID="lblProveedor" runat="server" Text="Proveedor:" Width="155px"></asp:Label>
                            </td>
                            <td class="tittleprecios03" align="left">
                                <asp:DropDownList ID="lstProveedor" runat="server" AutoPostBack="True" OnSelectedIndexChanged="lstProveedores_SelectedIndexChanged"
                                    Width="157px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="tittleprecios03" align="left">
                                <asp:Label ID="lbNombre" runat="server" Text="Nombre Producto:" Visible="False"></asp:Label>
                            </td>
                            <td class="tittleprecios03" align="left">
                                <asp:TextBox ID="txtNombreProd" runat="server" MaxLength="50" Visible="False"></asp:TextBox>
                            </td>
                            <td class="tittleprecios03" align="left">
                                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click"
                                    Visible="False" />
                            </td>
                        </tr>
                        <tr>
                            <td class="style20">
                            </td>
                            <td class="style17">
                                <asp:GridView ID="gvProductos" runat="server" Visible="False" CellPadding="4" ForeColor="#333333"
                                    GridLines="None" AutoGenerateColumns="False" OnSelectedIndexChanging="gvProductos_SelectedIndexChanging">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="IdProducto" HeaderText="N&uacute;mero Producto">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Nombre" HeaderText="Nombre">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Descripcion" HeaderText="Descripci&oacute;n">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:CommandField ShowSelectButton="True" ButtonType="Image" SelectImageUrl="~/images/Boton_next.png"
                                            SelectText="">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:CommandField>
                                    </Columns>
                                    <EditRowStyle BackColor="#2461BF" />
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#EFF3FB" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="style24" colspan="2">
                <asp:Panel ID="panDetalleIngreso" runat="server">
                    <table>
                        <tr>
                            <td class="style24">
                                Detalle Ingresos
                            </td>
                            <td class="style17">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:GridView ID="gvDetalle" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                                    AutoGenerateColumns="False" OnRowCancelingEdit="gvDetalle_RowCancelingEdit" OnRowDeleting="gvDetalle_RowDeleting"
                                    OnRowEditing="gvDetalle_RowEditing" OnRowUpdating="gvDetalle_RowUpdating" Width="400px">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="Producto.Nombre" HeaderText="Producto">
                                            <ItemStyle Width="100px" HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Descripci&oacute;n" DataField="ProductoEdicion.Descripcion">
                                            <ItemStyle Width="100px" HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Cantidad" DataField="CantidadUnidades">
                                            <ItemStyle Width="50px" HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Precio" DataField="ProductoEdicion.Precio">
                                            <HeaderStyle Width="50px" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:CommandField ShowEditButton="True" ButtonType="Image" CancelImageUrl="~/images/Boton_cancelar.png"
                                            CancelText="" EditImageUrl="~/images/Boton_editar.png" EditText="" UpdateImageUrl="~/images/Boton_ok.png"
                                            UpdateText="">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:CommandField>
                                        <asp:CommandField ShowDeleteButton="True" ButtonType="Image" CancelImageUrl="~/images/Boton_cancelar.png"
                                            CancelText="" DeleteImageUrl="~/images/Boton_editar_eliminar.png" DeleteText=""
                                            EditImageUrl="~/images/Boton_editar.png" EditText="" UpdateImageUrl="~/images/Iconos/button_ok.png"
                                            UpdateText="">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:CommandField>
                                    </Columns>
                                    <EditRowStyle BackColor="#2461BF" />
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#EFF3FB" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <%--  Control de Botones --%>
        <tr>
            <td colspan="2" class="style22">
            </td>
        </tr>
        <tr>
            <td colspan="2" class="tittlemenu">
                <asp:Panel ID="panReservas" runat="server">
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td class="style24">
                                <asp:Label ID="lblMensaje" runat="server" Font-Size="Medium" ForeColor="Red" Text="* Existe Reservas para los Producto que se est&aacute;n ingresando"></asp:Label>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td class="style24">
                                <asp:GridView ID="gvReservas" runat="server" CellPadding="4" ForeColor="#333333"
                                    GridLines="None" AutoGenerateColumns="False" OnSelectedIndexChanging="gvReservas_SelectedIndexChanging">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="CodReserva" HeaderText="C&oacute;digo">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Cliente.Nombre" HeaderText="Nombre">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Cliente.Apellido" HeaderText="Apellido">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Producto.Nombre" HeaderText="Producto">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:CommandField SelectText="" ShowSelectButton="True" ButtonType="Image" 
                                            SelectImageUrl="~/images/Boton_ok.png">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:CommandField>
                                    </Columns>
                                    <EditRowStyle BackColor="#2461BF" />
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#EFF3FB" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
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
                            <td>
                                &nbsp;
                            </td>
                            <td class="style24">
                                <asp:Button ID="btnConfirmarTodos" runat="server" OnClick="btnConfirmarTodos_Click"
                                    Text="Confirmar Todos" CausesValidation="False" OnClientClick="javascript:return confirm('Desea confirmar todas las reservas?');" />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td class="style24">
                                Se crearan las siguientes reservas:
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td class="style24">
                                <asp:GridView ID="gvReservasOk" runat="server" CellPadding="4" ForeColor="#333333"
                                    GridLines="None" AutoGenerateColumns="False" Visible="False" OnRowDeleting="gvReservasOk_RowDeleting">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="CodReserva" HeaderText="Codigo">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Cliente.Nombre" HeaderText="Nombre">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Cliente.Apellido" HeaderText="Apellido">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Producto.Nombre" HeaderText="Producto">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/images/Boton_editar_eliminar.png"
                                            DeleteText="" ShowDeleteButton="True" />
                                    </Columns>
                                    <EditRowStyle BackColor="#2461BF" />
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#EFF3FB" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                </asp:GridView>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2" style="height: 24px">
                <br />
                <asp:Button CssClass="adminbutton" ID="btnGuardar" runat="server" Text="Guardar"
                    OnClick="btnGuardar_Click" Enabled="False" />&nbsp;
                <asp:Button CssClass="adminbutton" ID="btnCancelar" runat="server" Text="Cancelar"
                    CausesValidation="False" OnClick="btnCancelar_Click" />&nbsp;
                <asp:Button CssClass="adminbutton" ID="btnEliminar" runat="server" Text="Anular"
                    CausesValidation="False" OnClientClick="javascript:return confirm('Desea eliminar la Coleccion?');"
                    Visible="False" Enabled="False" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphReserva" runat="server">
</asp:Content>
<asp:Content ID="Content5" runat="server" ContentPlaceHolderID="cphMenu">
    <!--Control de login de ejemplo-->
    <uc2:Login ID="Login1" runat="server" />
    <br />
    <uc1:MenuAdmin ID="MenuAdmin1" runat="server" />
</asp:Content>
