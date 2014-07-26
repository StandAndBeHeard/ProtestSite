using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

/// <summary>
/// Summary description for GravatarHelper
/// </summary>
public class GravatarHelper
{
	public GravatarHelper()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static string GetGravatarUrl(string email)
    {
        MD5 md5Hasher = MD5.Create();
        byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(email));
        StringBuilder sBuilder = new StringBuilder();
        for (int i = 0; i < data.Length; i++) sBuilder.Append(data[i].ToString("x2"));
        return "http://www.gravatar.com/avatar/" + sBuilder.ToString();
    }

}