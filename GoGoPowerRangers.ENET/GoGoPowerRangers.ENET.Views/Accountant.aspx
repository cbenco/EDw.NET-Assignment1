<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Accountant.aspx.cs" Inherits="GoGoPowerRangers.ENET.UI.AccountantScreen" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <%@Import namespace = "GoGoPowerRangers.ENET.Model" %>
    <title></title>
    <style type="text/css">
        .header {
            float: left;
            padding-left: 5%;
            height: 20px;
        }

        .viewPeople {
            padding-top: 50px;
            padding-left: 20%;
            float: left;
        }

        .viewReports {
            padding-top: 50px;
            padding-left: 20%;
            float: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
            <%User user = (User)Session["currentUser"];%>
            <h3>Hello, <%= user.Name%>
            </h3>
        </div>
        <br />
        <asp:Button ID="Logout" runat="server" Text="Logout" OnClick="Logout_Click" Height="26px" Width="57px" />
        <br />
        <br />
        <asp:Button ID="changePasswordButton" runat="server" OnClick="changePasswordButton_Click" Text="Change Password" />
        <br />
        <div class="viewPeople">
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
        <div class="viewReports">
            <asp:ImageButton ID="btnViewReports" runat="server" Height="200px" Width="210" ImageUrl="~/images/ViewReports.jpg" BorderStyle="Inset" BorderWidth="2px" OnClick="btnViewReports_Click"/>
        </div>
    </form>
</body>
</html>
