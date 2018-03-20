using IB2B.Localizacion.BE.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Xml.Linq;

namespace IB2B.Localizacion.UI.Filters
{
    public class FilterAccessCheck : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var sUrlActual = "/";
            var routeValues = HttpContext.Current.Request.RequestContext.RouteData.Values;

            List<MenuBE> LMenu = (List<MenuBE>)filterContext.HttpContext.Session[Constantes.GrupoLocalizacion.Menu];

            if (routeValues != null && filterContext.HttpContext.Session[Constantes.GrupoLocalizacion.Menu] != null)
            {
                if (filterContext.HttpContext.Request.HttpMethod == "GET")
                {
                    if (routeValues.ContainsKey("controller") && routeValues.ContainsKey("action"))
                    {

                        String vController = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
                        String vAccion = HttpContext.Current.Request.RequestContext.RouteData.Values["action"].ToString();
                        String vParametros = filterContext.HttpContext.Request.QueryString.ToString();

                        sUrlActual = "/"+vController + "/" + vAccion;

                        Boolean resultado = (  // Aqui Iran los Formularios que no pertenecen al menu pero que deben mostrarse, Generalmente seran los Partial View
                                sUrlActual.Contains("Sistema/Inicio") ||
                                sUrlActual.Contains("Sistema/LogOff") ||
                                sUrlActual.Contains("Sistema/_Session_Terminada") ||
                                sUrlActual.Contains("DocumentoElectronico/EnviarEmailClienteDocumentoElectronico") ||
                                sUrlActual.Contains("DocumentoElectronico/ProcesarDocumentosNotaCreditoDebito") ||
                                sUrlActual.Contains("DocumentoElectronico/ListaNotaCreditoDebitoCriterio") ||
                                sUrlActual.Contains("DocumentoElectronico/_Buscar_DocumentosElectronicos_ResumenComunicacionBaja") ||
                                sUrlActual.Contains("DocumentoElectronico/VisualizarNotificacion")
                                
                                );
                        if (!resultado)
                        {
                            if (GetExpectedReturnType(filterContext).Name == "ActionResult")
                            {
                                foreach(MenuBE oMenu in LMenu)
                                {
                                    String vValorOriginal = oMenu.Html_Mnu;
                                    oMenu.Url = XElement.Parse("<th>" + vValorOriginal + "</th>")
                                               .Descendants("a")
                                               .Select(x => x.Attribute("href").Value)
                                               .FirstOrDefault();
                                }
                                var vlFiltrado = LMenu.FindAll(x => x.Url == sUrlActual);

                                if (vlFiltrado.Count == 0)
                                {
                                    
                                        filterContext.Result = new RedirectToRouteResult(
                                                                new RouteValueDictionary 
                                                    { 
                                                        { "controller", "Sistema" }, 
                                                        { "action", "Inicio" } 
                                                    });
                                }
                            }
                        }

                    }
                }
            }
        }

        private Type GetExpectedReturnType(ActionExecutingContext filterContext)
        {
            Type controllerType = filterContext.Controller.GetType();
            string actionName = filterContext.ActionDescriptor.ActionName;
            MethodInfo actionMethodInfo = default(MethodInfo);

            try
            {
                System.Reflection.MethodInfo[] matchedMethods = controllerType.GetMethods(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public)
                .Where(m => m.Name == actionName).ToArray<System.Reflection.MethodInfo>();

                if (matchedMethods.Length > 1)
                {
                    foreach (System.Reflection.MethodInfo methodInfo in matchedMethods)
                    {
                            actionMethodInfo = methodInfo;
                            break;
                    }
                }
                else
                {
                    actionMethodInfo = controllerType.GetMethod(actionName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                }
            }
            catch (AmbiguousMatchException ex)
            {
                var actionParams = filterContext.ActionParameters;
                List<Type> paramTypes = new List<Type>();
                foreach (var p in actionParams)
                {
                    paramTypes.Add(p.Value.GetType());
                }
                actionMethodInfo = controllerType.GetMethod(actionName, paramTypes.ToArray());
            }

            return actionMethodInfo.ReturnType;
        }
    }
}