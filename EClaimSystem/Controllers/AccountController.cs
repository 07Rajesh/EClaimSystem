using EClaimSystem.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EClaimSystem.Controllers
{
    public class AccountController : Controller
    {
        AccountDataAccess dataAccess = new AccountDataAccess();


        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                int res = dataAccess.SignInEmployee(login);
                if (res == 1)
                {
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier, Convert.ToString(login.Email)),
                        new Claim(ClaimTypes.Name, login.Email)

                    };
                    //Initialize a new instance of the ClaimsIdentity with the claims and authentication scheme    
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    //SignInAsync is a Extension method for Sign in a principal for the specified scheme.    
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new
                        AuthenticationProperties()
                    {
                        IsPersistent=false
                    });
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.error = "Invaliad login!";
                    return View(login);
                }
            }
            return View(login);
        }
        public IActionResult SignUp()
        {
            return View();
        }
        public IActionResult SignUp(SignUpModel signUp)
        {
            string mssg = dataAccess.SignUpEmployee(signUp);
            if (!string.IsNullOrEmpty(mssg))
            {
                ViewBag.mssg = mssg;
                return View();
            }
            else
            {
                ViewBag.mssg = "Something went wrong";
                return View();
            }
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}

