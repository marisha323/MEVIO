using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace MEVIO.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GoogleLogin()
        {
            var properties = new AuthenticationProperties { RedirectUri = Url.Action(nameof(GoogleCallback)) };
            await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme, properties);
            return Unauthorized();
        }

        [HttpGet]
        public IActionResult LoginWithGoogle()
        {
            var redirectUri = Url.Action("GoogleCallback", "Account", null, Request.Scheme);
            var properties = new AuthenticationProperties { RedirectUri = redirectUri };
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }

        [HttpGet]
        public async Task<IActionResult> GoogleCallback()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("MainPage", "MainPage");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Registry", "Index");
        }
    }
}
