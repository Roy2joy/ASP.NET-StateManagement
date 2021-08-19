using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StateProj.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
namespace StateProj.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
 
        public IActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Test(string name,string pwd)
        {
            if(name=="abc" && pwd == "123")
            {
                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddSeconds(40);
                Response.Cookies.Append("userName", name, options);

                return RedirectToAction("Display");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public IActionResult Display()
        {
            if (Request.Cookies["userName"]!=null)
            {
                ViewBag.temp = Request.Cookies["userName"];
            }
            else
            {
                ViewBag.temp = "anonymous";
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
