<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Admin.Master" AutoEventWireup="true" CodeBehind="Proveedor.aspx.cs" Inherits="Dyn.Web.Admin.Proveedor" %>

<%@ MasterType VirtualPath="~/Masters/Admin.Master" %>
<%@ Register Src="../controls/Login.ascx" TagName="Login" TagPrefix="uc2" %>
<%@ Register Src="../controls/MenuAdminCategoria.ascx" TagName="MenuAdmin" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 275px;
        }
    </style>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphCentral" runat="server">

 <table width="100%" cellpadding="0" cellspacing="5" border="0">

        <tr>
            <td class="tittleprecios03" align="left" width="100">
                CUIT(*)
            </td>
            <td align="left" class="style1">
                <asp:TextBox ID="txtCuit" runat="server" CssClass="tittleprecios03" Text="<%# Entity.Cuit %>"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Debe ingresar Razon Social"
                    ControlToValidate="txtCuit" CssClass="tittleprecios03" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>

            <td class="tittleprecios03" align="left" width="100">
                Razon Social(*)
            </td>
            <td align="left" width="150">
                <asp:TextBox ID="txtRazonSocial" runat="server" CssClass="tittleprecios03" Text="<%# Entity.RazonSocial %>"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ErrorMessage="Debe ingresar Razon Social"
                    ControlToValidate="txtRazonSocial" CssClass="tittleprecios03" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>

            <td class="tittleprecios03" align="left" width="100">
                Correo Electronico(*)
            </td>
            <td align="left" class="style1">
                <asp:TextBox ID="txtEMail" runat="server" CssClass="tittleprecios03" Text="<%#Entity.Email%>"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Debe ingresar Razon Social"
                    ControlToValidate="txtEMail" CssClass="tittleprecios03" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td class="tittleprecios03" align="left" width="100">
                Detalle
            </td>

            <td class="style1">
                <asp:TextBox ID="txtDetalle" runat="server" Height="100px" Width="400px" CssClass="tittleprecios03"
                    Text="<%# Entity.Detalle %>" TextMode="MultiLine"></asp:TextBox><br />
            </td>
        </tr>

        <tr>
            <td class="tittleprecios03" align="left" width="100">
                Telefono
            </td>
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

            <td class="tittleprecios03" align="left" width="100">
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

            <td class="tittleprecios03" align="left" width="100">
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

            <td class="tittleprecios03" align="left" width="100">
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

            <td class="tittleprecios03" align="left" width="100">
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
