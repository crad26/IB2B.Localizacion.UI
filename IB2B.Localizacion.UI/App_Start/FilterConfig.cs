using System.Web;
using System.Web.Mvc;

namespace IB2B.Localizacion.UI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new Filters.FilterSessionCheck());
            //filters.Add(new Filters.FilterAccessCheck());
            filters.Add(new Filters.FilterDesencriptador());
        }
    }
}
