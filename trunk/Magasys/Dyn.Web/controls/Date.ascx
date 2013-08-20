<%@ Control Language="C#" AutoEventWireup="true" Inherits="Calendar_Date" CodeBehind="Date.ascx.cs" %>
<asp:Literal ID="litCSS" runat="server"></asp:Literal>
<asp:Literal ID="litJS" runat="server"></asp:Literal>
<table id="tbl_control" cellspacing="0" cellpadding="0" border="1" style="border-style: none;
    border-width: 0px; white-space: nowrap;">
    <tr>
        <td align="center" style="border-style: none; border-width: 0px; height: 30px;">
            <asp:TextBox CssClass="flatinput" ID="txt_Date" runat="server" Width="70"></asp:TextBox>&nbsp;
        </td>
        <td style="border-style: none; border-width: 0px; height: 30px;">
            <asp:Image ID="imgCalendar" runat="server" ImageUrl="/cal/calendar.gif"></asp:Image>
        </td>       
    </tr>
</table>
