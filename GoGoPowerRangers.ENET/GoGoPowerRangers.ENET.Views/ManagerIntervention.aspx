<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagerIntervention.aspx.cs" Inherits="GoGoPowerRangers.ENET.UI.ManagerIntervention" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .header {
            float: left;
            padding-left: 5%;
            height: 20px;
        }

        .button {
            padding-left: 70%;
        }

        .table {
            padding-left:10%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
            <h3>
                Interventions
            </h3>
        </div>
        <div class="button">
            <asp:Button ID="Button1" runat="server" Text="Filter" />
        </div>
        <div class="table">
            <asp:GridView ID="tblIntervention" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField HeaderText="Type" />
                    <asp:TemplateField HeaderText="Client"></asp:TemplateField>
                    <asp:TemplateField HeaderText="District"></asp:TemplateField>
                    <asp:TemplateField HeaderText="Status"></asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
