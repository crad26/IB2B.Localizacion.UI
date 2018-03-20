using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IB2B.Localizacion.UI.Helpers
{
    public class FaceBookHelper
    {
        //private void CheckAuthorization()
        //{
        //    string app_id = "142783116244349";
        //    string app_secret = "47b80520464639d399ba05301d25b9a3";
        //    string scope = "publish_actions,manage_pages";

        //    if (Request["code"] == null)
        //    {
        //        Response.Redirect(string.Format(
        //            "https://graph.facebook.com/oauth/authorize?client_id={0}&redirect_uri={1}&scope={2}",
        //            app_id, Request.Url.AbsoluteUri, scope));
        //    }
        //    else
        //    {
        //        Dictionary<string, string> tokens = new Dictionary<string, string>();

        //        string url = string.Format("https://graph.facebook.com/oauth/access_token?client_id={0}&redirect_uri={1}&scope={2}&code={3}&client_secret={4}",
        //            app_id, Request.Url.AbsoluteUri, scope, Request["code"].ToString(), app_secret);

        //        HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;

        //        using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
        //        {
        //            StreamReader reader = new StreamReader(response.GetResponseStream());

        //            string vals = reader.ReadToEnd();

        //            foreach (string token in vals.Split('&'))
        //            {
        //                //meh.aspx?token1=steve&token2=jake&...
        //                tokens.Add(token.Substring(0, token.IndexOf("=")),
        //                    token.Substring(token.IndexOf("=") + 1, token.Length - token.IndexOf("=") - 1));
        //            }
        //        }

        //        string access_token = tokens["access_token"];

        //        var client = new FacebookClient(access_token);

        //        client.Post("/me/feed", new { message = "Publicando desde MVC" });
        //    }
        //}
    }
}