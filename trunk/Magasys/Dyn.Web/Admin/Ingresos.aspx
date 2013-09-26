<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Admin.Master" AutoEventWireup="true"
    CodeBehind="Ingresos.aspx.cs" Inherits="Dyn.Web.Admin.Ingresos" %>

<%@ MasterType VirtualPath="~/Masters/Admin.Master" %>
<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="act" %>

<%@ Register Src="../controls/Login.ascx" TagName="Login" TagPrefix="uc2" %>
<%@ Register Src="../controls/MenuAdminCategoria.ascx" TagName="MenuAdmin" TagPrefix="uc1" %>
<%@ Register Src="../controls/WUCBuscarProducto.ascx" TagName="WUCBuscarProducto"
    TagPrefix="uc3" %>

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
                Numero de Ingreso:
            </td>
            <td align="left" class="style18">
                <asp:TextBox ID="txtNumeroVenta" runat="server" CssClass="tittleprecios03" 
                    Enabled="False"></asp:TextBox><br />
            </td>
        </tr>

        <tr>
            <td class="style25" align="left">
                Fecha (*)
            </td>
            <td class="style26">
                <asp:Calendar ID="calFecha" runat="server" BackColor="White" 
                    BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" 
                    ForeColor="Black" Height="16px" NextPrevFormat="FullMonth" Width="220px">
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
        </tr>
        <tr>
            <td class="style19" colspan="2">
            
                <asp:Panel ID="panBusquedaProductos" runat="server">
                <table>
                <tr>
            <td class="style19">
            
                Proveedor</td>
            <td class="style17">
            
                <asp:DropDownList ID="lstProveedor" runat="server" CssClass="style19" Height="45px" 
                    Width="200px" AutoPostBack="True" 
                    onselectedindexchanged="lstProveedores_SelectedIndexChanged">
                </asp:DropDownList>
            
            </td>
        </tr>
        <tr>
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
            <td class="style20">
            
            </td>
            <td class="style17">
            
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
            
                <asp:GridView ID="gvDetalle" runat="server" CellPadding="4" ForeColor="#333333" 
                    GridLines="None" AutoGenerateColumns="False" 
                    onrowcancelingedit="gvDetalle_RowCancelingEdit" 
                    onrowdeleting="gvDetalle_RowDeleting" onrowediting="gvDetalle_RowEditing" 
                    onrowupdating="gvDetalle_RowUpdating" Width="400px">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="Producto.Nombre" HeaderText="Producto" >
                        <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Descripcion" 
                            DataField="ProductoEdicion.Descripcion" >
                        <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Cantidad" DataField="CantidadUnidades" >
                        <ItemStyle Width="50px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Precio" DataField="ProductoEdicion.Precio" >
                        <HeaderStyle Width="50px" />
                        </asp:BoundField>
                        <asp:CommandField ShowEditButton="True" />
                        <asp:CommandField ShowDeleteButton="True" />
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
                    <table style="width:100%;">
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td class="style24">
                                <asp:Label ID="lblMensaje" runat="server" Font-Size="Medium" ForeColor="Red" 
                                    Text="* Existe Reservas para los Producto que se estan ingresando"></asp:Label>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td class="style24">
                                <asp:GridView ID="gvReservas" runat="server" CellPadding="4" 
                                    ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" 
                                    onselectedindexchanging="gvReservas_SelectedIndexChanging">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:BoundField DataField="CodReserva" HeaderText="Codigo" />
                                        <asp:BoundField DataField="Cliente.Nombre" HeaderText="Nombre" />
                                        <asp:BoundField DataField="Cliente.Apellido" HeaderText="Apellido" />
                                        <asp:BoundField DataField="Producto.Nombre" HeaderText="Producto" />
                                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                                        <asp:CommandField SelectText="Confirmar" ShowSelectButton="True" />
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
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td class="style24">
                                Se crearan las siguientes reservas:</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td class="style24">
                            <asp:GridView ID="gvReservasOk" runat="server" CellPadding="4" 
                                    ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" 
                                    Visible="False">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:BoundField DataField="CodReserva" HeaderText="Codigo" />
                                        <asp:BoundField DataField="Cliente.Nombre" HeaderText="Nombre" />
                                        <asp:BoundField DataField="Cliente.Apellido" HeaderText="Apellido" />
                                        <asp:BoundField DataField="Producto.Nombre" HeaderText="Producto" />
                                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
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

                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
            
            </td>
        </tr>

        
        <tr>
            <td colspan="2">
            
                &nbsp;</td>
        </tr>

        
        <tr>
            <td colspan="2">
            
                &nbsp;</td>
        </tr>

        
        <tr>
            <td colspan="2" style="height: 24px">
                <br />
                     <asp:Button CssClass="adminbutton" ID="btnGuardar" runat="server" 
                    Text="Guardar" OnClick="btnGuardar_Click" Enabled="False"
                    />&nbsp;
                <asp:Button CssClass="adminbutton" ID="btnCancelar" runat="server" Text="Cancelar"
                    CausesValidation="False" />&nbsp;
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
