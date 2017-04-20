<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="manager.aspx.cs" Inherits="GoGoPowerRangers.ENET.Views.manager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <%@Import namespace = "GoGoPowerRangers.ENET.Model" %>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: left;
        }
        .auto-style4 {
            font-size: large;
            text-align: right;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <div class="auto-style1">
                <div>
                    <div style="text-align: center">
                        <h1>E-NET</h1>
                    </div>
                    <div style="text-align: center">
                        <hr style="height: -12px" />
                    </div>
                    <div style="text-align: center">
                        <p style="text-align: right">
                            <%User user = (User)Session["currentUser"];%>Welcome, <%= user.Name%>
                        </p>
                    </div>
                    <div style="text-align: center">
                        <p style="text-align: right">
                            <asp:Button ID="changePasswordButton" runat="server" OnClick="changePasswordButton_Click" Text="Change Password" />
                        </p>
                        <div style="text-align: right">
                            <p>
&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnNewIntervention" runat="server" OnClick="Button2_Click" Text="Add Intervention" />
                            </p>
                        </div>
                    </div>
                    <div style="text-align: center">
                        <p style="text-align: right">
&nbsp;<asp:Button ID="btnLogout" runat="server" OnClick="btnLogout_Click" Text="Logout" />
                        </p>
                    </div>
                    <hr />
                    <h2>Proposed Interventions</h2>
                    <p class="auto-style4">
                        <strong>Filter</strong>s
                        <asp:Image ID="Image3" runat="server" Height="2%" ImageUrl="~/sortasc.png" Width="2%" />
                    </p>
                </div>
            </div>
            <table style="width:100%;">
                <tr>
                    <td>Date</td>
                    <td>Type</td>
                    <td>Site Engineer</td>
                    <td>District</td>
                    <td>Status</td>
                    <td>View</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="View" />
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="Button2" runat="server" OnClick="Button1_Click1" Text="View" />
                    </td>
                </tr>
            </table>
            <br />
        </div>
        <hr />
        <div>
            <div class="auto-style1">
                <div>
                    <h2>Current Interventions</h2>
                    <p class="auto-style4">
                        <strong>Filter</strong>s
                        <asp:Image ID="Image4" runat="server" Height="2%" ImageUrl="~/sortasc.png" Width="2%" />
                    </p>
                </div>
            </div>
            <table style="width:100%;">
                <tr>
                    <td>Date</td>
                    <td>Type</td>
                    <td>Site Engineer</td>
                    <td>District</td>
                    <td>Status</td>
                    <td>View</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="Button3" runat="server" OnClick="Button1_Click1" Text="View" />
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="Button4" runat="server" OnClick="Button1_Click1" Text="View" />
                    </td>
                </tr>
            </table>
            <br />
            <hr />
        <div>
            <div class="auto-style1">
                <div>
                    <h2>Past Interventions</h2>
                    <p class="auto-style4">
                        <strong>Filter</strong>s
                        <asp:Image ID="Image5" runat="server" Height="2%" ImageUrl="~/sortasc.png" Width="2%" />
                    </p>
                </div>
            </div>
            <table style="width:100%;">
                <tr>
                    <td>Date</td>
                    <td>Type</td>
                    <td>Site Engineer</td>
                    <td>District</td>
                    <td>Status</td>
                    <td>View</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="Button5" runat="server" OnClick="Button1_Click1" Text="View" />
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="Button6" runat="server" OnClick="Button1_Click1" Text="View" />
                    </td>
                </tr>
            </table>
            <br />
        </div>
        </div>
    </form>
</body>
</html>
