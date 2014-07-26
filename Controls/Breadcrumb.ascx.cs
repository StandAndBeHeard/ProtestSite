using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_BreadCrumb : System.Web.UI.UserControl
{

    protected void Page_Load(object sender, EventArgs e)
    {
        MasterBase master = (MasterBase)Page.Master;
        OutputLit.Text = "";
        if (master.BreadCrumbSteps.Length>0)
        {
            for (int i = 0; i < master.BreadCrumbSteps.GetLength(0);i++ )
            {
                OutputLit.Text += "<li><a href=\"" + master.BreadCrumbSteps[i, 0] + "\">" + master.BreadCrumbSteps[i, 1] + "</a></li>";
            }
        }
        OutputLit.Text += "<li class=\"active\">" + master.PageName + "</li>";
        PageNameLit.Text = master.PageName;
    }

}