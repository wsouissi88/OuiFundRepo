using OuiFund.Domain;
using OuiFund.Models;
using OuiFund.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OuiFund.Controllers
{
  
    public class HomeController : Controller
    {
        private IUserService _userSerice { get; set; }

        public HomeController(IUserService userService)
        {
            //test
            _userSerice = userService;
        }
        public ActionResult Index()
        {
            return View(new HomeViewModel { Users = _userSerice.GetAll() });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(HomeViewModel model)
        {
            _userSerice.Create(model.User);
            model.Users = _userSerice.GetAll();
            model.User = null;
            return View(model);
        }

    }
}