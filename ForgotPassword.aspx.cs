using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ForgotPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MasterBase master = (MasterBase)Page.Master;
        master.PageName = "Forgot Password";
    }

    private void ResetPassword(ProtestLib.User user)
    {
        System.Random rnd = new System.Random();
        string password = rnd.Next(999999999).ToString();
        user.PasswordHash = ProtestLib.Utils.HashAndSalt(password);
        user.Save();
        ProtestLib.Notification n = new ProtestLib.Notification();
        n.Body = "Your temporary password is " + password + ". Please login and change it.";
        n.CreationDate = DateTime.UtcNow;
        n.Link = System.Configuration.ConfigurationManager.AppSettings["BaseUrl"] + "/editprofile.aspx";
        n.Title = "Your Password Has Been Reset.";
        n.UserId = user.Id;
        n.Save();
        ShowErrors(new string[] { "Password has been reset and emailed to you.  It may take up to 5 minutes to deliver the message." });
    }

    protected void Reset1Button_Click(object sender, EventArgs e)
    {
        string error = "";
        if (UserName.Text == "") error = "User name cannot be blank.";
        ProtestLib.User user = ProtestLib.User.Load(UserName.Text, "");
        if (user == null) error = "Could not find a user with this name.";
        if (error != "") ShowErrors(new string[] { error });
        else ResetPassword(user);
    }

    protected void Reset2Button_Click(object sender, EventArgs e)
    {
        string error = "";
        if (Email.Text == "") error = "Email cannot be blank.";
        ProtestLib.User user = ProtestLib.User.Load("", Email.Text);
        if (user == null) error = "Could not find a user with this email.";
        if (error != "") ShowErrors(new string[] { error });
        else ResetPassword(user);
    }

    private void ShowErrors(string[] errors)
    {
        ErrorHolder.Visible = true;
        ErrorLit.Text = "";
        foreach (string error in errors) ErrorLit.Text += "<li>" + error + "</li>";
    }



}