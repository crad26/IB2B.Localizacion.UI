using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;

namespace IB2B.Localizacion.UI.Helpers
{
    public static class ConvertHelpers
    {

        public static Object[] Obtener_Objecto_XML<T>(Expression<Func<T>> expr)
        {
            Object[] ObjA = new Object[2];
            var body = ((MemberExpression)expr.Body);
            ObjA[0] = body.Member.Name;
            Type t = ((Object)expr).GetType();
            System.Reflection.PropertyInfo[] props = t.GetProperties();
            Object obj = ((Object)expr).GetType().GetProperty(props[0].Name).GetValue(((Object)expr), null);

            string propertyName = body.Member.Name;
            T value = expr.Compile()();
            ObjA[1] = value;
            return ObjA;
        }

        public static StringBuilder Obtener_Cadena_XML(List<Object[]> vLValores, string CabeceraXML)
        {
            StringBuilder CadenaMXL = new StringBuilder();
            CadenaMXL.Append("");

            CadenaMXL.Append("<" + CabeceraXML + "><Root>");
            foreach (Object[] o in vLValores)
            {
                CadenaMXL.Append("<" + o[0].ToString() + ">");
                CadenaMXL.Append(Convert.ToString(o[1]));
                CadenaMXL.Append("</" + o[0].ToString() + ">");
            }
            CadenaMXL.Append("</Root></" + CabeceraXML + ">");

            return CadenaMXL;
        }

        public static StringBuilder Obtener_Cadena_Lista_XML(List<List<Object[]>> vLValores, string CabeceraXML)
        {
            StringBuilder CadenaMXL = new StringBuilder();
            CadenaMXL.Append("");

            CadenaMXL.Append("<Root>" );
            foreach (List<Object[]> o in vLValores)
            {
                CadenaMXL.Append("<" + CabeceraXML);
                foreach (Object[] o2 in o) {

                    CadenaMXL.Append(" " + o2[0].ToString() + "=");
                    CadenaMXL.Append("\"" + Convert.ToString(o2[1]) + "\""); 
                }
                CadenaMXL.Append( ">");
                CadenaMXL.Append("</" + CabeceraXML + ">");
            }
            CadenaMXL.Append("</Root>");

            return CadenaMXL;
        }

        public static String ConvertDicListToXML(List<Dictionary<string, string>> lst_dic, string pl, string sn)
        {
            String str = string.Empty;
            str += "<" + pl + ">";

            for (int i = 0; i < lst_dic.Count; i++)
            {
                str += "<" + sn + "><Root>";
                foreach (KeyValuePair<string, string> entry in lst_dic[i])
                    str += "<" + entry.Key + ">" + entry.Value + "</" + entry.Key + ">";
                str += "</Root></" + sn + ">";
            }
            str += "</" + pl + ">";
            return str.Trim();
        }
    }
}