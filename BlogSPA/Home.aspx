<%@ Page Language="C#" AutoEventWireup="true" %>

<%@ Import Namespace="System.Web.Optimization" %>

<!DOCTYPE html>

<html ng-app="app" lang="pt-BR">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <title>Blog SPA</title>
    <meta name="description" content="">
    <meta name="viewport" content="width=device-width">

    <%: Styles.Render("~/bundle/style") %>
</head>
<body ng-controller="AppController">
    <div class="content">
        <div ng-include="'app/_layout/notifications.tpl.html'" ng-show="notifications.getCurrent().length"></div>
        <div ng-include="'app/_layout/header.tpl.html'"></div>    
        <main ng-view></main>
    </div>
    <%: Scripts.Render("~/bundle/libs") %>
    <%: Scripts.Render("~/bundle/app") %>
</body>
</html>
