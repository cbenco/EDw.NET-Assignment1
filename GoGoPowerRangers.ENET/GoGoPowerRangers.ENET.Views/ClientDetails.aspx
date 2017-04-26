<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClientDetails.aspx.cs" Inherits="GoGoPowerRangers.ENET.Views.ClientDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>
                Client Details for Client
            </h1>
        </div>
        <div>
            <asp:Label ID="labelClientName" runat="server" Text="Client Name"/>
            <br />
            <asp:Label ID="labelClientLocation" runat="server" Text="Client Location"/>
            <br />
        </div>
    </form>
</body>
</html>
