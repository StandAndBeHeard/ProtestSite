using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

public partial class Demonstrations_Edit : System.Web.UI.Page
{
    ProtestLib.Protest protest = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        AppUser.RequireLogin();

        int id = Convert.ToInt32(Request["id"]);
        if (id == 0) protest = new ProtestLib.Protest();
        else protest = ProtestLib.Protest.Load(id);
        

        MasterBase master = (MasterBase)Page.Master;
        if (id == 0) master.PageName = "Create Demonstration"; else master.PageName = "Edit Demonstration";
        //master.BreadCrumbSteps = new string[,] { {"/demonstrations/", "Demonstrations"} };
        master.BreadCrumbSteps = new string[,] { { "/", "Demonstrations" } };
        Page.Title = master.PageName;

        if (!IsPostBack)
        {
            foreach (TimeZoneInfo timeZone in TimeZoneInfo.GetSystemTimeZones())
            {
                TimezoneList.Items.Add(new ListItem(timeZone.DisplayName, timeZone.Id));
                TimezoneList.SelectedValue = "Central Standard Time";
            }
            if (protest.Id>0) PopulateFields();
        }
    }

    private void PopulateFields()
    {
        AddressText.Text = protest.Address;
        AdditionalInfoText.Text = protest.Body;
        CityText.Text = protest.City;
        CountryText.Text = protest.Country;
        AboutText.Text = protest.Description;
        DisplayLocationText.Text = protest.Location;
        MinTurnoutText.Text = protest.MinParticipants.ToString();
        MinTurnoutText.Enabled = false;
        TimeZoneInfo tz = ProtestLib.Utils.GetTimezone(protest.Timezone);
        DateTime theDate = TimeZoneInfo.ConvertTimeFromUtc(protest.ProtestDate, tz);
        DateText.Text = theDate.ToString("yyyy-MM-dd");
        TimeText.Text = theDate.ToString("HH:mm:ss");
        StateText.Text = protest.State;
        DemonstrationNameText.Text = protest.Title;
        //protest.Url = 
        Website1Text.Text = protest.Website1;
        Website2Text.Text = protest.Website2;
        Website3Text.Text = protest.Website3;
        ZipText.Text = protest.Zip;

        if (protest.Id > 0) UpdateHolder.Visible = true;
    }

    

    public bool Validate()
    {
        List<string> errors = new List<string>();

        
        try
        {
            int participants = Convert.ToInt32(MinTurnoutText.Text);
            if (participants < 1) errors.Add("You must require at least 1 participant.");
        }
        catch { errors.Add("Enter a valid number for minimum number of paricipants."); }
        
        if (DemonstrationNameText.Text.Trim().Length < 10) errors.Add("Enter a name that is at least 10 characters long for your demonstration.");
        if (AboutText.Text.Trim().Length < 20) errors.Add("Enter at least a 20 character description for your demonstration.");
        if (AboutText.Text.Trim().Length > 1000) errors.Add("The description is too long.  Please use this field to provide a brief summary and provide the full details in the additional info field.");
        if (DisplayLocationText.Text.Trim()=="") errors.Add("Display location cannot be blank.");
        if (AddressText.Text.Trim() == "") errors.Add("Address cannot be blank.");
        if (CityText.Text.Trim() == "") errors.Add("City cannot be blank.");
        if (StateText.Text.Trim() == "") errors.Add("State cannot be blank.");
        if (ZipText.Text.Trim() == "") errors.Add("Zip cannot be blank.");
        if (CountryText.Text.Trim() == "") errors.Add("Country cannot be blank.");

        if (Website1Text.Text != "" && !Website1Text.Text.Contains("://")
            || Website2Text.Text != "" && !Website2Text.Text.Contains("://")
            || Website3Text.Text != "" && !Website3Text.Text.Contains("://")) errors.Add("Please enter full urls for websites. (http://www.example.com/)");
        try
        {
            DateTime theDate = Convert.ToDateTime(DateText.Text);
            try
            {
                theDate = Convert.ToDateTime(DateText.Text + " " + TimeText.Text + ProtestLib.Utils.GetTimezone(TimezoneList.Text).DisplayName.Split(')')[0].Replace("(UTC",""));
                if (theDate < DateTime.Now) errors.Add("The date cannot be in the past.");
                if (theDate > DateTime.Now.AddMonths(3)) errors.Add("The date cannot be more than 3 months out.");
            }
            catch { errors.Add("The time entered in invalid"); }
        }
        catch { errors.Add("The date entered is invalid"); }

        if (errors.Count != 0) ShowErrors(errors.ToArray());
        return errors.Count == 0;
    }

    private void ShowErrors(string[] errors)
    {
        ErrorHolder.Visible = true;
        ErrorLit.Text = "";
        foreach (string error in errors) ErrorLit.Text += "<li>" + error + "</li>";
    }

    protected void SaveButton_Click(object sender, EventArgs e)
    {
        if (Validate())
        {
            protest.Address = AddressText.Text;
            protest.Body = AdditionalInfoText.Text;
            protest.City = CityText.Text;
            protest.Country = CountryText.Text;
            protest.Description = AboutText.Text;
            protest.Location = DisplayLocationText.Text;
            protest.OrganizerId = AppUser.Current.User.Id;
            protest.ProtestDate = GetUtcTime();
            protest.CutoffDate = protest.ProtestDate.AddDays(-1);
            protest.State = StateText.Text;
            protest.Title = DemonstrationNameText.Text;
            protest.Timezone = TimezoneList.SelectedValue;
            protest.Website1 = Website1Text.Text;
            protest.Website2 = Website2Text.Text;
            protest.Website3 = Website3Text.Text;
            protest.Zip = ZipText.Text;
            if (protest.Id == 0)
            {
                protest.CurrentParticipants = 0;
                protest.MinParticipants = Convert.ToInt32(MinTurnoutText.Text);
                protest.Status = ProtestLib.ProtestStatus.Open;
                protest.CreationDate = DateTime.UtcNow;
            }

            SetLatLon();

            protest.Save();

            if (protest.IsUrlNull)
            {
                protest.Url = ProtestLib.Utils.GenerateUrl(protest.Title + " " + protest.Id);
                ProtestLib.Participant.Join(AppUser.Current.User.Id, protest);

                ProtestLib.ProtestUpdate update = new ProtestLib.ProtestUpdate();
                update.Body = "Demonstration created.";
                update.ProtestId = protest.Id;
                update.Save();
            }

            Response.Redirect("/demonstrations/" + protest.Url);
        }
     }

    protected void UpdateButton_Click(object sender, EventArgs e)
    {
        ProtestLib.ProtestUpdate update = new ProtestLib.ProtestUpdate();
        update.Body = UpdateBody.Text;
        update.PostedDate = DateTime.UtcNow;
        update.ProtestId = protest.Id;
        update.Save();
        update.CreateNotifications(protest);
        Response.Redirect("/demonstrations/" + protest.Url);
    }

    private DateTime GetUtcTime()
    {
        TimeZoneInfo tz = ProtestLib.Utils.GetTimezone(TimezoneList.Text);
        string timeString = DateText.Text + " " + TimeText.Text + tz.DisplayName.Split(')')[0].Replace("(UTC", "");
        DateTime result = Convert.ToDateTime(timeString);
        if (tz.IsDaylightSavingTime(result)) result = result.AddHours(-1);
        return result.ToUniversalTime();
    }

    private void SetLatLon()
    {
        try
        {
            string url = "https://maps.googleapis.com/maps/api/geocode/json?address=" + Server.UrlEncode(protest.Address + ", " + protest.City + ", " + protest.State + " " + protest.Zip);
            string json = ProtestLib.Utils.GetUrlContents(url);
            Hashtable data = (Hashtable)ProtestLib.JSON.JsonDecode(json);
            ArrayList results = (ArrayList)(data)["results"];
            Hashtable geometry = (Hashtable)((Hashtable)results[0])["geometry"];
            Hashtable location = (Hashtable)geometry["location"];
            protest.Latitude = Convert.ToDouble(location["lat"]);
            protest.Longitude = Convert.ToDouble(location["lng"]);
        }
        catch { }
    }

}