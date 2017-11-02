using OuiFund.Domain;
using OuiFund.Models;
using OuiFund.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OuiFund.Controllers
{

    public class HomeController : Controller
    {
        private IUserService _userService { get; set; }

        public HomeController(IUserService userService)
        {
            _userService = userService;

            ViewBag.account = _userService.countUsers();
            ViewBag.adherent = _userService.countAdherents();
            ViewBag.client = _userService.countClients();
            ViewBag.active = _userService.countActive();
        }
        public ActionResult Index()
        {
            return View(new HomeViewModel { Users = _userService.GetAll() });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(HomeViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.User.ActiveUser = true;
                _userService.Create(model.User);
                model.Users = _userService.GetAll();
                model.User = null;
                return RedirectToAction("Questionnaire", "Question");
            }
            else
            {
                return View();
            }

        }

        public ActionResult Users()
        {
            var users = _userService.GetAll();
            return View(users);
        }

        [HttpGet]
        public ActionResult Delete(int userId)
        {
            var user = _userService.getUserById(userId);

            return View(user);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int userId)
        {
            var user = _userService.getUserById(userId);

            _userService.supprimerUser(user);
            return RedirectToAction("Users");
        }
    }
}