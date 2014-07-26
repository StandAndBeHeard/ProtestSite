using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AppUser
/// </summary>
public class AppUser
{

    public ProtestLib.User User;
    public bool IsAuthenticated
    {
        get { return this.User != null; }
    }

	public AppUser()
	{
        
	}

    public static void RequireLogin()
    {
        HttpContext context = HttpContext.Current;
        
        if (!AppUser.Current.IsAuthenticated) context.Response.Redirect("/login.aspx?returnUrl=" + context.Server.UrlEncode(context.Request.Url.PathAndQuery) );
    }

    public void Login(ProtestLib.User user)
    {
        user.LastLoginDate = DateTime.Now;
        user.Save();
        AppUser au = AppUser.Current;
        au.User = user;
        AppUser.Current = au;
    }

    public static void Logout()
    {
        AppUser.Current = new AppUser();
    }

    public static AppUser Current
    {
        get
        {
            HttpContext context = HttpContext.Current;
            if (context.Session["AppUser"] == null) Current = new AppUser();
            return (AppUser)HttpContext.Current.Session["AppUser"];
        }
        set { HttpContext.Current.Session["AppUser"] = value; }
    }

}