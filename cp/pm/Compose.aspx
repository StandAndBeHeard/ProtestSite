<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/SubPage.master" AutoEventWireup="true" CodeFile="Compose.aspx.cs" Inherits="cp_pm_Compose" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <form runat="server">
        <h1><asp:Literal ID="TitleLit" runat="server" Text="Compose Private Message" /></h1>
        <asp:Literal ID="CommentsLit" runat="server" />
    
        <asp:PlaceHolder ID="ErrorHolder" runat="server" Visible="false">
            <div class="alert alert-block alert-warning fade in">
                <button data-dismiss="alert" class="close" type="button">×</button>
                <h4>Please correct the following errors:</h4>
                <ul>
                    <asp:Literal ID="ErrorLit" runat="server" />
                </ul>
            </div>
        </asp:PlaceHolder>

        <asp:PlaceHolder ID="TitleHolder" runat="server" >
            <div class="row">
                <div class="col-lg-12">
                    <label>Title <span class="color-red">*</span></label>
                    <asp:TextBox CssClass="form-control" runat="server" id="TitleText" /><br />
                </div>
            </div>
        </asp:PlaceHolder>
        <div class="row">
            <div class="col-lg-12">
                <label>Message <span class="color-red">*</span></label>
                <asp:TextBox TextMode="MultiLine" Rows="3" CssClass="form-control" runat="server" id="BodyText" /><br />
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12 text-right">
                <asp:Button ID="PostButton" runat="server" Text="Post" CssClass="btn btn-u"  OnClick="PostButton_Click"  />
            </div>
        </div>
    </form>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadHolder" Runat="Server">
    <style>
        .comment .info {font-style:italic;color:#999;}
        .comment .body {min-height:40px;margin-bottom:10px;}
    </style>
</asp:Content>

