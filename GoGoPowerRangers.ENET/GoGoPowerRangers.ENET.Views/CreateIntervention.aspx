<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateIntervention.aspx.cs" Inherits="GoGoPowerRangers.ENET.Views.CreateIntervention" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Create Intervention</h1>
        </div>
        <div>
            <asp:DropDownList ID="types" runat="server" OnSelectedIndexChanged="types_SelectedIndexChanged" AppendDataBoundItems="true">
            </asp:DropDownList>
            type<br />
            <asp:DropDownList ID="clients" runat="server">
            </asp:DropDownList>
            client<br />
            <asp:TextBox ID="manHours" runat="server" EnableViewState="False"></asp:TextBox>
            man-hours<br />
            <asp:TextBox ID="materialCost" runat="server"></asp:TextBox>
            material cost<br />
            <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
            <br />
            <asp:TextBox ID="TextBox3" runat="server" Height="118px" Width="242px"></asp:TextBox>
            notes<br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Create" />
        </div>
    </form>
</body>
</html>
