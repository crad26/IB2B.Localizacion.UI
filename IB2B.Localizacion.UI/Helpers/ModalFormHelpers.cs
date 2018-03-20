using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Linq.Expressions;
using System.Web.Mvc.Html;
using System.Web.Mvc.Ajax;


namespace IB2B.Localizacion.UI.Helpers
{
    public class ModalFormHelpers
    {
        public String ActionName { get; set; }
        public String ControllerName { get; set; }
        public object RouteValues { get; set; }
        public FormMethod Method { get; set; }
        public object HtmlAttributes { get; set; }
        private String _guid = System.Guid.NewGuid().ToString();

        public String Guid
        {
            get { return _guid; }
        }

        public ModalFormHelpers()
        {
        }

        public ModalFormHelpers(object routeValues)
        {
            RouteValues = routeValues;
        }

        public ModalFormHelpers(string actionName, string controllerName)
        {
            ActionName = actionName;
            ControllerName = controllerName;
        }

        public ModalFormHelpers(string actionName, string controllerName, FormMethod method)
        {
            ActionName = actionName;
            ControllerName = controllerName;
            Method = method;
        }

        public ModalFormHelpers(string actionName, string controllerName, object routeValues)
        {
            ActionName = actionName;
            ControllerName = controllerName;
            RouteValues = routeValues;
        }

        public ModalFormHelpers(string actionName, string controllerName, FormMethod method, object htmlAttributes)
        {
            ActionName = actionName;
            ControllerName = controllerName;
            Method = method;
            HtmlAttributes = htmlAttributes;
        }

        public ModalFormHelpers(string actionName, string controllerName, object routeValues, FormMethod method)
        {

            ActionName = actionName;
            ControllerName = controllerName;
            RouteValues = routeValues;
            Method = method;
        }

        public ModalFormHelpers(string actionName, string controllerName, object routeValues, FormMethod method, object htmlAttributes)
        {
            ActionName = actionName;
            ControllerName = controllerName;
            RouteValues = routeValues;
            Method = method;
            HtmlAttributes = htmlAttributes;
        }

        public MvcForm BeginForm(HtmlHelper htmlHelper)
        {
            var htmlAttributes = new RouteValueDictionary(HtmlAttributes);

            if (htmlAttributes.ContainsKey("style"))
                htmlAttributes["style"] = "margin:0;" + htmlAttributes["style"];
            else
                htmlAttributes["style"] = "margin:0;";

            htmlAttributes["data-guid"] = Guid;

            return htmlHelper.BeginForm(ActionName, ControllerName, new RouteValueDictionary(RouteValues), Method, htmlAttributes);
        }
    }

    public class ModalAjaxFormHelpers
    {
        public String ActionName { get; set; }
        public String ControllerName { get; set; }
        public object RouteValues { get; set; }
        public AjaxOptions AjaxOptions { get; set; }
        public object HtmlAttributes { get; set; }

        public ModalAjaxFormHelpers(AjaxOptions ajaxOptions)
        {
            AjaxOptions = ajaxOptions;
        }

        public ModalAjaxFormHelpers(object routeValues, AjaxOptions ajaxOptions)
        {
            RouteValues = routeValues;
            AjaxOptions = ajaxOptions;
        }

        public ModalAjaxFormHelpers(string actionName, string controllerName, AjaxOptions ajaxOptions)
        {
            ActionName = actionName;
            ControllerName = controllerName;
            AjaxOptions = ajaxOptions;
        }


        public ModalAjaxFormHelpers(string actionName, string controllerName, object routeValues, AjaxOptions ajaxOptions)
        {
            ActionName = actionName;
            ControllerName = controllerName;
            RouteValues = routeValues;
            AjaxOptions = ajaxOptions;
        }

        public ModalAjaxFormHelpers(string actionName, string controllerName, AjaxOptions ajaxOptions, object htmlAttributes)
        {
            ActionName = actionName;
            ControllerName = controllerName;
            HtmlAttributes = htmlAttributes;
            AjaxOptions = ajaxOptions;
        }

        public MvcForm BeginForm(AjaxHelper ajaxHelper)
        {
            return ajaxHelper.BeginForm(ActionName, ControllerName, RouteValues, AjaxOptions, HtmlAttributes);
        }
    }
}





















