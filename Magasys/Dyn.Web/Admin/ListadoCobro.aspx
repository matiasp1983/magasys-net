<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Admin.Master" AutoEventWireup="true"
    CodeBehind="ListadoCobro.aspx.cs" Inherits="Dyn.Web.Admin.ListadoCobro" Culture="es-AR" %>

<%@ MasterType VirtualPath="~/Masters/Admin.Master" %>
<%@ Register Src="../controls/MenuAdminCategoria.ascx" TagName="MenuAdminCategoria"
    TagPrefix="uc1" %>
<%@ Register Src="../controls/Date.ascx" TagName="Date" TagPrefix="uc2" %>
<%@ Register Src="../controls/Login.ascx" TagName="Login" TagPrefix="uc3" %>
<%@ Register Src="../controls/BuscarClientes.ascx" TagName="BuscarClientes" TagPrefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link type="text/css" rel="Stylesheet" href="../GridView/dialog.css" />
    <link type="text/css" rel="Stylesheet" href="../GridView/pager.css" />
    <link type="text/css" rel="Stylesheet" href="../GridView/grid.css" />
    <link type="text/css" rel="Stylesheet" href="../GridView/subgrid.css" />
    <script type="text/javascript">
        //master: id of div element that contains the information about master data
        //details: id of div element wrapping the details grid
        function showhide(master, detail) {
            //First child of master div is the image
            var src = $(master).children()[0].src;
            //Switch image from (+) to (-) or vice versa.
            if (src.endsWith("plus.png"))
                src = src.replace('plus.png', 'minus.png');
            else
                src = src.replace('minus.png', 'plus.png');

            //Set new image
            $(master).children()[0].src = src;

            //Toggle expand/collapse                   
            $(detail).slideToggle("normal");
        }
    </script>
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
                <uc4:buscarclientes ID="ucBuscarClientes" runat="server" />
            </td>
            <td style="top: 15px; padding-bottom: 5px;">
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar Cobros" OnClick="btnBuscar_Click"
                    Width="100px" />
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td colspan="5" class="tittleproducto">
                <br />
                Detalle de cobros
                <hr />
            </td>
        </tr>
    </table>
    <div id="dlg" class="dialog" style="width: 700px">
        <div class="body">
            <div class="outer">
                <div class="inner">
                    <div class="content">
                        <asp:Panel CssClass="grid" ID="pnlCust" runat="server">
                            <asp:UpdatePanel ID="upCobros" runat="server">
                                <ContentTemplate>
                                    <asp:GridView Width="100%" ID="gridCobros" AutoGenerateColumns="False" runat="server"
                                        OnRowCreated="gridCobros_RowCreated" CellPadding="4" ForeColor="#333333" GridLines="None">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <table width="70%" style="background-color: #507CD1">
                                                        <tr>
                                                            <th style="width: 265px; background: url(sprite.png) repeat-x 0px 0px; border-color: #507CD1 #507CD1 #507CD1 #507CD1;
                                                                border-style: solid solid solid none; border-width: 1px 1px 1px medium; color: White;
                                                                padding: 4px 5px 4px 10px; vertical-align: bottom; text-align: center; font-weight: bold">
                                                                Código de Cobro
                                                            </th>
                                                            <th style="width: 138px; background: url(sprite.png) repeat-x 0px 0px; border-color: #507CD1 #507CD1 #507CD1 #507CD1;
                                                                border-style: solid solid solid none; border-width: 1px 1px 1px medium; color: White;
                                                                padding: 4px 5px 4px 10px; vertical-align: bottom; text-align: center; font-weight: bold">
                                                                Fecha
                                                            </th>
                                                            <th style="width: 120px; background: url(sprite.png) repeat-x 0px 0px; border-color: #507CD1 #507CD1 #507CD1 #507CD1;
                                                                border-style: solid solid solid none; border-width: 1px 1px 1px medium; color: White;
                                                                padding: 4px 5px 4px 10px; vertical-align: bottom; text-align: center; font-weight: bold">
                                                                Total
                                                            </th>
                                                        </tr>
                                                    </table>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <div class="group" id='<%#String.Format("customer{0}",Container.DataItemIndex) %>'
                                                        onclick='showhide(<%#String.Format("\"#customer{0}\"",Container.DataItemIndex) %>,<%#String.Format("\"#order{0}\"",Container.DataItemIndex) %>)'>
                                                        <asp:Image ID="imgCollapsible" CssClass="first" ImageUrl="~/GridView/plus.png" Style="margin-right: 5px;"
                                                            runat="server" />
                                                        <span class="header">
                                                            <asp:Label ID="lblCodCobro" runat="server" Text='<%#Eval("codCobro")%>' Width="220px"
                                                                Style="text-align: center; color: #333333;"></asp:Label>
                                                            <asp:Label ID="lblFechaCobro" runat="server" Text='<%#String.Format("{0:dd/MM/yyyy}",Eval("fechaCobro"))%>'
                                                                Width="105px" Style="text-align: center; color: #333333;"></asp:Label>
                                                            <asp:Label ID="lblMontoTotal" runat="server" Text='<%#String.Format("{0:c}",Eval("montoTotal"))%>'
                                                                Width="117px" Style="text-align: center; color: #333333;"></asp:Label>
                                                        </span>
                                                        <%--</div>--%>
                                                        <asp:SqlDataSource ID="sqlDsVentas" runat="server" ConnectionString="<%$ appSettings:keyconnection %>"
                                                            SelectCommand="SELECT codVenta, fecha, formaDePago, subtotal FROM DetalleCobro d inner join Ventas v on v.idVenta = d.codVenta WHERE codCobro = @CodCobro AND formaDePago LIKE 'Cuenta corriente' ORDER BY codVenta">
                                                            <SelectParameters>
                                                                <asp:Parameter Name="CodCobro" Type="String" DefaultValue="" />
                                                            </SelectParameters>
                                                        </asp:SqlDataSource>
                                                        <div id='<%#String.Format("order{0}",Container.DataItemIndex) %>' class="order">
                                                            <br />
                                                            <asp:GridView AutoGenerateColumns="false" CssClass="grid" ID="gridVentas" DataSourceID="sqlDsVentas"
                                                                runat="server" ShowHeader="true" EnableViewState="false">
                                                                <RowStyle CssClass="row" />
                                                                <Columns>
                                                                    <asp:TemplateField ItemStyle-CssClass="rownum">
                                                                        <ItemTemplate>
                                                                            <%# Container.DataItemIndex + 1 %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField HeaderText="Código de Venta" DataField="codVenta" ItemStyle-HorizontalAlign="Center" />
                                                                    <asp:BoundField HeaderText="Fecha" DataField="fecha" DataFormatString="{0:MM/dd/yyyy}"
                                                                        ItemStyle-HorizontalAlign="Center" />
                                                                    <asp:BoundField HeaderText="Forma de Pago" DataField="formaDePago" ItemStyle-HorizontalAlign="Center" />
                                                                    <asp:BoundField HeaderText="Subtotal" DataField="subtotal" ItemStyle-HorizontalAlign="Center"
                                                                        DataFormatString="{0:c}" />
                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <RowStyle BackColor="#EFF3FB" />
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
        <div class="footer">
            <div class="outer">
                <div class="inner">
                    <div class="content">
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphReserva" runat="server">
</asp:Content>

