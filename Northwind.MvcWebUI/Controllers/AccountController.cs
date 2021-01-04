using Northwind.Bll.Concrete;
using Northwind.Entities;
using Northwind.Entities.Models;
using Northwind.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Northwind.MvcWebUI.Controllers
{
    public class AccountController : Controller
    {
        private IAuthenticationService _authenticationService;
        public AccountController(IAuthenticationService _authenticationService)
        {
            this._authenticationService = _authenticationService;
        }
        // GET: Account
        public ActionResult Login()
        {
            return View(new User());
        }
        [HttpPost]
        public ActionResult Login(User user, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                User validatedUser= _authenticationService.Authenticate(user);
                if (validatedUser!=null)
                {
                    FormsAuthentication.SetAuthCookie(user.UserName, false);
                    return Redirect(returnUrl);

                }
            }
            else
            {
                ModelState.AddModelError("Hata", "Kullanıcı Adı veya Sifre Hatalı");
            }
            
            return View();
        }
    }
}