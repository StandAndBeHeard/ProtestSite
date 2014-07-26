<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/SubPage.master" AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="Demonstrations_Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">



    <div class="row">
        <div class="col-md-8 mb-margin-bottom-30">
            <asp:PlaceHolder ID="ErrorHolder" runat="server" Visible="false">
                <div class="alert alert-block alert-warning fade in">
                    <button data-dismiss="alert" class="close" type="button">×</button>
                    <h4>Please correct the following errors:</h4>
                    <ul>
                        <asp:Literal ID="ErrorLit" runat="server" />
                    </ul>
                </div>
            </asp:PlaceHolder>
        </div>
    </div>
    <form class="reg-page" runat="server">
        <div class="row">
            <div class="col-md-8">
                <div class="reg-header">
                    <asp:Literal ID="UpdateLit" runat="server" />
                    <h2 style="margin-bottom: 30px;">Edit Demonstration</h2>
                </div>

                <label>Minimum Number of Participants? <span class="color-red">*</span><br />
                </label>
                <div class="row">
                    <div class="col-sm-4">
                        <asp:TextBox ID="MinTurnoutText" runat="server" class="form-control margin-bottom-20" PlaceHolder="20" />
                    </div>
                    <div class="col-sm-8">
                        Choose carefully, this can not be changed.
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="headline" style="margin-top: 33px;">
                    <h2>Min Turnout</h2>
                </div>
                <p>This should be large enough that people feel comfortable showing up, but small enough to ensure it is achievable.  <u>The demonstration will not proceed unless this goal is met.</u></p>
            </div>
        </div>


        <div class="row">
            <div class="col-md-8">
                <div class="headline">
                    <h2>About</h2>
                </div>

                <label>Demonstration Name <span class="color-red">*</span></label>
                <asp:TextBox ID="DemonstrationNameText" runat="server" class="form-control margin-bottom-20" />

                <label>Description - Tell Us About This Demonstration <span class="color-red">*</span></label>
                <asp:TextBox ID="AboutText" runat="server" class="form-control margin-bottom-20" TextMode="MultiLine" Rows="3" />

                <label>Additional Info</label>
                <asp:TextBox ID="AdditionalInfoText" runat="server" class="form-control margin-bottom-20" TextMode="MultiLine" Rows="8" />
            </div>
            <div class="col-md-4">
                <div class="headline">
                    <h2>About</h2>
                </div>
                <p>Let people know why you are demonstrating.  Provide a detailed description so that people know the goal, what they should bring and any other important information.</p>
                <p>Provide a one paragraph description about how and why you will be demonstrating.  Use the additional info field to provide more background information, and to let people know the details of when and where to meet and what to bring.</p>
            </div>
        </div>

        <div class="row">
            <div class="col-md-8">
                <div class="headline">
                    <h2>Websites</h2>
                </div>
                <div class="row">
                    <div class="col-sm-4">
                        <asp:TextBox ID="Website1Text" runat="server" class="form-control margin-bottom-20" PlaceHolder="http://yourorganization.com/" />
                    </div>
                    <div class="col-sm-4">
                        <asp:TextBox ID="Website2Text" runat="server" class="form-control margin-bottom-20" PlaceHolder="http://facebook.com/YourOrganization/" />
                    </div>
                    <div class="col-sm-4">
                        <asp:TextBox ID="Website3Text" runat="server" class="form-control margin-bottom-20" PlaceHolder="https://www.thunderclap.it/projects/YourProject" />
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="headline">
                    <h2>Websites</h2>
                </div>
                <p>If you have a website, Facebook page, Thunderclap campaign or any other relevant urls, enter them here.</p>
            </div>
        </div>


        <div class="row">
            <div class="col-md-8">
                <div class="headline">
                    <h2>Location</h2>
                </div>
                <div class="row">
                    <div class="col-sm-6">
                        <label>Display Location <span class="color-red">*</span></label>
                        <asp:TextBox ID="DisplayLocationText" runat="server" class="form-control margin-bottom-20" PlaceHolder="White House" />
                    </div>
                    <div class="col-sm-6">
                        <label>Map Address <span class="color-red">*</span></label>
                        <asp:TextBox ID="AddressText" runat="server" class="form-control margin-bottom-20" PlaceHolder="1600 Pennsylvania Ave" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-4">
                        <label>City <span class="color-red">*</span></label>
                        <asp:TextBox ID="CityText" runat="server" class="form-control margin-bottom-20" PlaceHolder="Washington" />
                    </div>
                    <div class="col-sm-4">
                        <label>State / Province <span class="color-red">*</span></label>
                        <asp:TextBox ID="StateText" runat="server" class="form-control margin-bottom-20" PlaceHolder="DC" />
                    </div>
                    <div class="col-sm-4">
                        <label>Postal Code <span class="color-red">*</span></label>
                        <asp:TextBox ID="ZipText" runat="server" class="form-control margin-bottom-20" PlaceHolder="20500" />
                    </div>
                </div>
                <label>Country <span class="color-red">*</span></label>
                <asp:TextBox ID="CountryText" runat="server" class="form-control margin-bottom-20" PlaceHolder="United States" />
            </div>
            <div class="col-md-4">
                <div class="headline">
                    <h2>Location</h2>
                </div>
                <p>The display location is where you can describe your meeting place, such as "State Capitol".</p>
                <p>The physical address is needed in order to plot the location on the map and allow people to find demonstrations near them.</p>
            </div>
        </div>


        <div class="row">
            <div class="col-md-8">
                <div class="headline">
                    <h2>Time</h2>
                </div>
                <div class="row">
                    <div class="col-sm-3">
                        <label>Date <span class="color-red">*</span></label>
                        <asp:TextBox ID="DateText" runat="server" class="form-control margin-bottom-20" PlaceHolder="12/31/2014" TextMode="Date" />
                    </div>
                    <div class="col-sm-3">
                        <label>Time <span class="color-red">*</span></label>
                        <asp:TextBox ID="TimeText" runat="server" class="form-control margin-bottom-20" PlaceHolder="6:00pm" TextMode="Time" />
                    </div>
                    <div class="col-sm-6">
                        <label>Timezone <span class="color-red">*</span></label>
                        <asp:DropDownList ID="TimezoneList" runat="server" class="form-control margin-bottom-20" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-12 text-right">
                        <asp:Button CssClass="btn-u" type="submit" runat="server" Text="Save" ID="SaveButton" OnClick="SaveButton_Click" />
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="headline">
                    <h2>Time</h2>
                </div>
                <p>Let people know when this demonstration will take place.  Don't forget to set the timezone.</p>
            </div>
        </div>


        <asp:PlaceHolder ID="UpdateHolder" runat="server">
            <br />
            <hr />
            <br />
            <div class="row">
                <div class="col-md-8">
                    <h2 style="margin-bottom: 30px;">Post an Update</h2>
                    <div class="row">
                        <div class="col-lg-12">
                            <asp:TextBox TextMode="MultiLine" Rows="3" CssClass="form-control" runat="server" id="UpdateBody" /><br />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-12 text-right">
                            <asp:Button ID="UpdateButton" runat="server" Text="Post Update" CssClass="btn btn-u"  OnClick="UpdateButton_Click"  />
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div>
                        <h2>Post an Update</h2>
                    </div>
                    <p>As your demonstration gets closer, plans may change and there could be important information that you need to let all participants know about.  Post an update to communicate this information.  Updates show up on the demonstration page and are emailed to all participants.  Updates can not be edited once posted, you should post a new update with any corrections, if needed.</p>
                </div>
            </div>
        </asp:PlaceHolder>

    </form>

</asp:Content>

