<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Site.Master" AutoEventWireup="true"
    CodeBehind="MisDatos.aspx.cs" Inherits="Dyn.Web.User.MisDatos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%;">
        <tr>
            <td>
            </td>
            <td colspan="4">
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;
            </td>
            <td class="art-nav-outer" colspan="4">
                <h2 class="art-postheader">
                    <span class="art-postheadericon">Mis Datos </span>
                </h2>
            </td>
            <td class="art-nav-outer">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style1">
            </td>
            <td colspan="4">
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;
            </td>
            <%--            <td style="font-size: 16px;" colspan="4" class="art-post">
                Aquí puedas conocer el estado de tu cuenta y las compras realizadas que aun no han
                sido abonadas.
            </td>--%>
            <td style="font-size: 16px;" class="art-post">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;
            </td>
            <td style="font-size: 16px;" colspan="4">
                &nbsp;
            </td>
            <td style="font-size: 16px;">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="font-size: 16px;" align="left">
                N&uacute;mero Cliente:
            </td>
            <td align="left">
                <asp:Label ID="lblNroCliente" runat="server" CssClass="tittleprecios03" Enabled="False"
                    Width="200px"></asp:Label><br />
            </td>
        </tr>
        <tr>
            <td class="style1">
            </td>
            <td style="font-size: 16px;" align="left">
                Tipo Documento:
            </td>
            <td align="left">
                <asp:Label CssClass="tittleprecios03" ID="lblTipoDoc" runat="server" OnSelectedIndexChanged="lstProvincias_SelectedIndexChanged"
                    Enabled="False" Width="200px"></asp:Label>
            </td>
            <td style="font-size: 16px;" align="left">
                N&uacute;mero Documento:
            </td>
            <td align="left">
                <asp:Label ID="lblNroDocumento" runat="server" CssClass="tittleprecios03" MaxLength="10"
                    Enabled="False" Width="200px"></asp:Label><br />
            </td>
            <td align="left" class="style1">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style1">
            </td>
            <td style="font-size: 16px;" align="left">
                Nombre:
            </td>
            <td align="left">
                <asp:Label ID="lblNombre" runat="server" CssClass="tittleprecios03" MaxLength="50"
                    Enabled="False" Width="200px"></asp:Label><br />
            </td>
            <td style="font-size: 16px;" align="left">
                Apellido:
            </td>
            <td align="left">
                <asp:Label ID="lblApellido" runat="server" CssClass="tittleprecios03" MaxLength="50"
                    Enabled="False" Width="200px"></asp:Label><br />
            </td>
            <td align="left" class="style1">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style1">
            </td>
            <td style="font-size: 16px;" align="left">
                Alias:
            </td>
            <td align="left">
                <asp:Label ID="lblAlias" runat="server" CssClass="tittleprecios03" MaxLength="100"
                    Enabled="False" Width="200px"></asp:Label><br />
            </td>
        </tr>
        <tr>
            <td class="style1">
            </td>
            <td align="left">
            </td>
        </tr>
        <tr>
            <td class="style1">
            </td>
            <td style="font-size: 16px;" align="left">
                Tel&eacute;fono:
            </td>
            <td align="left">
                <asp:Label ID="lblTelefono" runat="server" CssClass="tittleprecios03" MaxLength="10"
                    Enabled="False" Width="200px"></asp:Label><br />
            </td>
            <td style="font-size: 16px;" align="left">
                Celular:
            </td>
            <td align="left">
                <asp:Label ID="lblCelular" runat="server" CssClass="tittleprecios03" MaxLength="12"
                    Enabled="False" Width="200px"></asp:Label><br />
            </td>
            <td align="left" class="style1">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style1">
            </td>
            <td style="font-size: 16px;" align="left">
                Correo Electr&oacute;nico:
            </td>
            <td align="left">
                <asp:Label ID="lblEMail" runat="server" CssClass="tittleprecios03" Width="200px"
                    MaxLength="50" Enabled="False"></asp:Label><br />
            </td>
        </tr>
        <tr>
            <td class="style1">
            </td>
            <td align="left">
            </td>
        </tr>
        <tr>
            <td class="style1">
<%--            </td>
            <td style="font-size: 16px;" align="left">
                Direcci&oacute;n
            </td>--%>
            <td colspan="5" class="tittleproducto">
                <br />
                Direcci&oacute;n
                <hr />
            </td>
        </tr>
        <tr>
            <td class="style1">
            </td>
            <td style="font-size: 16px;" align="left">
                Calle:
            </td>
            <td align="left">
                <asp:Label ID="lblCalle" runat="server" CssClass="tittleprecios03" MaxLength="50"
                    Width="200px" Enabled="False"></asp:Label><br />
            </td>
            <td style="font-size: 16px;" align="left">
                N&uacute;mero:
            </td>
            <td align="left">
                <asp:Label ID="lblNumero" runat="server" CssClass="tittleprecios03" MaxLength="6"
                    Width="200px" Enabled="False"></asp:Label><br />
            </td>
            <td align="left">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style1">
            </td>
            <td style="font-size: 16px;" align="left">
                Piso:
            </td>
            <td align="left">
                <asp:Label ID="lblPiso" runat="server" CssClass="tittleprecios03" MaxLength="5" Width="200px"
                    Enabled="False"></asp:Label><br />
            </td>
            <td style="font-size: 16px;" align="left">
                Departamento:
            </td>
            <td align="left">
                <asp:Label ID="lblDpto" runat="server" CssClass="tittleprecios03" MaxLength="5" Width="200px"
                    Enabled="False"></asp:Label><br />
            </td>
            <td align="left">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style1">
            </td>
            <td style="font-size: 16px;" align="left">
                Barrio:
            </td>
            <td align="left">
                <asp:Label ID="lblBarrio" runat="server" CssClass="tittleprecios03" MaxLength="100"
                    Width="200px" Enabled="False"></asp:Label><br />
            </td>
            <td style="font-size: 16px;" align="left">
                C&oacute;digo Postal:
            </td>
            <td align="left">
                <asp:Label ID="lblCodPostal" runat="server" CssClass="tittleprecios03" MaxLength="5"
                    Width="200px" Enabled="False"></asp:Label><br />
            </td>
        </tr>
        <tr>
            <td class="style1">
            </td>
            <td style="font-size: 16px;" align="left">
                Localidad:
            </td>
            <td align="left">
                <asp:Label CssClass="tittleprecios03" ID="lblLocalidad" runat="server" AutoPostBack="True"
                    Width="200px" Enabled="False">
                </asp:Label>
            </td>
            <td style="font-size: 16px;" align="left">
                Provincia:
            </td>
            <td align="left">
                <asp:Label CssClass="tittleprecios03" ID="lblProvincia" runat="server" Enabled="False"
                    Width="200px">
                </asp:Label>
            </td>
            <td align="left" class="style1">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style1">
            </td>
            <td colspan="2" style="height: 24px">
                <br />
                &nbsp; &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
