using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MasterBase
/// </summary>
public class MasterBase : System.Web.UI.MasterPage
{

    public string PageName = "";
    public string[,] BreadCrumbSteps = { };

	public MasterBase()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}