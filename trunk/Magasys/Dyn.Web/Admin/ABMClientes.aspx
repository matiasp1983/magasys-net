﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Admin.Master" AutoEventWireup="true" CodeBehind="ABMClientes.aspx.cs" Inherits="Dyn.Web.Admin.ABMClientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 25px;
        }
        .style2
        {
            width: 100px;
        }
        .style3
        {
            width: 5px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMenu" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphCentral" runat="server">
     <table width="100%" cellpadding="0" cellspacing="5" border="0">

        <tr>
            <td class="tittleprecios03" align="left" width="100">
                Numero Cliente
            </td>
            <td align="left" class="style3">
                <asp:TextBox ID="txtNroCliente" runat="server" CssClass="tittleprecios03" 
                    Text="<%# Entity.NroCliente %>" Enabled="False"></asp:TextBox><br />
            </td>
        </tr>
        <tr>
            <td class="tittleprecios03" align="left" width="100">
                Tipo Documento (*)
            </td>
            <td align="left" class="style3">
                <asp:DropDownList CssClass="tittleprecios03" ID="lstTipoDoc" runat="server" 
                    onselectedindexchanged="lstProvincias_SelectedIndexChanged" 
                    Enabled="False" DataSourceID="DSTipoDocumento" DataTextField="nombre" 
                    DataValueField="idTipoDocumento">
                </asp:DropDownList>
                <asp:SqlDataSource ID="DSTipoDocumento" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:MagasysConnectionString %>" 
                    SelectCommand="SELECT * FROM [TipoDocumento]"></asp:SqlDataSource>
            </td>
            <td class="tittleprecios03" align="left" width="100">
                Numero Documento (*)
            </td>
            <td align="left" class="style1">
                <asp:TextBox ID="txtNroDocumento" runat="server" CssClass="tittleprecios03" 
                    Text="<%# Entity.NroDocumento %>" Enabled="False"></asp:TextBox><br />
            </td>
        </tr>
        <tr>
            <td class="tittleprecios03" align="left" width="100">
                Nombre (*)</td>
            <td align="left" class="style3">
                <asp:TextBox ID="txtNombre" runat="server" CssClass="tittleprecios03" Text="<%# Entity.Nombre %>"></asp:TextBox><br />
            </td>
            <td class="tittleprecios03" align="left" width="100">
                Apellido (*)</td>
            <td align="left" class="style1">
                <asp:TextBox ID="txtApellido" runat="server" CssClass="tittleprecios03" Text="<%# Entity.Apellido %>"></asp:TextBox><br />
            </td>
        </tr>
        <tr>
            <td class="tittleprecios03" align="left" width="100">
                Alias</td>
            <td align="left" class="style3">
                <asp:TextBox ID="txtAlias" runat="server" CssClass="tittleprecios03" Text="<%# Entity.Alias %>"></asp:TextBox><br />
            </td>
        </tr>
        <tr>
            <td class="tittleprecios03" align="left" width="100">
                
            </td>
        </tr>
        <tr>
            <td class="tittleprecios03" align="left" width="100">
                Telefono</td>
            <td align="left" class="style3">
                <asp:TextBox ID="txtTelefono" runat="server" CssClass="tittleprecios03" Text="<%# Entity.Telefono %>"></asp:TextBox><br />
            </td>
            <td class="tittleprecios03" align="left" width="100">
                Celular</td>
            <td align="left" class="style1">
                <asp:TextBox ID="txtCelular" runat="server" CssClass="tittleprecios03" Text="<%# Entity.Celular %>"></asp:TextBox><br />
            </td>
        </tr>
        <tr>
            <td class="tittleprecios03" align="left" width="100">
                Correo Electronico</td>
            <td align="left" class="style3">
                <asp:TextBox ID="txtEMail" runat="server" CssClass="tittleprecios03" 
                    Text="<%# Entity.Email %>" Width="200px"></asp:TextBox><br />
            </td>
        </tr>
        <tr>
            <td class="tittleprecios03" align="left" width="100">
                
            </td>
        </tr>
        <tr>
            <td class="tittleprecios03" align="left" width="100">
                Direccion
            </td>
        </tr>
        <tr>
            <td class="tittleprecios03" align="left" width="100">
                Barrio (*)
            </td>
            <td align="left" class="style3">
                <asp:TextBox ID="txtBarrio" runat="server" CssClass="tittleprecios03" Text="<%# Entity.DomicilioBarrio %>"></asp:TextBox><br />
            </td>
        </tr>
        <tr>
            <td class="tittleprecios03" align="left" width="100">
                Calle (*)
            </td>
            <td align="left" class="style3">
                <asp:TextBox ID="txtCalle" runat="server" CssClass="tittleprecios03" Text="<%# Entity.DomicilioCalle %>"></asp:TextBox><br />
            </td>

            <td class="tittleprecios03" align="left">
                Numero (*)
            </td>
            <td align="left" class="style3">
                <asp:TextBox ID="txtNumero" runat="server" CssClass="tittleprecios03" Text="<%# Entity.DomicilioNro %>"></asp:TextBox><br />
            </td>
        </tr>

                <tr>
            <td class="tittleprecios03" align="left" width="100">
                Piso
            </td>
            <td align="left" class="style3">
                <asp:TextBox ID="txtPiso" runat="server" CssClass="tittleprecios03" Text="<%# Entity.DomicilioPiso %>"></asp:TextBox><br />
            </td>

            <td class="tittleprecios03" align="left">
                Departamento
            </td>
            <td align="left" class="style3">
                <asp:TextBox ID="txtDpto" runat="server" CssClass="tittleprecios03" Text="<%# Entity.DomicilioDpto %>"></asp:TextBox><br />
            </td>
        </tr>

                

                <tr>
            <td class="tittleprecios03" align="left" width="100">
                Provincia
            </td>
            <td align="left" class="style3">
                <asp:DropDownList CssClass="tittleprecios03" ID="lstProvincias" runat="server" 
                    onselectedindexchanged="lstProvincias_SelectedIndexChanged" 
                    Enabled="False">
                </asp:DropDownList>
                    </td>

            <td class="tittleprecios03" align="left">
                Localidad
            </td>
            <td align="left" class="style1">
                <asp:DropDownList CssClass="tittleprecios03" ID="lstLocalidades" runat="server">
                </asp:DropDownList>
            </td>
        </tr>

        
        <tr>
            <td class="tittleprecios03" align="left" width="100">
                
            </td>
        </tr>
        



        <tr>
            <td colspan="2" style="height: 24px">
                <br />
                <asp:Button CssClass="adminbutton" ID="btnGuardar" runat="server" Text="Guardar"
                    OnClick="btnGuardar_Click" />&nbsp;
                <asp:Button CssClass="adminbutton" ID="btnCancelar" runat="server" Text="Cancelar"
                    OnClick="btnCancelar_Click" CausesValidation="False" />&nbsp;
                <asp:Button CssClass="adminbutton" ID="btnEliminar" runat="server" Text="Eliminar"
                    OnClick="btnEliminar_Click" CausesValidation="False" />
            </td>
        </tr>
                                
</table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphReserva" runat="server">
</asp:Content>
