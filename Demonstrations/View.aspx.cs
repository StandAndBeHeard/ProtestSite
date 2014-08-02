using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class Demonstrations_View : System.Web.UI.Page
{
    ProtestLib.Protest protest;
    ProtestLib.Participants participants = null;
    ProtestLib.Participant participant = null;

    protected void Page_Load(object sender, EventArgs e)
    {

        LoadData();

        
        MasterBase master = (MasterBase)Page.Master;
        master.PageName = protest.Title;
        //master.BreadCrumbSteps = new string[,] { { "/demonstrations/", "Demonstrations" } };
        master.BreadCrumbSteps = new string[,] { { "/", "Demonstrations" } };
        Page.Title = master.PageName;


        Populate();

    }

    private void LoadData()
    {
        string url = Page.RouteData.Values["url"] == null ? Request["url"] : Page.RouteData.Values["url"].ToString();
        protest = ProtestLib.Protest.Load(url);

        participants = ProtestLib.Participants.LoadForProtest(protest.Id);
        if (AppUser.Current.IsAuthenticated) participant = participants.GetByUserId(AppUser.Current.User.Id);
    }


    protected void JoinButton_Click(object sender, EventArgs e)
    {
        AppUser.RequireLogin();
        if (AppUser.Current.IsAuthenticated && participant == null) ProtestLib.Participant.Join(AppUser.Current.User.Id, protest);
        Response.Redirect(protest.Url);
    }

    protected void CancelButton_Click(object sender, EventArgs e)
    {
        if (participant != null)
        {
            ProtestLib.Participant.Delete(participant.Id);
            protest.UpdateParticipantCount();
        }
        Response.Redirect(protest.Url);
    }

    private void Populate()
    {
        DemoNameLit.Text = protest.Title;
        AboutLit.Text = protest.Description;
        if (AppUser.Current.IsAuthenticated && AppUser.Current.User.Id == protest.OrganizerId) { EditLink.NavigateUrl = "edit.aspx?id=" + protest.Id; EditLink.Visible = true; }
        if (protest.Body != "")
        {
            AdditionalInfoLit.Text = protest.Body.Replace("\n","<br/>");
            AdditionalInfoHolder.Visible = true;
        }

        LocationLit.Text = "<p><b>" + protest.Location + "</b> - ";
        if (protest.Address != protest.Location) LocationLit.Text += protest.Address + ", ";
        LocationLit.Text += protest.City + ", " + protest.State + " " + protest.Zip + "</p>";
        if (!protest.IsLatitudeNull) LocationLit.Text += "<div id=\"map-canvas\" data-lat=\"" + protest.Latitude + "\" data-lng=\"" + protest.Longitude + "\"></div>";


        CutoffTimeRemainingLit.Text = GetDisplayTimeRemaining(protest.CutoffDate);
        CutoffTimeLit.Text = GetDisplayTime(protest.CutoffDate, protest.Timezone);

        DemoTimeRemainingLit.Text = GetDisplayTimeRemaining(protest.ProtestDate);
        DemoTimeLit.Text = GetDisplayTime(protest.ProtestDate, protest.Timezone);


        if (protest.Status == ProtestLib.ProtestStatus.Open || protest.Status == ProtestLib.ProtestStatus.Success)
        {
            JoinHolder.Visible = true;
            if (participant != null) {
                JoinButton.Visible = false;
                CancelButton.Visible = true;
            }
        }

        int displayPercent = Convert.ToInt32(System.Math.Round(protest.CurrentParticipants * 100.0 / protest.MinParticipants));
        int progessPercent = (displayPercent<=100) ? displayPercent : 100;
        ProgressLit.Text = protest.CurrentParticipants.ToString() + " of " + protest.MinParticipants.ToString() + " participants - " + displayPercent.ToString() + "% of goal";
        ProgressBarLit.Text = "<div class=\"progress-bar progress-bar-success\" role=\"progressbar\" aria-valuenow=\"" + progessPercent.ToString() + "\" aria-valuemin=\"0\" aria-valuemax=\"100\" style=\"width: " + progessPercent + "%;\">" + displayPercent + "%</div>";
        

        ParticipantsLit.Text = "";
        for (int i=0;i<10 && i<participants.Count;i++)
        {
            ParticipantsLit.Text += "<a href=\"/cp/pm/compose.aspx?toId=" + participants[i].UserId.ToString() + "\" class=\"clearfix participant\" onclick=\"return requireLogin('Please login to send a private message');\"><img src=\"" + GravatarHelper.GetGravatarUrl(participants[i].Email) + "\" /> " + participants[i].UserName + "</a>";
        }

        ProtestLib.User organizer = ProtestLib.User.Load(protest.OrganizerId);
        OrganizerLit.Text += "<a href=\"/cp/pm/compose.aspx?toId=" + protest.OrganizerId.ToString() + "\" class=\"clearfix participant\" onclick=\"return requireLogin('Please login to send a private message');\"><img src=\"" + GravatarHelper.GetGravatarUrl(organizer.Email) + "\" /> " + organizer.UserName + "</a>";


        PopulateComments();
        PopulateUpdates();
    }


    private void PopulateUpdates()
    {
        foreach (ProtestLib.ProtestUpdate update in ProtestLib.ProtestUpdates.LoadByProtestId(protest.Id))
        {
            UpdatesLit.Text += "<p><i>" + GetDisplayTime(update.PostedDate, protest.Timezone) + "</i><br/>" + update.Body.Replace("\n", "<br/>") + "</p><hr/>";
        }
    }

    private void PopulateComments()
    {
        if (AppUser.Current.IsAuthenticated) CommentLit.Text = "<div class=\"commentHolder clearfix\" data-contentid=\"" + protest.Id + "\" data-parentid=\"0\"></div>";
        else CommentLit.Text = "<p><i>Please login to comment.</i></p>";

        StringBuilder sb = new StringBuilder();
        ProtestLib.Comments comments = ProtestLib.Comments.LoadActive("protest", protest.Id);
        comments = comments.BuildTree();
        foreach (ProtestLib.Comment comment in comments) AppendComment(comment, sb);
        CommentLit.Text += sb.ToString();
    }

    private void AppendComment(ProtestLib.Comment comment, StringBuilder sb)
    {
        sb.Append("<div class=\"comment row\">");
        sb.Append("<div class=\"col-xs-1\"><img src=\"" + GravatarHelper.GetGravatarUrl(comment.Email) + "\" /></div><div class=\"col-xs-11\">");
        sb.Append("<div class=\"info\">Posted on " + GetDisplayTime(comment.PostedDate, protest.Timezone) + " by <a href=\"/cp/pm/compose.aspx?toId=" + comment.UserId.ToString() + "\" onclick=\"return requireLogin('Please login to send a private message');\">" + comment.UserName + "</a></div>");

        sb.Append("<div class=\"body\">" + comment.Body);
        sb.Append("<button class=\"btn btn-xs btn-success pull-right\" data-contentid=\"" + comment.ContentId.ToString() + "\" data-parentid=\"" + comment.Id.ToString() + "\" onclick=\"showReply(this);\">Reply</button>");
        sb.Append("</div>");
        
        if (comment.Children != null)
        {
            foreach (ProtestLib.Comment c in comment.Children) AppendComment(c, sb);
        }
        
        sb.Append("</div></div>");
    }


    private string GetDisplayTime(DateTime theDate, string tz)
    {
        theDate = ProtestLib.Utils.GetLocalTime(theDate, tz);
        return theDate.ToString("dddd MMMM ") + ProtestLib.Utils.GetOrdinalName(theDate.Day) + theDate.ToString(", yyyy - h:mmtt").Replace(":00","");
    }

    private string GetDisplayTimeRemaining(DateTime theDate)
    {
        TimeSpan ts = new TimeSpan(theDate.Ticks - DateTime.Now.ToUniversalTime().Ticks);
        if (ts.Days > 1) return ts.Days + " Days Remaining";
        else if (ts.Hours > 1) return ts.Hours + " Hours Remaining";
        else if (ts.Minutes > 1) return ts.Minutes + " Minutes Remaining";
        else if (ts.Seconds > 1) return ts.Seconds + " Seconds Remaining";
        else return "Expired";
    }

}