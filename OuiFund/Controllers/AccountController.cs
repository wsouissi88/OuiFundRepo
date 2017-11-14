using System;
using System.Security.Claims;
using System.Web.Security;
using System.Web;
using System.Web.Mvc;
using OuiFund.Models;
using OuiFund.Services.IServices;
using System.Configuration;
using OuiFund.Domain.Model;

namespace OuiFund.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {


        private readonly IUserService _userService;
        private readonly IEncryptionService _encryptionService;

        public AccountController(IUserService userService, IEncryptionService encryptionService)
        {

            _userService = userService;
            _encryptionService = encryptionService;
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var booleanTemp = model.RememberMe;
            
            var encryptationKey = ConfigurationManager.AppSettings["EncryptationKey"];
            var encryptationIv = ConfigurationManager.AppSettings["EncryptationIv"];
            model.Password = _encryptionService.Encrypt(model.Password, encryptationKey, encryptationIv);
            
            var user = _userService.GetByCodeAndPassword(model.Email, model.Password);

            //Roles Utilisateurs

            if (user != null)
            {
                SignIn(user, booleanTemp, HttpContext);
                ViewBag.UserName = user.AdresseEmail;
                return RedirectToLocal();
            }

            ModelState.AddModelError("", "Tentative de connexion non valide.");
            return View(model);
        }
        private ActionResult RedirectToLocal()
        {
            return RedirectToAction("Index", "Home");
        }

        public void SignIn(User user, bool createPersistentCookie, HttpContextBase context)
        {

            // external users have read/write rights
            FormsAuthentication.SetAuthCookie(user.AdresseEmail, false);
            var expirationDate = DateTime.Now.AddDays(1);

            var ticket = new FormsAuthenticationTicket(1, user.AdresseEmail, DateTime.Now, expirationDate,
                                                     createPersistentCookie, 1 + "," + user.UtilisateurID.ToString() + "," + user.AdresseEmail.ToString() ,// + "," + user.FirstName + "," + user.LastName,
                                                     FormsAuthentication.FormsCookiePath);

            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket)) { Expires = ticket.Expiration };
            cookie.Expires = ticket.Expiration;
            context.Response.Cookies.Add(cookie);
        }

        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var encryptationKey = ConfigurationManager.AppSettings["EncryptationKey"];
                var encryptationIv = ConfigurationManager.AppSettings["EncryptationIv"];
                var password = _encryptionService.Encrypt(model.Password, encryptationKey, encryptationIv);
                var user = new User { AdresseEmail = model.Email, Password = password };
                 _userService.Create(user);
                 user = _userService.GetByCodeAndPassword(model.Email, password);
                if (user != null)
                {
                    SignIn(user, false, HttpContext);
                    return RedirectToAction("Index", "Home");
                }
                
            }
            ModelState.AddModelError("", "Tentative de connexion non valide.");
            //Si nous sommes arrivés là, un échec s’est produit. Réafficher le formulaire
            return View(model);

        }
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }

    }
}