using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Core_R47.Filters
{
    public class HeaderAttribute : ActionFilterAttribute
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (!string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Value))
                filterContext.HttpContext.Response.Headers.Add(Name, Value);
            return;
        }
    }
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class CultureAttribute : ActionFilterAttribute
    {
        public string Name { get; set; }
        string a;
        public static string CookieName
        {
            get { return "_Culture"; }
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var culture = Name;

            if (string.IsNullOrEmpty(culture))
                culture = GetSavedCultureOrDefault(filterContext.HttpContext.Request);
            // Set culture on current thread
            a = SetCultureOnThread(culture);

            // Proceed as usual
            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (!string.IsNullOrEmpty(Name))
            {
                filterContext.HttpContext.Response.Headers.Add(Name, a);
            }
        }
        private static string GetSavedCultureOrDefault(HttpRequest httpRequest)
        {
            var culture = CultureInfo.CurrentCulture.Name;
            var cookie = httpRequest.Cookies[CookieName] ?? culture;
            return culture;
        }
        private static string SetCultureOnThread(string language)
        {
            var cultureInfo = new CultureInfo(language);
            CultureInfo.CurrentCulture = cultureInfo;
            CultureInfo.CurrentUICulture = cultureInfo;
            return string.Format("Culture: {0}", cultureInfo);
        }
    }
    public static class HttpRequestExtensions
    {
        public static bool IsAjaxRequest(this HttpRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");
            if (request.Headers != null)
                return request.Headers["X-Requested-With"] == "XMLHttpRequest";
            return false;
        }
    }
    //ActionMethodSelectorAttribute: conditional logic to enable or disable an action
    public class AjaxOnlyAttribute : ActionMethodSelectorAttribute
    {
        public override bool IsValidForRequest(RouteContext routeContext, ActionDescriptor action)
        {
            return routeContext.HttpContext.Request.IsAjaxRequest();
        }
    }

}
