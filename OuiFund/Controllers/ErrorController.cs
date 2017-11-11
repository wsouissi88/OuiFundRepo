using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OuiFund.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index()
        {
            TempData["Menu"] = "Home";
            Session.Clear();
            return View();
        }

        public ActionResult Permission(string controllerName, string actionName)
        {
            TempData["Menu"] = "Home";
            Session.Clear();
            ViewData["controllerName"] = controllerName ?? string.Empty;
            ViewData["actionName"] = actionName ?? string.Empty;
            return View();
        }
    }
}