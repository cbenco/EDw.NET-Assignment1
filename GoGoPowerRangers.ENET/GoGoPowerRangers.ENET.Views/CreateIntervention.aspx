<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateIntervention.aspx.cs" Inherits="GoGoPowerRangers.ENET.Views.CreateIntervention" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Content/bootstrap.min.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="row">
            <div class="col-md-4 col-md-offset-1">
                <div>
                    <h1>Create Intervention</h1>
                </div>
                <asp:DropDownList ID="types" runat="server" OnSelectedIndexChanged="types_SelectedIndexChanged" AutoPostBack="true" AppendDataBoundItems="true" CssClass="form-control">
                </asp:DropDownList>
                type<br />
                <asp:DropDownList ID="clients" runat="server" CssClass="form-control">
                </asp:DropDownList>
                client<br />
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="UpdateTextBoxes" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="manHours" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                        man-hours<br />
                        <asp:TextBox ID="materialCost" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                        material cost
                    </ContentTemplate>
                </asp:UpdatePanel>
                <br />
                <asp:Calendar ID="calendar" runat="server"></asp:Calendar>
                <br />
                <asp:TextBox ID="noteBox" runat="server" Height="118px" Width="242px" CssClass="form-control" TextMode="MultiLine" Rows="5"></asp:TextBox>
                notes<br />
                <br />

                <% if (!showApproveComplete)
                    { %>
                <asp:Button CssClass="btn-default btn" ID="buttonCreate" runat="server" Text="Create" OnClick="buttonCreate_Click" />
                <% }
                    else
                    { %>
                <asp:Button ID="buttonConfirmPending" runat="server" Text="Create as Pending" OnClick="buttonConfirmPending_Click" CssClass="btn-default btn"/>
                <asp:Button ID="buttonApprove" runat="server" Text="Create and Approve" OnClick="buttonApprove_Click" CssClass="btn-default btn"/>
                <asp:Button ID="buttonComplete" runat="server" Text="Create and Complete" OnClick="buttonComplete_Click" CssClass="btn-default btn"/>
                <% } %>
            </div>
        </div>
    </form>
</body>
</html>
