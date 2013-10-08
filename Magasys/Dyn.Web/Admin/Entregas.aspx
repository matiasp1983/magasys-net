<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Admin.Master" AutoEventWireup="true"
    CodeBehind="Entregas.aspx.cs" Inherits="Dyn.Web.Admin.Entregas" %>

<%@ MasterType VirtualPath="~/Masters/Admin.Master" %>
<%@ Register Src="../controls/BuscarClientes.ascx" TagName="BuscarClientes" TagPrefix="uc1" %>
<%@ Register Src="~/controls/MenuAdminCategoria.ascx" TagName="MenuAdmin" TagPrefix="uc3" %>
<%@ Register Src="../controls/Login.ascx" TagName="Login" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style27
        {
            width: 740px;
        }
        .style28
        {
            height: 20px;
        }
        .style29
        {
            width: 740px;
            height: 20px;
        }
        .style30
        {
            width: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphCentral" runat="server">
    <table style="width: 100%;">
        <tr>
            <td class="style1">
                &nbsp;
            </td>
            <td class="style27">
                <asp:Button ID="btnUltimoReparto" runat="server" OnClick="btnUltimoReparto_Click"
                    Text="Buscar Ultimo Reparto" />
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;
            </td>
            <td class="style27">
                <asp:Panel ID="panBusqueda" runat="server">
                    <table style="width: 100%;">
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
                            <td colspan="2" class="tittleproducto">
                                <br />
                                Selecci&oacute;n de Cliente
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <uc1:BuscarClientes ID="ucBuscarClientes" runat="server" />
                            </td>
                            <td>
                                &nbsp;
                            </td>
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
                                <td>
                                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar Reservas" OnClick="btnBuscar_Click" />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                    </table>
                </asp:Panel>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;
            </td>
            <td class="style27">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style28">
            </td>
            <td class="style29">
                <asp:Panel ID="panResultados" runat="server" Visible="False">
                    <table style="width: 100%;">
                        <tr>
                            <td colspan="3" class="tittleproducto">
                                <br />
                                Reservas a Entregar
                                <hr />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="style30">
                                &nbsp;
                            </td>
                            <td>
                                <asp:GridView ID="gvReservas" runat="server" CellPadding="4" ForeColor="#333333"
                                    GridLines="None" AutoGenerateColumns="False" OnSelectedIndexChanging="gvReservas_SelectedIndexChanging">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:BoundField DataField="CodReservaEdicion" HeaderText="Cod. Reserva" />
                                        <asp:BoundField DataField="ProductoEdicion.Producto.Nombre" HeaderText="Producto" />
                                        <asp:BoundField DataField="ProductoEdicion.Descripcion" HeaderText="Descripcion" />
                                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                                        <asp:BoundField DataField="Cliente.Nombre" HeaderText="Nombre" />
                                        <asp:BoundField DataField="Cliente.Apellido" HeaderText="Apellido" />
                                        <asp:BoundField DataField="Cliente.DomicilioCalle" HeaderText="Calle" />
                                        <asp:BoundField DataField="Cliente.DomicilioNro" HeaderText="Numero" />
                                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/Boton_next.png" SelectText=""
                                            ShowSelectButton="True" />
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
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="style30">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
            <td class="style28">
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;
            </td>
            <td>
                <asp:Panel ID="panEntregas" runat="server" Visible="False">
                    <table style="width: 100%;">
                        <tr>
                            <td colspan="3" class="tittleproducto">
                                <br />
                                Reservas a Entregar
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td class="style30">
                                &nbsp;
                            </td>
                            <td>
                                <asp:GridView ID="gvEntregas" runat="server" CellPadding="4" ForeColor="#333333"
                                    GridLines="None" AutoGenerateColumns="False" OnRowDeleting="gvEntregas_RowDeleting">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:BoundField DataField="ReservaEdicion.CodReservaEdicion" HeaderText="Reserva" />
                                        <asp:BoundField DataField="ReservaEdicion.ProductoEdicion.Producto.Nombre" HeaderText="Producto" />
                                        <asp:BoundField DataField="ReservaEdicion.ProductoEdicion.Descripcion" HeaderText="Descripcion" />
                                        <asp:BoundField DataField="ReservaEdicion.Cantidad" HeaderText="Cantidad" />
                                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/images/Boton_editar_eliminar.png"
                                            DeleteText="" ShowDeleteButton="True" />
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
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="style30">
                                &nbsp;
                            </td>
                            <td>
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
        <tr>
            <td class="style1">
                &nbsp;
            </td>
            <td class="tittleproducto">
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
<asp:Content ID="Content5" runat="server" ContentPlaceHolderID="cphMenu">
    <!--Control de login de ejemplo-->
    <uc2:Login ID="Login1" runat="server" />
    <br />
    <uc3:MenuAdmin ID="MenuAdmin1" runat="server" />
</asp:Content>
