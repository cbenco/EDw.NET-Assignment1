﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="GoGoPowerRangers.ENET.UI.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Content/bootstrap.min.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="row">
            <div class="col-md-4 col-md-offset-4">
                <div style="text-align: center;">
                    <div style="width: 400px; margin-left: auto; margin-right: auto;">
                        <h1>ENET</h1>
                        <asp:Login ID="Login" runat="server" Height="144px" OnAuthenticate="Login_Authenticate" OnLoggedIn="Logged_In" LoginButtonStyle-CssClass="btn btn-default" TextBoxStyle-CssClass="form-control" CheckBoxStyle-CssClass="checkbox">
                            <CheckBoxStyle CssClass="checkbox" />
                            <LoginButtonStyle CssClass="btn btn-default" />
                            <TextBoxStyle CssClass="form-control" />
                        </asp:Login>
                    </div>
                </div>
            </div>
        </div>
        <div style="margin-left: 680px">
            <asp:Label ID="ErrorMessage" runat="server" Align="Center"></asp:Label>
        </div>
    </form>
</body>
</html>
