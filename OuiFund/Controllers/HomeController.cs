﻿using OuiFund.Domain;
using OuiFund.Domain.Model;
using OuiFund.Infrastructure.Mvc;
using OuiFund.Models;
using OuiFund.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OuiFund.Controllers
{

    public class HomeController : BaseController
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
        [Authorize(Roles ="Utilisateur")]
        public ActionResult Index(HomeViewModel model)
        {
            if (ModelState.IsValid)
            {
                User u = _userService.getUserByEmail(model.User.AdresseEmail);
                if(u == null)
                {
                    model.User.ActiveUser = true;
                    _userService.Create(model.User);
                    model.Users = _userService.GetAll();
                    model.User = null;
                    return RedirectToAction("Questionnaire", "Question");
                }
                else
                {
                    ViewBag.Msg = "Votre Email Existe déjà, Veuillez Saisir un autre";
                    return View();
                }
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
        public ActionResult Adherents()
        {
            var users = _adhService.getAdherents();
            return View(users);
        }

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
                adherent.DateNaissance = DateTime.Now;
                adherent.AdresseEmail = "mail@mail.com";
                adherent.Password = "aaaa";
                adherent.ActiveUser = true;
                _adhService.registerAdherent(adherent);
            }
            return View();
        }        
    }
}