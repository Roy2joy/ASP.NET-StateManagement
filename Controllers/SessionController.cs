using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StateProj.Controllers
{
    public class SessionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Test(string name, string pwd)
        {
            if (name == "abc" && pwd == "123")
            {


                return RedirectToAction("Display");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public IActionResult Display()
        {
            if (/*Request.Cookies["userName"] != null*/true)
            {
                //string cryptext = Request.Cookies["userName"];
                //string result = Decrypt(cryptext);
                //ViewBag.temp = result;
            }
            else
            {
                //ViewBag.temp = "anonymous";
            }
            return View();
        }

        public IActionResult DeleteCookie()
        {
            if (Request.Cookies["userName"] != null)
            {
                Response.Cookies.Delete("userName");
            }
            return RedirectToAction("Display");
        }
    }
}
