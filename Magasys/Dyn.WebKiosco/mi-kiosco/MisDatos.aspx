<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MisDatos.aspx.cs" Inherits="Dyn.WebKiosco.mi_kiosco.MisDatos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 20px;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
        <tr>
        <td>
            </td>
        <td colspan="4">
            </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td class="art-nav-outer" colspan="4">
            <h2 class="art-postheader">
                <span class="art-postheadericon">Mi Cuenta </span>
            </h2>
        </td>
        <td class="art-nav-outer">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style1">
        </td>
        <td colspan="4">
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td style="font-size: 16px;" colspan="4" class="art-post">
            Aquí puedas conocer el estado de tu cuenta y las compras realizadas que aun no 
            han sido abonadas.</td>
        <td style="font-size: 16px;" class="art-post">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td style="font-size: 16px;" colspan="4">
            &nbsp;</td>
        <td style="font-size: 16px;">
            &nbsp;</td>
    </tr>
    <tr>
            <td>
            
            </td>
            <td style="font-size: 16px;" align="left">
                Numero Cliente
            </td>
            <td align="left">
                <asp:TextBox ID="txtNroCliente" runat="server" CssClass="art-box-body" Text="<%# Entity.NroCliente %>"
                    Enabled="False" Width="200px"></asp:TextBox><br />
            </td>
        </tr>
        <tr>
            <td class="style1">
            
            </td>
            <td style="font-size: 16px;" align="left">
                Tipo Documento</td>
            <td align="left">
                <asp:DropDownList CssClass="tittleprecios03" ID="lstTipoDoc" runat="server" 
                    OnSelectedIndexChanged="lstProvincias_SelectedIndexChanged" Enabled="False" 
                    Width="200px">
                </asp:DropDownList>
            </td>
            <td style="font-size: 16px;" align="left">
                Numero Documento</td>
            <td align="left">
                <asp:TextBox ID="txtNroDocumento" runat="server" CssClass="tittleprecios03" Text="<%# Entity.NroDocumento %>"
                    MaxLength="10" Enabled="False" Width="200px"></asp:TextBox><br />
            </td>
            <td align="left" class="style1">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
            
            </td>
            <td style="font-size: 16px;" align="left">
                Nombre</td>
            <td align="left">
                <asp:TextBox ID="txtNombre" runat="server" CssClass="tittleprecios03" Text="<%# Entity.Nombre %>"
                    MaxLength="50" Enabled="False" Width="200px"></asp:TextBox><br />
            </td>
            <td style="font-size: 16px;" align="left">
                Apellido</td>
            <td align="left">
                <asp:TextBox ID="txtApellido" runat="server" CssClass="tittleprecios03" Text="<%# Entity.Apellido %>"
                    MaxLength="50" Enabled="False" Width="200px"></asp:TextBox><br />
            </td>
            <td align="left" class="style1">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
            </td>
            <td style="font-size: 16px;" align="left">
                Alias
            </td>
            <td align="left">
                <asp:TextBox ID="txtAlias" runat="server" CssClass="tittleprecios03" Text="<%# Entity.Alias %>"
                    MaxLength="100" Enabled="False" Width="200px"></asp:TextBox><br />
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
                Telefono
            </td>
            <td align="left">
                <asp:TextBox ID="txtTelefono" runat="server" CssClass="tittleprecios03" Text="<%# Entity.Telefono %>"
                    MaxLength="10" Enabled="False" Width="200px"></asp:TextBox><br />
            </td>
            <td style="font-size: 16px;" align="left">
                Celular
            </td>
            <td align="left">
                <asp:TextBox ID="txtCelular" runat="server" CssClass="tittleprecios03" Text="<%# Entity.Celular %>"
                    MaxLength="12" Enabled="False" Width="200px"></asp:TextBox><br />
            </td>
            <td align="left" class="style1">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
            </td>
            <td style="font-size: 16px;" align="left">
                Correo Electronico
            </td>
            <td align="left">
                <asp:TextBox ID="txtEMail" runat="server" CssClass="tittleprecios03" Text="<%# Entity.Email %>"
                    Width="200px" MaxLength="50" Enabled="False"></asp:TextBox><br />
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
                Direccion</td>
        </tr>
        <tr>
            <td class="style1">
            </td>
            <td style="font-size: 16px;" align="left">
                Barrio
            </td>
            <td align="left">
                <asp:TextBox ID="txtBarrio" runat="server" CssClass="tittleprecios03" Text="<%# Entity.DomicilioBarrio %>"
                    MaxLength="100" Width="200px" Enabled="False"></asp:TextBox><br />
            </td>
        </tr>
        <tr>
            <td class="style1">
            </td>
            <td style="font-size: 16px;" align="left">
                Calle
            </td>
            <td align="left">
                <asp:TextBox ID="txtCalle" runat="server" CssClass="tittleprecios03" Text="<%# Entity.DomicilioCalle %>"
                    MaxLength="50" Width="200px" Enabled="False"></asp:TextBox><br />
            </td>
            <td style="font-size: 16px;" align="left">
                Numero
            </td>
            <td align="left">
                <asp:TextBox ID="txtNumero" runat="server" CssClass="tittleprecios03" Text="<%# Entity.DomicilioNro %>"
                    MaxLength="6" Width="200px" Enabled="False"></asp:TextBox><br />
            </td>
            <td align="left">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
            </td>
            <td style="font-size: 16px;" align="left">
                Piso
            </td>
            <td align="left">
                <asp:TextBox ID="txtPiso" runat="server" CssClass="tittleprecios03" Text="<%# Entity.DomicilioPiso %>"
                    MaxLength="5" Width="200px" Enabled="False"></asp:TextBox><br />
            </td>
            <td style="font-size: 16px;" align="left">
                Departamento
            </td>
            <td align="left">
                <asp:TextBox ID="txtDpto" runat="server" CssClass="tittleprecios03" Text="<%# Entity.DomicilioDpto %>"
                    MaxLength="5" Width="200px" Enabled="False"></asp:TextBox><br />
            </td>
            <td align="left">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
            </td>
            <td style="font-size: 16px;" align="left">
                Provincia
            </td>
            <td align="left">
                <asp:DropDownList CssClass="tittleprecios03" ID="lstProvincias" runat="server" OnSelectedIndexChanged="lstProvincias_SelectedIndexChanged"
                    AutoPostBack="True" Width="200px" Enabled="False">
                </asp:DropDownList>
            </td>
            <td style="font-size: 16px;" align="left">
                Localidad
            </td>
            <td align="left">
                <asp:DropDownList CssClass="tittleprecios03" ID="lstLocalidades" runat="server" 
                    Enabled="False" Width="200px">
                </asp:DropDownList>
            </td>
            <td align="left" class="style1">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1"></td>
            <td style="font-size: 16px;" align="left">
                Codigo Postal
            </td>
            <td align="left">
                <asp:TextBox ID="txtCodPostal" runat="server" CssClass="tittleprecios03" Text="<%# Entity.DomicilioCodPostal %>"
                    MaxLength="5" Width="200px" Enabled="False"></asp:TextBox><br />
            </td>
        </tr>
        <tr>
            <td class="style1"></td>
            <td align="left">
            </td>
        </tr>
        <tr>
            <td class="style1"></td>
            <td colspan="2" style="height: 24px">
                <br />
                <asp:Button CssClass="art-button" ID="btnGuardar" runat="server" Text="Guardar"
                    OnClick="btnGuardar_Click" />&nbsp;
                <asp:Button CssClass="art-button" ID="btnCancelar" runat="server" Text="Cancelar"
                    OnClick="btnCancelar_Click" CausesValidation="False" />&nbsp;
                <asp:Button CssClass="art-button" ID="btnEliminar" runat="server" Text="Eliminar"
                    OnClick="btnEliminar_Click" CausesValidation="False" />
            </td>
        </tr>
    </table>
</asp:Content>
