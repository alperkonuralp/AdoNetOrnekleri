<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Procedures.aspx.cs" Inherits="DersDemo_Ado_Parameters.Procedures" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    Başlangıç Tarihi :
    <asp:TextBox ID="tbStart" runat="server" />
    <br />
    Bitiş Tarihi :
    <asp:TextBox ID="tbEnd" runat="server" />
    <br />
    <asp:Button ID="bSearch" runat="server" Text="Ara" OnClick="bSearch_Click" />
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <asp:GridView ID="gv" runat="server" />
    </form>
</body>
</html>
