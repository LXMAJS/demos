<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="searchpoem.Default" %>
<%@ Import Namespace="searchpoem.Models" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server" action="Default.aspx">
        <input placeholder="请输入搜索关键字" name="keyword" />
        <input type="submit" />
        <p>默认返回前5条文档</p>
    </form>
    <div style="font-size:12px;">
        <%foreach (Poetries poetrie in poetries)
            {
                %>
                <div>《 <%= poetrie.Title %>》</div>
                <div> <%= poetrie.Content %></div>
        <hr />
        <%
            } %>
    </div>
</body>
</html>
