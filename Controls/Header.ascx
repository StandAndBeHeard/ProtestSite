<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Header.ascx.cs" Inherits="Controls_Header" %>
    <div class="header">
        <div class="topbar">
            <div class="container">
                <ul class="loginbar pull-right">
                    <asp:PlaceHolder ID="LoggedOutHolder" runat="server" ><li><a href="/register.aspx">Register</a></li><li class="topbar-devider"></li><li><a href="/login.aspx">Login</a></li></asp:PlaceHolder>
                    <asp:PlaceHolder ID="LoggedInHolder" runat="server" Visible="false" ><li>Welcome, <asp:Literal ID="UserNameLit" runat="server" /></li><li class="topbar-devider"></li><li><a href="/login.aspx?logout=1" id="logoutLink">Logout</a></li></asp:PlaceHolder>
                </ul>
            </div>
        </div>
    
        <!-- Navbar -->
        <div class="navbar navbar-default" role="navigation">
            <div class="container">
                <!-- Brand and toggle get grouped for better mobile display -->
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-responsive-collapse">
                        <span class="sr-only">Toggle navigation</span>
                        <span class="fa fa-bars"></span>
                    </button>
                    <a class="navbar-brand" href="/">
                        <img id="logo-header" src="/img/logo.png" alt="Logo">
                    </a>
                </div>

                <div class="collapse navbar-collapse navbar-responsive-collapse">
                    <ul class="nav navbar-nav">
                        <li class="active"><a href="/">Home</a></li>
                        <li class="dropdown">
                            <a href="javascript:void(0);" class="dropdown-toggle" data-toggle="dropdown">Demonstrations</a>
                            <ul class="dropdown-menu">
                                <li><a href="/demonstrations/edit.aspx">Create</a></li>
                                <li><a href="/#demonstrations">Join</a></li>
                            </ul>
                        </li>
                        <!--
                        <li><a href="/blog/">Blog</a></li>
                        <li>
                            <i class="search fa fa-search search-btn"></i>
                            <div class="search-open">
                                <div class="input-group animated fadeInDown">
                                    <input type="text" class="form-control" placeholder="Search">
                                    <span class="input-group-btn">
                                        <button class="btn-u" type="button">Go</button>
                                    </span>
                                </div>
                            </div>    
                        </li>
                        -->
                    </ul>
                </div>

            </div>    
        </div>            
        <!-- End Navbar -->
    </div>
    <!--=== End Header ===-->  