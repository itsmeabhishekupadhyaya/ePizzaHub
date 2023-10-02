using ePizzaHub.Models;
using ePizzaHub.Services.Interfaces;
using ePizzaHub.UI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;

namespace ePizzaHub.UI.Controllers
{
    public class AccountController : Controller
    {
        IAuthService _authService;

        public AccountController(IAuthService authService)
        {
                _authService = authService;
        }
        public IActionResult Login()
        {
            return View();
        }

        private async void GenrateTicket(UserModel user)
        {
            string strData = JsonSerializer.Serialize(user);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.UserData,strData),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Role,string.Join(",",user.Roles))
            };
            var identity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity), new AuthenticationProperties
                {
                    AllowRefresh = true,
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(60),
                });

        }

        [HttpPost]
        public IActionResult Login(LoginVeiwModel model)
        {
            if (ModelState.IsValid)
            {
                UserModel userModel = _authService.ValidateUser(model.Email, model.Password);
                if (userModel != null) 
                {
                    GenrateTicket(userModel);
                    if (userModel.Roles.Contains("Admin"))
                        {
                        return RedirectToAction("Index", "Home", new {area="Admin"});
                    }
                    else if (userModel.Roles.Contains("User"))
                    {
                        return RedirectToAction("Index", "Home", new { area = "User" });
                    }
                }
            }
            
            return View();
        }
    }
}
