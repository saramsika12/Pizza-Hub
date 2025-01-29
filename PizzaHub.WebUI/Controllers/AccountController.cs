using Microsoft.AspNetCore.Mvc;
using PizzaHub.Entities;
using PizzaHub.Services.Interfaces;
using PizzaHub.WebUI.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaHub.WebUI.Controllers
{
    public class AccountController : Controller
    {
        IAuthenticationService _authService;

        public AccountController(IAuthenticationService authService)
        {
            _authService = authService;

        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = await _authService.AuthenticateUserAsync(model.Email, model.Password);
                if (user != null)
                {
                    if(!String.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);
                    if (user.Roles.Contains("Admin"))
                    {
                        return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
                    }
                    else if (user.Roles.Contains("User"))
                    {
                        return RedirectToAction("Index", "Dashboard", new { area = "User" });
                    }

                    

                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                bool result = await _authService.ResetPasswordAsync(model.Email, model.NewPassword);
                if (result)
                {
                    return RedirectToAction("Login"); // Redirect to login on success
                }
                ModelState.AddModelError("", "Password reset failed.");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult ResetPassword()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserModel model)
        {
            if (ModelState.IsValid)
            {

                User user = new User
                {
                    Name = model.Name,
                    UserName = model.Email,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber
                };
                bool result = await _authService.CreateUserAsync(user, model.Password);
               if (result)
                {
                    RedirectToAction("Login");
                }
            }
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await _authService.SignOut();
            return RedirectToAction("LogOutComplete");
        }

        public IActionResult LogOutComplete()
        {
            return View();
        }
        public IActionResult Unauthorize()
        {
            return View();
        }
    }
}
