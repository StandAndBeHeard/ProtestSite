using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Utils
/// </summary>
public class Utils
{
	public Utils()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public static string GetIPAddress()
    {
        return System.Web.HttpContext.Current.Request.UserHostAddress;
    }

}