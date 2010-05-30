<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DersDemo_Ado_Parameters._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <table>
        <tr>
            <td>
                User Name
            </td>
            <td align="center">
                :
            </td>
            <td>
                <asp:TextBox ID="tbUserName" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                Password
            </td>
            <td align="center">
                :
            </td>
            <td>
                <asp:TextBox ID="tbPassword" runat="server" TextMode="Password" />
            </td>
        </tr>
        <tr>
            <td>
                Tarih
            </td>
            <td align="center">
                :
            </td>
            <td>
                <asp:TextBox ID="tbDate" runat="server" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="3">
                <asp:Button ID="bLogin" runat="server" Text="Giriş" OnClick="bLogin_Click" />
                <asp:Label ID="lMessage" runat="server" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
