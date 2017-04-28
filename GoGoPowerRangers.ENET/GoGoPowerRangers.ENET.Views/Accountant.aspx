<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Accountant.aspx.cs" Inherits="GoGoPowerRangers.ENET.UI.AccountantScreen" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <%@Import namespace = "GoGoPowerRangers.ENET.Model" %>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: right;
        }
        .auto-style2 {
            text-align: left;
        }
        .auto-style3 {
            margin-left: 0px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div><h1>ENET</h1></div>
        <div class="auto-style1">
        <div class="header">
            <%User user = (User)Session["currentUser"];%>
            <asp:Label ID="labelFirstName" runat="server" />
        </div>

        <br /><asp:Button ID="report1" runat="server" Text="Engineer Cost Report" OnClick="report1_Click" Height="26px" Width="198px" CssClass="auto-style3" />
        <br /><asp:Button ID="report2" runat="server" Text="Engineer Average Hours Report" OnClick="report2_Click" Height="26px" Width="200px" />
        <br /><asp:Button ID="report3" runat="server" Text="District Cost Report" OnClick="report3_Click" Height="26px" Width="200px" />
        <br />
        <asp:Button ID="Logout" runat="server" Text="Logout" OnClick="Logout_Click" Height="26px" Width="57px" />
        <br />
        <asp:Button ID="changePasswordButton" runat="server" OnClick="changePasswordButton_Click" Text="Change Password" />
        <br />
        <div class="viewPeople">
                        <h3 class="auto-style2">Site Engineers</h3>
                        <asp:GridView ID="EngineerGrid" AutoGenerateColumns="false" runat="server" OnRowCommand="GridView_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="Name">
                                        <ItemTemplate>
                                            <asp:Label ID="labelEngName" runat="server" Text='<%# Eval("Name") %>' />
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                <asp:TemplateField HeaderText="ID">
                                        <ItemTemplate>
                                            <asp:Label ID="labelEngID" runat="server" Text='<%# Eval("Id") %>' />
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                <asp:TemplateField HeaderText="District">
                                        <ItemTemplate>
                                            <asp:Label ID="labelEngDistrict" runat="server" Text='<%# Eval("District.Name") %>' />
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="changeEngDistrict" runat="server" Text="Change District" CommandName="changeDistrictClick" CommandArgument='<%# Bind("Id") %>'></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
            <br />
            <hr />
                        <h3 class="auto-style2">Managers</h3>
                        <asp:GridView ID="ManagerGrid" AutogenerateColumns="false" runat="server" OnRowCommand="GridView_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="Name">
                                        <ItemTemplate>
                                            <asp:Label ID="labelManName" runat="server" Text='<%# Eval("Name") %>' />
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                <asp:TemplateField HeaderText="ID">
                                        <ItemTemplate>
                                            <asp:Label ID="labelManID" runat="server" Text='<%# Eval("Id") %>' />
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                <asp:TemplateField HeaderText="District">
                                        <ItemTemplate>
                                            <asp:Label ID="labelManDistrict" runat="server" Text='<%# Eval("District.Name") %>' />
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="changeManDistrict" runat="server" Text="Change District" CommandName="changeDistrictClick" CommandArgument='<%# Bind("Id") %>'></asp:LinkButton>
                                        </ItemTemplate>
                                 </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
        </div>
        </div>
    </form>
</body>
</html>
