<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Site.Master" AutoEventWireup="true"
    CodeBehind="MiCuenta.aspx.cs" Inherits="Dyn.Web.User.MiCuenta" %>

<%@ Register Src="~/controls/Date.ascx" TagName="Date" TagPrefix="uc2" %>
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

        document.getElementById("calendar").style.color = "blue";
    </script>
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
                    <span class="art-postheadericon">Mi Cuenta </span>
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
                Aquí puedas conocer el estado de tu cuenta y las compras realizadas que aun no han
                sido abonadas.
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
                        <td>
                            <asp:Button ID="btnBuscar" runat="server" Text="Buscar Deudas" OnClick="btnBuscar_Click" />
                        </td>
                    </tr>
                </table>
                <table width="100%">
                    <tr>
                        <td colspan="5" class="tittleproducto">
                            <br />
                            Detalle de ventas
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
                                        <asp:UpdatePanel ID="upVentas" runat="server">
                                            <ContentTemplate>
                                                <asp:GridView Width="100%" ID="gridVentas" AutoGenerateColumns="False" runat="server"
                                                    OnRowCreated="gridVentas_RowCreated" CellPadding="4" ForeColor="#333333" GridLines="None">
                                                    <AlternatingRowStyle BackColor="White" />
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <table width="100%" style="background-color: #507CD1">
                                                                    <tr>
                                                                        <th style="width: 265px; background: url(sprite.png) repeat-x 0px 0px; border-color: #507CD1 #507CD1 #507CD1 #507CD1;
                                                                            border-style: solid solid solid none; border-width: 1px 1px 1px medium; color: White;
                                                                            padding: 4px 5px 4px 10px; vertical-align: bottom; text-align: center; font-weight: bold">
                                                                            Código de Venta
                                                                        </th>
                                                                        <th style="width: 138px; background: url(sprite.png) repeat-x 0px 0px; border-color: #507CD1 #507CD1 #507CD1 #507CD1;
                                                                            border-style: solid solid solid none; border-width: 1px 1px 1px medium; color: White;
                                                                            padding: 4px 5px 4px 10px; vertical-align: bottom; text-align: center; font-weight: bold">
                                                                            Fecha
                                                                        </th>
                                                                        <th style="width: 120px; background: url(sprite.png) repeat-x 0px 0px; border-color: #507CD1 #507CD1 #507CD1 #507CD1;
                                                                            border-style: solid solid solid none; border-width: 1px 1px 1px medium; color: White;
                                                                            padding: 4px 5px 4px 10px; vertical-align: bottom; text-align: center; font-weight: bold">
                                                                            N&uacute;mero Cliente
                                                                        </th>
                                                                        <th style="width: 120px; background: url(sprite.png) repeat-x 0px 0px; border-color: #507CD1 #507CD1 #507CD1 #507CD1;
                                                                            border-style: solid solid solid none; border-width: 1px 1px 1px medium; color: White;
                                                                            padding: 4px 5px 4px 10px; vertical-align: bottom; text-align: center; font-weight: bold">
                                                                            Apellido
                                                                        </th>
                                                                        <th style="width: 120px; background: url(sprite.png) repeat-x 0px 0px; border-color: #507CD1 #507CD1 #507CD1 #507CD1;
                                                                            border-style: solid solid solid none; border-width: 1px 1px 1px medium; color: White;
                                                                            padding: 4px 5px 4px 10px; vertical-align: bottom; text-align: center; font-weight: bold">
                                                                            Nombre
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
                                                                        <asp:Label ID="lblCodCVenta" runat="server" Text='<%#Eval("idVenta")%>' Width="132px"
                                                                            Style="text-align: center; color: #333333;"></asp:Label>
                                                                        <asp:Label ID="lblFechaVenta" runat="server" Text='<%#String.Format("{0:dd/MM/yyyy}",Eval("fecha"))%>'
                                                                            Width="140px" Style="text-align: center; color: #333333;"></asp:Label>
                                                                        <asp:Label ID="lblNroCliente" runat="server" Text='<%#Eval("nroCliente")%>' Width="53px"
                                                                            Style="text-align: center; color: #333333;"></asp:Label>
                                                                        <asp:Label ID="lblApellido" runat="server" Text='<%#Eval("Cliente.Apellido")%>' Width="130px"
                                                                            Style="text-align: center; color: #333333;"></asp:Label>
                                                                        <asp:Label ID="lblNombre" runat="server" Text='<%#Eval("Cliente.Nombre")%>' Width="64px"
                                                                            Style="text-align: center; color: #333333;"></asp:Label>
                                                                        <asp:Label ID="lblTotal" runat="server" Text='<%#String.Format("{0:c}",Eval("montotal"))%>'
                                                                            Width="85px" Style="text-align: right; color: #333333;"></asp:Label>
                                                                    </span>
                                                                    <%--</div>--%>
                                                                    <asp:SqlDataSource ID="sqlDsDetalleVenta" runat="server" ConnectionString="<%$ appSettings:keyconnection %>"
                                                                        SelectCommand="SELECT p.nombre, d.precioUnidad, d.cantidad, d.subTotal FROM DetalleVentas d inner join Ventas v on v.idVenta = d.idVenta inner join Productos p on p.idProducto = d.idProducto WHERE d.idVenta = @idVenta ORDER BY p.nombre">
                                                                        <SelectParameters>
                                                                            <asp:Parameter Name="idVenta" Type="String" DefaultValue="" />
                                                                        </SelectParameters>
                                                                    </asp:SqlDataSource>
                                                                    <div id='<%#String.Format("order{0}",Container.DataItemIndex) %>' class="order">
                                                                        <br />
                                                                        <asp:GridView AutoGenerateColumns="false" CssClass="grid" ID="gridDetalleVenta" DataSourceID="sqlDsDetalleVenta"
                                                                            runat="server" ShowHeader="true" EnableViewState="false">
                                                                            <RowStyle CssClass="row" />
                                                                            <Columns>
                                                                                <asp:TemplateField ItemStyle-CssClass="rownum">
                                                                                    <ItemTemplate>
                                                                                        <%# Container.DataItemIndex + 1 %>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField HeaderText="Producto" DataField="nombre" ItemStyle-HorizontalAlign="Center" />
                                                                                <asp:BoundField HeaderText="Precio Unitario" DataField="precioUnidad" DataFormatString="{0:c}"
                                                                                    ItemStyle-HorizontalAlign="Center" />
                                                                                <asp:BoundField HeaderText="Cantidad" DataField="cantidad" ItemStyle-HorizontalAlign="Center" />
                                                                                <asp:BoundField HeaderText="Subtotal" DataField="subTotal" DataFormatString="{0:c}"
                                                                                    ItemStyle-HorizontalAlign="Center" />
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
