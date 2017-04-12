<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="GoGoPowerRangers.ENET.UI.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Content/bootstrap.min.css"></script>
    <style type="text/css">
        #form1 {
            height: 485px;
        }

        .center {
            padding-left:40%;
        }
        .center.logo {
            padding-left:7%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="center">
            <div class="center logo">
                <asp:Label ID="lblLogo" runat="server" Font-Bold="True" Font-Size="X-Large" Text="ENET" margin-left="5000px"></asp:Label>
            </div>
            <asp:Login ID="Login" runat="server" Height="144px" OnAuthenticate="Login_Authenticate" Width="260px" OnLoggedIn="Logged_In">
            </asp:Login>
        <p style="width: 593px">
            <asp:Button ID="Accountant_Button" runat="server" Text="Accountant" OnClick="AccountantButton_OnClick"/>
            <asp:Button ID="InterventionApproval_Button" runat="server" Text="InterventionApproval" OnClick="InterventionApprovalButton_OnClick"/>
            <asp:Button ID="Manager_Button" runat="server" Text="Manager" OnClick="ManagerButton_OnClick"/>
            <asp:Button ID="SiteEngineer_Button" runat="server" Text="SiteEngineer" OnClick="SiteEngineerButton_OnClick"/>
        </p>
        </div>
    </form>

    
</body>
</html>
