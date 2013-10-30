<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Site.Master" AutoEventWireup="true"
    CodeBehind="MisReservas.aspx.cs" Inherits="Dyn.Web.User.MisReservas" %>

<%@ Register Src="~/controls/Date.ascx" TagName="Date" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 20px;
        }
        .style2
        {
            width: 20px;
            height: 20px;
        }
        .style3
        {
            height: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%;">
        <tr>
            <td class="style1">
                &nbsp;
            </td>
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
            <td class="style1">
                &nbsp;
            </td>
            <td class="art-nav-outer">
                <h2 class="art-postheader">
                    <span class="art-postheadericon">Mis Reservas</span>
                </h2>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style2">
            </td>
            <td class="style3">
            </td>
            <td class="style3">
            </td>
            <td class="style3">
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;
            </td>
            <td style="font-size: 16px;">
                Aquí podrás ver tus reservas.
            </td>
            <td>
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
            <td class="style1">
                &nbsp;
            </td>
            <td>
                <br />
                <table>
                    <tr>
                        <td class="tittleprecios03" align="left">
                            <asp:Label ID="lblFecha" runat="server" Text="Fecha de reserva:"></asp:Label>
                        </td>
                        <td class="tittleprecios03" align="left">
                            <uc1:Date ID="calFechaReserva" runat="server" Visible="True" />
                        </td>
                        <td class="tittleprecios03" align="left">
                            <asp:Label ID="lblTipoReserva" runat="server" Text="Tipo de reserva:"></asp:Label>
                        </td>
                        <td class="tittleprecios03" align="left">
                            <asp:DropDownList ID="ddlTipoReserva" runat="server">
                                <asp:ListItem>Seleccionar...</asp:ListItem>
                                <asp:ListItem>Única</asp:ListItem>
                                <asp:ListItem>Periódica</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td align="right" style="width: 80px;">
                            <asp:Button ID="btnBuscar" CssClass="adminbutton" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
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
                    <tr>
                        <td>
                            <br />
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            <asp:UpdatePanel ID="upReservas" runat="server">
                                <ContentTemplate>
                                    <td align="center" class="style3">
                                        <asp:GridView ID="gridReservas" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                            ForeColor="#333333" GridLines="None" OnRowCommand="gridReservas_RowCommand">
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:HyperLinkField DataTextField="codReserva" HeaderText="Reserva" />
                                                <asp:BoundField DataField="fechaReserva" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" />
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
                                    <td align="center" class="style3">
                                        <asp:GridView ID="gridReservasEdicion" runat="server" AutoGenerateColumns="False"
                                            CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="gridReservasEdicion_RowCommand">
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:HyperLinkField DataTextField="codReservaEdicion" HeaderText="Reserva" />
                                                <asp:BoundField DataField="fechaReservaEdicion" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" />
                                                <asp:BoundField DataField="fechaInicio" HeaderText="Desde" DataFormatString="{0:dd/MM/yyyy}" />
                                                <asp:BoundField DataField="fechaFin" HeaderText="Hasta" DataFormatString="{0:dd/MM/yyyy}" />
                                                <asp:BoundField DataField="ProductoEdicion.Producto.Nombre" HeaderText="Edici&oacute;n" />
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
                        </td>
                    </tr>
                </table>
            </td>
            <td>
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
</asp:Content>
