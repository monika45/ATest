using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ATest.Controllers
{
    public class LoginController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        private bool ValidateLogin(string username, string password)
        {
            return true;
        }

        [HttpPost]
        public async Task<IActionResult> Index(string username, string password, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (ValidateLogin(username, password))
            {
                var claims = new List<Claim>
                {
                    new Claim("user", username),
                    new Claim("role", "Member")
                };

                await HttpContext.SignInAsync(new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme, "user", "role")));

                if(Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return Redirect("/");
                }

            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }

  
}
