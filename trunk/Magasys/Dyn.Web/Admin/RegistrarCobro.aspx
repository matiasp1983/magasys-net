<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Admin.Master" AutoEventWireup="true"
    CodeBehind="RegistrarCobro.aspx.cs" Inherits="Dyn.Web.Admin.RegistrarCobro" Culture="es-AR" %>

<%@ MasterType VirtualPath="~/Masters/Admin.Master" %>
<%@ Register Src="../controls/Date.ascx" TagName="Date" TagPrefix="uc2" %>
<%@ Register Src="../controls/BuscarClientes.ascx" TagName="BuscarClientes" TagPrefix="uc4" %>
<%@ Register Src="../controls/Login.ascx" TagName="Login" TagPrefix="uc2" %>
<%@ Register Src="../controls/MenuAdminCategoria.ascx" TagName="MenuAdmin" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphCentral" runat="server">    
    <table>
        <tr>
            <td class="tittleprecios03">
                <asp:Label ID="lblFechaInicio" runat="server" Text="Fecha Inicio:"></asp:Label>
            </td>
            <td style="width: 120px">
                <uc2:Date ID="calFechaInicial" runat="server" />
            </td>
            <td class="tittleprecios03">
                <asp:Label ID="lblFechaFin" runat="server" Text="Fecha Fin:"></asp:Label>
            </td>
            <td style="width: 120px;">
                <uc2:Date ID="calFechaFinal" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <br />
                <uc4:BuscarClientes ID="ucBuscarClientes" runat="server" />
            </td>
            <td style="top: 15px; padding-bottom: 5px;">
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar Ventas" OnClick="btnBuscar_Click"
                    Width="100px" />
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td colspan="5" class="tittleproducto">
                <br />
                Items del cobro
                <hr />
            </td>
        </tr>
    </table>
    <asp:UpdatePanel ID="upVentas" runat="server">
        <ContentTemplate>
            <asp:GridView ID="gridVentas" runat="server" AutoGenerateColumns="False" Width="485px"
                HeaderStyle-ForeColor="#565758" HeaderStyle-BackColor="#B6D3FF" ShowFooter="True"
                CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkVenta" runat="server" CommandName="Select" CausesValidation="false"
                                OnCheckedChanged="chkVenta_CheckedChanged" AutoPostBack="True" Text='<%#Bind("idVenta")%>'
                                Font-Size="0px" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Código de Venta" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblCodigoVenta" runat="server" Text='<%# Bind("idVenta") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="150px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Fecha" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblFecha" runat="server" Text='<%# Bind("fecha", "{0:dd/MM/yyyy}") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterStyle Font-Bold="true" HorizontalAlign="Right" ForeColor="#333333" />
                        <FooterTemplate>
                            <asp:Label ID="lblTotal" runat="server" Text="TOTAL: $" ForeColor="White"></asp:Label>
                        </FooterTemplate>
                        <ItemStyle Width="150px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Monto Total" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblMontoTotal" runat="server" Text='<%# Bind("montotal", "{0:c}") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="150px" />
                        <FooterTemplate>
                            <asp:Label ID="lblValorMontoTotal" runat="server" Text="0,00" ForeColor="#333333"
                                Font-Bold="true" Width="100%" Font-Size="" BackColor="White"></asp:Label>
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <asp:Button ID="btnGragar" runat="server" Text="Grabar" OnClick="btnGragar_Click"
        Visible="false" />&nbsp;<asp:Button ID="btnCancelar" runat="server" Text="Cancelar"
            Visible="false" OnClick="btnCancelar_Click" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphReserva" runat="server">
</asp:Content>
<asp:Content ID="Content5" runat="server" ContentPlaceHolderID="cphMenu">
    <!--Control de login de ejemplo-->
    <uc2:Login ID="Login1" runat="server" />
    <br />
    <uc1:MenuAdmin ID="MenuAdmin1" runat="server" />
</asp:Content>
