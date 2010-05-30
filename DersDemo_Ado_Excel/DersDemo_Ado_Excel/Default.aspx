<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DersDemo_Ado_Excel._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:Panel ID="p1" runat="server">
        Excel Dosyası :
        <asp:FileUpload ID="fu" runat="server" />
        <asp:Button ID="bSend" runat="server" Text="Gönder" onclick="bSend_Click" />
    </asp:Panel>
    <asp:Panel ID="p2" runat="server" Visible="false">
        Sayfa :
        <asp:DropDownList ID="ddlSheets" runat="server" 
            AutoPostBack="true" 
            onselectedindexchanged="ddlSheets_SelectedIndexChanged" />
        <asp:GridView ID="gv" runat="server" />
    </asp:Panel>
    </form>
</body>
</html>
