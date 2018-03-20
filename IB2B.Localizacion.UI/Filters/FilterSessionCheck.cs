using IB2B.Localizacion.BE.BE;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace IB2B.Localizacion.UI.Filters
{
    public class FilterSessionCheck : ActionFilterAttribute
    {
        public Boolean NotVerifyMethod { get; set; }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!NotVerifyMethod)
            {
                HttpSessionStateBase session = filterContext.HttpContext.Session;
                var user = session[Constantes.GrupoLocalizacion.UsuarioSesionId];
                if (user == null)
                {
                    session.RemoveAll();
                    session.Clear();
                    session.Abandon();
                    String vAccion = HttpContext.Current.Request.RequestContext.RouteData.Values["action"].ToString();
                    if (filterContext.HttpContext.Request.IsAjaxRequest())
                    {
                        if (vAccion != "_Session_Terminada")
                        {
                            filterContext.Result = new RedirectToRouteResult(
                                new RouteValueDictionary { 
                                                    { "controller", "Sistema" }, 
                                                    { "action", "_Session_Terminada" } 
                            }
                            );
                        }
                    }
                    else {
                        filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary { 
                                                                            { "controller", "Sistema" }, 
                                                                            { "action", "Login" },
                                                                            { "SessionExpired", "True" } 
                                                    }
                        );
                    } 
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}