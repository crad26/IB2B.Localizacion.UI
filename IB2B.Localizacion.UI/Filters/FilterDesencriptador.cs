using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace IB2B.Localizacion.UI.Filters
{
    public class FilterDesencriptador : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            int Id;
            try
            {
                Dictionary<string, object> decryptedParameters = new Dictionary<string, object>();
                if (HttpContext.Current.Request.QueryString.Get("q") != null)
                {

                    string encryptedQueryString = HttpContext.Current.Request.QueryString.Get("q");
                    encryptedQueryString = encryptedQueryString.Replace(" ", "+");
                    string decrptedString = Decrypt(encryptedQueryString.ToString());
                    string[] paramsArrs = decrptedString.Split('?');

                    for (int i = 0; i < paramsArrs.Length; i++)
                    {
                        string[] paramArr = paramsArrs[i].Split('=');
                        decryptedParameters.Add(paramArr[0],  paramArr[1]);
                    }
                }
                else if (!HttpContext.Current.Request.Url.ToString().Contains("?"))
                {
                    if (int.TryParse(Decrypt(HttpContext.Current.Request.Url.ToString().Split('/').Last()), out Id))
                    {
                        string id = Id.ToString();
                        decryptedParameters.Add("id", id);
                    }
                }
                else if (HttpContext.Current.Request.Url.ToString().Contains("?"))
                {
                    if (int.TryParse(Decrypt(HttpContext.Current.Request.Url.ToString().Split('/').Last().Split('?')[0]), out Id))
                    {
                        string id = Id.ToString();
                        if (id.Contains('?'))
                        {
                            id = id.Split('?')[0];
                        }
                        decryptedParameters.Add("id", id);
                    }

                    string[] paramsArrs = HttpContext.Current.Request.Url.ToString().Split('/').Last().Split('?');
                    for (int i = 1; i < paramsArrs.Length; i++)
                    {
                        string[] paramArr = paramsArrs[i].Split('=');
                        decryptedParameters.Add(paramArr[0], Convert.ToInt32(paramArr[1]));
                    }
                }

                for (int i = 0; i < decryptedParameters.Count; i++)
                {
                    filterContext.ActionParameters[decryptedParameters.Keys.ElementAt(i)] = decryptedParameters.Values.ElementAt(i);
                }
            }
            catch (Exception ex)
            { 
            
            }
            base.OnActionExecuting(filterContext);

        }

        private string Decrypt(string encryptedText)
        {

            string key = ConfigurationManager.AppSettings["DesLlave"].ToString();
            byte[] DecryptKey = { };
            byte[] IV = { 55, 34, 87, 64, 87, 195, 54, 21 };
            byte[] inputByte = new byte[encryptedText.Length];

            DecryptKey = System.Text.Encoding.UTF8.GetBytes(key.Substring(0, 8));
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            inputByte = Convert.FromBase64String(encryptedText);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(DecryptKey, IV), CryptoStreamMode.Write);
            cs.Write(inputByte, 0, inputByte.Length);
            cs.FlushFinalBlock();
            System.Text.Encoding encoding = System.Text.Encoding.UTF8;
            return encoding.GetString(ms.ToArray());
        }
    }
}