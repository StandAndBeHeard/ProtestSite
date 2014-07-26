using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditProfile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AppUser.RequireLogin();
        MasterBase master = (MasterBase)Page.Master;
        master.PageName = "Edit Profile";
        if (!IsPostBack) Populate();
    }

    private void Populate()
    {
        ProtestLib.User u = AppUser.Current.User;
        Email.Text = u.Email;
        ContactDemo.Checked = u.ContactDemonstrations;
        ContactOther.Checked = u.ContactOther;
    }

    public bool Validate()
    {
        List<string> errors = new List<string>();
        if (Password.Text != "")
        {
            if (Password.Text.Length < 8) errors.Add("Please choose a password that is at least 8 characters long.");
            if (VerifyPassword.Text != Password.Text) errors.Add("Passwords do not match.");
        }
        if (!System.Text.RegularExpressions.Regex.Match(Email.Text, @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}$").Success) errors.Add("Please enter a valid email address.");
        if (errors.Count != 0) ShowErrors(errors.ToArray());
        return errors.Count == 0;
    }

    private void ShowErrors(string[] errors)
    {
        ErrorHolder.Visible = true;
        ErrorLit.Text = "";
        foreach (string error in errors) ErrorLit.Text += "<li>" + error + "</li>";
    }

    protected void UpdateButton_Click(object sender, EventArgs e)
    {
        if (Validate())
        {
            ProtestLib.User user = AppUser.Current.User;
            user.ContactDemonstrations = ContactDemo.Checked;
            user.ContactOther = ContactOther.Checked;
            user.Email = Email.Text;
            if (Password.Text!="") user.PasswordHash = ProtestLib.Utils.HashAndSalt(Password.Text);
            user.Save();
            Response.Redirect("/");
        }
        
    }
}