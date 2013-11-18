<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Admin.Master" AutoEventWireup="true" 
    CodeBehind="ABMEmpleados.aspx.cs" Inherits="Dyn.Web.Admin.ABMEmpleados" %>

<%@ MasterType VirtualPath="~/Masters/Admin.Master" %>
<%@ Register Src="../controls/MenuAdminCategoria.ascx" TagName="MenuAdmin" TagPrefix="uc1" %>
<%@ Register Src="../controls/Login.ascx" TagName="Login" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .Style1
        {
            width: 25px;
        }
         .style3
        {
            width: 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphCentral" runat="server">
    <table width="100%" cellpadding="0" cellspacing="5" border="0">
        <tr>
            <td class="tittleprecios03" align="left" width="100%">
                N&uacute;mero Empleado:
            </td>
            <td align="left" class="style3">
                <asp:TextBox ID="txtNroEmpleado" runat="server" CssClass="tittleprecios03" Text="<%# Entity.NroEmpleado %>" 
                    Enabled="false"></asp:TextBox><br />
            </td>  
        </tr>
        <tr>
            <td class="tittleprecios03" align="left" width="100%">
                Tipo Documento: (*)
            </td>
            <td align="left" class="style3">
                <asp:DropDownList  CssClass="tittleprecios03" ID="lstTipoDoc" runat="server" OnSelectedIndexChanged="lstProvincias_SelectedIndexChanged">
                </asp:DropDownList> 
            </td>
            <td class="tittleprecios03" align="left" width="100%">
                N&uacute;mero Documento: (*)
            </td>
            <td align="left" class="Style1">
                <asp:CompareValidator ID="cvDocumento" runat="server" ErrorMessage="Debe ingresar un número" 
                    Display="Dynamic" Operator="DataTypeCheck" ControlToValidate="txtNroDocumento" 
                    CssClass="tittleprecios03" Type="Integer" ForeColor="Red"></asp:CompareValidator>
                <asp:TextBox ID="txtNroDocumento" runat="server" CssClass="tittleprecios03" Text="<%# Entity.NroDocumento %>" 
                    MaxLength="10"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Debe ingresar un número de documento" 
                    ControlToValidate="txtNroDocumento" CssClass="tittleprecios03" ForeColor="Red" 
                    Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
         </tr>
         <tr>
            <td class="tittleprecios03" align="left" width="100%">
                Nombre: (*)
            </td>
            <td align="left" class="Style1">
                <asp:TextBox ID="txtNombre" runat="server" CssClass="tittleprecios03" Text="<%# Entity.Nombre %>" 
                    MaxLength="10"></asp:TextBox><br />
                <asp:RangeValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Debe ingresar un nombre" 
                    ControlToValidate="txtNombre" CssClass="tittleprecios03" ForeColor="Red" 
                    Display="Dynamic"></asp:RangeValidator>
            </td>
             <td class="tittleprecios03" align="left" width="100%">
                Apellido: (*)
            </td>
            <td align="left" class="Style1">
                <asp:TextBox ID="txtApellido" runat="server" CssClass="tittleprecios03" Text="<%# Entity.Apellido %>" 
                    MaxLength="10"></asp:TextBox><br />
                <asp:RangeValidator ID="RangeValidator3" runat="server" ErrorMessage="Debe ingresar un apellido" 
                    ControlToValidate="txtApellido" CssClass="tittleprecios03" ForeColor="Red" 
                    Display="Dynamic"></asp:RangeValidator>
            </td>
        </tr>
        <tr>
            <td class="tittleprecios03" align="left" width="100%">
            </td>
        </tr>
        <tr>
            <td class="tittleprecios03" align="left" width="100%">
                Tel&eacute;fono:
            </td>
            <td align="left" class="Style3">
                <asp:TextBox ID="txtTelefono" runat="server" CssClass="tittleprecios03" Text="<%# Entity.Telefono %>" 
                    MaxLength="10"></asp:TextBox>
            </td>
            <td class="tittleprecios03" align="left" width="100">
                Celular:
            </td>
            <td align="left" class="style1">
                <asp:TextBox ID="txtCelular" runat="server" CssClass="tittleprecios03" Text="<%# Entity.Celular %>"
                    MaxLength="12"></asp:TextBox><br />
            </td>
        </tr>
        <tr>
            <td class="tittleprecios03" align="left" width="100">
                Correo Electr&oacute;nico:
            </td>
            <td align="left" class="style3">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" 
                    Display="Dynamic" ErrorMessage="El Email no es correcto" Font-Bold="true" ForeColor="Red" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="tittleprecios03" Text="<%# Entity.Email %>" 
                    Width="200px" MaxLength="50"></asp:TextBox><br />
            </td>
            </tr>
        <tr>
            <td class="tittleprecios03" align="left" width="100">
            </td>
        </tr>
        <tr>
            <td class="tittleprecios03" align="left" width="100">
                Direcci&oacute;n:
            </td>
        </tr>
        <tr>
            <td class="tittleprecios03" align="left" width="100">
                Barrio: (*)
            </td>
            <td align="left" class="style3">
                <asp:TextBox ID="txtBarrio" runat="server" CssClass="tittleprecios03" Text="<%# Entity.DomicilioBarrio %>"
                    MaxLength="100"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Debe ingresar un Barrio"
                    ControlToValidate="txtBarrio" CssClass="tittleprecios03" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="tittleprecios03" align="left" width="100">
                Calle: (*)
            </td>
            <td align="left" class="style3">
                <asp:TextBox ID="txtCalle" runat="server" CssClass="tittleprecios03" Text="<%# Entity.DomicilioCalle %>"
                    MaxLength="50"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Debe ingresar una Calle"
                    ControlToValidate="txtCalle" CssClass="tittleprecios03" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
            <td class="tittleprecios03" align="left" width="100">
                N&uacute;mero: (*)
            </td>
            <td align="left" class="style3">
                <asp:TextBox ID="txtNumero" runat="server" CssClass="tittleprecios03" Text="<%# Entity.DomicilioNro %>" 
                    MaxLength="6"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Debe ingresar un número de domicilio" 
                    ControlToValidate="txtNumero" CssClass="tittleprecios03" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cvDomNumero" runat="server" ErrorMessage="Debe ingresar un numero" 
                    Display="Dynamic" Operator="DataTypeCheck" ControlToValidate="txtNumero" CssClass="tittleprecios03" ForeColor="Red"></asp:CompareValidator>
            </td>          
        </tr>
        <tr>
            <td class="tittleprecios03" align="left" width="100%">
                Piso:
            </td>
            <td align="left" class="style3">
                <asp:TextBox ID="txtPiso" runat="server" CssClass="tittleprecios03" Text="<%# Entity.DomicilioPiso %>" 
                    MaxLength="6"></asp:TextBox><br />
                <asp:CompareValidator ID="cvDomPiso" runat="server" ErrorMessage="Debe ingresar un numero" 
                    Display="Dynamic" Operator="DataTypeCheck" ControlToValidate="txtPiso" CssClass="tittleprecios03" 
                    Type="Integer" ForeColor="Red"></asp:CompareValidator>
            </td>
            <td class="tittleprecios03" align="left" width="100">
                Departamento:
            </td>
            <td align="left" class="style3">
                <asp:TextBox ID="txtDpto" runat="server" CssClass="tittleprecios03" Text="<%# Entity.DomicilioDpto %>" 
                    MaxLength="5"></asp:TextBox><br />
            </td>
        </tr>
        <tr>
            <td class="tittleprecios03" align="left" width="100">
                Provincia:
            </td>
            <td align="left" class="style3">
                <asp:DropDownList CssClass="tittleprecios03" ID="lstProvincias" runat="server" 
                    OnSelectedIndexChanged="lstProvincias_SelectedIndexChanged" AutoPostBack="true">
                </asp:DropDownList>
            </td>
            <td class="tittleprecios03" align="left" width="100">
                Localidad:
            </td>
            <td align="left" class="Style1">
                <asp:DropDownList CssClass="tittleprecios03" ID="lstLocalidades" runat="server"> 
                </asp:DropDownList>
            </td>
        </tr>
         <tr>
            <td class="tittleprecios03" align="left">
                C&oacute;digo Postal:
            </td>
            <td align="left" class="style3">
                <asp:TextBox ID="txtCodPostal" runat="server" CssClass="tittleprecios03" Text="<%# Entity.DomicilioCodPostal %>"
                    MaxLength="5"></asp:TextBox><br />
            </td>
        </tr>
        <tr>
            <td colspan="4" class="tittleproducto">
                <br />
                    Datos de Usuario
                <hr />
            </td>
        </tr>
        <tr>
            <td align="left" class="tittleprecios03">
                Nombre de Usuario:
            </td>
            <td align="left">
                <asp:TextBox ID="txtLogin" CssClass="tittleprecios03" runat="server" Enabled="false"></asp:TextBox><br /> 
            </td>
            <td class="tittleprecios03">
                <asp:Button ID="btnModificarUsuario" runat="server" OnClick="btnModificarUsuario_Click" />
            </td>
        </tr>
        <tr>
            <td align="left" class="tittleprecios03">
                <asp:Label ID="lblPasswordActual" runat="server" Text="Contrase&ntilde;a Actual"></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="txtPasswordActual" CssClass="tittleprecios03" runat="server" Enabled="false"></asp:TextBox><br /> 
            </td>
        </tr>
        <tr>
            <td align="left" class="tittleprecios03">
                Nueva Contrase&ntilde;a:
            </td>
            <td align="left">
                <asp:TextBox ID="txtPassword" TextMode="Password" CssClass="tittleprecios03" runat="server"
                    Enabled="False"></asp:TextBox><br />
                <asp:CompareValidator Display="Dynamic" CssClass="tittleprecios03" ID="cvPassword" 
                    runat="server" ControlToCompare="txtRepetirPassword" ControlToValidate="txtPassword" 
                    ErrorMessage="La contrase&ntilde;a no coincide" ForeColor="Red"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td align="left" class="tittleprecios03">
                Confirmar Contrase&ntilde;a:
            </td>
            <td align="left">
                <asp:TextBox ID="txtRepetirPassword" CssClass="tittleprecios03" TextMode="Password" 
                    runat="server" Enabled="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="height: 24px">
                <br />
                <asp:Button CssClass="adminbutton" ID="btnGuardar" runat="server" Text="Guardar" 
                    OnClick="btnGuardar_Click" />&nbsp;
                <asp:Button CssClass="adminbutton" ID="btnCancelar" runat="server" Text="Cancelar" 
                    OnClick="btnCancelar_Click" />&nbsp;
                <asp:Button CssClass="adminbutton" ID="btnModificar" runat="server" Text="Modificar"
                    OnClick="btnModificar_Click" />&nbsp;
                <asp:Button CssClass="adminbutton" ID="btnEliminar" runat="server" Text="Eliminar" 
                    OnClick="btnEliminar_Click" />&nbsp;

            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphReserva" runat="server">
</asp:Content>
