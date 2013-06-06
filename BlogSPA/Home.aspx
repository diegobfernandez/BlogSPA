<%@ Page Language="C#" AutoEventWireup="true" %>

<%@ Import Namespace="System.Web.Optimization" %>

<!DOCTYPE html>

<html ng-app="app" lang="pt-BR">
<head runat="server">
	<title>Blog SPA</title>
	<meta charset="utf-8"/>
	<%: Styles.Render("~/bundle/style") %>
</head>
<body ng-controller="AppController">
	<div ng-include="'app/notifications.tpl.html'" class="container-fluid" ng-show="notifications.getCurrent().length"></div>
	<div ng-view></div>
	<%: Scripts.Render("~/bundle/libs") %>
	<%: Scripts.Render("~/bundle/app") %>
</body>
</html>
