using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class cp_pm_Compose : System.Web.UI.Page
{
    ProtestLib.PrivateMessage pm;
    ProtestLib.Comments comments;
    protected void Page_Load(object sender, EventArgs e)
    {
        AppUser.RequireLogin();

        MasterBase master = (MasterBase)Page.Master;
        master.PageName = "Private Message";
        //master.BreadCrumbSteps = new string[,] { { "/", "Demonstrations" } };
        Page.Title = master.PageName;

        LoadData();
        if (pm.Id > 0) { 
            TitleHolder.Visible = false; 
            master.PageName = pm.Title; 
            TitleLit.Text = pm.Title;
        }
        PopulateComments();
    }

    private void PopulateComments()
    {
        StringBuilder sb = new StringBuilder();
        ProtestLib.Comments comments = ProtestLib.Comments.LoadActive("privatemessage", pm.Id);
        foreach (ProtestLib.Comment comment in comments)
        {
            sb.Append("<div class=\"comment row\">");
            sb.Append("<div class=\"col-xs-1\"><img src=\"" + GravatarHelper.GetGravatarUrl(comment.Email) + "\" /></div><div class=\"col-xs-11\">");
            sb.Append("<div class=\"info\">Posted on " + comment.PostedDate.ToString(", yyyy - h:mmtt").Replace(":00", "") + " UTC by <a href=\"#\">" + comment.UserName + "</a></div>");
            sb.Append("<div class=\"body\">" + comment.Body + "</div>");
            sb.Append("</div></div>");
        }
        CommentsLit.Text += sb.ToString();
        if (CommentsLit.Text != "") CommentsLit.Text += "<br/>";
    }

    //private string GetDisplayTime(DateTime theDate, string tz)
    //{
    //    theDate = ProtestLib.Utils.GetLocalTime(theDate, tz);
    //    return theDate.ToString("dddd MMMM ") + ProtestLib.Utils.GetOrdinalName(theDate.Day) + theDate.ToString(", yyyy - h:mmtt").Replace(":00", "");
    //}

    private void LoadData()
    {
        int id = Convert.ToInt32(Request["Id"]);
        if (id>0)
        {
            pm = ProtestLib.PrivateMessage.LoadPrivateMessage(id);
            if (pm.FromId != AppUser.Current.User.Id && pm.ToId != AppUser.Current.User.Id) Response.Redirect("/");
        }
        else
        {
            pm = new ProtestLib.PrivateMessage();
            pm.ToId = Convert.ToInt32(Request["ToId"]);
            pm.FromId = AppUser.Current.User.Id;
        }
        comments = ProtestLib.Comments.LoadActive("privatemessage", pm.Id);
    }

    protected void PostButton_Click(object sender, EventArgs e)
    {
        if (ValidateForm())
        {
            if (pm.Id == 0) {
                pm.Title = TitleText.Text; 
                pm.Save(); 
            }
            ProtestLib.Comment c = new ProtestLib.Comment();
            c.ContentId = pm.Id;
            c.Active = true;
            c.Body = ProtestLib.Utils.RemoveHtml(BodyText.Text);
            c.ContentType = "privatemessage";
            c.IpAddress = Utils.GetIPAddress();
            c.ParentId = 0;
            c.PostedDate = DateTime.UtcNow;
            c.UserId = AppUser.Current.User.Id;
            c.Save();
            pm.GenerateNotification(c, AppUser.Current.User);
            Response.Redirect("compose.aspx?id=" + pm.Id.ToString());
        }
    }

    private bool ValidateForm()
    {
        List<string> errors = new List<string>();

        if (pm.Id == 0)
        {
            if (TitleText.Text.Length < 3) errors.Add("Title is too short.");
        }
        if (BodyText.Text.Length < 2) errors.Add("Body is too short.");
        if (errors.Count != 0) ShowErrors(errors.ToArray());
        return errors.Count == 0;
    }

    private void ShowErrors(string[] errors)
    {
        ErrorHolder.Visible = true;
        ErrorLit.Text = "";
        foreach (string error in errors) ErrorLit.Text += "<li>" + error + "</li>";
    }

}