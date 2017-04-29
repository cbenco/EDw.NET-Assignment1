<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClientDetails.aspx.cs" Inherits="GoGoPowerRangers.ENET.Views.ClientDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Content/bootstrap.min.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="row">
            <div class="col-md-10 col-md-offset-1">
                <div>
                    <h1>Client Details for Client
                    </h1>
                </div>
                <div>
                    <asp:Label ID="labelClientName" runat="server" Text="Client Name" />
                    <br />
                    <asp:Label ID="labelClientLocation" runat="server" Text="Client Location" />
                    <br />
                </div>
                <div>
                    <asp:GridView ID="interventionGrid" AutoGenerateColumns="false" runat="server" OnRowCommand="interventionGrid_RowCommand" CssClass="table table-bordered">
                        <Columns>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:LinkButton ID="viewIntervention" runat="server" Text="View Details" CommandName="viewInterventionClick" CommandArgument='<%# Bind("InterventionId") %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Intervention Type">
                                <ItemTemplate>
                                    <asp:Label ID="interventionType" runat="server" Text='<%# Eval("InterventionName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Proposed By">
                                <ItemTemplate>
                                    <asp:Label ID="proposedBy" runat="server" Text='<%# String.Format("{0} {1}", Eval("FirstName"), Eval("LastName")) %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Proposed Date">
                                <ItemTemplate>
                                    <asp:Label ID="date" runat="server" Text='<%# Eval("Date" )%>'></asp:Label>
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
                </div>
            </div>
        </div>
    </form>
</body>
</html>
