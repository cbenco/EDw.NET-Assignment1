<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="manager.aspx.cs" Inherits="GoGoPowerRangers.ENET.Views.manager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Content/bootstrap.min.css" />
    <style type="text/css">
        .auto-style1 {
            text-align: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <br />
                <div style="text-align: center">
                    <h1>E-NET</h1>
                </div>
                <div style="text-align: center">
                    <hr style="height: -12px" />
                </div>
                <div class="row">
                    <div class="col-md-2 col-md-offset-9">
                        <div style="text-align: center">
                            <p style="text-align: right">
                                Welcome,&nbsp;
                            <asp:Label ID="labelFirstName" runat="server" Text="First Name"></asp:Label>
                            </p>
                        </div>
                        <div style="text-align: center">
                            <p style="text-align: right">
                                <asp:Button ID="changePasswordButton" runat="server" OnClick="changePasswordButton_Click" Text="Change Password" CssClass="btn btn-default" />
                            </p>
                        </div>
                        <div style="text-align: center">
                            <p style="text-align: right">
                                <asp:Button ID="btnLogout" runat="server" OnClick="btnLogout_Click" Text="Logout" CssClass="btn btn-default" />
                            </p>
                        </div>
                    </div>
                </div>
            </div>
            <hr />

        </div>
        <hr />
        <div class="row">
            <div class="col-md-10 col-md-offset-1">
                <div class="auto-style1">
                    <div>
                        <asp:Label ID="labelInterventionsHeader" runat="server"></asp:Label>

                    </div>
                </div>
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="updateApprovedText" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="interventionGrid" AutoGenerateColumns="false" runat="server" OnRowCommand="interventionGrid_RowCommand" CssClass="table table-bordered">
                            <Columns>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="approve" runat="server" Text="Approve" CommandName="ApproveClick" CommandArgument='<%# Bind("Id") %>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ID">
                                    <ItemTemplate>
                                        <asp:Label ID="id" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Intervention Type">
                                    <ItemTemplate>
                                        <asp:Label ID="interventionType" runat="server" Text='<%# Eval("InterventionType.Name") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Client">
                                    <ItemTemplate>
                                        <asp:Label ID="client" runat="server" Text='<%# Eval("Client.Name") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Location">
                                    <ItemTemplate>
                                        <asp:Label ID="client" runat="server" Text='<%# Eval("Client.Location") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Proposed By">
                                    <ItemTemplate>
                                        <asp:Label ID="proposedBy" runat="server" Text='<%# String.Format("{0} {1}", Eval("Requester.FirstName"), Eval("Requester.LastName")) %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Man Hours">
                                    <ItemTemplate>
                                        <asp:Label ID="manHours" runat="server" Text='<%# Eval("ManHours") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Material Cost">
                                    <ItemTemplate>
                                        <asp:Label ID="matCost" runat="server" Text='<%# Eval("MaterialCost") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Proposed Date">
                                    <ItemTemplate>
                                        <asp:Label ID="date" runat="server" Text='<%# Eval("RequestDate") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Last Visited">
                                    <ItemTemplate>
                                        <asp:Label ID="lastVisited" runat="server" Text='<%# Eval("LastVisited") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <br />
                <div>
                    <br />
                </div>
            </div>
        </div>
        <hr />
    </form>
</body>
</html>
