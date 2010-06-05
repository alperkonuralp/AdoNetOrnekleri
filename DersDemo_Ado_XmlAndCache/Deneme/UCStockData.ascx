<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCStockData.ascx.cs"
    Inherits="DersDemo_Ado_XmlAndCache.UCStockData" %>
<%--<asp:GridView ID="gv" runat="server" />--%><asp:ListView ID="ListView1" 
    runat="server" DataSourceID="ObjectDataSource1" GroupItemCount="2">
    <EmptyItemTemplate>
        <td runat="server" />
        </EmptyItemTemplate>
        <ItemTemplate>
            <td runat="server" class="style1" 
                style="background-color:#DCDCDC;color: #000000;">
                <b>
                <asp:Label ID="SymbolLabel" runat="server" Text='<%# Eval("Symbol") %>'></asp:Label>
                &nbsp;-
                <asp:Label ID="DescriptionLabel" runat="server" 
                    Text='<%# Eval("Description") %>'></asp:Label>
                </b>
                <br />
                <asp:Label ID="LastPriceLabel" runat="server" Text='<%# Eval("LastPrice") %>'></asp:Label>
                &nbsp;(
                <asp:Image ID="iUp" runat="server" OnInit="iUp_Init" 
                    Visible='<%# (double)Eval("Pernc") > 0 %>' />
                <asp:Image ID="iDown" runat="server" OnInit="iDown_Init" 
                    Visible='<%# (double)Eval("Pernc") < 0 %>' />
                <asp:Label ID="PerncLabel" runat="server" Text='<%# Eval("Pernc") %>'></asp:Label>
                )<br />
            </td>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <td runat="server" style="background-color:#FFF8DC;">
                <b>
                <asp:Label ID="SymbolLabel" runat="server" Text='<%# Eval("Symbol") %>'></asp:Label>
                &nbsp;-
                <asp:Label ID="DescriptionLabel" runat="server" 
                    Text='<%# Eval("Description") %>'></asp:Label>
                </b>
                <br />
                <asp:Label ID="LastPriceLabel" runat="server" Text='<%# Eval("LastPrice") %>'></asp:Label>
                &nbsp;(
                <asp:Image ID="iUp" runat="server" OnInit="iUp_Init" 
                    Visible='<%# (double)Eval("Pernc") > 0 %>' />
                <asp:Image ID="iDown" runat="server" OnInit="iDown_Init" 
                    Visible='<%# (double)Eval("Pernc") < 0 %>' />
                <asp:Label ID="PerncLabel" runat="server" Text='<%# Eval("Pernc") %>'></asp:Label>
                )<br />
            </td>
        </AlternatingItemTemplate>
        <EmptyDataTemplate>
            <table runat="server" 
                style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                <tr>
                    <td>
                        No data was returned.</td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <InsertItemTemplate>
            <td runat="server" style="">
                Symbol:
                <asp:TextBox ID="SymbolTextBox" runat="server" Text='<%# Bind("Symbol") %>' />
                <br />
                Description:
                <asp:TextBox ID="DescriptionTextBox" runat="server" 
                    Text='<%# Bind("Description") %>' />
                <br />
                LastPrice:
                <asp:TextBox ID="LastPriceTextBox" runat="server" 
                    Text='<%# Bind("LastPrice") %>' />
                <br />
                Pernc:
                <asp:TextBox ID="PerncTextBox" runat="server" Text='<%# Bind("Pernc") %>' />
                <br />
                LastModifiedDateTime:
                <asp:TextBox ID="LastModifiedDateTimeTextBox" runat="server" 
                    Text='<%# Bind("LastModifiedDateTime") %>' />
                <br />
                <asp:Button ID="InsertButton" runat="server" CommandName="Insert" 
                    Text="Insert" />
                <br />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                    Text="Clear" />
                <br />
            </td>
        </InsertItemTemplate>
        <LayoutTemplate>
            <table runat="server">
                <tr runat="server">
                    <td runat="server">
                        <table ID="groupPlaceholderContainer" runat="server" border="1" 
                            style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                            <tr ID="groupPlaceholder" runat="server">
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr runat="server">
                    <td runat="server" 
                        style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;">
                        <asp:DataPager ID="DataPager1" runat="server" PageSize="4">
                            <Fields>
                                <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" 
                                    ShowLastPageButton="True" />
                            </Fields>
                        </asp:DataPager>
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
        <EditItemTemplate>
            <td runat="server" style="background-color:#008A8C;color: #FFFFFF;">
                Symbol:
                <asp:TextBox ID="SymbolTextBox" runat="server" Text='<%# Bind("Symbol") %>' />
                <br />
                Description:
                <asp:TextBox ID="DescriptionTextBox" runat="server" 
                    Text='<%# Bind("Description") %>' />
                <br />
                LastPrice:
                <asp:TextBox ID="LastPriceTextBox" runat="server" 
                    Text='<%# Bind("LastPrice") %>' />
                <br />
                Pernc:
                <asp:TextBox ID="PerncTextBox" runat="server" Text='<%# Bind("Pernc") %>' />
                <br />
                LastModifiedDateTime:
                <asp:TextBox ID="LastModifiedDateTimeTextBox" runat="server" 
                    Text='<%# Bind("LastModifiedDateTime") %>' />
                <br />
                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" 
                    Text="Update" />
                <br />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                    Text="Cancel" />
                <br />
            </td>
        </EditItemTemplate>
        <GroupTemplate>
            <tr ID="itemPlaceholderContainer" runat="server">
                <td ID="itemPlaceholder" runat="server">
                </td>
            </tr>
        </GroupTemplate>
        <SelectedItemTemplate>
            <td runat="server" 
                style="background-color:#008A8C;font-weight: bold;color: #FFFFFF;">
                Symbol:
                <asp:Label ID="SymbolLabel" runat="server" Text='<%# Eval("Symbol") %>' />
                <br />
                Description:
                <asp:Label ID="DescriptionLabel" runat="server" 
                    Text='<%# Eval("Description") %>' />
                <br />
                LastPrice:
                <asp:Label ID="LastPriceLabel" runat="server" Text='<%# Eval("LastPrice") %>' />
                <br />
                Pernc:
                <asp:Label ID="PerncLabel" runat="server" Text='<%# Eval("Pernc") %>' />
                <br />
                LastModifiedDateTime:
                <asp:Label ID="LastModifiedDateTimeLabel" runat="server" 
                    Text='<%# Eval("LastModifiedDateTime") %>' />
                <br />
            </td>
        </SelectedItemTemplate>
    </asp:ListView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetStockDatas" 
        TypeName="DersDemo_Ado_XmlAndCache.UCStockData"></asp:ObjectDataSource>


