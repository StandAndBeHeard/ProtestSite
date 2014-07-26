using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        PopulateFeatured();

    }

    private void PopulateFeatured()
    {
        StringBuilder sb = new StringBuilder();
        ProtestLib.Protests protests = ProtestLib.Protests.LoadActive();
        for (int i=0;i<protests.Count && i<20;i++)
        {
            ProtestLib.Protest p = protests[i];
            int displayPercent = Convert.ToInt32(System.Math.Round(p.CurrentParticipants * 100.0 / p.MinParticipants));
            int progessPercent = (displayPercent <= 100) ? displayPercent : 100;
            if (i%2 == 0) sb.Append("<div class=\"row margin-bottom-30\">");
            sb.Append("<div class=\"col-md-6\">");
            sb.Append("<a href=\"/demonstrations/" + p.Url + "\" style=\"text-decoration:none;display:block;\" class=\"service\">");
            sb.Append("<h3>" + p.Title + "</h3>");
            sb.Append("<p><i>" + p.Location + " - " + p.City + ", " + p.State + "</i></p>");
            sb.Append("<p style=\"height:60px;overflow:hidden;\">" + p.Description + "</p>");
            sb.Append("<div class=\"progress\" style=\"margin-bottom:5px;\"><div class=\"progress-bar progress-bar-success\" role=\"progressbar\" aria-valuenow=\"" + progessPercent.ToString() + "\" aria-valuemin=\"0\" aria-valuemax=\"100\" style=\"width: " + progessPercent + "%;\">" + displayPercent + "%</div></div>");
            sb.Append(p.CurrentParticipants.ToString() + " of " + p.MinParticipants.ToString() + " participants - " + displayPercent.ToString() + "% of goal");
            sb.Append("</a>");
            sb.Append("</div>");
            if (i % 2 == 1) sb.Append("</div>");
        }
        if (protests.Count % 2 == 1) sb.Append("</div>");
        if (protests.Count > 0)
        {
            FeaturedHolder.Visible = true;
            FeaturedLit.Text = sb.ToString();
        }
    }

}