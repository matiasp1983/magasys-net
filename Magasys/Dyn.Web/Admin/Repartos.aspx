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
            width: 62px;
        }
        .style24
        {
            font-style: normal;
            color: #7f7f7f;
            font-weight: bold;
            height: 45px;
            width: 62px;
        }
        .style25
        {
            width: 556px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMenu" runat="server">
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
                            <td class="style17">
                                <asp:DropDownList ID="lstProveedores" runat="server" DataSourceID="DSProveedores"
                                    DataTextField="razonSocial" DataValueField="idProveedor" CssClass="style19" Height="45px"
                                    Width="200px" AutoPostBack="True" OnSelectedIndexChanged="lstProveedores_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="DSProveedores" runat="server" ConnectionString="<%$ ConnectionStrings:MagasysConnectionString %>"
                                    SelectCommand="SELECT [razonSocial], [idProveedor], [estado] FROM [Proveedores] WHERE ([estado] = @estado)">
                                    <SelectParameters>
                                        <asp:Parameter DefaultValue="1" Name="estado" Type="Int16" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
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
            <td class="style17">
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
            <td class="style2">
                &nbsp;
            </td>
            <td>
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
                        <asp:CommandField ShowSelectButton="True" >
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
            &nbsp;
        </td>
        <td class="style24">
            <asp:Label ID="lbNombre0" runat="server" Text="Nombre Producto:" Visible="False"></asp:Label>
        </td>
        <td class="style25">
            <asp:GridView ID="gvBusqueda" runat="server" Visible="False" CellPadding="4" ForeColor="#333333"
                GridLines="None" AutoGenerateColumns="False" OnSelectedIndexChanging="gvProductos_SelectedIndexChanging">
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
            <asp:Button ID="Button1" runat="server" Text="Buscar Repartos" Visible="False" />
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
            <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
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
