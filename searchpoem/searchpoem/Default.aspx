<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="searchpoem.Default" %>

<%@ Import Namespace="searchpoem.Models" %>
<%@ Import Namespace="Nest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server" action="Default.aspx">
        <input placeholder="请输入搜索关键字" name="keyword" />
        <input type="submit" />
        <p>默认返回前5条文档</p>
    </form>
    <div style="font-size: 12px;">
        <%foreach (IHit<Poetries> poetrie in poetries)
            {
        %>
        <div>《 <%= 
                   poetrie.Highlights.Count > 0 &  poetrie.Highlights.ContainsKey("title") && poetrie.Highlights["title"] != null && poetrie.Highlights["title"].Highlights != null && poetrie.Highlights["title"].Highlights.Count >0
                        ? poetrie.Highlights["title"].Highlights.FirstOrDefault() 
                        : poetrie.Source.Title  %>》</div>
        <div><%= 
                 poetrie.Highlights.Count > 0 && poetrie.Highlights.ContainsKey("content") && poetrie.Highlights["content"] != null && poetrie.Highlights["content"].Highlights != null && poetrie.Highlights["content"].Highlights.Count >0
                        ? poetrie.Highlights["content"].Highlights.FirstOrDefault() 
                        : poetrie.Source.Content %></div>
        <hr />
        <%
            } %>
    </div>
</body>
</html>
