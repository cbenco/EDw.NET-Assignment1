<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountantScreen.aspx.cs" Inherits="GoGoPowerRangers.ENET.UI.AccountantScreen" %>

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
        <br />
        <div class="viewPeople">
            <asp:GridView ID="EngineerGrid" runat="server">

            </asp:GridView>
            <asp:GridView ID="ManagerGrid" runat="server" >
            </asp:GridView>
        </div>
        <div class="viewReports">
            <asp:ImageButton ID="btnViewReports" runat="server" Height="200px" Width="210" ImageUrl="~/images/ViewReports.jpg" BorderStyle="Inset" BorderWidth="2px" OnClick="btnViewReports_Click"/>
        </div>
    </form>
</body>
</html>
