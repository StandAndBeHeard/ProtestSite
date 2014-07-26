<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <style>.da-dots {display:none;}</style>    

    <!--=== Slider ===-->
    <div class="slider-inner">
        <div id="da-slider" class="da-slider">
            <div class="da-slide">
                <h2 style="top:70px;"><img src="/img/logo-slider.png" alt="Stand and be Heard" /></h2>
                <div class="da-img"><img src="/img/sliders/1.jpg" alt="" style="border:3px solid #FFF;box-shadow: 10px 10px 5px #666, -10px 10px 10px #666, 10px -10px 10px #666;" /></div>
            </div>
        </div>
    </div><!--/slider-->
    <!--=== End Slider ===-->
    
    <div class="purchase">
        <div class="container">
            <div class="row">
                <div class="col-md-9 animated fadeInLeft">
                    <span>STAND and be HEARD makes it easy to organize for any cause.</span>
                    <p>Many people are hesitant to commit to showing up unless they know there is going to be a decent turnout.  STAND and be HEARD addresses this issue by allowing you to define a minimum turnout for your event and allowing people to pledge to show up if the turnout goal is reached.</p>
                </div>            
                <div class="col-md-3 btn-buy animated fadeInRight">
                    <a href="/demonstrations/edit.aspx" class="btn-u btn-u-lg"><i class="fa fa-bullhorn"></i> Start a Demonstration</a>
                </div>
            </div>
        </div>
    </div>
    

    
    <div class="container content">	

        <asp:PlaceHolder ID="FeaturedHolder" runat="server" Visible="false">
        <div class="headline" id="demonstrations"><h2>Featured Demonstrations</h2></div>
        <asp:Literal ID="FeaturedLit" runat="server" />
        </asp:PlaceHolder>
        
        <div class="headline"><h2>About STAND and be HEARD</h2></div>
        <div class="row">
            <div class="col-md-8">
                <p>Organizing protests and other demonstrations can be an effective way to draw attention to a cause and bring about positive change.  Almost everyone has something they
                    would like to change about the world.  Even though public demonstrations are one of the best ways to make your voice heard, a very small percentage of people will ever
                    participate in one.  It's not because people are lazy, it is because they often feel alone and organizing a demonstration can be difficult.</p>
                <p>STAND and be HEARD aims to fix this problem.  We allow the organizer and participicants to be assured of a reasonable turnout at their event, before committing to holding the demonstration.  Similar to other campaign sites like Kickstarter or Thunderclap, we allow the organizer to set a minimum turnout required and allow participants to pledge that they will show up if that number is met.  If the number is not met, the demonstration does not continue.</p>
            </div>
            <div class="col-md-4">
                <blockquote>"Never be afraid to raise your voice for honesty and truth and compassion against injustice and lying and greed. If people all over the world would do this, it would change the earth." ― William Faulkner</u></blockquote>
            </div>
        </div>
        
        
        
    </div>


</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="HeadHolder" Runat="Server">
    <script type="text/javascript" src="/js/pages/index.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            App.init();
            App.initSliders();
            Index.initParallaxSlider();
        });
</script>
</asp:Content>