<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Admin.Master" AutoEventWireup="true" CodeBehind="Devoluciones.aspx.cs" Inherits="Dyn.Web.Admin.Devoluciones" %>

<%@ MasterType VirtualPath="~/Masters/Admin.Master" %>
<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="act" %>

<%@ Register Src="../controls/Login.ascx" TagName="Login" TagPrefix="uc2" %>
<%@ Register Src="../controls/MenuAdminCategoria.ascx" TagName="MenuAdmin" TagPrefix="uc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .style1
        {
            font-style: normal;
            color: #7f7f7f; /*font-size: 11px;*/;
            font-weight: bold;
            height: 45px;
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
    </style>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphCentral" runat="server">
    <table width="100%" cellpadding="0" cellspacing="5" border="0">
        <tr>
            <td class="style1" align="left" colspan="2">
                <asp:Panel ID="panBusqueda" runat="server">
                    <table style="width:100%;">
                        <tr>
            <td class="style1" align="left">
                Numero de Devoluci&oacute;n:
            </td>
            <td align="left" width="150">
                <asp:TextBox ID="txtNumeroDevolucion" runat="server" CssClass="tittleprecios03" 
                    Enabled="False"></asp:TextBox><br />
            </td>
        </tr>

        <tr>
            <td class="style1" align="left">
                Fecha (*)
            </td>
            <td>
                <asp:Calendar ID="calFecha" runat="server" BackColor="White" 
                    BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" 
                    ForeColor="Black" Height="114px" NextPrevFormat="FullMonth" Width="228px">
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
            <td class="style1" align="left" valign="middle">
                        Proveedor:
            </td>
            <td class="style17">
                <asp:DropDownList CssClass="tittleprecios03" ID="lstProveedor" runat="server">
                </asp:DropDownList><br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Debe seleccionar un Proveedor"
                    ControlToValidate="lstProveedor" CssClass="tittleprecios03" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>

            <td class="style19">
                <asp:Button CssClass="adminbutton" ID="btnSeleccionarProveedor" runat="server" 
                    Text="Seleccionar Proveedor" onclick="btnSeleccionarProveedor_Click"
                    />&nbsp;
            </td>
         </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>

        

         <tr>
            <td class="style18" colspan="2">
            
                <asp:Panel ID="panProductos" runat="server">
                    <table style="width:100%;">
                                 <tr>
            <td class="style18">
            
            </td>
            <td class="style16">
            
                <asp:GridView ID="gvDetalles" runat="server" AutoGenerateColumns="False" 
                    onrowcancelingedit="gvDetalles_RowCancelingEdit" onrowediting="gvDetalles_RowEditing" 
                    onrowupdating="gvDetalles_RowUpdating" CellPadding="4" ForeColor="#333333" 
                    GridLines="None" 
                    onselectedindexchanging="gvDetalles_SelectedIndexChanging">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="Producto.Nombre" HeaderText="Producto" 
                            ReadOnly="True" />
                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                        <asp:CommandField ShowEditButton="True" ButtonType="Image" 
                            EditImageUrl="~/images/Iconos/edit.png" EditText="" />
                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/Iconos/next.png" 
                            SelectText="" ShowSelectButton="True" />
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
            <td class="style18">
            
                &nbsp;</td>
            <td class="style16">
            
                <asp:Panel ID="panReservas" runat="server" Visible="False">
                    <table style="width:100%;">
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" CssClass="style17" Font-Bold="True" 
                                    ForeColor="Red" Text="* Existen Reservas sin Entregar" Visible="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
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
                                        <asp:CommandField SelectText="" ShowSelectButton="True" ButtonType="Image" 
                                            SelectImageUrl="~/images/Iconos/button_ok.png" />
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
            <td class="style18">
            
                &nbsp;</td>
            <td class="tittlemenu">
            
                Producto a Devolver</td>



         </tr>

         <tr>
            <td class="style18">
            
                &nbsp;</td>
            <td class="style16">
            
                &nbsp;</td>



         </tr>

         <tr>
            <td class="style18">
            
                &nbsp;</td>
            <td class="style16">
            
                <asp:GridView ID="gvDevoluciones" runat="server" AutoGenerateColumns="False" 
                    onrowdeleting="gvDevoluciones_RowDeleting" CellPadding="4" ForeColor="#333333" 
                    GridLines="None" Visible="False">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="Producto.Nombre" HeaderText="Producto" 
                            ReadOnly="True" />
                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                        <asp:CommandField ButtonType="Image" 
                            DeleteImageUrl="~/images/Iconos/edit_remove.png" ShowDeleteButton="True" />
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

         <tr>
            <td class="style18">
            
                &nbsp;</td>
            <td class="style16">
            
                &nbsp;</td>



         </tr>

         <tr>
            <td class="style16" colspan="2">
            
                <asp:Button CssClass="adminbutton" ID="btnGuardar" runat="server" 
                    Text="Guardar" OnClick="btnGuardar_Click" Enabled="False"
                    />&nbsp;
                <asp:Button CssClass="adminbutton" ID="btnCancelar" runat="server" Text="Cancelar"
                    CausesValidation="False" onclick="btnCancelar_Click" />&nbsp;
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
