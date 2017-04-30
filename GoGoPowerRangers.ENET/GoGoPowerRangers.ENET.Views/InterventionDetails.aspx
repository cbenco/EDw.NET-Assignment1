<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InterventionDetails.aspx.cs" Inherits="GoGoPowerRangers.ENET.Views.InterventionDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Content/bootstrap.min.css" />
    <style type="text/css">
        .auto-style1 {
        }

        .auto-style2 {
            width: 176px;
            text-align: right;
        }

        .auto-style3 {
            width: 176px;
            text-align: right;
        }
        p {
            padding-top: 10px;
        }

        .button-margin {
            margin-top: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="row">
            <div class="col-md-11 col-md-offset-1">
                <h1>Intervention Details</h1>
                <h2><i>Core Information</i></h2>
                <div class="row">
                    <div class=" col-md-5 col-md-offset-1">
                        <table style="width: 100%;">
                            <tr>
                                <td class="auto-style3">
                                    <p>Type: </p>
                                </td>
                                <td class="auto-style1">
                                    <asp:Label ID="labelType" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style3">
                                    <p>Client: </p>
                                </td>
                                <td class="auto-style1">
                                    <asp:Label ID="labelClient" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style2">
                                    <p>Required labour: </p>
                                </td>
                                <td>
                                    <asp:Label ID="labelManHours" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style2">
                                    <p>Material costs: </p>
                                </td>
                                <td>
                                    <asp:Label ID="labelMatCost" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style2">
                                    <p>Requesting engineer: </p>
                                </td>
                                <td>
                                    <asp:Label ID="labelRequester" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style2">
                                    <p>Date of intervention: </p>
                                </td>
                                <td>
                                    <asp:Label ID="labelDate" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <h2><i>Administrative Information</i></h2>
                <div class="row">
                    <div class="col-md-3 col-md-offset-1">
                        <table style="width: 100%">
                            <tr>
                                <td class="auto-style2">
                                    <p>Status: </p>
                                </td>
                                <td>
                                    <asp:Label ID="labelStatus" runat="server" />
                                    <% if (_intervention.Approvable(_user))
                                        { %>
                                    <asp:Button ID="buttonApprove" runat="server" OnClick="buttonApprove_Click" Text="Approve" CssClass="btn btn-default btn-warning" />
                                    <%}
                                        else if (_intervention.Status == GoGoPowerRangers.ENET.Model.Status.Approved)
                                        {%>
                                    <asp:Button ID="buttonComplete" runat="server" OnClick="buttonComplete_Click" Text="Complete" CssClass="btn btn-default btn-success" />
                                    <asp:Button ID="buttonCancel" runat="server" OnClick="buttonCancel_Click" Text="Cancel" CssClass="btn btn-default btn-danger" />
                                    <%} %>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style2">
                                    <p>Approved by: </p>
                                </td>
                                <td>
                                    <asp:Label ID="labelApprover" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <h2><i>Quality Management Information</i></h2>
                <div class="row">
                    <div class="col-md-7 col-md-offset-1">
                        <table style="width: 100%;">
                            <tr>
                                <td class="auto-style3">
                                    <p>Notes: </p>
                                </td>
                                <td class="auto-style1">
                                    <asp:TextBox ID="noteBox" runat="server" Height="118px" Width="486px" CssClass="form-control" TextMode="MultiLine" />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style3">
                                    <p>% of lifetime remaining</p>
                                </td>
                                <td class="auto-style1">
                                    <asp:TextBox ID="remainingLifeBox" runat="server" Width="166px"  CssClass="form-control"/>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style2">
                                    <p>Most recent visit: </p>
                                </td>
                                <td>
                                    <asp:Calendar ID="calendarLastVisited" runat="server" ShowGridLines="true" SelectionMode="Day">
                                        <SelectedDayStyle BackColor="LightBlue" ForeColor="Black" />
                                    </asp:Calendar>
                                </td>
                            </tr>
                        </table>
                        <asp:Button ID="buttonSaveChanges" runat="server" OnClick="buttonSaveChanges_Click" Text="Save Changes" Width="130px"  CssClass="btn btn-default button-margin btn-success"/>
                        <asp:Label ID="labelChangesSaved" runat="server" /><br />
                        <asp:Button ID="buttonGoBack" runat="server" OnClick="buttonGoBack_Click" Text="Go Back" Width="130px"  CssClass="btn btn-default button-margin btn-danger"/>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
