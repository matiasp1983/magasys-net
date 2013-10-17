
<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PaginaKiosko.Login" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
    Conectarse como usuario</p>
<table class="style2">
    <tr>
        <td>
            Usuario</td>
        <td>
            <asp:TextBox ID="TxtUsuario" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="TxtUsuario" Display="Dynamic" 
                ErrorMessage="Debe ingresar el usuario" ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>
            Contraseña</td>
        <td>
            <asp:TextBox ID="TxtContraseña" runat="server" TextMode="Password"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="LabInfo" runat="server" ForeColor="Red" Visible="False"></asp:Label>
        </td>
        <td>
            <asp:Button ID="BtnConectarse" runat="server" onclick="BtnConectarse_Click" 
                Text="Ingresar" CssClass="art-button" />
        </td>
    </tr>
</table>
</asp:Content>
