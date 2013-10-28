<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Site.Master" AutoEventWireup="true"
    CodeBehind="MostrarReservaEdicion.aspx.cs" Inherits="Dyn.Web.User.MostrarReservaEdicion" %>

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
                Aquí podrás ver tus reservas realizadas.
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
                                    <td class="tittleprecios03" align="left" style="width: 115px">
                                        <asp:Label ID="lblFecha" runat="server" Text="Fecha de reserva:"></asp:Label>
                                    </td>
                                    <td class="tittleprecios03" align="left">
                                        <asp:Label ID="lblFechaText" runat="server" Width="160px"></asp:Label>
                                    </td>
                                    <td class="tittleprecios03" align="left">
                                        <asp:Label ID="lblTipoReserva" runat="server" Text="  Tipo de reserva:" Width="120px"></asp:Label>
                                    </td>
                                    <td class="tittleprecios03" align="left">
                                        <asp:Label ID="lblTipoReservaText" runat="server" Text="<%# Entity.TipoReserva %>"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="tittleproducto">
                            <br />
                            Per&iacute;odo de reserva
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td class="tittleprecios03" align="left">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblInicio" runat="server" Text="Inicio:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblFechaInicio" runat="server" Text="<%# Entity.FechaInicio %>" Width="160px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblFin" runat="server" Text="Fin:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblFechaFin" runat="server" Text="<%# Entity.FechaFin %>" Width="160px"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td class="tittleprecios03" align="left">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblidProducto" runat="server" Text="C&oacute;digo Producto:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblidProductoText" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblNombreProducto" runat="server" Text="Nombre:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblNombreProductoText" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblEdicion" runat="server" Text="Edici&oacute;n:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblEdicionText" runat="server" Text="<%# Entity.IdProductoEdicion %>"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblCantidad" runat="server" Text="Cantidad: "></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblCantidadText" runat="server" Text="<%# Entity.Cantidad %>" Width="25px"></asp:Label>
                                    </td>
                                </tr>
                            </table>
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
