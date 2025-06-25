<%@ Page Language="C#" %>

<html>
<head runat="server">
    <title>NuGet Package Server</title>
    <link href="/css/main.css" rel="stylesheet" type="text/css" />
    <script>
        // https://stackoverflow.com/questions/247483/http-get-request-in-javascript
        function httpGet(theUrl) {
            var xmlHttp = new XMLHttpRequest();
            xmlHttp.open("GET", theUrl, false); // false for synchronous request
            xmlHttp.send(null);
            return xmlHttp.responseText;
        }
    </script>
</head>
<body>
    <div class="navbar navbar-default navbar-static-top">
        <div class="container-fluid">
            <div class="navbar-header">
                <div class="navbar-brand">
                    VTIL LLc &copy;
                    <script> document.write(new Date().getFullYear());</script>
                </div>
            </div>

            <ul class="nav navbar-nav navbar-right">
                <li class="navbar-text"><%= System.Environment.MachineName %></li>
            </ul>


            <ul class="nav navbar-nav">
                <li class="">
                    <a href="/nuget/Packages">NuGet Packages</a>
                </li>
            </ul>


            <ul class="nav navbar-nav">
                <li class="">
                    <a href="" onclick="httpGet('/nuget/clear-cache'); return false">Clear cache</a>
                </li>
            </ul>
        </div>
    </div>
</body>
</html>
