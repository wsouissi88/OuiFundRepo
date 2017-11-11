using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security;
using OuiFund.Infrastructure.Security;

namespace OuiFund.Infrastructure.Mvc
{
    [Authorize]
    public class BaseController : Controller
    {
        //private readonly IAutorisationService _autorisationService;
        public BaseController()
        {
           // _autorisationService = DependencyResolver.Current.GetService<IAutorisationService>();
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {

                if (!IsAuthorized(filterContext.ActionDescriptor.ControllerDescriptor.ControllerName))
                {

                    throw new SecurityException("Pas autorisé; \r\n" +
                                                System.Web.HttpContext.Current.Request.Url.AbsolutePath);


                }

                base.OnActionExecuting(filterContext);
            }
            catch (SecurityException)
            {

                if (filterContext.RequestContext != null)
                {
                    HttpContext.Server.ClearError();

                    filterContext.Result = new RedirectResult(new UrlHelper(filterContext.RequestContext).Action("Permission", "Error", new
                    {
                        controllerName = filterContext.ActionDescriptor.ControllerDescriptor.
                                ControllerName,
                        actionName = filterContext.ActionDescriptor.ActionName,
                        area = string.Empty
                    }));
                }
            }


        }


        private bool IsAuthorized(string controllerName)
        {
            //var idAutorisation = _autorisationService.GetIdAutorisationByController(controllerName);
            return SecurityHelper.IsAuthorized(1);
        }
    }
}