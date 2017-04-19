<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="GoGoPowerRangers.ENET.Views.test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <%@Import namespace = "GoGoPowerRangers.ENET.Model" %>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            LOGGED IN!!!
            <% User user = (User)Session["currentUser"];  %>
            <%= user.Name  %>
        </div>
    </form>
</body>
</html>
