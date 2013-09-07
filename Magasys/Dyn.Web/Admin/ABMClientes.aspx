<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Admin.Master" AutoEventWireup="true" CodeBehind="ABMClientes.aspx.cs" Inherits="Dyn.Web.Admin.ABMClientes" %>
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
            <td align="left" class="style1">
                <asp:TextBox ID="txtNumero" runat="server" CssClass="tittleprecios03" 
                    Text="<%# Entity.Numero %>" Enabled="False"></asp:TextBox><br />
            </td>
        </tr>

        <tr>
            <td class="tittleprecios03" align="left" width="100">
                Nombre</td>
            <td align="left" class="style1">
                <asp:TextBox ID="txtTelefono" runat="server" CssClass="tittleprecios03" Text="<%# Entity.Telefono %>"></asp:TextBox><br />
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
                Calle
            </td>
            <td align="left" class="style1">
                <asp:TextBox ID="txtCalle" runat="server" CssClass="tittleprecios03" Text="<%# Entity.DomicilioCalle %>"></asp:TextBox><br />
            </td>

            <td class="style2" align="left">
                Numero
            </td>
            <td align="left" class="style1">
                <asp:TextBox ID="txtNumero" runat="server" CssClass="tittleprecios03" Text="<%# Entity.DomicilioNro %>"></asp:TextBox><br />
            </td>
        </tr>

                <tr>
            <td class="tittleprecios03" align="left" width="100">
                Piso
            </td>
            <td align="left" class="style1">
                <asp:TextBox ID="txtPiso" runat="server" CssClass="tittleprecios03" Text="<%# Entity.DomicilioPiso %>"></asp:TextBox><br />
            </td>

            <td class="style2" align="left">
                Departamento
            </td>
            <td align="left" class="style1">
                <asp:TextBox ID="txtDpto" runat="server" CssClass="tittleprecios03" Text="<%# Entity.DomicilioDpto %>"></asp:TextBox><br />
            </td>
        </tr>

                

                <tr>
            <td class="tittleprecios03" align="left" width="100">
                Provincia
            </td>
            <td align="left" class="style1">
                <asp:DropDownList CssClass="tittleprecios03" ID="lstProvincias" runat="server" 
                    onselectedindexchanged="lstProvincias_SelectedIndexChanged" 
                    Enabled="False">
                </asp:DropDownList>
                    </td>

            <td class="style2" align="left">
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
            <td class="tittleprecios03" align="left" width="100">
                Persona de Contacto
            </td>
        </tr>

               <tr>
            <td class="tittleprecios03" align="left" width="100">
                Nombre
            </td>
            <td align="left" class="style1">
                <asp:TextBox ID="txtResponsableNombre" runat="server" CssClass="tittleprecios03" Text="<%# Entity.ResponsableNombre %>"></asp:TextBox><br />
            </td>

            <td class="style2" align="left">
                Apellido
            </td>
            <td align="left" class="style1">
                <asp:TextBox ID="txtResponsableApellido" runat="server" CssClass="tittleprecios03" Text="<%# Entity.ResponsableApellido %>"></asp:TextBox><br />
            </td>
        </tr>
        
        <tr>
            <td class="tittleprecios03" align="left" width="100">
                Correo Electronico
            </td>
            <td align="left" class="style1">
                <asp:TextBox ID="txtResponsableEmail" runat="server" CssClass="tittleprecios03" Text="<%# Entity.ResponsableEmail %>"></asp:TextBox><br />
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
