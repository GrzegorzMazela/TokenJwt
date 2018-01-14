using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TokenJwt.ApiClient.Services;
using TokenJwt.Web.Models;

namespace TokenJwt.Web.Controllers
{
    public class HomeController : Controller
    {
        private TxtService TxtService { get; set; }

        public HomeController(TxtService txtService)
        {
            TxtService = txtService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        [Authorize]
        public IActionResult Contact()
        {
            var user = HttpContext.User;
            var tokenClaims = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "token");
            var token = tokenClaims.Value;
            return View();
        }

        [Authorize]
        public IActionResult UserTxt()
        {

            var tokenClaims = HttpContext.User.Identities.First().Claims.FirstOrDefault(x => x.Type == "Token");
            var token = tokenClaims.Value;
            var txt = TxtService.GetTxt(token);

            return View(txt.Data);
        }
    

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
