using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using TokenJwt.ApiClient.Services;
using TokenJwt.Dto;

namespace TokenJwt.Web.Controllers
{
    public class AuthController : Controller
    {
        private AuthService AuthService { get; set; }

        public AuthController(AuthService authService)
        {
            AuthService = authService;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto model)
        {
            var tokenResult = AuthService.GetToken(model);

            if (tokenResult.Succes)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, model.Email),
                    new Claim("Token", tokenResult.Data.Token)
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));
                return RedirectToAction("Index", "Home");
            }


            return View();
        }
    }
}