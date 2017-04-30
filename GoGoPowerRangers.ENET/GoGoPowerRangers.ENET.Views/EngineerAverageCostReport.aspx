<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EngineerAverageCostReport.aspx.cs" Inherits="GoGoPowerRangers.ENET.Views.EngineerAverageCostReport" %>

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
                    <asp:Button ID="Logout" runat="server" Text="Logout" OnClick="Logout_Click" CssClass="btn btn-default margin" />
                    <br />
                </div>
            </div>
            <div class="viewPeople">
                <div class="row">
                    <div class="col-md-10 col-md-offset-1">
                        <h3 class="auto-style2">Average Cost and Hours of Completed Interventions by Engineer</h3>
                        <asp:GridView ID="EngineerAverageCostGrid" AutoGenerateColumns="false" runat="server" CssClass="table table-bordered">
                            <Columns>
                                <asp:TemplateField HeaderText="Name">
                                    <ItemTemplate>
                                        <asp:Label ID="labelEngName" runat="server" Text='<%# String.Format("{0} {1}", Eval("FirstName"), Eval("LastName")) %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Average Costs">
                                    <ItemTemplate>
                                        <asp:Label ID="labelEngCosts" runat="server" Text='<%# Eval("AverageCosts") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Average Hours">
                                    <ItemTemplate>
                                        <asp:Label ID="labelEngHours" runat="server" Text='<%# Eval("AverageHours") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <br />
                <hr />
            </div>
        </div>
    </form>
</body>
</html>
