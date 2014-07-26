using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MasterBase master = (MasterBase)Page.Master;
        master.PageName = "Register";
    }

    public bool Validate()
    {
        List<string> errors = new List<string>();
        if (UserName.Text.Trim().Length < 3) errors.Add("Please choose a username that is at least 3 characters long.");
        if (Password.Text.Length < 8) errors.Add("Please choose a password that is at least 8 characters long.");
        if (VerifyPassword.Text != Password.Text) errors.Add("Passwords do not match.");
        if (!System.Text.RegularExpressions.Regex.Match(Email.Text, @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}$").Success) errors.Add("Please enter a valid email address.");
        if (!Terms.Checked) errors.Add("You must agree to the Terms and Conditions.");

        if (errors.Count != 0) ShowErrors(errors.ToArray());
        return errors.Count == 0;
    }

    private void ShowErrors(string[] errors)
    {
        ErrorHolder.Visible = true;
        ErrorLit.Text = "";
        foreach (string error in errors) ErrorLit.Text += "<li>" + error + "</li>";
    }

    protected void RegisterButton_Click(object sender, EventArgs e)
    {
        if (Validate())
        {
            ProtestLib.User user = new ProtestLib.User();
            user.ContactDemonstrations = ContactDemo.Checked;
            user.ContactOther = ContactOther.Checked;
            user.Email = Email.Text;
            user.PasswordHash = ProtestLib.Utils.HashAndSalt(Password.Text);
            user.RegistrationDate = DateTime.Now;
            user.LastLoginDate = DateTime.Now;
            user.UserName = UserName.Text;
            user.Save();
            AppUser.Current.Login(user);
            Response.Redirect("/");
        }
    }
}