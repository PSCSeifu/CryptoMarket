using CryptoMarket.Controllers.Api;
using CryptoMarket.Controllers.Web;
using CryptoMarket.Entities;
using CryptoMarket.Models;
using CryptoMarket.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMarket.Controllers
{
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
                var user = new User { UserName = model.Username, Email = model.Email };

                var result = await _userManager.CreateAsync(user, model.Password);

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

        
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Client", "App");
            }
            return View();
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
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "App");
                    }
                }
            }
            ModelState.AddModelError("", "Invalid login Attempt");
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Logina(LoginViewModel vm,string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var signInResult = await _signInManager.PasswordSignInAsync(vm.Username,
                    vm.Password,
                    false, false);

                if (signInResult.Succeeded)
                {
                    if (string.IsNullOrWhiteSpace(returnUrl))
                    {
                        //Redirect to result page
                        return RedirectToAction("Client", "App");
                    }
                    else
                    {
                        return RedirectToAction(returnUrl);
                    }
                }
                else
                {
                    ModelState.TryAddModelError("", "Username or password incorrect");
                }  
            }

            return View();
        }
                
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
           
            return RedirectToAction("Index", "App");
        }


    }
}
