using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DRLab.Data.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DRLab.Web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login(string ReturnUrl)
        {
            LoginViewModel model = new LoginViewModel() { ReturnUrl = String.IsNullOrEmpty(ReturnUrl) ? "" : ReturnUrl };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromForm]LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (!this.loginValidation(model))
            {
                ViewBag.LoginFail = true;
                return View(model);
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, model.Email)
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties{ };

            if (model.IsRemember)
            {
                authProperties.IsPersistent = true;
                authProperties.IssuedUtc = DateTimeOffset.UtcNow.AddYears(1);
            }

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

            if(Url.IsLocalUrl(model.ReturnUrl))
                return LocalRedirect(model.ReturnUrl);

            return LocalRedirect("/");
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login");
        }



        private bool loginValidation(LoginViewModel model)
        {
            if(model.Email == "xbook@gmail.com" && model.Password == "123456")
            {
                return true;
            }
            return false;
        }
    }
}