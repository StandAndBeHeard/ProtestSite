<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/SubPage.master" AutoEventWireup="true" CodeFile="View.aspx.cs" Inherits="Demonstrations_View" EnableViewState="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <style>
        .participant { font-size:16px; }
        .participant img { float:left;margin-right:20px;width:50px;height:50px;  margin-bottom:15px; }
        .comment img { float:left;margin-right:20px;width:50px;height:50px;  margin-bottom:15px; }
        #map-canvas {width:100%;height:200px;}
        .largeText {font-size:18px;}
        .comment .info {font-style:italic;color:#999;}
        .comment .body {min-height:40px;margin-bottom:10px;}
    </style>

    

    <div class="row">
        <div class="col-md-8 mb-margin-bottom-30">

            <div class="addthis_sharing_toolbox" style="height:37px;"></div>
            <asp:HyperLink ID="EditLink" runat="server" CssClass="pull-right btn btn-primary" Text="Edit" Visible="false" />
            
            
            <h1><asp:Literal ID="DemoNameLit" runat="server" /></h1>
            
            

            <div style="font-size:13pt;font-weight:normal;">
            <asp:Literal ID="AboutLit" runat="server" />
            </div>


            <div class="headline"><h2>Location</h2></div>
            <asp:Literal ID="LocationLit" runat="server" />

            <asp:PlaceHolder ID="AdditionalInfoHolder" runat="server" Visible="false">
                <div class="headline"><h2>Additional Information</h2></div>
                <p><asp:Literal ID="AdditionalInfoLit" runat="server" /></p>
            </asp:PlaceHolder>

            <div class="headline"><h2>Updates</h2></div>
            <asp:Literal ID="UpdatesLit" runat="server" />

            <div class="addthis_sharing_toolbox" style="height:37px;"></div>

            <div class="headline"><h2>Comments</h2></div>
            <asp:Literal ID="CommentLit" runat="server" />
            
            


        </div>
        <div class="col-md-4">
            
            <asp:PlaceHolder ID="JoinHolder" runat="server" Visible="false" >
                <form runat="server">
                <asp:Button ID="JoinButton" CssClass="btn btn-lg btn-block btn-success" runat="server" Text="Join This Demonstration" onclick="JoinButton_Click" />
                <asp:Button ID="CancelButton" CssClass="btn btn-lg btn-block btn-danger" runat="server" Text="Leave This Demonstration" Visible="false" OnClick="CancelButton_Click" />
                <br />
                </form>
            </asp:PlaceHolder>

            <div class="headline"><h2>Supporters</h2></div>
            <div class="progress">
                <asp:Literal ID="ProgressBarLit" runat="server" />
            </div>
            <asp:Literal ID="ProgressLit" runat="server" />
            <br /><br />

            <div class="headline"><h2>Time to Pledge</h2></div>
            <div class="largeText"><asp:Literal ID="CutoffTimeRemainingLit" runat="server" /></div>
            <asp:Literal ID="CutoffTimeLit" runat="server" /><br /><br />

            <div class="headline"><h2>Time until Demonstration</h2></div>
            <div class="largeText"><asp:Literal ID="DemoTimeRemainingLit" runat="server" /></div>
            <asp:Literal ID="DemoTimeLit" runat="server" /><br /><br />

            <div class="headline"><h2>Organizer</h2></div>
            <asp:Literal ID="OrganizerLit" runat="server" />
            <div class="headline"><h2>Recent Participants</h2></div>
            <asp:Literal ID="ParticipantsLit" runat="server" />
        </div>
    </div>

    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadHolder" Runat="Server">
    <script src="//maps.googleapis.com/maps/api/js?v=3.exp"></script>
    <script>
        var map;
        function initialize() {
            if ($('#map-canvas').length > 0) {
                var latlng = new google.maps.LatLng($('#map-canvas').data('lat'), $('#map-canvas').data('lng'));
                var mapOptions = { zoom: 13, center: latlng };
                map = new google.maps.Map(document.getElementById('map-canvas'), mapOptions);

                var marker = new google.maps.Marker({
                    position: latlng,
                    map: map,
                    title: 'Protest'
                });
            }
        }

        google.maps.event.addDomListener(window, 'load', initialize);

    </script>
</asp:Content>