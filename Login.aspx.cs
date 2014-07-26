using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) if (Request["logout"] == "1") { AppUser.Logout(); Response.Redirect("/"); }
        MasterBase master = (MasterBase)Page.Master;
        master.PageName = "Login";
    }

    public bool Validate()
    {
        List<string> errors = new List<string>();
        if (UserName.Text.Trim().Length < 3) errors.Add("Please enter a user name or email address.");
        if (Password.Text == "") errors.Add("Please enter a password.");
        if (errors.Count != 0) ShowErrors(errors.ToArray());
        return errors.Count == 0;
    }

    private void ShowErrors(string[] errors)
    {
        ErrorHolder.Visible = true;
        ErrorLit.Text = "";
        foreach (string error in errors) ErrorLit.Text += "<li>" + error + "</li>";
    }

    protected void LoginButton_Click(object sender, EventArgs e)
    {
        if (Validate())
        {
            ProtestLib.User user = ProtestLib.User.Load(UserName.Text, UserName.Text, Password.Text);
            if (user==null)
            {
                ShowErrors(new string[] { "Could not find a user with those credentials." });
            }
            else
            {
                AppUser.Current.Login(user);
                Response.Redirect("/");
            }
        }

    }
}