<%@ Page Title="Login" Language="C#" MasterPageFile="~/MasterPages/SubPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="row">
        <div class="col-md-4 col-md-offset-4 col-sm-6 col-sm-offset-3">
            <asp:PlaceHolder ID="ErrorHolder" runat="server" Visible="false">
                <div class="alert alert-block alert-warning fade in">
                    <button data-dismiss="alert" class="close" type="button">×</button>
                    <h4>Please correct the following errors:</h4>
                    <ul>
                        <asp:Literal ID="ErrorLit" runat="server" />
                    </ul>
                </div>
            </asp:PlaceHolder>


            <form class="reg-page" runat="server">
                <div class="reg-header"><h2>Login to your account</h2></div>
                <div class="input-group margin-bottom-20">
                    <span class="input-group-addon"><i class="fa fa-user"></i></span>
                    <asp:TextBox type="text" placeholder="Username or Email" CssClass="form-control" runat="server" ID="UserName" />
                </div>                    
                <div class="input-group margin-bottom-20">
                    <span class="input-group-addon"><i class="fa fa-lock"></i></span>
                    <asp:TextBox type="password" placeholder="Password" class="form-control" runat="server" id="Password" TextMode="Password" />
                </div>                    
                <div class="row">
                    <div class="col-md-12"><asp:button CssClass="btn-u pull-right" type="submit" Text="Login" runat="server" id="LoginButton" OnClick="LoginButton_Click" /></div>
                </div>

                <hr>

                <h4>Forget your Password ?</h4>
                <p>No problem, <a class="color-green" href="/forgotpassword.aspx">click here</a> to reset your password.</p>
            </form>            
        </div>
    </div><!--/row-->
</asp:Content>

