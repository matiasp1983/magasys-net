<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Admin.Master" AutoEventWireup="true"
    CodeBehind="Devoluciones.aspx.cs" Inherits="Dyn.Web.Admin.Devoluciones" %>

<%@ MasterType VirtualPath="~/Masters/Admin.Master" %>
<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="act" %>
<%@ Register Src="../controls/Login.ascx" TagName="Login" TagPrefix="uc2" %>
<%@ Register Src="../controls/MenuAdminCategoria.ascx" TagName="MenuAdmin" TagPrefix="uc1" %>
<%@ Register Src="../controls/Date.ascx" TagName="Date" TagPrefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            font-style: normal;
            color: #7f7f7f; /*font-size: 11px;*/;
            font-weight: bold;
            height: 45px;
            width: 149px;
        }
        .style16
        {
        }
        .style17
        {
            height: 45px;
        }
        .style18
        {
        }
        .style19
        {
            width: 326px;
        }
        .style20
        {
            font-style: normal;
            color: #7f7f7f; /*font-size: 11px;*/;
            font-weight: bold;
            width: 149px;
        }
        .style21
        {
            width: 149px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphCentral" runat="server">
    <table width="100%" cellpadding="0" cellspacing="5" border="0">
        <tr>
            <td class="tittleprecios03" align="left" colspan="2">
                <asp:Panel ID="panBusqueda" runat="server">
                    <table style="width: 100%;">
                        <tr>
                            <td class="style20" align="left">
                                <asp:Label ID="lblNroIngreso" runat="server" Text="N&uacute;mero de Devoluci&oacute;n:"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtNumeroDevolucion" runat="server" CssClass="tittleprecios03" Enabled="False"></asp:TextBox><br />
                            </td>
                        </tr>
                        <tr>
                            <td class="style21" align="left">
                                Fecha (*)
                            </td>
                            <td class="tittleprecios03" align="left" style="width: 180px">
                                <uc4:Date ID="calFecha" runat="server" Visible="True" />
                            </td>
                        </tr>
                        <tr>
                            <td class="style1" align="left" valign="middle">
                                Proveedor:
                            </td>
                            <td class="tittleprecios03" align="left">
                                <asp:DropDownList CssClass="tittleprecios03" ID="lstProveedor" runat="server">
                                </asp:DropDownList>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Debe seleccionar un Proveedor"
                                    ControlToValidate="lstProveedor" CssClass="tittleprecios03" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                            <td class="style19">
                                <asp:Button CssClass="adminbutton" ID="btnSeleccionarProveedor" runat="server" Text="Seleccionar Proveedor"
                                    OnClick="btnSeleccionarProveedor_Click" />&nbsp;
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="style18" colspan="2">
                <asp:Panel ID="panProductos" runat="server">
                    <table style="width: 100%;">
                        <tr>
                            <td class="style18">
                            </td>
                            <td class="style16">
                                <asp:GridView ID="gvDetalles" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="gvDetalles_RowCancelingEdit"
                                    OnRowEditing="gvDetalles_RowEditing" OnRowUpdating="gvDetalles_RowUpdating" CellPadding="4"
                                    ForeColor="#333333" GridLines="None" OnSelectedIndexChanging="gvDetalles_SelectedIndexChanging">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="Producto.Nombre" HeaderText="Producto" ReadOnly="True">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:CommandField ShowEditButton="True" ButtonType="Image" EditImageUrl="~/images/Boton_editar.png"
                                            EditText="">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:CommandField>
                                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/Boton_next.png" SelectText=""
                                            ShowSelectButton="True">
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
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="style18">
                &nbsp;
            </td>
            <td class="style16">
                <asp:Panel ID="panReservas" runat="server" Visible="False">
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" CssClass="style17" Font-Bold="True" ForeColor="Red"
                                    Text="* Existen Reservas sin Entregar" Visible="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
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
            <td class="style18">
                &nbsp;
            </td>
            <td class="tittlemenu">
                Producto a Devolver
            </td>
        </tr>
        <tr>
            <td class="style18">
                &nbsp;
            </td>
            <td class="style16">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style18">
                &nbsp;
            </td>
            <td class="style16">
                <asp:GridView ID="gvDevoluciones" runat="server" AutoGenerateColumns="False" OnRowDeleting="gvDevoluciones_RowDeleting"
                    CellPadding="4" ForeColor="#333333" GridLines="None" Visible="False">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="Producto.Nombre" HeaderText="Producto" ReadOnly="True">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/images/Boton_editar_eliminar.png"
                            ShowDeleteButton="True">
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
        </tr>
        <tr>
            <td class="style18">
                &nbsp;
            </td>
            <td class="style16">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style16" colspan="2">
                <asp:Button CssClass="adminbutton" ID="btnGuardar" runat="server" Text="Guardar"
                    OnClick="btnGuardar_Click" Enabled="False" />&nbsp;
                <asp:Button CssClass="adminbutton" ID="btnCancelar" runat="server" Text="Cancelar"
                    CausesValidation="False" OnClick="btnCancelar_Click" />&nbsp;
                <asp:Button CssClass="adminbutton" ID="btnEliminar" runat="server" Text="Anular"
                    CausesValidation="False" OnClientClick="javascript:return confirm('Desea eliminar la Coleccion?');"
                    Visible="False" />
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
