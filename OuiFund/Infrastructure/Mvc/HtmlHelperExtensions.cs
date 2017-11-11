using OuiFund.Infrastructure.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace OuiFund.Infrastructure.Mvc
{
    public static class HtmlHelperExtensions
    {


        public static MvcHtmlString ActionLinkExtValorisation(this HtmlHelper html, string displayedValue, string action, string controller, int id)
        {
            //var autorisationService = DependencyResolver.Current.GetService<IAutorisationService>();
           // var idAutorisation = autorisationService.GetIdAutorisationByController(controller);
            var isAuthorized = SecurityHelper.IsAuthorized(1);
            return isAuthorized
                ? html.ActionLink(displayedValue, action, controller, new { area = "", id }, null)
                : MvcHtmlString.Empty;

        }

        public static MvcHtmlString ActionLinkExt(this HtmlHelper html, string displayedValue, string action, string controller, string area)
        {
            //var autorisationService = DependencyResolver.Current.GetService<IAutorisationService>();
            //var idAutorisation = autorisationService.GetIdAutorisationByController(controller);
            var isAuthorized = SecurityHelper.IsAuthorized(1);
            return isAuthorized
                ? html.ActionLink(displayedValue, action, controller, new { area }, null)
                : MvcHtmlString.Empty;

        }
    }
}