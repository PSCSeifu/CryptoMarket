using CryptoMarket.Controllers.Api;
using CryptoMarket.Controllers.Web;
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
        private SignInManager<CryptoMarketUser> _signInManager;
        private UserManager<CryptoMarketUser> _userManager;

        //Injection of SigninManager
        public AuthController(UserManager<CryptoMarketUser> userManager,
                            SignInManager<CryptoMarketUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Register()
        {
             if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Client", "App");
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
        public async Task<ActionResult> Login(LoginViewModel vm,string returnUrl)
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
        public async Task<IActionResult> Register (RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new CryptoMarketUser { UserName = model.Email, Email = model.Email };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent : false);
                    return RedirectToAction(nameof(AppController.Index),"App");
                }
                else
                {
                    foreach (var error  in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return View(model);                
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "App");
        }


    }
}
