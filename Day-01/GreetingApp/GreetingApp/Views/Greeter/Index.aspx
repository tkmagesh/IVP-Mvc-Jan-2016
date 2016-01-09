<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<GreetInput>" %>
<%@ Import Namespace="GreetingApp.Models" %>


<!DOCTYPE html>

<html>
<head runat="server">
    <title>Index</title>
    <style>
        
        .invalid {
            border: 2px solid red;
            background-color: lightpink;
        }
    </style>
</head>
<body>
    <div>
        
       <%-- <form action="/greeter/greet" method="post">--%>
        <% using (Html.BeginForm("Greet", "Greeter"))
           { %>
            <label>Name :</label>
            <%--<input type="text" name="FirstName" value="<%=Model.FirstName %>" class="<%= this.Model.ErrorMessages.ContainsKey("FirstName") ? "invalid" : "" %>" />
            <input type="text" name="LastName" value="<%=Model.LastName %>" class="<%= this.Model.ErrorMessages.ContainsKey("LastName") ? "invalid" : "" %>" />--%>
            <%= Html.TextBoxFor(m => m.FirstName) %>
            <%= Html.TextBoxFor(m => m.LastName) %>
            <input type="submit" name="name" value="Greet" />
            <div>
                <ol>
                <% if (!this.Model.IsValid)
                   {
                       foreach (var item in Model.ErrorMessages)
                       {
                %>
                        <li><%= item.Value %></li>
                <% }
                   }
                %>
                    </ol>
            </div>
        <% } %>
        <%--</form>   --%>     
    </div>
</body>
</html>
