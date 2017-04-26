<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Engineer.aspx.cs" Inherits="GoGoPowerRangers.ENET.Views.Engineer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
                            Welcome,&nbsp;
                            <asp:Label ID="labelFirstName" runat="server" Text="First Name"></asp:Label>
                        </p>
                    </div>
                    <div style="text-align: center">
                        <p style="text-align: right">
                            <asp:Button ID="changePasswordButton" runat="server"  Text="Change Password" OnClick="changePasswordButton_Click" />
                        </p>
                        <div style="text-align: right">
                            <p>
&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnNewIntervention" runat="server"  Text="Add New Intervention" OnClick="btnNewIntervention_Click" />
                            </p>
                        </div>
                    </div>
                    <div style="text-align: center">
                        <p style="text-align: right">
&nbsp;<asp:Button ID="Logout" runat="server" Text="Logout" OnClick="Logout_Click"/>
                        </p>
                    </div>
                    <hr />
                    <h2>Clients In &lt;District&gt;</h2>
                </div>
            </div>
            <div>
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="UpdateClients" updatemode="Conditional" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="clientGrid" AutoGenerateColumns="false" runat="server" OnRowCommand="clientGrid_RowCommand">
                        <Columns>
                            <asp:TemplateField HeaderText="Client Name">
                            <ItemTemplate>
                                <asp:LinkButton ID="clientName" runat="server" Text='<%# Eval("Name") %>' CommandName="clientNameClick" CommandArgument='<%# Bind("Id") %>'></asp:LinkButton>
                            </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <br />
            Create Client<br />
            <asp:TextBox ID="newClientName" runat="server"></asp:TextBox>
            name<br />
            <asp:TextBox ID="newClientLocation" runat="server"></asp:TextBox>
            location<br />
            <asp:Button ID="newClientButton" runat="server" OnClick="newClientButton_Click" Text="New Client" />
            <br />
        </div>
        </div>
        <hr />
        <div>
            <div class="auto-style1">
                <div>
                    <h2>Current Interventions For &lt;Name&gt;</h2>
                </div>
            </div>
            <asp:GridView ID="interventionGrid" AutoGenerateColumns="true" runat="server"></asp:GridView>
            <br />
            <hr />
            <div>
            <br />
        </div>
        </div>
    </form>
</body>
</html>
