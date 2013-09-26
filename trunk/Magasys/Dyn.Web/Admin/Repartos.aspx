<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Admin.Master" AutoEventWireup="true" CodeBehind="Repartos.aspx.cs" Inherits="Dyn.Web.Admin.Repartos" %>
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
    <table style="width:100%;">
        <tr>
            <td class="style22">
                &nbsp;</td>
            <td class="style23">
                &nbsp;</td>
            <td class="style25">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style22">
                &nbsp;</td>
            <td class="style24">
                Fecha:</td>
            <td class="style25">
                <asp:Calendar ID="calFecha" runat="server" BackColor="White" 
                    BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" 
                    ForeColor="Black" Height="114px" NextPrevFormat="FullMonth" Width="255px">
                    <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                    <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" 
                        VerticalAlign="Bottom" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                    <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" 
                        Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                    <TodayDayStyle BackColor="#CCCCCC" />
                </asp:Calendar>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        
        <tr>
            <td class="style22">
                &nbsp;</td>
            <td class="style17" colspan="3">
                <asp:Panel ID="panSeleccion" runat="server">
                    <table style="width:100%;">
        <tr>
            <td class="style22">
                &nbsp;</td>
            <td class="style19">
            
                Proveedor</td>
            <td class="style17">
            
                <asp:DropDownList ID="lstProveedores" runat="server" 
                    DataSourceID="DSProveedores" DataTextField="razonSocial" 
                    DataValueField="idProveedor" CssClass="style19" Height="45px" 
                    Width="200px" AutoPostBack="True" 
                    onselectedindexchanged="lstProveedores_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:SqlDataSource ID="DSProveedores" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:MagasysConnectionString %>" 
                    SelectCommand="SELECT [razonSocial], [idProveedor], [estado] FROM [Proveedores] WHERE ([estado] = @estado)">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="1" Name="estado" Type="Int16" />
                    </SelectParameters>
                </asp:SqlDataSource>
            
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style22">
                &nbsp;</td>
                        <td class="style19">         
                &nbsp;<asp:Label ID="lbNombre" runat="server" Text="Nombre Producto" Visible="False"></asp:Label>
            </td>
            <td class="style17">
            
                <asp:TextBox ID="txtNombreProd" runat="server" MaxLength="50" Width="192px" 
                    Visible="False" CssClass="style19" Height="35px"></asp:TextBox>
            
            </td>
            <td class="style21">
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" 
                    onclick="btnBuscar_Click" Visible="False" />
            </td>
        </tr>
        <tr>
            <td class="style22">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                                <asp:GridView ID="gvProductos" runat="server" Visible="False" CellPadding="4" 
                    ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" 
                    onselectedindexchanging="gvProductos_SelectedIndexChanging">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="IdProducto" HeaderText="ID Producto" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                        <asp:CommandField ShowSelectButton="True" />
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
                </asp:GridView></td>
            <td>
                &nbsp;</td>
        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        
        <tr>
            <td class="style22">
                &nbsp;</td>
            <td class="style24">
                <asp:Label ID="lbNombre0" runat="server" Text="Nombre Producto" Visible="False"></asp:Label>
            </td>
            <td class="style25">
                <asp:GridView ID="gvBusqueda" runat="server" Visible="False" CellPadding="4" 
                    ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" 
                    onselectedindexchanging="gvProductos_SelectedIndexChanging">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="IdProducto" HeaderText="ID Producto" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
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
                </asp:GridView></td>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Buscar Repartos" 
                    Visible="False" />
            </td>
        </tr>
        <tr>
            <td class="style22">
                &nbsp;</td>
            <td class="style23">
                &nbsp;</td>
            <td class="style25">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style22">
                &nbsp;</td>
            <td class="style23">
                &nbsp;</td>
            <td class="tittleproducto">
                Listado de Repartos para los Productos</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style22">
                &nbsp;</td>
            <td class="style23">
                &nbsp;</td>
            <td class="style25">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style22">
                &nbsp;</td>
            <td class="style23">
                &nbsp;</td>
            <td class="style25">
                <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" 
                    GridLines="None">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
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
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style22">
                &nbsp;</td>
            <td class="style23">
                &nbsp;</td>
            <td class="style25">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphReserva" runat="server">
</asp:Content>
