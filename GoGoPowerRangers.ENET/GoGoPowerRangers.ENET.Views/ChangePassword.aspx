<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="GoGoPowerRangers.ENET.Views.ChangePassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Content/bootstrap.min.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="row">
            <div class="col-md-2 col-md-offset-1">
                <div>
                    <h1>Change Password</h1>
                </div>
                <div>
                    <asp:TextBox runat="server" ID="currentPassword" CssClass="form-control"></asp:TextBox>
                    Enter current password<br />
                    <asp:TextBox ID="newPassword" runat="server" CssClass="form-control"></asp:TextBox>
                    Enter new password<br />
                    <asp:TextBox ID="confirmPassword" runat="server" CssClass="form-control"></asp:TextBox>
                    Confirm new password
                </div>
                <div>
                    <asp:Button ID="changePasswordButton" runat="server" Text="Confirm" OnClick="changePasswordButton_Click"  CssClass="btn btn-default"/>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="ErrorMessage" runat="server" ForeColor="#FF3300"></asp:Label>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
