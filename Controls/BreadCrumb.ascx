<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Breadcrumb.ascx.cs" Inherits="Controls_BreadCrumb" %>
<div class="breadcrumbs">
    <div class="container">
        <h1 class="pull-left"><asp:Literal ID="PageNameLit" runat="server" /></h1>
        <ul class="pull-right breadcrumb">
            <li><a href="index.html">Home</a></li>
            <asp:Literal ID="OutputLit" runat="server" />
        </ul>
    </div>
</div>