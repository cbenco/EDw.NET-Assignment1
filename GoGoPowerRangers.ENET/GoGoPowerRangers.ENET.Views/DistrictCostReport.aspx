<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DistrictCostReport.aspx.cs" Inherits="GoGoPowerRangers.ENET.Views.DistrictCostReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <%@ Import Namespace="GoGoPowerRangers.ENET.Model" %>
    <title></title>
    <link rel="stylesheet" href="Content/bootstrap.min.css" />
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
        .margin {
            margin-top:5px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="text-center">
            <h1>ENET</h1>
        </div>
        <div class="auto-style1">
            <div class="row">
                <div class="col-md-3 col-md-offset-8">
                    <div class="header">
                        <%User user = (User)Session["currentUser"];%>
                        <asp:Label ID="labelFirstName" runat="server" />
                    </div>

                    <br />
                    <asp:Button ID="back" runat="server" Text="Back" OnClick="back_Click" CssClass="btn btn-default margin" />
                    <br />
                    <asp:Button ID="changePasswordButton" runat="server" OnClick="changePasswordButton_Click" Text="Change Password" CssClass="btn btn-default margin" />
                    <br />
                    <asp:Button ID="Logout" runat="server" Text="Logout" OnClick="Logout_Click" CssClass="btn btn-default margin" />
                    <br />
                </div>
            </div>
            <div class="viewPeople">
                <div class="row">
                    <div class="col-md-10 col-md-offset-1">
                        <h3 class="auto-style2">Total Costs and Hours of Completed Interventions by District</h3>
                        <asp:GridView ID="DistrictCostGrid" AutoGenerateColumns="false" runat="server" OnRowCommand="GridView_RowCommand" CssClass="table table-bordered">
                            <Columns>
                                <asp:TemplateField HeaderText="Name">
                                    <ItemTemplate>
                                        <asp:Label ID="labelDistrictName" runat="server" Text='<%#Eval("DistrictName") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ID">
                                    <ItemTemplate>
                                        <asp:Label ID="labelDistrictID" runat="server" Text='<%# Eval("DistrictId") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Total Costs">
                                    <ItemTemplate>
                                        <asp:Label ID="labelDistrictCosts" runat="server" Text='<%# Eval("TotalCosts") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Total Hours">
                                    <ItemTemplate>
                                        <asp:Label ID="labelDistrictHours" runat="server" Text='<%# Eval("TotalHours") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:Label ID="labelGrandTotal" runat="server" Text='<%# Eval("GrandTotalHours") %>' />
                    </div>
                </div>
                <br />
                <hr />
            </div>
        </div>
    </form>
</body>
</html>
