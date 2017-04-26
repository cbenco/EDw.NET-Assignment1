<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="GoGoPowerRangers.ENET.UI.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Content/bootstrap.min.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="row">
            <div class="col-md-5 col-md-offset-4">
                <h1>ENET</h1>
                <asp:Login ID="Login" runat="server" Height="144px" OnAuthenticate="Login_Authenticate" OnLoggedIn="Logged_In" LoginButtonStyle-CssClass="btn btn-default" TextBoxStyle-CssClass="form-control" CheckBoxStyle-CssClass="checkbox">
                    <CheckBoxStyle CssClass="checkbox" />
                    <LoginButtonStyle CssClass="btn btn-default" />
                    <TextBoxStyle CssClass="form-control" />
                </asp:Login>
                <p style="width: 593px">
                    <asp:Button ID="InterventionApproval_Button" runat="server" Text="InterventionApproval" OnClick="InterventionApprovalButton_OnClick" CssClass="btn btn-default"/>
                </p>
            </div>
        </div>
    </form>


</body>
</html>
