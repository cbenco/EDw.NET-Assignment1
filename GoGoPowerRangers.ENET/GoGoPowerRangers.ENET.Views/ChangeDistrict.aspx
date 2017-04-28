<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangeDistrict.aspx.cs" Inherits="GoGoPowerRangers.ENET.Views.ChangeDistrict" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Content/bootstrap.min.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="row">
            <div class="col-md-offset-1">
                <div>
                    <asp:Label ID="labelHeader" runat="server"></asp:Label>
                </div>
                <div>
                    <asp:RadioButtonList ID="districtButtons" runat="server" CssClass="radio">
                    </asp:RadioButtonList>
                </div>
                <div>
                    <asp:Button ID="confirmButton" runat="server" OnClick="confirmButton_Click" Text="Confirm District Change" CssClass="btn btn-default" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
