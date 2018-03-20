using IB2B.Localizacion.BE.BE;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace IB2B.Localizacion.UI.Helpers
{
    public static class HtmlExtensionHelpers
    {
        public static MvcHtmlString ESMenu(this HtmlHelper htmlHelper, List<MenuBE> lMenu)
        {
            String html = String.Empty;
        //    lMenu = lMenu.FindAll(x => x.Visible_Mnu == 1);
        //    if (lMenu != null)
        //    {
        //        var listMenu = lMenu;
        //        //var oMenuPrincipal = listMenu.Find(x => (x.Padre_Mnu == 0));
        //        foreach (var oMenuModel1 in listMenu.FindAll(x => x.Padre_Mnu == 0))
        //        {
        //            var listMenu2 = listMenu.FindAll(x => x.Padre_Mnu == oMenuModel1.MenuId);
        //            html += "<li class=\"treeview\">";
        //            html += oMenuModel1.Html_Mnu;
        //            if (listMenu2.Count > 0)
        //            {
        //                html += "<ul class=\"treeview-menu\">";
        //                foreach (var oMenuModel2 in listMenu2)
        //                {
        //                    var listMenu3 = listMenu.FindAll(x => x.Padre_Mnu == oMenuModel2.MenuId);
        //                    html += "<li>";
        //                    html += oMenuModel2.Html_Mnu;
        //                    if (listMenu3.Count > 0)
        //                    {
        //                        html += "<ul class=\"treeview-menu\">";
        //                        foreach (var oMenuModel3 in listMenu3)
        //                        {
        //                            html += "<li>";
        //                            html += oMenuModel3.Html_Mnu;
        //                            html += "</li>";
        //                        }
        //                        html += "</ul>";
        //                    }

        //                    html += "</li>";
        //                }
        //                html += "</ul>";
        //            }

        //            html += "</li>";
        //        }
        //    }
            return new MvcHtmlString(html);
        }

        private static string Encrypt(string plainText)
        {
            string key = ConfigurationManager.AppSettings["DesLlave"].ToString();
            byte[] EncryptKey = { };
            byte[] IV = { 55, 34, 87, 64, 87, 195, 54, 21 };
            EncryptKey = System.Text.Encoding.UTF8.GetBytes(key.Substring(0, 8));
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByte = Encoding.UTF8.GetBytes(plainText);
            MemoryStream mStream = new MemoryStream();
            CryptoStream cStream = new CryptoStream(mStream, des.CreateEncryptor(EncryptKey, IV), CryptoStreamMode.Write);
            cStream.Write(inputByte, 0, inputByte.Length);
            cStream.FlushFinalBlock();
            return Convert.ToBase64String(mStream.ToArray());
        }
        public static MvcHtmlString UrlEncodedActionLink(this HtmlHelper htmlHelper, string Action, string ControllerName, object routeValues)
        {
            string queryString = string.Empty;
            string htmlAttributesString = string.Empty;
            bool IsRoute = false;
            if (routeValues != null)
            {
                RouteValueDictionary d = new RouteValueDictionary(routeValues);
                for (int i = 0; i < d.Keys.Count; i++)
                {
                    if (!d.Keys.Contains("IsRoute"))
                    {
                        if (i > 0)
                        {
                            queryString += "?";
                        }
                        queryString += d.Keys.ElementAt(i) + "=" + d.Values.ElementAt(i);
                    }
                    else
                    {
                        if (!d.Keys.ElementAt(i).Contains("IsRoute"))
                        {
                            queryString += d.Values.ElementAt(i);
                            IsRoute = true;
                        }
                    }
                }
            }

            StringBuilder ancor = new StringBuilder();

            if (ControllerName != string.Empty)
            {
                ancor.Append("/" + ControllerName);
            }

            if (Action != "Index")
            {
                ancor.Append("/" + Action);
            }
            if (queryString != string.Empty)
            {
                if (IsRoute == false)
                    ancor.Append("?q=" + Encrypt(queryString));
                else
                    ancor.Append("/" + Encrypt(queryString));
            }
            return new MvcHtmlString(ancor.ToString());
        }
    }
}
