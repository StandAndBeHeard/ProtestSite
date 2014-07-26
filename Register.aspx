<%@ Page Title="Register" Language="C#" MasterPageFile="~/MasterPages/SubPage.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    

    <div class="row">
        <div class="col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2">

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
                <div class="reg-header">
                    <h2>Register a new account</h2>
                    <p>Already Signed Up? Click <a href="/login.aspx" class="color-green">Sign In</a> to login your account.</p>                    
                </div>

                <label>User Name <span class="color-red">*</span></label>
                <asp:TextBox ID="UserName" runat="server" class="form-control margin-bottom-20" />
                    
                   
                <label>Email Address <span class="color-red">*</span></label>
                <asp:TextBox ID="Email" runat="server" class="form-control margin-bottom-20" />

                <div class="row">
                    <div class="col-sm-6">
                        <label>Password <span class="color-red">*</span></label>
                        <asp:TextBox ID="Password" runat="server" class="form-control margin-bottom-20" TextMode="Password" />
                    </div>
                    <div class="col-sm-6">
                        <label>Confirm Password <span class="color-red">*</span></label>
                        <asp:TextBox ID="VerifyPassword" runat="server" class="form-control margin-bottom-20" TextMode="Password" />
                    </div>
                </div>

                <label>May We Contact You About:</label>
                <div class="checkbox"><label><input type="checkbox" id="ContactDemo" runat="server" checked="checked"> Updates to demonstrations you're participating in.</label></div>
                <div class="checkbox"><label><input type="checkbox" id="ContactOther" runat="server"> Invitations to similar demonstrations and other site news.</label></div>

                <hr>

                <div class="row">
                    <div class="col-lg-6">
                        <label class="checkbox">
                            <input type="checkbox" id="Terms" runat="server" checked="checked"> 
                            I read <a href="/terms.aspx" class="color-green">Terms and Conditions</a>
                        </label>                        
                    </div>
                    <div class="col-lg-6 text-right">
                        <asp:button CssClass="btn-u" type="submit" runat="server" Text="Register" id="RegisterButton" OnClick="RegisterButton_Click" />
                    </div>
                </div>
            </form>
        </div>
    </div>
</asp:Content>

