<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Site.Master" AutoEventWireup="true"
    CodeBehind="Contacto.aspx.cs" Inherits="Dyn.Web.Contacto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style2
        {
            width: 130px;
            height: 29px;
        }
        .style3
        {
            height: 29px;
        }
        .style4
        {
            width: 130px;
        }
        .style5
        {
            width: 130px;
            height: 24px;
        }
        .style6
        {
            height: 24px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="art-layout-cell art-content">
        <div class="art-box art-post">
            <div class="art-box-body art-post-body">
                <div class="art-post-inner art-article">
                    <h2 class="art-postheader">
                        <span class="art-postheadericon">Contacto </span>
                    </h2>
                    <div class="art-postcontent">
                        <div class="art-content-layout-wrapper layout-item-0">
                            <div class="art-content-layout layout-item-1">
                                <div class="art-content-layout-row">
                                    <div class="art-layout-cell layout-item-2" style="width: 100%;">
                                        <p>
                                            <span style="font-size: 16px;">Dejamos tu mensaje, sugerencia o consulta y te responderemos
                                                a la brevedad</span></p>
                                        <p>
                                            <span style="font-size: 16px;">
                                                <br />
                                            </span>
                                        </p>
                                        <table class="art-article" border="0" cellspacing="0" cellpadding="0" style="width: 100%;">
                                            <tbody>
                                                <tr>
                                                    <td class="style4">
                                                        <span style="font-size: 16px;">Nombre</span>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="TextBox1" runat="server" Width="400px"></asp:TextBox>
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style5">
                                                        <span style="font-size: 16px;">Apellido</span>
                                                    </td>
                                                    <td class="style6">
                                                        <asp:TextBox ID="TextBox2" runat="server" Width="400px"></asp:TextBox>
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style2">
                                                        <span style="font-size: 16px;">Correo Electronico</span></td>
                                                    <td class="style3">
                                                        <asp:TextBox ID="TextBox3" runat="server" Width="400px"></asp:TextBox>
                                                        <span style="font-size: 16px;">
                                                            <br />
                                                        </span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style4">
                                                        <span style="font-size: 16px;">Mensaje</span>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="TextBox4" runat="server" Height="200px" Rows="6" Width="400px"></asp:TextBox>
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style4">
                                                        <br />
                                                    </td>
                                                    <td>
                                                        <br />
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                        <p>
                                            <a href="" class="art-button">Enviar</a> <span style="font-size: 16px;">
                                                <br />
                                            </span>
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="cleared">
                    </div>
                </div>
                <div class="cleared">
                </div>
            </div>
        </div>
        <div class="cleared">
        </div>
    </div>
</asp:Content>
