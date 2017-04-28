<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangeDistrict.aspx.cs" Inherits="GoGoPowerRangers.ENET.Views.ChangeDistrict" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="labelHeader" runat="server"></asp:Label>
        </div>
        <div>
            <asp:RadioButtonList ID="districtButtons" runat="server">
            </asp:RadioButtonList>
        </div>
        <div>
            <asp:Button ID="confirmButton" runat="server" OnClick="confirmButton_Click" Text="Confirm District Change" />
        </div>
    </form>
</body>
</html>
