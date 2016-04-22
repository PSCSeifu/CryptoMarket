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

        //Injection of SinginManager
        public AuthController(SignInManager<CryptoMarketUser> signInManager)
        {
            _signInManager = signInManager;
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
                    true, false);

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
    }
}
