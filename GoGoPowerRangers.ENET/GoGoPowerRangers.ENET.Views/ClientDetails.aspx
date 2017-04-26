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
        <div>
            <asp:GridView ID="interventionGrid" AutoGenerateColumns="false" runat="server">
                <Columns>
                    <asp:TemplateField HeaderText="Intervention Type">
                            <ItemTemplate>
                                <asp:Label ID="interventionType" runat="server" Text='<%# Eval("InterventionType.Name") %>'></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>
                    <asp:TemplateField HeaderText="Proposed By">
                            <ItemTemplate>
                                <asp:Label ID="proposedBy" runat="server" Text='<%# Eval("Requester.Name") %>'></asp:Label>
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
                    <asp:TemplateField HeaderText="Remaining Life">
                            <ItemTemplate>
                                <asp:Label ID="remLife" runat="server" Text='<%# Eval("RemainingLife") %>'></asp:Label>
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
                    <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <asp:Label ID="status" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
