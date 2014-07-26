using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Collections.Generic;

public partial class Ajax_Comment : System.Web.UI.Page
{

    private ProtestLib.Comment comment = new ProtestLib.Comment();

    protected void Page_Load(object sender, EventArgs e)
    {
        comment.ContentType = Request["contenttype"];
        comment.ContentId = Convert.ToInt32(Request["contentid"]);
        comment.Body = ProtestLib.Utils.RemoveHtml(Request["commentbody"]).Trim();
        comment.ParentId = Convert.ToInt32(Request["ParentId"]);
        comment.PostedDate = DateTime.UtcNow;
        comment.Active = true;
        comment.IpAddress = Utils.GetIPAddress();
        Submit();
    }

    private void Submit()
    {
        string[] errors = Validate();
        if (errors.Length == 0)
        {
            comment.UserId = AppUser.Current.User.Id;
            comment.Save();
            OutputLit.Text = "{\"id\": " + comment.Id.ToString() + "}";
        }
        else
        {
            OutputLit.Text = "{\"errors\":[\"" + String.Join("','", errors) + "\"]}";
        }
    }


    public string[] Validate()
    {
        List<string> errors = new List<string>();
        if (!AppUser.Current.IsAuthenticated) errors.Add("Please login first.");
        else if (comment.Body.Length < 10) errors.Add("Comment is too short.");
        return errors.ToArray();
    }




}