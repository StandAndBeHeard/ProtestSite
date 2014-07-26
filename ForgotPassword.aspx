<%@ Page Title="Forgot Password" Language="C#" MasterPageFile="~/MasterPages/SubPage.master" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="ForgotPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    

    <div class="row">
        <div class="col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2">

            <asp:PlaceHolder ID="ErrorHolder" runat="server" Visible="false">
                <div class="alert alert-block alert-warning fade in">
                    <button data-dismiss="alert" class="close" type="button">×</button>
                    <h4>Notice:</h4>
                    <ul>
                        <asp:Literal ID="ErrorLit" runat="server" />
                    </ul>
                </div>
            </asp:PlaceHolder>

            <form class="reg-page" runat="server">
                <div class="reg-header">
                    <h2>Forgot Password</h2>
                </div>


                <div class="row">
                    <div class="col-xs-8">
                        <label>User Name</label>
                        <asp:TextBox ID="UserName" runat="server" class="form-control margin-bottom-20" />
                    </div>
                    <div class="col-xs-4" style="padding-top:24px;">
                        <asp:button CssClass="btn-u" type="submit" runat="server" Text="Reset" id="Reset1Button" OnClick="Reset1Button_Click" />
                    </div>
                </div>

                <div class="row">
                    <div class="col-xs-8">
                        <label>Email</label>
                        <asp:TextBox ID="Email" runat="server" class="form-control margin-bottom-20" />
                    </div>
                    <div class="col-xs-4" style="padding-top:24px;">
                        <asp:button CssClass="btn-u" type="submit" runat="server" Text="Reset" id="Reset2Button"  OnClick="Reset2Button_Click"  />
                    </div>
                </div>
                
                    
                    
                
            </form>
        </div>
    </div>
</asp:Content>

