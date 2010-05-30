<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DersDemo_Ado_WebDemo._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
</head>
<body>
    <form id="form1" runat="server">
    <table>
        <tr>
            <td valign="top">
                <asp:GridView ID="gv" runat="server" AllowPaging="True" AllowSorting="True" 
                    AutoGenerateColumns="False" DataKeyNames="CategoryID" 
                    DataSourceID="odsCategories" >
                    <Columns>
                        <asp:CommandField SelectText="Seç" ShowSelectButton="True" />
                        <asp:BoundField DataField="CategoryID" HeaderText="CategoryID" 
                            InsertVisible="False" ReadOnly="True" SortExpression="CategoryID" />
                        <asp:BoundField DataField="CategoryName" HeaderText="CategoryName" 
                            SortExpression="CategoryName" />
                        <asp:BoundField DataField="Description" HeaderText="Description" 
                            SortExpression="Description" Visible="False" />
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="odsCategories" runat="server" DeleteMethod="Delete" 
                    InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" 
                    SelectMethod="GetData" 
                    TypeName="DersDemo_Ado_WebDemo.DataLayer.NorthwindDataSetTableAdapters.CategoriesTableAdapter" 
                    UpdateMethod="Update">
                    <DeleteParameters>
                        <asp:Parameter Name="Original_CategoryID" Type="Int32" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="CategoryName" Type="String" />
                        <asp:Parameter Name="Description" Type="String" />
                        <asp:Parameter Name="Picture" Type="Object" />
                        <asp:Parameter Name="Original_CategoryID" Type="Int32" />
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:Parameter Name="CategoryName" Type="String" />
                        <asp:Parameter Name="Description" Type="String" />
                        <asp:Parameter Name="Picture" Type="Object" />
                    </InsertParameters>
                </asp:ObjectDataSource>
            </td>
            <td valign="top">
                <asp:DetailsView ID="dv" runat="server" AutoGenerateRows="False" 
                    DataKeyNames="CategoryID" DataSourceID="odsCategory" 
                    onitemdeleted="dv_ItemDeleted" >
                    <Fields>
                        <asp:BoundField DataField="CategoryID" HeaderText="CategoryID" 
                            InsertVisible="False" ReadOnly="True" SortExpression="CategoryID" />
                        <asp:TemplateField HeaderText="CategoryName" SortExpression="CategoryName">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" MaxLength="15" 
                                    Text='<%# Bind("CategoryName") %>' Width="200px"></asp:TextBox>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" MaxLength="15" 
                                    Text='<%# Bind("CategoryName") %>' Width="200px"></asp:TextBox>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("CategoryName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Description" SortExpression="Description">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Height="100px" 
                                    Text='<%# Bind("Description") %>' TextMode="MultiLine" Width="200px"></asp:TextBox>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Height="100px" 
                                    Text='<%# Bind("Description") %>' TextMode="MultiLine" Width="200px"></asp:TextBox>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="False">
                            <EditItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" 
                                    CommandName="Update" Text="Update"></asp:LinkButton>
                                &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                                    CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" 
                                    CommandName="Insert" Text="Insert"></asp:LinkButton>
                                &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                                    CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                                    CommandName="Edit" Text="Edit"></asp:LinkButton>
                                &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                                    CommandName="New" Text="New"></asp:LinkButton>
                                &nbsp;<asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" 
                                    CommandName="Delete" 
                                    onclientclick="return confirm(&quot;Silmek istediğinize emin misiniz?&quot;);" 
                                    Text="Delete"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Fields>
                </asp:DetailsView>
                <asp:ObjectDataSource ID="odsCategory" runat="server" DeleteMethod="Delete" 
                    InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" 
                    SelectMethod="GetDataByCategoryID" 
                    TypeName="DersDemo_Ado_WebDemo.DataLayer.NorthwindDataSetTableAdapters.CategoriesTableAdapter" 
                    UpdateMethod="Update">
                    <DeleteParameters>
                        <asp:Parameter Name="Original_CategoryID" Type="Int32" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="CategoryName" Type="String" />
                        <asp:Parameter Name="Description" Type="String" />
                        <asp:Parameter Name="Picture" Type="Object" />
                        <asp:Parameter Name="Original_CategoryID" Type="Int32" />
                    </UpdateParameters>
                    <SelectParameters>
                        <asp:ControlParameter ControlID="gv" DefaultValue="0" Name="CategoryID" 
                            PropertyName="SelectedValue" Type="Int32" />
                    </SelectParameters>
                    <InsertParameters>
                        <asp:Parameter Name="CategoryName" Type="String" />
                        <asp:Parameter Name="Description" Type="String" />
                        <asp:Parameter Name="Picture" Type="Object" />
                    </InsertParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
