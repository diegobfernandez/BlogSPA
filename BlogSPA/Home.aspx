<%@ Page Language="C#" AutoEventWireup="true" %>
<%@ Import Namespace="System.Web.Optimization" %>

<!DOCTYPE html>

<html ng-app xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%: Styles.Render("~/bundle/style") %>
</head>
<body>
    <div ng-view>
    </div>
    <%: Scripts.Render("~/bundle/libs") %>
</body>
</html>