using CryptoMarket.Controllers.Api;
using CryptoMarket.Controllers.Web;
using CryptoMarket.Entities;
using CryptoMarket.Models;
using CryptoMarket.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CryptoMarket.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private SignInManager<User> _signInManager;
        private UserManager<User> _userManager;

        //Injection of SigninManager
        public AuthController(UserManager<User> userManager,SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Set user credentials
                var user = new User { UserName = model.Username, Email = model.Email };

                //Create the user
                var result = await _userManager.CreateAsync(user, model.Password);

                //Get the Role from view model, add to user role
                var userRole = model.WebUserType.ToString();
                await _userManager.AddToRoleAsync(user, userRole);
                                    
                if (result.Succeeded)
                {                    
                    await _signInManager.SignInAsync(user, isPersistent: false);                  
                    return RedirectToAction(nameof(AppController.Index), "App");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return View();
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            var model = new LoginViewModel { ReturnUrl = returnUrl };
            return View(model);           
        } 

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    if (String.IsNullOrEmpty(model.ReturnUrl) &&
                        Url.IsLocalUrl(model.ReturnUrl))
                    //second check, if there is a url,check the url is local to prevent phising attacks.
                    {
                        //User user = await _userManager.FindByNameAsync(model.Username);
                        //user.Id

                        //var x = _userManager.GetUserIdAsync();
                        //HttpContext.Session.Set("ClientId", model.user);
                        return Redirect(model.ReturnUrl); //Redirect to the url the user was attempting to access.
                    }
                    else
                    {
                        return RedirectToAction("Index", "App"); //Redirect to home.
                    }
                }
            }
            ModelState.AddModelError("", "Invalid login Attempt");
            return View(model);
        }
              
                
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
           
            return RedirectToAction("Index", "App");
        }


        //public IActionResult Unauthorized()
        //{
        //    return View();
        //}

        public IActionResult Forbidden()
        {
            return View();
        }

    }
}
