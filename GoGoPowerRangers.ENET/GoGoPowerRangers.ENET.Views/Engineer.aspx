<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Engineer.aspx.cs" Inherits="GoGoPowerRangers.ENET.Views.Engineer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Content/bootstrap.min.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <br />
                <div>
                    <div>
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
                                <div>
                                    <p class="text-right">
                                        <asp:Button ID="changePasswordButton" runat="server" Text="Change Password" OnClick="changePasswordButton_Click" CssClass="btn btn-default" />
                                    </p>
                                    <div>
                                        <p class="text-right">
                                            &nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnNewIntervention" runat="server" Text="Add New Intervention" OnClick="btnNewIntervention_Click" CssClass="btn btn-default" />
                                        </p>
                                    </div>
                                </div>
                                <div style="text-align: center">
                                    <p class="text-right">
                                        &nbsp;<asp:Button ID="Logout" runat="server" Text="Logout" OnClick="Logout_Click" CssClass="btn btn-default" />
                                    </p>
                                </div>
                            </div>
                        </div>
                        <hr />
                    </div>
                </div>
                <div>
                    <div class="row">
                        <div class="col-md-2 col-md-offset-1">
                            <asp:Label ID="labelDistrictName" runat="server"></asp:Label>
                            <div>
                                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                <asp:UpdatePanel ID="UpdateClients" UpdateMode="Conditional" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="clientGrid" AutoGenerateColumns="false" runat="server" OnRowCommand="GridView_RowCommand" CssClass="table table-bordered table-hover">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Client Name">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="clientName" runat="server" Text='<%# Eval("Name") %>' CommandName="clientNameClick" CommandArgument='<%# Bind("ClientId") %>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <br />
                            Create Client<br />
                            <asp:TextBox ID="newClientName" runat="server" CssClass="form-control"></asp:TextBox>
                            name<br />
                            <asp:TextBox ID="newClientLocation" runat="server" CssClass="form-control"></asp:TextBox>
                            location<br />
                            <asp:Button ID="newClientButton" runat="server" OnClick="newClientButton_Click" Text="New Client" CssClass="btn btn-default" />
                            <br />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <hr />
        <div>
            <div class="row">
                <div class="col-md-10 col-md-offset-1">
                    <div>
                        <div>
                            <asp:Label ID="labelInterventionsHeader" runat="server"></asp:Label>
                        </div>
                    </div>
                    <asp:GridView ID="interventionGrid" AutoGenerateColumns="false" runat="server" OnRowCommand="GridView_RowCommand" CssClass="table table-hover">
                        <Columns>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:LinkButton ID="viewIntervention" runat="server" Text="View Details" CommandName="viewInterventionClick" CommandArgument='<%# Bind("InterventionID") %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Intervention Type">
                                <ItemTemplate>
                                    <asp:Label ID="interventionType" runat="server" Text='<%# Eval("InterventionName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Client">
                                <ItemTemplate>
                                    <asp:Label ID="client" runat="server" Text='<%# Eval("ClientName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Location">
                                <ItemTemplate>
                                    <asp:Label ID="location" runat="server" Text='<%# Eval("ClientLocation") + ", " + Eval("DistrictName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Proposed Date">
                                <ItemTemplate>
                                    <asp:Label ID="date" runat="server" Text='<%# Eval("Date") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Last Visited">
                                <ItemTemplate>
                                    <asp:Label ID="lastVisited" runat="server" Text='<%# Eval("LastVisited") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                    <asp:Label ID="status" runat="server" Text='<%# Eval("State") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <br />
                    <hr />
                    <div>
                        <br />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
