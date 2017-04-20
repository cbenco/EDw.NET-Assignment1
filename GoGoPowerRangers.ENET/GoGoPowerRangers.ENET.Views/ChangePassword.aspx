<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="GoGoPowerRangers.ENET.Views.ChangePassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <h1>Change Password</h1>
            </div>
            <div>
                <asp:TextBox runat="server" ID="currentPassword"></asp:TextBox>
                Enter current password<br />
                <asp:TextBox ID="newPassword" runat="server"></asp:TextBox>
                Enter new password<br />
                <asp:TextBox ID="confirmPassword" runat="server"></asp:TextBox>
                Confirm new password
            </div>
            <div>
                <asp:Button ID="changePasswordButton" runat="server" Text="Confirm" OnClick="changePasswordButton_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="ErrorMessage" runat="server" ForeColor="#FF3300"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
