﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="details.aspx.cs" Inherits="GoGoPowerRangers.ENET.Views.Details" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2 class="auto-style1">Intervention Details</h2>
        </div>
        <div>
            Intervention Type:
            <asp:Label ID="labelType" runat="server" Text="Type"></asp:Label>
            <br />
            Site Engineer: <asp:Label ID="labelEngineerName" runat="server" Text="Engineer Name"></asp:Label>
            <br />
            Client: <asp:Label ID="labelClientName" runat="server" Text="Client Name"></asp:Label>
&nbsp;<br />
            District:
            <asp:Label ID="labelDistrict" runat="server" Text="District"></asp:Label>
            <br />
            Date:
            <asp:Label ID="labelInterventionDate" runat="server" Text="dd/mm/yyyy"></asp:Label>
            <br />
            <br />
            Cost:
            <asp:Label ID="labelCost" runat="server" Text="$0.00"></asp:Label>
            <br />
            Time Required:
            <asp:Label ID="labelTime" runat="server" Text="0.0 hours"></asp:Label>
            <br />
            <br />
            Notes:<br />
            <textarea id="textareaNotes" cols="20" name="S1" rows="2"></textarea><br />
            </div>
    </form>
</body>
</html>