<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="GoGoPowerRangers.ENET.UI.WebForm1" %>

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
            <asp:Login ID="Login" runat="server" Height="144px" OnAuthenticate="Login_Authenticate" Width="260px">
            </asp:Login>
        </div>
    </form>
</body>
</html>
