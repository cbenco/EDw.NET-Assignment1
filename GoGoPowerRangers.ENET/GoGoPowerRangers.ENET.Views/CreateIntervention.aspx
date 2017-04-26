<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateIntervention.aspx.cs" Inherits="GoGoPowerRangers.ENET.Views.CreateIntervention" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Content/bootstrap.min.css" />
</head>
<body>
    <form id="form1" runat="server">

        <div>
            <h1>Create Intervention</h1>
        </div>
        <div class="row">
            <div class="col-md-1"></div>
            <div class="col-md-4">
                <asp:DropDownList CssClass="form-control" ID="types" runat="server" OnSelectedIndexChanged="types_SelectedIndexChanged" AutoPostBack="true" AppendDataBoundItems="true">
                </asp:DropDownList>
                type<br />
                <asp:DropDownList CssClass="form-control" ID="clients" runat="server">
                </asp:DropDownList>
                client<br />
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="UpdateTextBoxes" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="manHours" runat="server" CssClass="form-control"></asp:TextBox>
                        man-hours<br />
                        <asp:TextBox ID="materialCost" runat="server" CssClass="form-control"></asp:TextBox>
                        material cost
                    </ContentTemplate>
                </asp:UpdatePanel>
                <br />
                <asp:Calendar ID="calendar" runat="server"></asp:Calendar>
                <br />
                <asp:TextBox ID="noteBox" runat="server" Height="118px" Width="242px" CssClass="form-control"></asp:TextBox>
                notes<br />
                <br />
                <asp:Button CssClass="btn-default btn" ID="Button1" runat="server" Text="Create" OnClick="Button1_Click" />
            </div>
        </div>
    </form>
</body>
</html>
