<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Greeter</title>
</head>
<body style="background-color: lightblue">
    <div>
        <h1><%= ViewData["message"] %></h1>
    </div>
</body>
</html>
