using OuiFund.Domain;
using OuiFund.Domain.Model;
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
        private IAdherentService _adhService { get; set; }
        private IDossierService _dossService { get; set; }
        private IStartupService _strService { get; set; }

        public HomeController(IUserService userService, IAdherentService adService, IStartupService stService,
                                IDossierService dService)
        {
            _userService = userService;
            _adhService = adService;
            _strService = stService;
            _dossService = dService;

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

        public ActionResult RegisterAdherent()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterAdherent(Adherent adherent)
        {
            if (ModelState.IsValid)
            {
                adherent.dossierAdherent = new Dossier()
                {
                    StatusDossier = "Dossier en lancement",
                    ReferenceDossier = "AdherentStartUp",
                    startupDossier = new StartUp()
                    {
                        NomStartup = "OuiCloud",
                        CreationStartup = DateTime.Now
                    }
                };

                // get user by email 
                adherent.UtilisateurID = 1;
                //_strService.ajouterStartup(s);
                //_dossService.ajouterDossier(d);                
                adherent.ActiveUser = true;
                _adhService.registerAdherent(adherent);
            }
            return View();
        }
    }
}