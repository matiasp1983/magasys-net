<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Site.Master" AutoEventWireup="true"
    CodeBehind="MostrarReserva.aspx.cs" Inherits="Dyn.Web.User.MostrarReserva" %>

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
                    <span class="art-postheadericon">Mi Reserva</span>
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
                Aquí podrás visualizar tu reserva.
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
            <td class="style5">
                &nbsp;
            </td>
            <td>
                <br />
                <table>
                    <tr>
                        <td colspan="2">
                            <table>
                                <tr>
                                    <td class="tittleprecios03" align="left">
                                        <asp:Label ID="lblFecha" runat="server" Text="Fecha de reserva:"></asp:Label>
                                    </td>
                                    <td class="tittleprecios03" align="left">
                                        <asp:Label ID="lblFechaText" runat="server" Width="160px" EnableTheming="True"></asp:Label>
                                    </td>
                                    <td class="tittleprecios03" align="left">
                                        <asp:Label ID="lblTipoReserva" runat="server" Text="  Tipo de reserva:" Width="120px"></asp:Label>
                                    </td>
                                    <td class="tittleprecios03" align="left">
                                        <asp:Label ID="lblTipoReservaText" runat="server" Text="<%# Entity.TipoReserva %>"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" class="tittleproducto">
                                        <br />
                                        Per&iacute;odo de reserva
                                        <hr />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tittleprecios03" align="left">
                                        <asp:Label ID="lblInicio" runat="server" Text="Inicio:"></asp:Label>
                                    </td>
                                    <td class="tittleprecios03" align="left">
                                        <asp:Label ID="lblFechaInicio" runat="server" Width="160px"></asp:Label>
                                    </td>
                                    <td class="tittleprecios03" align="left">
                                        <asp:Label ID="lblFin" runat="server" Text="Fin:"></asp:Label>
                                    </td>
                                    <td class="tittleprecios03" align="left">
                                        <asp:Label ID="lblFechaFin" runat="server" Width="160px"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <hr />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tittleprecios03" align="left">
                                        <asp:Label ID="lblidProducto" runat="server" Text="C&oacute;digo Producto:"></asp:Label>
                                    </td>
                                    <td class="tittleprecios03" align="left">
                                        <asp:Label ID="lblidProductoText" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tittleprecios03" align="left">
                                        <asp:Label ID="lblNombreProducto" runat="server" Text="Nombre:"></asp:Label>
                                    </td>
                                    <td class="tittleprecios03" align="left">
                                        <asp:Label ID="lblNombreProductoText" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tittleprecios03" align="left">
                                        <asp:Label ID="lblCantidad" runat="server" Text="Cantidad: "></asp:Label>
                                    </td>
                                    <td class="tittleprecios03" align="left">
                                        <asp:Label ID="lblCantidadText" runat="server" Text="<%# Entity.Cantidad %>" Width="25px"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <asp:Button ID="btnVolver" CssClass="adminbutton" runat="server" Text="Volver a listado reserva"
                                            OnClick="btnVolveraListadoReserva_Click" />
                                    </td>
                                </tr>
                            </table>
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
            <td class="style5">
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
