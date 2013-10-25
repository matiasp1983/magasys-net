<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Admin.Master" AutoEventWireup="true"
    CodeBehind="ListadoReserva.aspx.cs" Inherits="Dyn.Web.Admin.ListadoReserva" %>

<%@ MasterType VirtualPath="~/Masters/Admin.Master" %>
<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="act" %>
<%@ Register Src="../controls/Login.ascx" TagName="Login" TagPrefix="uc2" %>
<%@ Register Src="../controls/MenuAdminCategoria.ascx" TagName="MenuAdmin" TagPrefix="uc1" %>
<%@ Register Src="../controls/Date.ascx" TagName="Date" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphCentral" runat="server">
    <table border="0" cellpadding="0" cellspacing="5" width="100%">
        <tr>
            <td class="tittleproducto" width="700" align="left">
                <h2>
                    Listado de reservas</h2>
            </td>
        </tr>
        <tr>
            <td>
                <table>
                    <tr>
                        <td class="tittleprecios03" align="left" style="width: 115px">
                            <asp:Label ID="lblFecha" runat="server" Text="Fecha de reserva:" Width="115px"></asp:Label>
                        </td>
                        <td class="tittleprecios03" align="left" style="width: 180px">
                            <uc3:Date ID="calFechaReserva" runat="server" Visible="True" />
                        </td>
                        <td class="tittleprecios03" align="left">
                            <asp:Label ID="lblTipoReserva" runat="server" Text="Tipo de reserva:" Width="105px"></asp:Label>
                        </td>
                        <td class="tittleprecios03" align="left">
                            <asp:DropDownList ID="ddlTipoReserva" runat="server">
                                <asp:ListItem>Seleccionar...</asp:ListItem>
                                <asp:ListItem>Única</asp:ListItem>
                                <asp:ListItem>Periódica</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td align="left">
                            <asp:Button ID="btnBuscar" CssClass="adminbutton" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td class="tittleprecios03" align="left" style="width: 115px">
                            <asp:Label ID="lblAlias" runat="server" Text="Alias:" Width="115px"></asp:Label>
                        </td>
                        <td class="tittleprecios03" align="left">
                            <asp:TextBox ID="txtAlias" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="tittleprecios03" align="left">
                            <asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label>
                        </td>
                        <td class="tittleprecios03" align="left">
                            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                        </td>
                        <td class="tittleprecios03" align="left">
                            <asp:Label ID="lblApellido" runat="server" Text="Apellido:"></asp:Label>
                        </td>
                        <td class="tittleprecios03" align="left">
                            <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="tittleprecios03" align="left" style="width: 115px">
                            <asp:Label ID="lblEstado" runat="server" Text="Estado:" Width="115px"></asp:Label>
                        </td>
                        <td class="tittleprecios03" align="left">
                            <asp:DropDownList ID="ddlEstado" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="tittleprecios03" align="left">
                            <asp:RadioButton ID="rdbReserva" runat="server" Text="Reserva" Checked="True" GroupName="Reserva" />
                        </td>
                        <td class="tittleprecios03" align="left">
                            <asp:RadioButton ID="rdbReservaEdicion" runat="server" Text="Reserva por Edici&oacute;n"
                                GroupName="Reserva" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="tittleproducto">
                <br />
                <hr />
            </td>
        </tr>
        <tr>
            <asp:UpdatePanel ID="upReservas" runat="server">
                <ContentTemplate>
                    <td align="center" class="style3" colspan="3">
                        <asp:GridView ID="gridReservas" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            ForeColor="#333333" GridLines="None" OnRowCommand="gridReservas_RowCommand">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:HyperLinkField DataTextField="codReserva" HeaderText="Reserva" />
                                <asp:BoundField DataField="fechaReserva" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" />
                                <asp:BoundField DataField="Cliente.Nombre" HeaderText="Nombre" />
                                <asp:BoundField DataField="Cliente.Apellido" HeaderText="Apellido" />
                                <asp:BoundField DataField="fechaInicio" HeaderText="Desde" DataFormatString="{0:dd/MM/yyyy}" />
                                <asp:BoundField DataField="fechaFin" HeaderText="Hasta" DataFormatString="{0:dd/MM/yyyy}" />
                                <asp:BoundField DataField="Producto.Nombre" HeaderText="Producto" />
                                <asp:BoundField DataField="cantidad" HeaderText="Cantidad" />
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imbVisualizar" runat="server" CausesValidation="False" CommandName="ShowRow"
                                            ImageUrl="~/images/Boton_buscar.png" Text="Editar" CommandArgument="<%#((GridViewRow) Container).RowIndex%>" />
                                    </ItemTemplate>
                                    <ControlStyle CssClass="estilosBotonesGrid" />
                                </asp:TemplateField>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imbEditar" runat="server" CausesValidation="False" CommandName="EditRow"
                                            ImageUrl="~/images/Boton_editar.png" Text="Editar" CommandArgument="<%#((GridViewRow) Container).RowIndex%>" />
                                    </ItemTemplate>
                                    <ControlStyle CssClass="estilosBotonesGrid" />
                                </asp:TemplateField>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imbBorrar" runat="server" CausesValidation="False" CommandName="DeleteRow"
                                            ImageUrl="~/images/Boton_editar_eliminar.png" Text="Borrar" CommandArgument="<%#((GridViewRow) Container).RowIndex%>"
                                            OnClientClick="javascript:return confirm('Desea eliminar la reserva?');" />
                                    </ItemTemplate>
                                    <ControlStyle CssClass="estilosBotonesGrid" />
                                </asp:TemplateField>
                            </Columns>
                            <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        </asp:GridView>
                    </td>
                    </tr>
                    <tr>
                        <td align="center" class="style3" colspan="3">
                            <asp:GridView ID="gridReservasEdicion" runat="server" AutoGenerateColumns="False"
                                CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="gridReservasEdicion_RowCommand">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:HyperLinkField DataTextField="codReservaEdicion" HeaderText="Reserva" />
                                    <asp:BoundField DataField="fechaReservaEdicion" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" />
                                    <asp:BoundField DataField="nroCliente" HeaderText="Número Cliente" />
                                    <asp:BoundField DataField="fechaInicio" HeaderText="Desde" DataFormatString="{0:dd/MM/yyyy}" />
                                    <asp:BoundField DataField="fechaFin" HeaderText="Hasta" DataFormatString="{0:dd/MM/yyyy}" />
                                    <asp:BoundField DataField="idProductoEdicion" HeaderText="Edici&oacute;n" />
                                    <asp:BoundField DataField="cantidad" HeaderText="Cantidad" />
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imbVisualizar" runat="server" CausesValidation="False" CommandName="ShowRow"
                                                ImageUrl="~/images/Boton_buscar.png" Text="Editar" CommandArgument="<%#((GridViewRow) Container).RowIndex%>" />
                                        </ItemTemplate>
                                        <ControlStyle CssClass="estilosBotonesGrid" />
                                    </asp:TemplateField>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imbEditar" runat="server" CausesValidation="False" CommandName="EditRow"
                                                ImageUrl="~/images/Boton_editar.png" Text="Editar" CommandArgument="<%#((GridViewRow) Container).RowIndex%>" />
                                        </ItemTemplate>
                                        <ControlStyle CssClass="estilosBotonesGrid" />
                                    </asp:TemplateField>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imbBorrar" runat="server" CausesValidation="False" CommandName="DeleteRow"
                                                ImageUrl="~/images/Boton_editar_eliminar.png" Text="Borrar" CommandArgument="<%#((GridViewRow) Container).RowIndex%>"
                                                OnClientClick="javascript:return confirm('Desea eliminar la reserva?');" />
                                        </ItemTemplate>
                                        <ControlStyle CssClass="estilosBotonesGrid" />
                                    </asp:TemplateField>
                                </Columns>
                                <EditRowStyle BackColor="#2461BF" />
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                            </asp:GridView>
                        </td>
                </ContentTemplate>
            </asp:UpdatePanel>
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
