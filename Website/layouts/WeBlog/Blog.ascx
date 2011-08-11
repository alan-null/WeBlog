﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Blog.ascx.cs" Inherits="Sitecore.Modules.WeBlog.Layouts.Blog" %>

<div class="blog-header">
    <asp:HyperLink ID="HyperlinkBlog" runat="server"><sc:Text ID="fieldtextItem" Field="Title" runat="server" /></asp:HyperLink>
</div>

<div class="blog">

    <div class="blog-leftcolumn">
        <sc:placeholder ID="phBlogMain" key="phBlogMain" runat="server" />
    </div>

    <div class="blog-rightcolumn">
        <sc:placeholder ID="phBlogSidebar" key="phBlogSidebar" runat="server" />
    </div>

    <div class="blog-footer">Powered by <a href="http://trac.sitecore.net/WeBlog">WeBlog</a></div>
</div>