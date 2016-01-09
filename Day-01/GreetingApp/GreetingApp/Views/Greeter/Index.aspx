<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Index</title>
</head>
<body>
    <div>
        <form action="/greeter/greet" method="post">
            <label>Name :</label>
            <input type="text" name="name" value="" />
            <input type="submit" name="name" value="Greet" />
        </form>        
    </div>
</body>
</html>
